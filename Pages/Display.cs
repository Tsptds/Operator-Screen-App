using Operator_Screen_App.Connections;
using Operator_Screen_App.Items.Log;
using Operator_Screen_App.Items.Node;
using System.IO;
using System.Text;
using System.Text.Json;
using Operator_Screen_App._ignore;
using Operator_Screen_App.Pages;
using Operator_Screen_App.Items.Log.Attributes;

namespace Operator_Screen_App
{
    public partial class Display : Form
    {
        NodeList nodeList;

        public Display()
        {
            InitializeComponent();
            nodeList = new();
        }

        public async void btnSimulateOp_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Question.Play();
            btnSimulateOp.Enabled = false;
            btnLists.Enabled = false;
            string json = "";
            try
            {
                #if DEBUG
                    json = Json_response.getString();
                #else
                    json = await RequestLog.FetchJsonGetAsync();
                #endif
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            if (json is null)
            {
                btnSimulateOp.Enabled=true;
                btnLists.Enabled = true;
                return;
            }


            // Find the header-body separator (\r\n\r\n)
            int idx1 = json.IndexOf("\r\n");
            //MessageBox.Show($"{idx1}", "index header end");
            if (idx1 != -1)
            {
                json = json.Substring(idx1 + 2); // Extract everything after the headers

                int idx2 = json.IndexOf("{");
                //MessageBox.Show($"{idx2}", "index inner");
                if (idx2 != -1)
                {
                    json = json.Substring(idx2);

                    int idx3 = json.IndexOf("}");
                    //MessageBox.Show($"{idx3}", "index tail");
                    if (idx3 != -1)
                    {
                        json = json.Substring(0, idx3 + 1);
                    }
                }
            }
#if DEBUG
MessageBox.Show(json, "Stripped HTTP RESPONSE");
#endif
            try
            {
                LogEntry? parsedData = JsonSerializer.Deserialize<LogEntry>(json);
                if (parsedData != null)
                {
                    nodeList.Append(parsedData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            nodeList.AssignContentToGrid(nodeList.listLength, gridLog);

            VerifyStatusCode status = (VerifyStatusCode)nodeList.tail.Data.verifyStatusCode;

            if (status > VerifyStatusCode.kSuccess)
                popUp(status, nodeList);

            btnSimulateOp.Enabled = true;
            btnLists.Enabled = true;
        }

        private void btnLists_Click(object sender, EventArgs e)
        {
            nodeList.Print();
            //nodeList.AssignContentToGrid(nodeList.listLength, gridLog);
        }

        private void popUp(VerifyStatusCode code, NodeList nodeList)
        {
            this.Visible = false;
            PopUp PopupScreen = new(this, code, nodeList);
            PopupScreen.Show();
        }

        private void Display_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Exit?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result == DialogResult.Cancel) e.Cancel = true;
        }
    }
}
