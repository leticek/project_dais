using orm_implementace.Objects;
using orm_implementace.Tables;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace project_dais
{
    public partial class prehledTrenera : Form
    {
        private Trener prehledTreneraTrener = null;
        private Form prehledTreneraHlavniMenuForm = null;
        public prehledTrenera()
        {
            InitializeComponent();
        }
        public prehledTrenera(int id_trenera, Form f)
        {
            InitializeComponent();
            this.prehledTreneraTrener = new Trener();
            this.prehledTreneraTrener.id_trenera = id_trenera;
            this.prehledTreneraTrener = TrenerGW.detailTrenera(this.prehledTreneraTrener);
            this.prehledTreneraHlavniMenuForm = f;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lChyba.Hide();
            jmenoTextBox.MaxLength = 20;
            prijmeniTextBox.MaxLength = 20;
            emailTextBox.MaxLength = 50;
            adresaTextBox.MaxLength = 100;
            jmenoTextBox.Text = this.prehledTreneraTrener.jmeno;
            prijmeniTextBox.Text = this.prehledTreneraTrener.prijmeni;
            _ = this.prehledTreneraTrener.pohlavi == "Muž" ? muzRadioButton.Checked = true : zenaRadioButton.Checked = true;
            datumNarozeni.Value = this.prehledTreneraTrener.datum_narozeni;
            telefonTextBox.Text = this.prehledTreneraTrener.telefonni_cislo;
            emailTextBox.Text = this.prehledTreneraTrener.email;
            adresaTextBox.Text = this.prehledTreneraTrener.adresa;
            jmenoTextBox.KeyUp += JmenoPrijemniValidace;
            prijmeniTextBox.KeyUp += JmenoPrijemniValidace;
            telefonTextBox.KeyUp += TelefonTextBox_KeyUp;
            minVekTextBox.KeyUp += MinVekTextBox_KeyUp;
            List<Lekce> listTrenerovychLekci = new List<Lekce>(TrenerGW.seznamTrenerovychLekci(this.prehledTreneraTrener.id_trenera));
            foreach(Lekce l in listTrenerovychLekci)
            {
                trenerovyLekceDGW.Rows.Add(l.id_mistnosti,
                    l.cas_konani.ToString(),
                    decimal.ToInt32(l.cena) + " €",
                    l.clenstvi == '1' ? "Ano" : "Ne",
                    Druh_treninkuGW.detailDruhuTreninku(l.id_treninku));
            }
        }
        private void MinVekTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox minVekTextBox = (TextBox)sender;
            Regex minVekRegex = new Regex("^[0-9]+$");
            if (!minVekRegex.IsMatch(minVekTextBox.Text) && !string.IsNullOrWhiteSpace(minVekTextBox.Text))
            {
                MessageBox.Show("Neplatný znak.", "Chyba", MessageBoxButtons.OK);
                int index = 0;
                foreach (char c in minVekTextBox.Text)
                {
                    if (!minVekRegex.IsMatch(c.ToString()))
                    {
                        minVekTextBox.Text = minVekTextBox.Text.Remove(index, 1);
                    }
                    index += 1;
                }
            }
        }
        private void TelefonTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox telefonTextBox = (TextBox)sender;
            Regex telefonRegex = new Regex("^[0-9-]+$");
            if (!telefonRegex.IsMatch(telefonTextBox.Text) && !string.IsNullOrWhiteSpace(telefonTextBox.Text))
            {
                MessageBox.Show("Neplatný znak.", "Chyba", MessageBoxButtons.OK);
                int index = 0;
                foreach (char c in telefonTextBox.Text)
                {
                    if (!telefonRegex.IsMatch(c.ToString()))
                    {
                        telefonTextBox.Text = telefonTextBox.Text.Remove(index, 1);
                    }
                    index += 1;
                }
            }
        }
        private void JmenoPrijemniValidace(object sender, KeyEventArgs e)
        {
            TextBox jmenoPrijmeniTextBox = (TextBox)sender;
            Regex jmenoPrijmeniRegex = new Regex("^[a-zA-ZěščřžýáíéĚŠČŘŽÝÁÍÉ]+$");
            if (!jmenoPrijmeniRegex.IsMatch(jmenoPrijmeniTextBox.Text) && !string.IsNullOrWhiteSpace(jmenoPrijmeniTextBox.Text))
            {
                MessageBox.Show("Neplatný znak.", "Chyba", MessageBoxButtons.OK);
                int index = 0;
                foreach(char c in jmenoPrijmeniTextBox.Text)
                {
                    if (!jmenoPrijmeniRegex.IsMatch(c.ToString()))
                    {
                        jmenoPrijmeniTextBox.Text = jmenoPrijmeniTextBox.Text.Remove(index, 1);
                    }
                    index += 1;
                }
            }
        }
        private void UlozZmeny(object sender, EventArgs e)
        {
            Regex regexJmenoPrijmeni = new Regex("^[a-zA-ZěščřžýáíéĚŠČŘŽÝÁÍÉ]+$");
            Regex regexTelefon = new Regex("^[0-9]{3}[-]{1}[0-9]{3}[-]{1}[0-9]{3}$");
            Regex regexEmail = new Regex("^(\\D)+(\\w)*((\\.(\\w)+)?)+@(\\D)+(\\w)*((\\.(\\D)+(\\w)*)+)?(\\.)[a-z]{2,}$");
            try
            {
                if ((regexJmenoPrijmeni.IsMatch(jmenoTextBox.Text) && !string.IsNullOrEmpty(jmenoTextBox.Text)) &&
                   (regexJmenoPrijmeni.IsMatch(prijmeniTextBox.Text) && !string.IsNullOrEmpty(prijmeniTextBox.Text)) &&
                   (regexTelefon.IsMatch(telefonTextBox.Text) && !string.IsNullOrEmpty(telefonTextBox.Text)) &&
                   (regexEmail.IsMatch(emailTextBox.Text) && !string.IsNullOrEmpty(emailTextBox.Text)) &&
                   !string.IsNullOrEmpty(adresaTextBox.Text))
                {
                    this.prehledTreneraTrener.jmeno = jmenoTextBox.Text;
                    this.prehledTreneraTrener.prijmeni = prijmeniTextBox.Text;
                    this.prehledTreneraTrener.pohlavi = muzRadioButton.Checked ? "Muž" : "Žena";
                    this.prehledTreneraTrener.datum_narozeni = datumNarozeni.Value;
                    this.prehledTreneraTrener.telefonni_cislo = telefonTextBox.Text;
                    this.prehledTreneraTrener.email = emailTextBox.Text;
                    this.prehledTreneraTrener.adresa = adresaTextBox.Text;
                    TrenerGW.upravaTrenera(prehledTreneraTrener);
                    MessageBox.Show("Změny byly uloženy.", "OK", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("Zkontrolujte si formát údajů a akci opakujte.", "Chyba", MessageBoxButtons.OK);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void MinVekButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(minVekTextBox.Text))
            {
                probehleLekceDGW.Rows.Clear();
                List<Lekce> listLekci = new List<Lekce>(TrenerGW.seznamTrenerovychLekci(this.prehledTreneraTrener.id_trenera));
                Dictionary<int, int> dictLekceDleVeku = new Dictionary<int, int>(LekceGW.seznamLekciDleVeku(Int32.Parse(minVekTextBox.Text), this.prehledTreneraTrener.id_trenera));
                bool existujeLekce = false;
                foreach (Lekce l in listLekci)
                {
                    if (dictLekceDleVeku.ContainsKey(l.id_lekce))
                    {
                        existujeLekce = true;
                        Tuple<int, int> podilClenu = LekceGW.podilClenu(l.id_lekce);
                        dictLekceDleVeku.TryGetValue(l.id_lekce, out int prumernyVek);
                        probehleLekceDGW.Rows.Add(l.id_mistnosti,
                            l.cas_konani.ToString(),
                            decimal.ToInt32(l.cena) + " €",
                            l.clenstvi == '1' ? "Ano" : "Ne",
                            prumernyVek,
                            podilClenu.Item1 + "/" + podilClenu.Item2);
                    }
                }
                if (existujeLekce)
                {
                    lChyba.Hide();
                    probehleLekceDGW.Refresh();
                    trenerovyLekceDGW.Hide();
                    probehleLekceDGW.Show();
                }
                else
                {
                    lChyba.Show();
                    trenerovyLekceDGW.Hide();
                    probehleLekceDGW.Hide();
                }
            }
            else
            {
                MessageBox.Show("Prosím vyplňte minimální věk.", "Chyba", MessageBoxButtons.OK);
            }
        }
        private void VsechnyLekceButton_Click(object sender, EventArgs e)
        {
            lChyba.Hide();
            probehleLekceDGW.Hide();
            trenerovyLekceDGW.Show();
        }
        private void ZpetClick(object sender, EventArgs e)
        {
            this.Close();
            this.prehledTreneraHlavniMenuForm.Show();
        }
        private void PrehledTrenera_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.prehledTreneraHlavniMenuForm.Show();
        }
    }
}
