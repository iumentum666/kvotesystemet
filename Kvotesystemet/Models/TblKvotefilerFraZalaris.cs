using System;
using System.Collections.Generic;

namespace Kvotesystemet.Models
{
    public partial class TblKvotefilerFraZalaris
    {
        public int Id { get; set; }
        public double? Ansattnummer { get; set; }
        public string Status { get; set; }
        public string Fornavn { get; set; }
        public string Etternavn { get; set; }
        public string Ansettelsesdato { get; set; }
        public string Kvotekode { get; set; }
        public string StillingStatus { get; set; }
        public string Stilling { get; set; }
        public DateTime? OppdatertDato { get; set; }
        public double? Materialnummer { get; set; }
        public double? Antall { get; set; }
        public DateTime? SalgsDato { get; set; }
        public double? Øl { get; set; }
        public double? Brus { get; set; }
        public double? Gratis { get; set; }
        public bool GratisBrus { get; set; }
        public byte[] UpsizeTs { get; set; }
    }
}
