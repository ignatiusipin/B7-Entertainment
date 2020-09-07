using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace B7_Entertainment.Models
{
    public class EntertainmentModel
    {
        public int EntertainNumber { get; set; }

        public DateTime ApplyDate { get; set; }

        public string Department { get; set; }

        public DateTime ClaimDate { get; set; }

        public string TempatPemberian { get; set; }

        public string AlamatTempatPemberian { get; set; }

        public string JenisPemberian { get; set; }

        public string JumlahPemberian { get; set; }

        public string NamaRelasiUsaha { get; set; }

        public string PosisiRelasiUsaha { get; set; }

        public string NamaPerusahaanRelasi { get; set; }

        public string JenisUsahaRelasi { get; set; }

        public string Keterangan { get; set; }

        public int UserID { get; set; }
    }
}