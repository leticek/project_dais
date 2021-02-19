using orm_implementace;
using orm_implementace.Objects;
using orm_implementace.Tables;
using project_dais.Forms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace project_dais
{
    public partial class upravaLekceForm : Form
    {
        private Lekce upravaLekceLekce = new Lekce();
        private Form seznamLekciForm = null;
        private List<Mistnost> upravaLekceListMistnoti = null;
        private Dictionary<string, int> upravaLekceDictDruhTreninku = null;
        public upravaLekceForm()
        {
            InitializeComponent();
        }
        public upravaLekceForm(int id_lekce, Form f)
        {
            InitializeComponent();
            this.upravaLekceLekce = LekceGW.detailLekce(id_lekce);
            this.seznamLekciForm = f;
            this.upravaLekceListMistnoti = new List<Mistnost>(MistnostGW.seznamMistnosti());
            List<Druh_treninku> druh_Treninkus = new List<Druh_treninku>(Druh_treninkuGW.seznamDruhuTreninku());
            this.upravaLekceDictDruhTreninku = new Dictionary<string, int>();
            foreach(Druh_treninku dt in druh_Treninkus)
            {
                this.upravaLekceDictDruhTreninku.Add(dt.druh_treninku, dt.id_treninku);
            }
        }
        private void upravaLekce_Load(object sender, EventArgs e)
        {
            string[] zmeny = { "Změna data a času", "Změna místa", "Změna tréninku" };
            cas.Maximum = 23;
            zmenyComboBox.Items.AddRange(zmeny);
            List<Mistnost> listMistnosti = new List<Mistnost>(MistnostGW.seznamMistnosti());
            foreach(Mistnost m in listMistnosti)
            {
                string mistnost = "Místnost: " + m.id_mistnosti + " (" + m.kapacita_mistnosti + ")";
                mistnostiComboBox.Items.Add(mistnost);
            }
            List<Trenerova_specializace> listSpecializaci = new List<Trenerova_specializace>(Trenerova_specializaceGW.seznamSpecializaci());
            foreach (Trenerova_specializace ts in listSpecializaci)
            {
                if (ts.id_trenera == this.upravaLekceLekce.id_trenera)
                {
                    treninkComboBox.Items.Add(Druh_treninkuGW.detailDruhuTreninku(ts.id_treninku));
                }
            }
            PopulateSeznamUcastniku();
        }
        private void UpravaLekce_Closed(object sender, FormClosedEventArgs e)
        {
            this.seznamLekciForm.Show();
        }
        private void ZpetButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.seznamLekciForm.Show();
        }
        private void ZmenyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (zmenyComboBox.SelectedIndex)
            {
                case 0:
                    datumLabel.Visible = true;
                    datumPicker.Visible = true;
                    casLabel.Visible = true;
                    cas.Visible = true;
                    mistoLabel.Visible = false;
                    mistnostiComboBox.Visible = false;
                    treninkComboBox.Visible = false;
                    treninkLabel.Visible = false;
                    break;
                case 1:
                    datumLabel.Visible = false;
                    datumPicker.Visible = false;
                    casLabel.Visible = false;
                    cas.Visible = false;
                    mistoLabel.Visible = true;
                    mistnostiComboBox.Visible = true;
                    treninkComboBox.Visible = false;
                    treninkLabel.Visible = false;
                    break;
                case 2:
                    datumLabel.Visible = false;
                    datumPicker.Visible = false;
                    casLabel.Visible = false;
                    cas.Visible = false;
                    mistoLabel.Visible = false;
                    mistnostiComboBox.Visible = false;
                    treninkComboBox.Visible = true;
                    treninkLabel.Visible = true;
                    break;
            }
        }
        private void UlozitZmenuButton_Click(object sender, EventArgs e)
        {
            switch (zmenyComboBox.SelectedIndex)
            {
                case 0:
                    DateTime datum = new DateTime(datumPicker.Value.Year, datumPicker.Value.Month, datumPicker.Value.Day, decimal.ToInt32(cas.Value), 0, 0);
                    int resultZmenaData = LekceGW.zmenaData(this.upravaLekceLekce.id_lekce, datum);
                    switch (resultZmenaData)
                    {
                        case 0:
                            MessageBox.Show("Lekce začíná za méně jak 3 hodiny.", "Chyba", MessageBoxButtons.OK);
                            break;
                        case 1:
                            MessageBox.Show("Změna data byla provedena.", "Ok", MessageBoxButtons.OK);
                            break;
                        case 2:
                            MessageBox.Show("Místnost je na toto datum již zabraná.", "Chyba", MessageBoxButtons.OK);
                            break;
                        default:
                            MessageBox.Show("Někde se stala chyba.", "Chyba", MessageBoxButtons.OK);
                            break;
                    }
                    break;
                case 1:
                    int resultZmenaMista = LekceGW.zmenaMista(this.upravaLekceLekce.id_lekce, this.upravaLekceListMistnoti[mistnostiComboBox.SelectedIndex].id_mistnosti);
                    switch (resultZmenaMista)
                    {
                        case 0:
                            MessageBox.Show("Lekce začíná za méně jak 3 hodiny.", "Chyba", MessageBoxButtons.OK);
                            break;
                        case 1:
                            MessageBox.Show("Změna místnosti byla provedena.", "Ok", MessageBoxButtons.OK);
                            break;
                        case 2:
                            MessageBox.Show("Místnost je na toto datum již zabraná.", "Chyba", MessageBoxButtons.OK);
                            break;
                        case 3:
                            MessageBox.Show("Nová místnost nemá dostatečnou kapacitu.", "Chyba", MessageBoxButtons.OK);
                            break;
                        default:
                            MessageBox.Show("Někde se stala chyba.", "Chyba", MessageBoxButtons.OK);
                            break;
                    }
                    break;
                case 2:
                    int id_treninku = 0;
                    this.upravaLekceDictDruhTreninku.TryGetValue(this.treninkComboBox.SelectedItem.ToString(), out id_treninku);
                    int resultZmenaTreninku = LekceGW.zmenaTreninku(this.upravaLekceLekce.id_lekce, id_treninku);
                    switch (resultZmenaTreninku)
                    {
                        case 0:
                            MessageBox.Show("Lekce začíná za méně jak 3 hodiny.", "Chyba", MessageBoxButtons.OK);
                            break;
                        case 1:
                            MessageBox.Show("Změna tréninku byla provedena.", "Ok", MessageBoxButtons.OK);
                            break;
                        default:
                            MessageBox.Show("Někde se stala chyba.", "Chyba", MessageBoxButtons.OK);
                            break;
                    }
                    break;
                default:
                    MessageBox.Show("Prvně proveďte změnu.", "Chyba", MessageBoxButtons.OK);
                    break;
            }
        }
        private void ZrusitLekciButton_Click(object sender, EventArgs e)
        {
            int result = LekceGW.zruseniLekce(this.upravaLekceLekce.id_lekce);
            switch (result)
            {
                case 0:
                    MessageBox.Show("Lekce začíná za méně jak 3 hodiny.", "Chyba", MessageBoxButtons.OK);
                    break;
                case 1:
                    MessageBox.Show("Lekce byla zrušena", "Ok", MessageBoxButtons.OK);
                    this.Hide();
                    this.seznamLekciForm.Show();
                    break;
                default:
                    MessageBox.Show("Někde se stala chyba.", "Chyba", MessageBoxButtons.OK);
                    break;
            }
        }
        private void OdhlasitCvicenceButton_Click(object sender, EventArgs e)
        {
            if (seznamUcastniku.Rows.Count != 0)
            {
                int id_cvicence = (int)seznamUcastniku.CurrentRow.Cells[0].Value;
                Cvicenec c = new Cvicenec();
                c.id_cvicence = id_cvicence;
                Prihlaseni_cvicenciGW.odhlasCvicence(c, this.upravaLekceLekce.id_lekce);
                PopulateSeznamUcastniku();
            }
        }
        private void PopulateSeznamUcastniku()
        {
            seznamUcastniku.Rows.Clear();
            List<int> listCvicencu = new List<int>(Prihlaseni_cvicenciGW.seznamPrihlasenychCvicencu(this.upravaLekceLekce.id_lekce));
            foreach (int idCvicence in listCvicencu)
            {
                Cvicenec c = new Cvicenec();
                c.id_cvicence = idCvicence;
                c = CvicenecGW.detailCvicence(c);
                TimeSpan timeSpan = DateTime.Now - c.datum_narozeni;
                int vek = Convert.ToInt32(timeSpan.TotalDays / 365.25);
                seznamUcastniku.Rows.Add(c.id_cvicence, c.jmeno, c.prijmeni, vek, c.pohlavi, c.email);
            }
            seznamUcastniku.Refresh();
        }
        private void PrihlasitCvicenceButton_Click(object sender, EventArgs e)
        {
            Form prihlaseniCvicence = new prihlaseniCvicence(this.upravaLekceLekce.id_lekce, this);
            this.Visible = false;
            prihlaseniCvicence.Visible = true;
        }
        private void PrihlasitCvicenceButton_VisibleChanged(object sender, EventArgs e)
        {
            PopulateSeznamUcastniku();
        }
    }
}
