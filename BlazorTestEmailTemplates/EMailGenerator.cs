using BlazorTestClasses;

namespace BlazorTestEmailTemplates
{
    public static class EMailGenerator
    {
        public static IEnumerable<string> CreatePerformanceEmail(Employee employee, IEnumerable<Performance> performances, PerformanceSequance sequance)
        {
            if (performances?.Any() ?? false)
            {
                yield return new GeneratePerformanceEmail(employee, performances).EmailContent;
                if (sequance != null)
                {
                    yield return new GenerateBestPerformanceEmail(sequance).EmailContent;
                }
            }
        }

        public static IEnumerable<string> CreateBestPerformanceEmail(PerformanceSequance sequance)
        {
            if (sequance != null)
            {
                yield return new GenerateBestPerformanceEmail(sequance).EmailContent;
            }
        }
    }
}