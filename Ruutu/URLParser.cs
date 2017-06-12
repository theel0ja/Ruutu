﻿using System;
using System.Windows.Forms;

namespace Ruutu
{
    class URLParser
    {
        /// <summary>
        /// Parses URL and opens the video
        /// </summary>
        /// <param name="urlToParse">Program's URL</param>
        public static void Parse(String urlToParse)
        {
            // Tarkista URL
            if (urlToParse == "")
            {
                // Jos URL tyhjä, näytä virheilmoitus
                MessageBox.Show("Osoite on tyhjä!", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bool urlParseResult = Uri.TryCreate(urlToParse, UriKind.Absolute, out Uri url);

                // Tuloksen tulee olla hyvä, sekä domainin pitää olla "www.ruutu.fi" tai "ruutu.fi" ja alkaa "/video"
                if (urlParseResult == true && (url.Host == "www.ruutu.fi" || url.Host == "ruutu.fi") && url.LocalPath.Split('/')[1] == "video")
                {
                    // Onko videoID int?
                    bool videoIDparseResult = int.TryParse(url.LocalPath.Split('/')[2], out int videoID);

                    if (videoIDparseResult == true)
                    {
                        Uri mediaFileURL = GetMediaFileURL.Get(videoID);

                        if (mediaFileURL.ToString() == "http://error/drm")
                        {
                            // If DRM protected video
                            MessageBox.Show("DRM-suojauksen takia et voi katsella videota.", "Virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else if (mediaFileURL.Host == "error")
                        {
                            // If other error
                            MessageBox.Show("Tuntematon virhe", "Tuntematon virhe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            // If no errors, open default media player
                            //MessageBox.Show("media file url: " + mediaFileURL);
                            OpenVLC.Open(mediaFileURL);
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
