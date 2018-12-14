using System;
using System.Collections.Generic;

namespace Kvotesystemet.Models
{
    public partial class TblKvotedefinisjoner
    {
        public string Kvote { get; set; }
        public double? Øl { get; set; }
        public double? Brus { get; set; }
        public double? Gratis { get; set; }
        public byte[] UpsizeTs { get; set; }
    }
}
