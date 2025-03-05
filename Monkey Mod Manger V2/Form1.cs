using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Monkey_Mod_Manger_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private string GetGorillaTagSteamPath()
        {
            string steamPath = @"C:\Program Files (x86)\Steam\steamapps\common\Gorilla Tag";
            return Directory.Exists(steamPath) ? steamPath : null;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string gtPath = GetGorillaTagSteamPath();
            if (gtPath == null)
            {
                MessageBox.Show("Gorilla Tag (Steam) not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (WebClient client = new WebClient())
            {
                try
                {
                    // Define download URLs for individual files
                    string downloadWimUrl = "https://cdn.discordapp.com/attachments/1176645226153132172/1346970900767051867/winhttp.dll?ex=67ca1fe8&is=67c8ce68&hm=4d897fdbf51070ca4f7c7e94aeceded68ef836dbfca4b409cbca9c7dd878b8f4&";
                    string downloadDoorStopVUrl = "https://cdn.discordapp.com/attachments/1176645226153132172/1346970923915546665/doorstop_version?ex=67ca1fed&is=67c8ce6d&hm=3ca20457bebccf4d9ea09905dc4f0117bf8370ba66e08feea273afeb1693137e&";
                    string downloadDoorStopConUrl = "https://cdn.discordapp.com/attachments/1176645226153132172/1346970953544106065/doorstop_config.ini?ex=67ca1ff4&is=67c8ce74&hm=5005dfd2612238678246e6781c4ce883a4901155698a2b84b97cc0f0a3b8999a&";
                    string downloadChangeLogUrl = "https://cdn.discordapp.com/attachments/1176645226153132172/1346970991322075197/changelog.txt?ex=67ca1ffd&is=67c8ce7d&hm=3879973b46695ec38620e3a6a3a8af1434cd694bf4c6cfcc7b8cf494a6465a6e&";

                    // Define file destinations for individual files
                    string fileWinHttp = Path.Combine(gtPath, "winhttp.dll");
                    string fileDoorStopV = Path.Combine(gtPath, ".doorstop_version");
                    string fileDoorStopCon = Path.Combine(gtPath, "doorstop_config.ini");
                    string fileChangeLog = Path.Combine(gtPath, "changelog.txt");

                    // Download individual files
                    client.DownloadFile(downloadWimUrl, fileWinHttp);
                    client.DownloadFile(downloadDoorStopVUrl, fileDoorStopV);
                    client.DownloadFile(downloadDoorStopConUrl, fileDoorStopCon);
                    client.DownloadFile(downloadChangeLogUrl, fileChangeLog);

                    MessageBox.Show("Download complete! Files placed in Gorilla Tag folder.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Define ZIP download URL and file paths
                    string BepInExDownloadUrl = "https://cdn.discordapp.com/attachments/1176645226153132172/1346975499536044033/BepInEx.zip?ex=67ca2430&is=67c8d2b0&hm=ccf79b53fc75bdc17076d09543854d69fcf75f734bc1327b0d6f34aa7bcbbeda&";
                    string FilePath = Path.Combine(gtPath, "BepInEx.zip"); // Save ZIP in GT folder
                    


                    // Download the BepInEx file
                    client.DownloadFile(BepInExDownloadUrl, FilePath);
                    MessageBox.Show("BepInEx Download complete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Operation failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}