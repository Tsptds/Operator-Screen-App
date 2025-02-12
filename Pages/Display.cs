using Operator_Screen_App.Connections;
using Operator_Screen_App.Items.Log;
using Operator_Screen_App.Items.Node;
using System.Text.Json;

namespace Operator_Screen_App
{
    public partial class Display : Form
    {
        public Display()
        {
            InitializeComponent();
        }

        public void btnSimulateOp_Click(object sender, EventArgs e)
        {
            //System.Media.SystemSounds.Beep.Play();
            MessageBox.Show("Attempting Operation Simulation", "Alert", MessageBoxButtons.OK);
            string json = RequestLog.FetchJson();

            static string ExtractJson(string httpResponse)
            {
                // Find the header-body separator (\r\n\r\n)
                int index = httpResponse.IndexOf("\r\n\r\n");
                MessageBox.Show(index.ToString());
                if (index != -1)
                {
                    return httpResponse.Substring(index + 4); // Extract everything after the headers
                }
                return httpResponse; // If no headers found, return full response
            }

            json = ExtractJson(json);

            LogEntry? parsedData = JsonSerializer.Deserialize<LogEntry>(json);

            if (parsedData != null)
            {
                LogList logList = new();
                logList.Append(parsedData);
                logList.Print();
            }
        }
    }
}
