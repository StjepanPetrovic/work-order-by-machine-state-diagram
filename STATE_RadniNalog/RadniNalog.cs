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
        public StateManager StateManager { get; set; } = new StateManager();

        public void ZakljucajNalog(string opis)
        {
            Opis = opis;
            DatumKreiranja = DateTime.Now;
            StateManager.MakeTransition(ActivationEvents.AllItemsAddedInOrder);
        }

        public void PredajUProizvodnju(DateTime datumPredaje)
        {
            DatumPredaje = DateTime.Now;
            StateManager.MakeTransition(ActivationEvents.ProductionCommited);
        }

        public void ZapocniProizvodnju(DateTime datumPocetka)
        {
            DatumPocetka = datumPocetka;
            StateManager.MakeTransition(ActivationEvents.OrderTaken);
        }

        internal void DovrsiProizvodnju(DateTime datumDovrsetka)
        {
            DatumDovrsetka = datumDovrsetka;
            StateManager.MakeTransition(ActivationEvents.AllItemsFinished);
        }

        public void OtkaziNalog()
        {
            StateManager.MakeTransition(ActivationEvents.GivingUpProduction);
        }

        public ProjectStates getState()
        {
            return StateManager.CurrentState;
        }
    }
}
