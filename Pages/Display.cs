/*FOR OFFLINE TESTING, DEFINE FAKEHOST HERE, ELSE COMMENT IT OUT*/
//#define FAKEHOST

using Operator_Screen_App.Items.Log;
using Operator_Screen_App.Items.Node;
using System.Text.Json;
using Operator_Screen_App.Pages;
using Operator_Screen_App.Items.Log.Attributes;
using Operator_Screen_App.Connections.API;

namespace Operator_Screen_App
{
    public partial class Display : Form
    {
        NodeList nodeList;
        NLog.Logger logger;
        public Display()
        {
            InitializeComponent();
            logger = NLog.LogManager.GetCurrentClassLogger();
            nodeList = new();

#if FAKEHOST
            logger.Info("**Local Json generator enabled\nTo use the actual API for JSON Fetching\nundefine FAKEHOST inside Display**");
            MessageBox.Show("Local Json generator enabled\nTo use the actual API for JSON Fetching\nundefine FAKEHOST inside Display", "ATTENTION");
#endif
        }

        public async void btnSimulateOp_Click(object sender, EventArgs e)
        {
            System.Media.SystemSounds.Question.Play();
            btnSimulateOp.Enabled = false;
            btnLists.Enabled = false;
            string json = "";
            try
            {
#if FAKEHOST
                logger.Info("Generating Debug json");
                json = Json_response.getString();
#else
                logger.Info("Awaiting response from server");
                json = await RequestLog.FetchJsonGetAsync();
#endif
                if (json != null)
                {
                    logger.Info("Retrieved not-null response, parsing json body");

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
                }
            }
            catch (ArgumentException ex)
            {
                logger.Error($"Missing INI Value Under API: {ex.ParamName}");
                MessageBox.Show($"Missing INI Value Under API: {ex.ParamName}", "Settings.ini File Not Filled Correctly");

                btnSimulateOp.Enabled = true;
                btnLists.Enabled = true;
                return;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show(ex.Message, "ERROR");

                btnSimulateOp.Enabled = true;
                btnLists.Enabled = true;
                return;
            }


#if DEBUG
            logger.Info("Stripped HTTP RESPONSE\n{0}", json);
            MessageBox.Show(json, "Stripped HTTP RESPONSE");
#endif
            try
            {
                LogEntry? parsedData = JsonSerializer.Deserialize<LogEntry>(json);
                if (parsedData != null)
                {
                    logger.Info("Json successfully parsed, appending to list");
                    nodeList.Append(parsedData);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
            nodeList.AssignContentToGrid(nodeList.listLength, gridLog);

            // Alert Operator if status isn't valid
            VerifyStatusCode status = (VerifyStatusCode)nodeList.tail.Data.verifyStatusCode;

            if (status > VerifyStatusCode.kSuccess)
            {
                popUp(status, nodeList.tail);
            }

            btnSimulateOp.Enabled = true;
            btnLists.Enabled = true;
        }

        private void btnLists_Click(object sender, EventArgs e)
        {
            nodeList.Print();
        }

        private void popUp(VerifyStatusCode _code, Node _tail)
        {
            logger.Info($"Status code is invalid\nShowing Manual Confirmation Window For Entry:\n{_tail.Data.logID}");
            this.Visible = false;
            PopUp PopupScreen = new(this, _code, _tail);
            PopupScreen.Show();
        }

        private void Display_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Exit?", "Confirmation", MessageBoxButtons.OKCancel);

            if (result == DialogResult.Cancel) e.Cancel = true;
        }
    }
}
