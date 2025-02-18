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
using Operator_Screen_App.Items.Log.Attributes;

namespace Operator_Screen_App.Pages
{
    public partial class PopUp : Form
    {
        private UInt16 timeout;
        private UInt16 messageDisplayTime;
        private VerifyStatusCode displayCode;
        private Form parentForm;
        public PopUp(Form parent, VerifyStatusCode statusCode)
        {
            timeout = 30;
            messageDisplayTime = 5;
            displayCode = statusCode;

            InitializeComponent();
            lblContext.Text = $"Status: {(displayCode.context())}";
            parentForm = parent;
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

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            tmrConfirm.Stop();
            tmrAlert.Start();

            barTimer.Value = messageDisplayTime;
            barTimer.Visible = true;

            DialogResult result = MessageBox.Show("Identity Confirmed", "Success");
            if (result == DialogResult.OK)
            {
                tmrAlert.Stop();

                //TODO: Post to API with Log ID & Description


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
