using System;
using System.IO;
using System.Net;
using System.Xml;

namespace Ruutu
{
    class GetMediaFileURL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="videoID"></param>
        /// <returns>http://error/drm (Uri) if DRM, m3u8 file URL (Uri) if no DRM</returns>
        public static Uri getURL(int videoID)
        {
            // TODO: check if is <Playerdata><Clip><DRM>1

            Uri xmlURI = new Uri("http://gatling.nelonenmedia.fi/media-xml-cache?id=" + videoID);
            WebRequest request = WebRequest.Create(xmlURI);

            // Set User Agent to some generic User Agent
            ((HttpWebRequest)request).UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";
            
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            XmlDocument xmlContent = new XmlDocument();
            xmlContent.LoadXml(reader.ReadToEnd());
            // Clean up the streams and the response.
            reader.Close();
            response.Close();

            string haveDRM = xmlContent.DocumentElement.SelectSingleNode("/Playerdata/Clip/DRM").InnerText;

            if(haveDRM == "1")
            {
                return new Uri("http://error/drm");
            }
            else
            {
                string mediaFile = xmlContent.DocumentElement.SelectSingleNode("/Playerdata/Clip/WebHLSMediaFiles/WebHLSMediaFile").InnerText;
                return new Uri(mediaFile);
            }
        }
    }
}
