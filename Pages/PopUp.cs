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
        private VerifyStatusCode displayCode;
        private bool shouldClose = false;
        public PopUp(VerifyStatusCode statusCode)
        {
            timeout = 30;
            displayCode = statusCode;
            InitializeComponent();
            lblContext.Text = $"Status: {(displayCode.context())}";
            tmrConfirm.Start();
        }

        private void tmrConfirm_Tick(object sender, EventArgs e)
        {

            if (timeout < 1)
            {
                tmrConfirm.Stop();
                shouldClose = true;
                this.Close();
                Dispose();
            }
            timeout -= 1;
            lblTime.Text = timeout.ToString();

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
            shouldClose = true;
            MessageBox.Show("Identity Confirmend", "Success");
            this.Close();
            Dispose();
        }
    }
}
