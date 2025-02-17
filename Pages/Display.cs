using Operator_Screen_App.Connections;
using Operator_Screen_App.Items.Log;
using Operator_Screen_App.Items.Node;
using System.IO;
using System.Text;
using System.Text.Json;
using Operator_Screen_App._ignore;
using Operator_Screen_App.Pages;

namespace Operator_Screen_App
{
    public partial class Display : Form
    {
        NodeList nodeList;
        Random random;

        public Display()
        {
            InitializeComponent();
            nodeList = new();
            random = new Random();
        }

        public void btnSimulateOp_Click(object sender, EventArgs e)
        {
            //System.Media.SystemSounds.Beep.Play();

            string json = "";
            try
            {
                //json1 = RequestLog.FetchJson();
                json = Json_response.getString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            MessageBox.Show(json, "Stripped HTTP RESPONSE");

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
            nodeList.AssignContentToGrid(gridLog);

            if (nodeList.tail.Data.verifyStatusCode > 0)
                popUp(nodeList.tail.Data.verifyStatusCode);
        }

        private void btnLists_Click(object sender, EventArgs e)
        {
            nodeList.Print();
            nodeList.AssignContentToGrid(gridLog);
        }

        private void popUp(UInt16 code)
        {
            PopUp PopupScreen = new(code);
            PopupScreen.Show();
        }

        private void Display_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Exit?", "Confirmation", MessageBoxButtons.OKCancel);
            
            if(result == DialogResult.Cancel) e.Cancel = true;
        }
    }
}
