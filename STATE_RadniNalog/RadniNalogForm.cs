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
        }

        private void btnZakljucaj_Click(object sender, EventArgs e)
        {
            _radniNalog.ZakljucajNalog(txtOpis.Text);
            txtDatumKreiranja.Text = _radniNalog.DatumKreiranja.ToString();

            txtStatus.Text = _radniNalog.getState().ToString();
        }

        private void btnPredajNalog_Click(object sender, EventArgs e)
        {
            _radniNalog.PredajUProizvodnju(dtpDatumPredaje.Value);

            txtStatus.Text = _radniNalog.getState().ToString();
        }

        private void btnZapocniProizvodnju_Click(object sender, EventArgs e)
        {
            _radniNalog.ZapocniProizvodnju(dtpDatumPocetka.Value);

            txtStatus.Text = _radniNalog.getState().ToString();
        }

        private void btnDovrsiProizvodnju_Click(object sender, EventArgs e)
        {
            _radniNalog.DovrsiProizvodnju(dtpDatumDovrsetka.Value);

            txtStatus.Text = _radniNalog.getState().ToString();
        }

        private void btnOtkaziNalog_Click(object sender, EventArgs e)
        {
            _radniNalog.OtkaziNalog();

            txtStatus.Text = _radniNalog.getState().ToString();
        }
    }
}
