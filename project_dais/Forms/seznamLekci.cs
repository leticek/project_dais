using orm_implementace.Objects;
using orm_implementace.Tables;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace project_dais
{
    public partial class seznamLekci : Form
    {
        private Trener seznamLekciTrener = null;
        private Form hlavniMenuForm = null;
        public seznamLekci()
        {
            InitializeComponent();
        }
        public seznamLekci(int id_trenera, Form f)
        {
            InitializeComponent();
            this.seznamLekciTrener = new Trener();
            this.seznamLekciTrener.id_trenera = id_trenera;
            this.seznamLekciTrener = TrenerGW.detailTrenera(this.seznamLekciTrener);
            this.hlavniMenuForm = f;
        }
        private void PopulateDGW()
        {
            seznamLekciDGW.Rows.Clear();
            List<Lekce> listLekci = new List<Lekce>(LekceGW.seznamLekci());
            foreach (Lekce l in listLekci)
            {
                DataGridViewRow dataGridViewRow = new DataGridViewRow();
                dataGridViewRow.CreateCells(seznamLekciDGW, l.id_mistnosti, l.cas_konani, decimal.ToInt32(l.cena) + " €", l.id_lekce);
                _ = l.id_trenera == seznamLekciTrener.id_trenera ? dataGridViewRow.DefaultCellStyle.BackColor = Color.Green : dataGridViewRow.DefaultCellStyle.BackColor = Color.White;
                seznamLekciDGW.Rows.Add(dataGridViewRow);
            }
            seznamLekciDGW.Refresh();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            CasPicker.Maximum = 23;
            cenaTextBox.MaxLength = 2;
            cenaTextBox.KeyUp += CenaTextBox_KeyUp;
            List<Mistnost> listMistnosti = new List<Mistnost>(MistnostGW.seznamMistnosti());
            foreach(Mistnost m in listMistnosti)
            {
                mistnostiComboBox.Items.Add(m.id_mistnosti);
            }
            List<Trenerova_specializace> listSpecializaci = new List<Trenerova_specializace>(Trenerova_specializaceGW.seznamSpecializaci());
            foreach(Trenerova_specializace ts in listSpecializaci)
            {
                if(ts.id_trenera == seznamLekciTrener.id_trenera)
                {
                    druhTreninkuComboBox.Items.Add(Druh_treninkuGW.detailDruhuTreninku(ts.id_treninku));
                }
            }
            PopulateDGW();
        }
        private void CenaTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            Regex r = new Regex("^[0-9]+$");
            if (!r.IsMatch(tb.Text) && !string.IsNullOrWhiteSpace(tb.Text))
            {
                MessageBox.Show("Neplatný znak.", "Chyba", MessageBoxButtons.OK);
                int index = 0;
                foreach (char c in tb.Text)
                {

                    if (!r.IsMatch(c.ToString()))
                    {
                        tb.Text = tb.Text.Remove(index, 1);
                    }
                    index += 1;
                }
            }
        }
        private void ZpetClick(object sender, EventArgs e)
        {
            this.Close();
            this.hlavniMenuForm.Show();
        }
        private void SeznamLekci_FormClosing(object sender, FormClosingEventArgs e)
        {
                this.hlavniMenuForm.Show();
        }
        private void PridejLekciButton_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(cenaTextBox.Text, out decimal value) && mistnostiComboBox.SelectedIndex != -1 && druhTreninkuComboBox.SelectedIndex != -1)
            {
                Lekce l = new Lekce();
                DateTime datum = new DateTime(datumPicker.Value.Year, datumPicker.Value.Month, datumPicker.Value.Day, decimal.ToInt32(CasPicker.Value), 0, 0);
                l.cas_konani = datum;
                l.cena = value;
                l.clenstvi = clenstviCheckBox.Checked ? '1' : '0';
                l.id_mistnosti = mistnostiComboBox.SelectedIndex + 1;
                l.id_trenera = this.seznamLekciTrener.id_trenera;
                List<Druh_treninku> listDT = new List<Druh_treninku>(Druh_treninkuGW.seznamDruhuTreninku());
                foreach (Druh_treninku dt in listDT)
                {
                    if (dt.druh_treninku.Equals(druhTreninkuComboBox.SelectedItem.ToString()))
                    {
                        l.id_treninku = dt.id_treninku;
                        break;
                    }
                }
                int result = LekceGW.vytvorLekci(l);
                switch (result)
                {
                    case 0:
                        MessageBox.Show("Mistnost je již na tuto dobu zabraná.", "Chyba", MessageBoxButtons.OK);
                        break;
                    case 1:
                        MessageBox.Show("Již máte v tuto dobu jinou lekci.", "Chyba", MessageBoxButtons.OK);
                        break;
                    case 3:
                        MessageBox.Show("Lekce byla vytvořena.", "OK", MessageBoxButtons.OK);
                        PopulateDGW();
                        break;
                    case 4:
                        MessageBox.Show("Nelze vytvořit lekci v minulosti.", "Chyba", MessageBoxButtons.OK);
                        PopulateDGW();
                        break;
                    default:
                        MessageBox.Show("Někde se stala chyba.", "Chyba", MessageBoxButtons.OK);
                        break;
                }
            }
            else
            {
                MessageBox.Show("Zkontrolujte si zadané údaje.(vše je povinnné)", "Chyba", MessageBoxButtons.OK);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            foreach(DataGridViewRow dataGridViewRow in seznamLekciDGW.SelectedRows)
            {
                    Lekce l = new Lekce();
                    l = LekceGW.detailLekce((int)dataGridViewRow.Cells[3].Value);
                    Mistnost mistnost = new Mistnost();
                    mistnost = MistnostGW.detailMistnosti(l.id_mistnosti);
                    Trener trener = new Trener();
                    trener.id_trenera = l.id_trenera;
                    trener = TrenerGW.detailTrenera(trener);
                    string druh_Treninku = Druh_treninkuGW.detailDruhuTreninku(l.id_treninku);
                    int pocetPrihlasenych = Prihlaseni_cvicenciGW.seznamPrihlasenychCvicencu(l.id_lekce).Count();
                    string info = "Vedoucí trenér: " + trener.jmeno + " " + trener.prijmeni + Environment.NewLine +
                                  "Druh tréninku: " + druh_Treninku + Environment.NewLine +
                                  "Počet přihlášených: " + pocetPrihlasenych + "/" + mistnost.kapacita_mistnosti + Environment.NewLine +
                                  "Datum konání: " + l.cas_konani.Day + "." + l.cas_konani.Month + "." + l.cas_konani.Year + Environment.NewLine +
                                  "Čas konání: " + l.cas_konani.Hour + ":00" + Environment.NewLine + 
                                  "Cena: " + Decimal.ToInt32(l.cena).ToString() + " €" + Environment.NewLine + 
                                  "Členství: " + (l.clenstvi == '1' ? "Ano" : "Ne"); 
                    MessageBox.Show(info, "Informace", MessageBoxButtons.OK);
            }
        }
        private void UpravLekciButton_Click(object sender, EventArgs e)
        {
            int id_lekce = (int)seznamLekciDGW.CurrentRow.Cells[3].Value;
            Lekce l = new Lekce();
            l = LekceGW.detailLekce(id_lekce);
            if (l.id_trenera == this.seznamLekciTrener.id_trenera)
            {
                Form uprava = new upravaLekceForm((int)seznamLekciDGW.CurrentRow.Cells[3].Value, this);
                this.Visible = false;
                uprava.Show();
            }
            else
            {
                MessageBox.Show("Nemáte oprávnění pro úpravu této lekce.", "Chyba", MessageBoxButtons.OK);
            }
        }
        private void SeznamLekci_VisibleChanged(object sender, EventArgs e)
        {
            PopulateDGW();
        }
    }
}
