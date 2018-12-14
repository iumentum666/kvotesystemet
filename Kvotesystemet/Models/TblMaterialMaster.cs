using System;
using System.Collections.Generic;

namespace Kvotesystemet.Models
{
    public partial class TblMaterialMaster
    {
        public double? Legacy { get; set; }
        public double Bsp1 { get; set; }
        public string Tekst { get; set; }
        public double? Liter { get; set; }
        public string Mg1 { get; set; }
        public string IkkeTillatt { get; set; }
        public double? Brus { get; set; }
        public double? Øl { get; set; }
        public byte[] UpsizeTs { get; set; }
    }
}
