using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STATE_RadniNalog
{
    public partial class RadniNalogForm : Form
    {
        private RadniNalog _radniNalog;
        public RadniNalogForm()
        {
            InitializeComponent();
        }

        private void RadniNalogForm_Load(object sender, EventArgs e)
        {
            _radniNalog = new RadniNalog();

            txtStatus.Text = _radniNalog.getState().ToString();

            refreshButtons();
        }

        private void btnZakljucaj_Click(object sender, EventArgs e)
        {
            _radniNalog.ZakljucajNalog(txtOpis.Text);
            txtDatumKreiranja.Text = _radniNalog.DatumKreiranja.ToString();

            txtStatus.Text = _radniNalog.getState().ToString();

            refreshButtons();
        }

        private void btnPredajNalog_Click(object sender, EventArgs e)
        {
            _radniNalog.PredajUProizvodnju(dtpDatumPredaje.Value);

            txtStatus.Text = _radniNalog.getState().ToString();

            refreshButtons();
        }

        private void btnZapocniProizvodnju_Click(object sender, EventArgs e)
        {
            _radniNalog.ZapocniProizvodnju(dtpDatumPocetka.Value);

            txtStatus.Text = _radniNalog.getState().ToString();

            refreshButtons();
        }

        private void btnDovrsiProizvodnju_Click(object sender, EventArgs e)
        {
            _radniNalog.DovrsiProizvodnju(dtpDatumDovrsetka.Value);

            txtStatus.Text = _radniNalog.getState().ToString();

            refreshButtons();
        }

        private void btnOtkaziNalog_Click(object sender, EventArgs e)
        {
            _radniNalog.OtkaziNalog();

            txtStatus.Text = _radniNalog.getState().ToString();

            refreshButtons();
        }

        public void refreshButtons()
        {
            ProjectStates state = _radniNalog.StateManager.CurrentState;

            btnDovrsiProizvodnju.Enabled = state == ProjectStates.ProductionStarted;
            btnZapocniProizvodnju.Enabled = state == ProjectStates.PutIntoProduction;
            btnPredajNalog.Enabled = state == ProjectStates.OrderLocked;
            btnZakljucaj.Enabled = state == ProjectStates.OrderCreated || state == ProjectStates.ProductionCanceled || state == ProjectStates.ProductionFinished;
            btnOtkaziNalog.Enabled = state == ProjectStates.OrderLocked;
        }
    }
}
