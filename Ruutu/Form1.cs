using System;
using System.Windows.Forms;

namespace Ruutu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void avaabtn_Click(object sender, EventArgs e)
        {
            // Tarkista URL
            if (urlboksi.Text == "")
            {
                // Jos URL tyhjä, näytä virheilmoitus
                MessageBox.Show("Osoite on tyhjä!", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Uri url;
                bool urlParseResult = Uri.TryCreate(urlboksi.Text, UriKind.Absolute, out url);

                // Tuloksen tulee olla hyvä, sekä domainin pitää olla "www.ruutu.fi" ja alkaa "/video"
                if(urlParseResult == true && url.Host == "www.ruutu.fi" && url.LocalPath.Split('/')[1] == "video")
                {
                    // Onko videoID int?
                    int videoID;
                    bool videoIDparseResult = int.TryParse(url.LocalPath.Split('/')[2], out videoID);

                    if(videoIDparseResult == true)
                    {
                        Uri mediaFileURL = GetMediaFileURL.getURL(videoID);

                        if (mediaFileURL.ToString() == "http://error/drm")
                        {
                            // If DRM protected video
                            MessageBox.Show("DRM-suojauksen takia et voi katsella videota.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if(mediaFileURL.Host == "error")
                        {
                            // If other error
                            MessageBox.Show("Tuntematon virhe", "Tuntematon virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // If no errors, open default media player
                            //MessageBox.Show("media file url: " + mediaFileURL);
                            OpenVLC.openVLC(mediaFileURL);
                        }
                    }
                    else
                    {
                        // Jos videoID ei ole int, näytä virheilmoitus
                        MessageBox.Show("Osoite on virheellinen!", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Näytä virheilmoitus
                    MessageBox.Show("Osoite on virheellinen!", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
