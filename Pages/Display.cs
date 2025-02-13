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

            string json = Json_response.getString();


            // Find the header-body separator (\r\n\r\n)
            int index = json.IndexOf("\r\n\r\n");
            if (index != -1)
            {
                json = json.Substring(index + 4); // Extract everything after the headers
            }
            MessageBox.Show(json);

            LogEntry? parsedData = JsonSerializer.Deserialize<LogEntry>(json);

            if (parsedData != null)
            {
                //LogList logList = new();
                logList.Append(parsedData);
                logList.Print();
            }
        }

        private void btnLists_Click(object sender, EventArgs e)
        {
            logList.Print();
        }
    }
}
