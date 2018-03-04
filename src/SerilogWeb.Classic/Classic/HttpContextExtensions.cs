using System;
using System.Collections.Generic;
using System.Web;

namespace SerilogWeb.Classic
{
    /// <summary>
    /// SerilogWeb specific extension methods
    /// </summary>
    public static class HttpContextExtensions
    {
        /// <summary>
        /// Add an error to be added to the Log Event writtent by SerilogWeb.Classic module
        /// </summary>
        /// <param name="httpContext">The HttpContext</param>
        /// <param name="exception">The error to add</param>
        /// <param name="source">An optional text that can help identify the source of the exception (where/ when it was intercepted)</param>
        public static void AddSerilogWebError(this HttpContext httpContext, Exception exception, string source = null)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            httpContext.Items.AddSerilogWebError(new SerilogWebErrorInfo(exception, source));
        }

        /// <summary>
        /// Add an error to be added to the Log Event writtent by SerilogWeb.Classic module
        /// </summary>
        /// <param name="httpContext">The HttpContext</param>
        /// <param name="exception">The error to add</param>
        /// <param name="source">An optional text that can help identify the source of the exception (where/ when it was intercepted)</param>
        public static void AddSerilogWebError(this HttpContextBase httpContext, Exception exception, string source = null)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            httpContext.Items.AddSerilogWebError(new SerilogWebErrorInfo(exception, source));
        }

        /// <summary>
        /// Access the list of registered SerilogWeb Errors
        /// </summary>
        internal static IReadOnlyList<SerilogWebErrorInfo> GetSerilogWebErrors(this HttpContext httpContext)
        {
            if (httpContext == null) throw new ArgumentNullException(nameof(httpContext));

            return httpContext.Items.GetSerilogWebErrors();
        }
    }
}
