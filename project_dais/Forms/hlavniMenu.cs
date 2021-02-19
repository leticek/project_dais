using orm_implementace.Objects;
using orm_implementace.Tables;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace project_dais.Forms
{
    public partial class hlavniMenu : Form
    {
        public hlavniMenu()
        {
            InitializeComponent();
        }
        private void HlavniMenu_Load(object sender, EventArgs e)
        {
            List<Trener> listTreneru = new List<Trener>(TrenerGW.seznamTreneru());
            foreach(Trener t in listTreneru)
            {
                string jmeno = t.jmeno + " " + t.prijmeni;
                seznamTreneruComboBox.Items.Add(jmeno);
            }
            this.seznamTreneruComboBox.SelectedIndexChanged += new System.EventHandler(SeznamTreneruIndexChanged);
        }
        private void SeznamTreneruIndexChanged(object sender, System.EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            Trener t = new Trener();
            t.id_trenera = comboBox.SelectedIndex + 1;
            t = TrenerGW.detailTrenera(t);
            jmenoLabel.Text = t.jmeno;
            prijmeniLabel.Text = t.prijmeni;
            pohlaviLabel.Text = t.pohlavi;
            datumNarozeniLabel.Text = t.datum_narozeni.ToString("d.MMMM yyyy");
            telefonniCisloLabel.Text = t.telefonni_cislo;
            emailLabel.Text = t.email;
            adresaLabel.Text = t.adresa;
            List<Trenerova_specializace> trenerova_Specializace = new List<Trenerova_specializace>(Trenerova_specializaceGW.seznamSpecializaci());
            seznamSpecializaciLabel.Text = "";
            foreach (Trenerova_specializace ts in trenerova_Specializace)
            {
                if (ts.id_trenera == t.id_trenera)
                {
                    seznamSpecializaciLabel.Text += Druh_treninkuGW.detailDruhuTreninku(ts.id_treninku) + ", ";
                }
            }
        }
        private void PrehledTreneraButton_Click(object sender, EventArgs e)
        {
            if (seznamTreneruComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Pro vstup do aplikace je nutné si zvolit trenéra.", "Chyba", MessageBoxButtons.OK);
            }
            else
            {
                Form f = new prehledTrenera(seznamTreneruComboBox.SelectedIndex + 1, this);
                this.Hide();
                f.Show();
            }
        }
        private void SeznamLekciButton_Click(object sender, EventArgs e)
        {
            if (seznamTreneruComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Pro vstup do aplikace je nutné si zvolit trenéra.", "Chyba", MessageBoxButtons.OK);
            }
            else
            {
                Form f = new seznamLekci(seznamTreneruComboBox.SelectedIndex + 1, this);
                this.Hide();
                f.Show();
            }
        }
    }
}
