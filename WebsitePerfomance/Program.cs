using System;
using System.Linq;
using WebsitePerfomance.Print;
using WebsitePerfomance.Sitemap;
using WebsitePerfomance.Website;

namespace WebsitePerfomance
{
    class Program
    {
        static void Main(string[] args)
        {
            var websiteCrawler = new WebsiteCrawler();
            var sitemapCrawler = new SitemapCrawler();

            var differencePrinter = new PrintLinksDifference();
            var responcePrinter = new PrintResponse();

            var performanceEvaluationGetter = new PerfomanceEvaluationGet();

            Uri WebsiteUrl = null;

            Console.WriteLine(@"Enter the website url (e.g. https://www.example.com/):");
            string websiteLink = Console.ReadLine();
            WebsiteUrl = new Uri(websiteLink);

            Console.WriteLine("Crawling website. It will take some time...");
            var websiteLinks = websiteCrawler.Crawl(WebsiteUrl, new DownloadPage(), new Parser());

            Console.WriteLine("Crawling sitemap. It will take some time...");
            var sitemapLinks = sitemapCrawler.Crawl(WebsiteUrl, new SitemapLinkReceiver(), new DownloadPage(), new SitemapParser());

            differencePrinter.PrintDifference(sitemapLinks, websiteLinks);

            Console.WriteLine("Response time processing. It will take some time...");
            var combinedLinks = sitemapLinks.Union(websiteLinks).ToList();
            responcePrinter.PrintTable(performanceEvaluationGetter.PrepareLinks(combinedLinks, new PerfomanceEvaluator()));

            Console.ReadLine();
        }
    }
}
