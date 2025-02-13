using Operator_Screen_App.Connections;
using Operator_Screen_App.Items.Log;
using Operator_Screen_App.Items.Node;
using System.IO;
using System.Text;
using System.Text.Json;
using Operator_Screen_App._ignore;

namespace Operator_Screen_App
{
    public partial class Display : Form
    {
        LogList logList;
        public Display()
        {
            InitializeComponent();
            logList = new();
        }

        public void btnSimulateOp_Click(object sender, EventArgs e)
        {
            //System.Media.SystemSounds.Beep.Play();
            MessageBox.Show("Attempting Operation Simulation", "Alert", MessageBoxButtons.OK);
            //string json = RequestLog.FetchJson();

            string json = Json_response.getString(true);


            // Find the header-body separator (\r\n\r\n)
            int idx1 = json.IndexOf("\r\n\r\n");
            if (idx1 != -1)
            {
                MessageBox.Show($"{idx1}", "index");
                json = json.Substring(idx1 + 4); // Extract everything after the headers

                int idx2 = json.IndexOf("{");
                if (idx2 != -1)
                {
                    MessageBox.Show($"{idx2}", "index inner");
                    json = json.Substring(idx2 - 1);

                    int idx3 = json.IndexOf("}");
                    if (idx3 != -1)
                    {
                        MessageBox.Show($"{idx3}", "index tail");
                        json = json.Substring(0, idx3 + 1);
                    }
                }
            }
            MessageBox.Show(json, "HTTP RESPONSE");

            try
            {
                LogEntry? parsedData = JsonSerializer.Deserialize<LogEntry>(json);
                if (parsedData != null)
                {
                    //LogList logList = new();
                    logList.Append(parsedData);
                }
            } catch (Exception ex)
            {
                    MessageBox.Show(ex.ToString());
            }

        }

        private void btnLists_Click(object sender, EventArgs e)
        {
            logList.Print();
        }
    }
}
