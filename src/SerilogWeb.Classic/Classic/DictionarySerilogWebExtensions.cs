using System;
using System.Collections;
using System.Collections.Generic;

namespace SerilogWeb.Classic
{
    internal static class DictionarySerilogWebExtensions
    {
        private const string SerilogWebErrorsHttpContextKey = "SerilogWebErrors";
        private static readonly IReadOnlyList<SerilogWebErrorInfo> EmptyList = new List<SerilogWebErrorInfo>().AsReadOnly();

        internal static void AddSerilogWebError(this IDictionary dictionary, SerilogWebErrorInfo errorInfo)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            var existingErrors = dictionary[SerilogWebErrorsHttpContextKey] as List<SerilogWebErrorInfo>;
            if (existingErrors == null)
            {
                existingErrors = new List<SerilogWebErrorInfo>();
                dictionary[SerilogWebErrorsHttpContextKey] = existingErrors;
            }

            existingErrors.Add(errorInfo);
        }

        internal static IReadOnlyList<SerilogWebErrorInfo> GetSerilogWebErrors(this IDictionary dictionary)
        {
            if (dictionary == null) throw new ArgumentNullException(nameof(dictionary));

            var existingErrors = dictionary[SerilogWebErrorsHttpContextKey] as List<SerilogWebErrorInfo>;
            return existingErrors?.AsReadOnly() ?? EmptyList;
        }
    }
}