using System;
using Serilog;
using SerilogWeb.Classic;

namespace SerilogWeb.Test
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Log.Information("Page viewed!");

            // throw new InvalidOperationException("Unlucky this time!");
        }

        protected void Fail(object sender, EventArgs e)
        {
            throw new InvalidOperationException("Kablooey");
        }

        protected void ReportSerilogError(object sender, EventArgs e)
        {
            var theException = new NotSupportedException("This exception shows up in the logged event, even with Custom Errors on!");
            this.Context.AddSerilogWebError(theException, $"{typeof(Default).FullName}.{nameof(ReportSerilogError)}");
        }
    }
}