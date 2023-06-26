using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STATE_RadniNalog
{
    public class RadniNalog
    {
        public string Opis { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public DateTime DatumPredaje { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumDovrsetka { get; set; }

        public void ZakljucajNalog(string opis)
        {
            Opis = opis;
            DatumKreiranja = DateTime.Now;
        }

        public void PredajUProizvodnju(DateTime datumPredaje)
        {
            DatumPredaje = DateTime.Now;
        }

        public void ZapocniProizvodnju(DateTime datumPocetka)
        {
            DatumPocetka = datumPocetka;
        }

        internal void DovrsiProizvodnju(DateTime datumDovrsetka)
        {
            DatumDovrsetka = datumDovrsetka;
        }

        public void OtkaziNalog()
        {

        }
    }
}
