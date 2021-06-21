using System;
using System.Collections.Generic;
using System.Linq;

namespace WebsitePerfomance.Website
{
    public class WebsiteCrawler
    {
        public List<Uri> Crawl(Uri websiteUri, DownloadPage download, Parser pageParser)
        {
            List<Uri> result = new List<Uri>();
            List<Uri> linksToParse = new List<Uri>();
            linksToParse.Add(websiteUri);

            while (linksToParse.Count != 0)
            {
                result.Add(linksToParse[0]);
                string htmlPage = download.GetPage(linksToParse[0]);
                var parsedLinks = pageParser.GetLinks(htmlPage, websiteUri);

                foreach (var link in parsedLinks)
                {
                    if (!result.Contains(link) && !linksToParse.Contains(link))
                        linksToParse.Add(link);
                }
                linksToParse.RemoveAt(0);
            }

            return result
                .Distinct()
                .ToList();
        }
    }
}
