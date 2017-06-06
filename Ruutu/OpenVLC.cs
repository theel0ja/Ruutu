using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Ruutu
{
    class OpenVLC
    {
        /// <summary>
        /// Returns false if the operating system isn't Linux (not sure about macOS), true if it is.
        /// </summary>
        private static bool IsLinux
        {
            get
            {
                int p = (int)Environment.OSVersion.Platform;
                return (p == 4) || (p == 6) || (p == 128);
            }
        }

        /// <summary>
        /// Tries to run VLC (with RunVLC function) with most popular paths, if not found, show file explorer
        /// </summary>
        /// <param name="m3u8URL">URL of .m3u8 file that's opened</param>
        public static void Open(Uri m3u8URL)
        {
            List<string> defaultVlcPaths = new List<string>();

            // Default paths for VLC
            string[] defaultVlcPathsWindows = { "C:\\Program Files (x86)\\VideoLAN\\VLC\\vlc.exe", "C:\\Program Files\\VideoLAN\\VLC\\vlc.exe" };
            string[] defaultVlcPathsLinux = { "/usr/bin/vlc" };
            
            // If VLCPath in Settings isn't "", add it to "Try these" paths
            if (Properties.Settings.Default.VLCPath != "")
            {
                defaultVlcPaths.Add(Properties.Settings.Default.VLCPath);
            }

            // If operating system is Linux, select default paths for VLC for Linux, otherwise Windows ones
            if (RuntimeInfo.IsLinux)
            {
                foreach (string path in defaultVlcPathsLinux)
                {
                    defaultVlcPaths.Add(path);
                }
            }
            else if(RuntimeInfo.IsLinux)
            {
                
                foreach (string path in defaultVlcPathsLinux)
                {
                    defaultVlcPaths.Add(path);
                }
            }


            bool isVLCFound = false;

            // If vlc.exe exists in vlcPath, open it, otherwise 
            foreach (string vlcPath in defaultVlcPaths)
            {
                if (File.Exists(vlcPath))
                {
                    // Run VLC
                    RunVLC(m3u8URL, vlcPath);

                    // VLC is found, save it to variable
                    isVLCFound = true;

                    // Out of foreach, if other paths has also VLC.
                    break;
                }
            }

            
            if (isVLCFound == false)
            {
                String exeFile = SelectVLCExeFile();

                if (exeFile == "error")
                {
                    MessageBox.Show("Error code: OpenVLC--0", "Unknown error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Save VLC path to settings
                    Properties.Settings.Default["VLCPath"] = exeFile;
                    Properties.Settings.Default.Save();

                    // Open VLC
                    RunVLC(m3u8URL, exeFile);
                }
            }
        }

        /// <summary>
        /// Shows OpenFileDialog for finding vlc.exe
        /// </summary>
        /// <returns>VLC path, that user has selected</returns>
        static string SelectVLCExeFile()
        {
            // TODO: file selecting with "vlc" or whatever (tested only with "*" (default)) not tested with linux
            string fileNameOfVLCExec = "";
            string fileFilter = "";

            // TODO: Test this with macOS and Linux
            if (RuntimeInfo.IsLinux)
            {
                fileNameOfVLCExec = "vlc";
                fileFilter = String.Format("VLC executable ({0})|{0}", fileNameOfVLCExec);
            }
            else if (RuntimeInfo.IsWindows)
            {
                fileNameOfVLCExec = "vlc.exe";
                fileFilter = String.Format("VLC executable ({0})|{0}", fileNameOfVLCExec);
            }
            else
            {
                // Do nothing

                // TODO: this isn't tested, test it...
            }


            #region Select VLC exe file with dialog

            // Initialize file dialog
            OpenFileDialog file = new OpenFileDialog()
            {
                Title = "Valitse VLCn .exe-tiedosto",
                Filter = fileFilter
            };


            // Run it until user selects some file
            while (true) {
                if (file.ShowDialog() == DialogResult.OK)
                {
                    // Check if fileNameOfVLCExec have been set to something?
                    if (fileNameOfVLCExec != "")
                    {
                        // Check if file's name is same as in fileNameOfVLCExec
                        if (file.SafeFileName.ToLower() == fileNameOfVLCExec)
                        {
                            return file.FileName;
                        }
                        else
                        {
                            continue; // TODO: not tested
                        }
                    }
                    else
                    {
                        return file.FileName;
                    }
                }
                else
                {
                    // Allow exiting the application
                    DialogResult dialogResult = MessageBox.Show("Et valinnut tiedostoa! Haluatko yrittää uudelleen?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    switch (dialogResult)
                    {
                        case DialogResult.Yes:
                            // Continue and try to select the file again
                            continue;
                        case DialogResult.No:
                            // Get out of the switch and close the program after switch
                            // NOT WORKING
                            Application.Exit();
                            break;
                        default:
                            MessageBox.Show("User didn't press Yes or No? Selecting \"Show file selecting dialog again\"", "Tuntematon virhe", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            continue;
                    }

                    // Close application (case DialogResult.No gets here)
                    break;
                }
            }

            return "error";
            #endregion
        }

        /// <summary>
        /// Starts VLC media player application
        /// </summary>
        /// <param name="m3u8URL">URL of .m3u8 file that's opened</param>
        /// <param name="vlcPath">VLC's path</param>
        static void RunVLC(Uri m3u8URL, String vlcPath)
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
