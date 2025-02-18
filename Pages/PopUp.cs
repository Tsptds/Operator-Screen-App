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
        private UInt16 messageDisplayTime;
        private VerifyStatusCode displayCode;
        private NodeList nodeList;
        private Form parentForm;
        
        public PopUp(Form _parent, VerifyStatusCode _statusCode, NodeList _nodeList)
        {
            timeout = 5;
            messageDisplayTime = 5;
            displayCode = _statusCode;
            nodeList = _nodeList;

            InitializeComponent();
            lblContext.Text = $"Status: {(displayCode.context())}";
            parentForm = _parent;
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
            tmrConfirm.Stop();
            barConfirm.Visible = false;
            tmrAlert.Start();

            barTimer.Value = messageDisplayTime;
            barTimer.Visible = true;

            //DialogResult result = MessageBox.Show("Identity Confirmed", "Success");
            //if (result == DialogResult.OK)
            {

                try
                {
                    var lastNode = nodeList.tail.Data;
                    var payload = new
                    {
                        LogId = lastNode.logID.ToString(),
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
                        barTimer.Visible = true;
                        MessageBox.Show($"Server Returned: {jsonResponse}", "Server Response");
                    }
                    else
                        MessageBox.Show("Server Returned null Response");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }


                parentForm.Visible = true;
                this.Close();
                this.Dispose();
            }
        }

        private void tmrAlert_Tick(object sender, EventArgs e)
        {
            if (messageDisplayTime < 1)
            {
                tmrAlert.Stop();
                parentForm.Visible = true;
                this.Close();
                this.Dispose();
            }
            else
            {
                messageDisplayTime -= 1;
            }
            barTimer.Value = Math.Max(messageDisplayTime , (UInt16)0 );
        }
    }
}
