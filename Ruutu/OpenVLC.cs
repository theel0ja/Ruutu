using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Ruutu
{
    class OpenVLC
    {

        /// <summary>
        ///  Tries to run VLC (with RunVLC function) with most popular paths, if not found, show file explorer
        /// </summary>
        /// <param name="m3u8URL">URL of .m3u8 file that's opened</param>
        public static void Open(Uri m3u8URL)
        {
            string vlcPathA = "C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe";
            string vlcPathB = "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe";

            // If vlc.exe exists in vlcPath,
            if (File.Exists(vlcPathA))
            {
                RunVLC(m3u8URL, vlcPathA);
            }
            else if(File.Exists(vlcPathB))
            {
                RunVLC(m3u8URL, vlcPathB);
            }
            else
            {
                // Can't found VLC, allow user to select VLC executable
                string vlcPathUserDefined;

                OpenFileDialog file = new OpenFileDialog();

                if (file.ShowDialog() == DialogResult.OK)
                {
                    vlcPathUserDefined = file.FileName;

                    RunVLC(m3u8URL, vlcPathUserDefined);
                }
            }
        }

        /// <summary>
        ///  Starts VLC media player application
        /// </summary>
        /// <param name="m3u8URL">URL of .m3u8 file that's opened</param>
        /// <param name="vlcPath">VLC's path</param>
        private static void RunVLC(Uri m3u8URL, String vlcPath)
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
