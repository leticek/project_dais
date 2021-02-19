using orm_implementace;
using orm_implementace.Objects;
using orm_implementace.Tables;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace project_dais.Forms
{
    public partial class prihlaseniCvicence : Form
    {
        private Lekce prihlaseniCvicenceLekce = new Lekce();
        private Form upravaLekceForm = null;
        public prihlaseniCvicence()
        {
            InitializeComponent();
        }
        public prihlaseniCvicence(int id_lekce, Form f)
        {
            InitializeComponent();
            this.prihlaseniCvicenceLekce = LekceGW.detailLekce(id_lekce);
            this.upravaLekceForm = f;
        }
        private void PopulateSeznamUcastniku()
        {
            seznamUcastniku.Rows.Clear();
            List<Cvicenec> listCvicencu = new List<Cvicenec>(CvicenecGW.seznamCvicencu());
            foreach (Cvicenec c in listCvicencu)
            {
                TimeSpan timeSpan = DateTime.Now - c.datum_narozeni;
                int vek = Convert.ToInt32(timeSpan.TotalDays / 365.25);
                seznamUcastniku.Rows.Add(c.id_cvicence, c.jmeno, c.prijmeni, vek, c.pohlavi, c.email);
            }
            seznamUcastniku.Refresh();
        }
        private void PrihlaseniCvicence_Load(object sender, EventArgs e)
        {
            PopulateSeznamUcastniku();
        }
        private void ZpetButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.upravaLekceForm.Show();
        }
        private void PrihlaseniCvicence_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.upravaLekceForm.Visible = true;
        }
        private void PrihlasitCvicenceButton_Click(object sender, EventArgs e)
        {
            int id_cvicence = (int)seznamUcastniku.CurrentRow.Cells[0].Value;
            Cvicenec c = new Cvicenec();
            c.id_cvicence = id_cvicence;
            int resultPrihlaseni = Prihlaseni_cvicenciGW.zapisCvicence(c, this.prihlaseniCvicenceLekce.id_lekce);
            switch (resultPrihlaseni)
            {
                case 0:
                    MessageBox.Show("Na lekci již není místo.", "Chyba", MessageBoxButtons.OK);
                    break;
                case 1:
                    MessageBox.Show("Cvičenec byl přihlášen.", "OK", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("Lekce je pouze pro cvičence.", "Chyba", MessageBoxButtons.OK);
                    break;
                default:
                    MessageBox.Show("Někde se stala chyba.", "Chyba", MessageBoxButtons.OK);
                    break;
            }
        }
    }
}
