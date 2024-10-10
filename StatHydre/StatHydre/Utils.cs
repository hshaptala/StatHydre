using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace StatHydre
{
    internal class Utils
    {
        private readonly string mapPath;
        private readonly string graphPath;

        private readonly string mapScript;
        public readonly string mapImage;

        private readonly string graphScript;
        public readonly string graphImage;

        public Utils()
        {
            string strExeFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string strWorkPath = Path.GetDirectoryName(strExeFilePath);
            string strScriptsPath = Path.Combine(Path.GetDirectoryName(Path.GetDirectoryName(strWorkPath)), "Data");

            // Path
            mapPath = System.IO.Path.Combine(strScriptsPath, "Map");
            graphPath = System.IO.Path.Combine(strScriptsPath, "Graph");

            // Map
            mapScript = System.IO.Path.Combine(mapPath, "map.py");
            mapImage = System.IO.Path.Combine(mapPath, "map.png");

            // Graph
            graphScript = System.IO.Path.Combine(graphPath, "graph.py");
            graphImage = System.IO.Path.Combine(graphPath, "graph.png");
        }

        private Process GenerateCmd()
        {
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.Start();
            return cmd;
        }

        private void CmdAction(string line, Process cmd)
        {
            cmd.StandardInput.WriteLine(line);
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
        }

        public void RunMapScript(string args)
        {
            // For map ONLY
            Process cmd = GenerateCmd();
            string commandLine = $"python {Path.Combine(mapPath, mapScript)} {args}";
            Console.WriteLine(commandLine);
            CmdAction(commandLine, cmd);
        }

        public void RunGraphScript(string arguments)
        {
            // For graphs ONLY
            Process cmd = GenerateCmd();
            string commandLine = $"python {Path.Combine(graphPath, graphScript)} {arguments}";
            Console.WriteLine(commandLine);
            CmdAction(commandLine, cmd);
        }

        public void DisplayImage(PictureBox pictureBox, string imageName)
        {
            using (Image img = Image.FromFile(imageName))
            {
                pictureBox.Image = new Bitmap(img);
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        public void ShowCountriesListBox(TextBox textBox, ListBox listBox)
        {
            listBox.Width = textBox.Width;
            listBox.Visible = true;
            listBox.BringToFront();
        }
    }
}
