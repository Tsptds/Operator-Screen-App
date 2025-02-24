using Operator_Screen_App.Connections.API;
using Operator_Screen_App.Connections.Mail;
using Operator_Screen_App.Items.Log.Attributes;
using Operator_Screen_App.Items.Node;

namespace Operator_Screen_App.Pages
{
    public partial class PopUp : Form
    {
        private readonly NLog.Logger logger;

        private UInt16 timeout;
        private UInt16 messageDisplayTimeNormal;
        private UInt16 messageDisplayTimeError;
        private VerifyStatusCode displayCode;
        private Node node;
        private Form parentForm;

        private void setActionTaken()
        {
            tmrConfirm.Stop();
            barConfirm.Visible = false;

            btnConfirm.BackColor = Color.WhiteSmoke;
            btnConfirm.Enabled = false;

            btnDeny.BackColor = Color.WhiteSmoke;
            btnDeny.Enabled = false;
        }
        private void alertStart()
        {
            tmrAlert.Start();
            barTimer.Visible = true;
        }
        private void sendMail(bool _timedOut)
        {
            try
            {
                setActionTaken();

                Mail.Send(node);

                alertStart();

                if (_timedOut)
                {
                    logger.Info("Mail Sent to Supervisor\nOperator Did Not Confirm Within Time");
                    MessageBox.Show("Operator Did Not Confirm Within Time", "Mail Sent to Supervisor");
                }
                else
                {
                    logger.Info("Mail Sent to Supervisor\nOperator Denied The Entry");
                    MessageBox.Show("Operator Denied The Entry", "Mail Sent to Supervisor");
                }
            }
            catch (Exception ex)
            {
                alertStart();

                logger.Error(ex.Message);
                MessageBox.Show(ex.Message, "ERROR");
            }

            parentForm.Visible = true;
            this.Close();
            this.Dispose();
        }
        public PopUp(Form _parent, VerifyStatusCode _statusCode, Node _node)
        {
            logger = NLog.LogManager.GetCurrentClassLogger();
#if DEBUG
            timeout = 3;
            messageDisplayTimeNormal = 3;
            messageDisplayTimeError = 5;
#else
            timeout = 30;
            messageDisplayTimeNormal = 5;
            messageDisplayTimeError = 15;
#endif
            displayCode = _statusCode;
            node = _node;
            parentForm = _parent;

            InitializeComponent();
            lblStatus.Text = $"Status: {((VerifyStatusCode)displayCode).Format()}";
            lblUsername.Text = $"User: {node.Data.username}";
            tmrConfirm.Start();
        }

        private void tmrConfirm_Tick(object sender, EventArgs e)
        {
            if (timeout < 1)
            {
                logger.Info("Manual Confirm Timed Out\nSending Mail to Supervisor");

                setActionTaken();

                // Attempt to send mail, with timed out is true
                sendMail(true);
            }
            else
            {
                timeout -= 1;
                lblTime.Text = timeout.ToString();
            }
            barConfirm.Value = Math.Max(timeout, (UInt16)0);
        }

        private void PopUp_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prevent this form from closing inappropriately
            e.Cancel = true;
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            setActionTaken();

            try
            {
                var nodeData = node.Data;
                var payload = new
                {
                    LogID = nodeData.logID.ToString(),
                    Description = Post.FormatDescription(nodeData)
                };
#if DEBUG
                MessageBox.Show(nodeData.logID.ToString() + "\n" + Post.FormatDescription(nodeData), "POST body preview");
#endif
                logger.Info("Manual confirm registered\nAttempting to post to server");

                string jsonResponse = await SendLog.SendJsonPostAsync(payload);

                if (jsonResponse != null)
                {
                    // Find the header-body separator (\r\n\r\n)
                    int idx1 = jsonResponse.IndexOf("\r\n");
                    if (idx1 != -1)
                    {
                        // Extract everything after the headers
                        jsonResponse = jsonResponse.Substring(idx1 + 2);

                        // Delete trailing 0 as well
                        int idx3 = jsonResponse.IndexOf("\r\n");
                        if (idx3 != -1)
                        {
                            jsonResponse = jsonResponse.Substring(0, idx3);
                        }

                    }

                    alertStart();
                    barTimer.Value = messageDisplayTimeNormal;

                    logger.Info($"Server Returned: {jsonResponse}");
                    DialogResult skipped = MessageBox.Show($"Server Returned: {jsonResponse}", "Server Response", MessageBoxButtons.OK);

                    // Temporary solution to spamming API
                    if (skipped == DialogResult.OK)
                    {
                        // Wait at least 3 seconds, API rule. Skip to 0 if it's been 3 seconds already
                        barTimer.Value = messageDisplayTimeNormal = (ushort)(barTimer.Value >= 3 ? 3 : 0);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);

                messageDisplayTimeNormal = messageDisplayTimeError;
                barTimer.Maximum = messageDisplayTimeError;
                barTimer.Value = messageDisplayTimeError;
                alertStart();

                DialogResult skipped = MessageBox.Show(ex.Message, "SERVER ERROR", MessageBoxButtons.OK);

                // Skip early
                if (skipped == DialogResult.OK)
                {
                    // Set 0, since there was an error anyway
                    barTimer.Value = messageDisplayTimeNormal = (ushort)0;
                }
            }
        }

        private void tmrAlert_Tick(object sender, EventArgs e)
        {
            if (messageDisplayTimeNormal < 1)
            {
                tmrAlert.Stop();
                parentForm.Visible = true;
                this.Close();
                this.Dispose();
            }
            else
            {
                messageDisplayTimeNormal -= 1;
            }
            barTimer.Value = Math.Max(messageDisplayTimeNormal, (UInt16)0);
        }

        private void btnDeny_Click(object sender, EventArgs e)
        {
            logger.Info("Entry Denied\nSending Mail to Supervisor");

            // Attempt to send mail, with timed out is false
            sendMail(false);
        }
    }
}
