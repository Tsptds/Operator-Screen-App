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
using Operator_Screen_App.Connections;
using Operator_Screen_App.Items.Log.Attributes;
using Operator_Screen_App.Items.Node;

namespace Operator_Screen_App.Pages
{
    public partial class PopUp : Form
    {
        private UInt16 timeout;
        private UInt16 messageDisplayTimeNormal;
        private UInt16 messageDisplayTimeError;
        private VerifyStatusCode displayCode;
        private Node node;
        private Form parentForm;
        
        public PopUp(Form _parent, VerifyStatusCode _statusCode, Node _node)
        {
#if DEBUG
            timeout = 5;
#else
            timeout = 30;
#endif
            messageDisplayTimeNormal = 5;
            messageDisplayTimeError = 15;
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
                tmrAlert.Start();
                barTimer.Visible = true;
                MessageBox.Show("Message Sent to Supervisor", "Operator Hasn't Confirmed");


                //TODO: Read SMTP settings from Settings.ini, Send Mail to supervisor


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
            e.Cancel = true;
        }

        //private void PopUp_Deactivate(object sender, EventArgs e)
        //{
        //    if (!shouldClose)
        //        MessageBox.Show("Please confirm your identity");
        //}

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            btnConfirm.Enabled = false;
            tmrConfirm.Stop();
            barConfirm.Visible = false;

            //DialogResult result = MessageBox.Show("Identity Confirmed", "Success");
            //if (result == DialogResult.OK)
            {

                try
                {
                    var nodeData = node.Data;
                    var payload = new
                    {
                        LogID = nodeData.logID.ToString(),
                        Description = $"User Data Test"
                    };

                    string jsonResponse = await SendLog.SendJsonPostAsync(payload);

                    if (jsonResponse != null)
                    {

                        // Find the header-body separator (\r\n\r\n)
                        int idx1 = jsonResponse.IndexOf("\r\n");
                        //MessageBox.Show($"{idx1}", "index header end");
                        if (idx1 != -1)
                        {
                            jsonResponse = jsonResponse.Substring(idx1 + 2); // Extract everything after the headers

                            

                            int idx3 = jsonResponse.IndexOf("\r\n");
                            //MessageBox.Show($"{idx3}", "index tail");
                            if (idx3 != -1)
                            {
                                jsonResponse = jsonResponse.Substring(0, idx3);
                            }
                            
                        }
                        
                        tmrAlert.Start();
                        barTimer.Value = messageDisplayTimeNormal;
                        barTimer.Visible = true;
                        MessageBox.Show($"Server Returned: {jsonResponse}", "Server Response");
                    }
                }
                catch (Exception ex)
                {
                    messageDisplayTimeNormal = messageDisplayTimeError;
                    barTimer.Maximum = messageDisplayTimeNormal;
                    barTimer.Value = messageDisplayTimeNormal;
                    barTimer.Visible = true;
                    tmrAlert.Start();
                    MessageBox.Show(ex.Message, "SERVER ERROR");
                }


                parentForm.Visible = true;
                this.Close();
                this.Dispose();
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
            barTimer.Value = Math.Max(messageDisplayTimeNormal , (UInt16)0 );
        }
    }
}
