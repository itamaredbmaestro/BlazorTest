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
    internal class GenerateBestPerformanceEmail
    {
        private PerformanceSequance sequance;

        public string EmailContent { get; set; }

        public GenerateBestPerformanceEmail(PerformanceSequance sequance)
        {
            this.sequance = sequance;
            string templateContent = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Templates", "BestPerformanceEmail.sbn"));

            var tpl = Template.Parse(templateContent);
            var scriptObject = new ScriptObject();
            scriptObject.Import(tpl);
            scriptObject.Import(nameof(GetPerformanceStart), GetPerformanceStart);
            scriptObject.Import(nameof(GetPerformanceEnd), GetPerformanceEnd);
            scriptObject.Import(nameof(GetTotalTicketsOver), GetTotalTicketsOver);
            var context = new TemplateContext();
            context.PushGlobal(scriptObject);
            context.CurrentGlobal.SetValue("employee", sequance.Emp, true);
            var output = tpl.Render(context);
            context.PopGlobal();
            EmailContent = output.ToString().Trim();
        }

        private DateTime GetPerformanceStart()
        {
            return new DateTime(2024, sequance.Month, sequance.FromDay);
        }

        private DateTime GetPerformanceEnd()
        {
            return new DateTime(2024, sequance.Month, sequance.ToDay);
        }

        private int GetTotalTicketsOver()
        {
            return sequance.SumTicketsOverMin;
        }
    }
}
