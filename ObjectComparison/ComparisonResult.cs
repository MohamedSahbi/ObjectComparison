using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectComparison
{
    public class ComparisonResult
    {
        public string ClassName { get; set; }
        public string ChangedProperties { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
