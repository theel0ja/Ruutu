using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Ruutu
{
    class OpenVLC
    {

        public static void openVLC(Uri m3u8URL)
        {
            string vlcPathA = "C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe";
            string vlcPathB = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";

            // If vlc.exe exists in vlcPath,
            if (File.Exists(vlcPathA))
            {
                runVLC(m3u8URL, vlcPathA);
            }
            else if(File.Exists(vlcPathB))
            {
                runVLC(m3u8URL, vlcPathB);
            }
            else
            {
                // Can't found VLC, allow user to select VLC executable
                string vlcPathUserDefined;

                OpenFileDialog file = new OpenFileDialog();

                if (file.ShowDialog() == DialogResult.OK)
                {
                    vlcPathUserDefined = file.FileName;

                    runVLC(m3u8URL, vlcPathUserDefined);
                }
            }
        }

        private static void runVLC(Uri m3u8URL, String vlcPath)
        {
            Application.Exit();
            Process p1 = new Process();
            p1.StartInfo.FileName = vlcPath;
            p1.StartInfo.Arguments = m3u8URL.ToString();
            p1.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
            p1.Start();
        }
    }
}
