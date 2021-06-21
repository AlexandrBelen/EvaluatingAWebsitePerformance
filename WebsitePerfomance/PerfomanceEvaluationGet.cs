using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebsitePerfomance
{
    class PerfomanceEvaluationGet
    {
        public List<PerfomanceResult> PrepareLinks(List<Uri> links, PerfomanceEvaluator performanceEvaluator)
        {
            List<PerfomanceResult> result = new List<PerfomanceResult>();

            foreach (var link in links)
            {
                result.Add(new PerfomanceResult { Link = link.AbsoluteUri, ResponseTime = performanceEvaluator.GetResponceTime(link) });
            }

            return result
                .OrderBy(r => r.ResponseTime)
                .ToList();
        }
    }
}
