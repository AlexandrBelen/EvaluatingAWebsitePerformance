using System;
using System.Linq;

namespace WebsitePerfomance.Sitemap
{
    public class SitemapLinkReceiver
    {
        public Uri GetSitemapUri(Uri baseUri, DownloadPage downloader)
        {
            Uri sitemapUri;
            try
            {
                Uri robotsTxtUri = new Uri(baseUri, "/robots.txt");

                string fileContent = "";

                fileContent = downloader.GetPage(robotsTxtUri);

                var sitemapString = fileContent.Split('\n')
                .Select(x => x.Trim())
                .Where(x => x.StartsWith("Sitemap:"))
                .FirstOrDefault();

                if (!String.IsNullOrEmpty(sitemapString))
                {
                    sitemapString = sitemapString
                    .Replace("Sitemap:", "")
                    .Trim();
                    sitemapUri = new Uri(sitemapString);
                }
                else
                {
                    sitemapUri = new Uri(baseUri, "/sitemap.xml");
                }

                return sitemapUri;
            }
            catch
            {
                return sitemapUri = new Uri(baseUri, "/sitemap.xml"); //default sitemap url
            }
        }
    }
}