using System;
using System.Net;

namespace WebsitePerfomance
{
    public class DownloadPage
    {
        public string GetPage(Uri websiteUri)
        {
            WebClient client = new WebClient();
            string page = "";
            try
            {
                using (client)
                {
                    page = client.DownloadString(websiteUri);
                }
            }
            catch
            {
                Console.WriteLine($"Error during downloading: {websiteUri}");
            }
            return page;
        }
    }
}
