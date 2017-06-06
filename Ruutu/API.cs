using System;

namespace Ruutu
{
    class API
    {
        public static void OpenRuutuVideo(Uri videoURL)
        {
            // Opens videoURL in VLC
            URLParser.Parse(videoURL.AbsoluteUri);
        }
    }
}
