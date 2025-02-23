using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
            lblStatus.Text = $"Status: {((VerifyStatusCode)node.Data.verifyStatusCode).context()}";
            lblUsername.Text = $"User: {node.Data.username}";
            tmrConfirm.Start();
        }

        private void tmrConfirm_Tick(object sender, EventArgs e)
        {
            if (timeout < 1)
            {
                tmrConfirm.Stop();
                logger.Info("Manual Confirmation Not Done, Sending Mail to Supervisor");
                //MessageBox.Show("Manual Confirmation Not Done, Sending Mail to Supervisor", "Operator Hasn't Confirmed");

                // Attempt to send mail
                try
                {
                    btnConfirm.Enabled = false;
                    Mail.Send();

                    tmrAlert.Start();
                    barTimer.Visible = true;

                    logger.Info("Message Sent to Supervisor");
                    MessageBox.Show("Message Sent to Supervisor", "Operator Hasn't Confirmed");
                }
                catch (Exception ex)
                {
                    tmrAlert.Start();
                    barTimer.Visible = true;

                    logger.Error(ex.Message);
                    MessageBox.Show(ex.Message, "ERROR");
                }                

                parentForm.Visible = true;
                this.Close();
                this.Dispose();
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
            btnConfirm.Enabled = false;
            tmrConfirm.Stop();
            barConfirm.Visible = false;

            try
            {
                var nodeData = node.Data;
                var payload = new
                {
                    LogID = nodeData.logID.ToString(),
                    Description = $"User Data Test"
                };
                logger.Info("Manual confirm registered, attempting to post to server");

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

                    tmrAlert.Start();
                    barTimer.Value = messageDisplayTimeNormal;
                    barTimer.Visible = true;

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
                barTimer.Visible = true;
                tmrAlert.Start();

                MessageBox.Show(ex.Message, "SERVER ERROR");
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
    }
}
