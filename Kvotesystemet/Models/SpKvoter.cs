using System;
using System.Collections.Generic;

namespace Kvotesystemet.Models
{
    public partial class SpKvoter
    {
        public double? Ansattnr { get; set; }
        public string T0E { get; set; }
        public string T0ENavn { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public double? TotaltØl { get; set; }
        public double? TotaltBrus { get; set; }
        public double? TotaltGratis { get; set; }
    }
}
