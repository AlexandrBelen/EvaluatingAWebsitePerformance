using System;
using System.Collections.Generic;
using System.Text;

namespace WebsitePerfomance.Sitemap
{
    public class SitemapCrawler
    {
        public List<Uri> Crawl(Uri websiteUri, SitemapLinkReceiver linkReceiver, DownloadPage pageDownloader, SitemapParser sitemapParser)
        {
            Uri sitemapUri = linkReceiver.GetSitemapUri(websiteUri, pageDownloader);
            string sitemap = pageDownloader.GetPage(sitemapUri);
            List<Uri> crawledLinks = sitemapParser.GetLinks(sitemap, websiteUri);

            return crawledLinks;
        }
    }
}
