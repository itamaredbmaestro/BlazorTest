using BlazorTestClasses;
using Scriban.Runtime;
using Scriban;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorTestEmailTemplates
{
    internal class GeneratePerformanceEmail
    {
        private Employee employee;

        private IEnumerable<Performance> performance;

        public string EmailContent { get; set; }

        public GeneratePerformanceEmail(Employee employee, IEnumerable<Performance> performances)
        {
            this.employee = employee;
            this.performance = performances;
            string templateContent = File.ReadAllText(Path.Combine(Path.GetDirectoryName(typeof(GeneratePerformanceEmail).Assembly.Location), "Templates", "PerformanceEmail.sbn"));

            var tpl = Template.Parse(templateContent);
            var scriptObject = new ScriptObject();
            scriptObject.Import(tpl);
            scriptObject.Import(nameof(SumTicketsFromAmount), SumTicketsFromAmount);
            scriptObject.Import(nameof(IsSumTicketsGood), IsSumTicketsGood);
            scriptObject.Import(nameof(GetPerformanceStart), GetPerformanceStart);
            scriptObject.Import(nameof(GetPerformanceEnd), GetPerformanceEnd);
            var context = new TemplateContext();
            context.PushGlobal(scriptObject);
            context.CurrentGlobal.SetValue("employee", employee, true);
            var output = tpl.Render(context);
            context.PopGlobal();
            EmailContent = output.ToString().Trim();
        }

        private string GetPerformanceStart()
        {
            return performance.Select(p => new DateTime(2024, p.Month, p.Day)).Min().ToShortDateString();
        }

        private string GetPerformanceEnd()
        {
            return performance.Select(p => new DateTime(2024, p.Month, p.Day)).Max().ToShortDateString();
        }

        private int SumTicketsFromAmount()
        {
            return Math.Abs(performance.Select(p => p.TicketsOverMin).Sum());
        }

        private bool IsSumTicketsGood()
        {
            return performance.Select(p => p.TicketsOverMin).Sum() > 0;
        }
    }
}
