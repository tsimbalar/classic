using System;
using Serilog.Events;

namespace SerilogWeb.Classic
{
    internal struct SerilogWebErrorInfo
    {
        internal SerilogWebErrorInfo(Exception exception, string source, LogEventLevel? level = null)
        {
            Exception = exception ?? throw new ArgumentNullException(nameof(exception));
            Source = source;
            Level = level;
        }

        internal Exception Exception { get; }
        internal string Source { get; }
        internal LogEventLevel? Level { get; }

        internal bool HasValue => Exception != null;
    }
}
