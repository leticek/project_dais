namespace project_dais
{
    partial class upravaLekceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.seznamUcastniku = new System.Windows.Forms.DataGridView();
            this.id_cvicence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.s = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zmenyComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.odhlasitCvicenceButton = new System.Windows.Forms.Button();
            this.prihlasitCvicenceButton = new System.Windows.Forms.Button();
            this.datumLabel = new System.Windows.Forms.Label();
            this.mistoLabel = new System.Windows.Forms.Label();
            this.datumPicker = new System.Windows.Forms.DateTimePicker();
            this.mistnostiComboBox = new System.Windows.Forms.ComboBox();
            this.treninkLabel = new System.Windows.Forms.Label();
            this.treninkComboBox = new System.Windows.Forms.ComboBox();
            this.ulozitZmenuButton = new System.Windows.Forms.Button();
            this.zrusitLekciButton = new System.Windows.Forms.Button();
            this.minutyLabel = new System.Windows.Forms.Label();
            this.casLabel = new System.Windows.Forms.Label();
            this.cas = new System.Windows.Forms.NumericUpDown();
            this.ZpetButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.seznamUcastniku)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cas)).BeginInit();
            this.SuspendLayout();
            // 
            // seznamUcastniku
            // 
            this.seznamUcastniku.AllowUserToAddRows = false;
            this.seznamUcastniku.AllowUserToDeleteRows = false;
            this.seznamUcastniku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seznamUcastniku.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id_cvicence,
            this.s,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.seznamUcastniku.Location = new System.Drawing.Point(12, 37);
            this.seznamUcastniku.Name = "seznamUcastniku";
            this.seznamUcastniku.ReadOnly = true;
            this.seznamUcastniku.Size = new System.Drawing.Size(560, 124);
            this.seznamUcastniku.TabIndex = 0;
            // 
            // id_cvicence
            // 
            this.id_cvicence.HeaderText = "id";
            this.id_cvicence.Name = "id_cvicence";
            this.id_cvicence.ReadOnly = true;
            this.id_cvicence.Visible = false;
            // 
            // s
            // 
            this.s.HeaderText = "Jméno";
            this.s.Name = "s";
            this.s.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Příjmení";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Věk";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Pohlaví";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "E-mail";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // zmenyComboBox
            // 
            this.zmenyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.zmenyComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zmenyComboBox.FormattingEnabled = true;
            this.zmenyComboBox.Location = new System.Drawing.Point(17, 193);
            this.zmenyComboBox.Name = "zmenyComboBox";
            this.zmenyComboBox.Size = new System.Drawing.Size(201, 33);
            this.zmenyComboBox.TabIndex = 1;
            this.zmenyComboBox.SelectedIndexChanged += new System.EventHandler(this.ZmenyComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Akce:";
            // 
            // odhlasitCvicenceButton
            // 
            this.odhlasitCvicenceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.odhlasitCvicenceButton.Location = new System.Drawing.Point(578, 102);
            this.odhlasitCvicenceButton.Name = "odhlasitCvicenceButton";
            this.odhlasitCvicenceButton.Size = new System.Drawing.Size(106, 59);
            this.odhlasitCvicenceButton.TabIndex = 3;
            this.odhlasitCvicenceButton.Text = "Odhlásit cvičence";
            this.odhlasitCvicenceButton.UseVisualStyleBackColor = true;
            this.odhlasitCvicenceButton.Click += new System.EventHandler(this.OdhlasitCvicenceButton_Click);
            // 
            // prihlasitCvicenceButton
            // 
            this.prihlasitCvicenceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prihlasitCvicenceButton.Location = new System.Drawing.Point(578, 37);
            this.prihlasitCvicenceButton.Name = "prihlasitCvicenceButton";
            this.prihlasitCvicenceButton.Size = new System.Drawing.Size(106, 59);
            this.prihlasitCvicenceButton.TabIndex = 4;
            this.prihlasitCvicenceButton.Text = "Přihlásit cvičence";
            this.prihlasitCvicenceButton.UseVisualStyleBackColor = true;
            this.prihlasitCvicenceButton.VisibleChanged += new System.EventHandler(this.PrihlasitCvicenceButton_VisibleChanged);
            this.prihlasitCvicenceButton.Click += new System.EventHandler(this.PrihlasitCvicenceButton_Click);
            // 
            // datumLabel
            // 
            this.datumLabel.AutoSize = true;
            this.datumLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datumLabel.Location = new System.Drawing.Point(219, 167);
            this.datumLabel.Name = "datumLabel";
            this.datumLabel.Size = new System.Drawing.Size(127, 25);
            this.datumLabel.TabIndex = 5;
            this.datumLabel.Text = "Nové datum";
            this.datumLabel.Visible = false;
            // 
            // mistoLabel
            // 
            this.mistoLabel.AutoSize = true;
            this.mistoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mistoLabel.Location = new System.Drawing.Point(219, 229);
            this.mistoLabel.Name = "mistoLabel";
            this.mistoLabel.Size = new System.Drawing.Size(119, 25);
            this.mistoLabel.TabIndex = 6;
            this.mistoLabel.Text = "Nové místo";
            this.mistoLabel.Visible = false;
            // 
            // datumPicker
            // 
            this.datumPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datumPicker.Location = new System.Drawing.Point(224, 195);
            this.datumPicker.Name = "datumPicker";
            this.datumPicker.Size = new System.Drawing.Size(292, 31);
            this.datumPicker.TabIndex = 8;
            this.datumPicker.Visible = false;
            // 
            // mistnostiComboBox
            // 
            this.mistnostiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mistnostiComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mistnostiComboBox.FormattingEnabled = true;
            this.mistnostiComboBox.Location = new System.Drawing.Point(224, 257);
            this.mistnostiComboBox.Name = "mistnostiComboBox";
            this.mistnostiComboBox.Size = new System.Drawing.Size(181, 33);
            this.mistnostiComboBox.TabIndex = 9;
            this.mistnostiComboBox.Visible = false;
            // 
            // treninkLabel
            // 
            this.treninkLabel.AutoSize = true;
            this.treninkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.treninkLabel.Location = new System.Drawing.Point(219, 293);
            this.treninkLabel.Name = "treninkLabel";
            this.treninkLabel.Size = new System.Drawing.Size(132, 25);
            this.treninkLabel.TabIndex = 10;
            this.treninkLabel.Text = "Nový trénink";
            this.treninkLabel.Visible = false;
            // 
            // treninkComboBox
            // 
            this.treninkComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.treninkComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.treninkComboBox.FormattingEnabled = true;
            this.treninkComboBox.Location = new System.Drawing.Point(224, 321);
            this.treninkComboBox.Name = "treninkComboBox";
            this.treninkComboBox.Size = new System.Drawing.Size(181, 33);
            this.treninkComboBox.TabIndex = 11;
            this.treninkComboBox.Visible = false;
            // 
            // ulozitZmenuButton
            // 
            this.ulozitZmenuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ulozitZmenuButton.Location = new System.Drawing.Point(462, 255);
            this.ulozitZmenuButton.Name = "ulozitZmenuButton";
            this.ulozitZmenuButton.Size = new System.Drawing.Size(217, 30);
            this.ulozitZmenuButton.TabIndex = 12;
            this.ulozitZmenuButton.Text = "Uložit změnu";
            this.ulozitZmenuButton.UseVisualStyleBackColor = true;
            this.ulozitZmenuButton.Click += new System.EventHandler(this.UlozitZmenuButton_Click);
            // 
            // zrusitLekciButton
            // 
            this.zrusitLekciButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zrusitLekciButton.Location = new System.Drawing.Point(462, 291);
            this.zrusitLekciButton.Name = "zrusitLekciButton";
            this.zrusitLekciButton.Size = new System.Drawing.Size(217, 30);
            this.zrusitLekciButton.TabIndex = 13;
            this.zrusitLekciButton.Text = "Zrušit lekci";
            this.zrusitLekciButton.UseVisualStyleBackColor = true;
            this.zrusitLekciButton.Click += new System.EventHandler(this.ZrusitLekciButton_Click);
            // 
            // minutyLabel
            // 
            this.minutyLabel.AutoSize = true;
            this.minutyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.minutyLabel.Location = new System.Drawing.Point(576, 196);
            this.minutyLabel.Name = "minutyLabel";
            this.minutyLabel.Size = new System.Drawing.Size(42, 25);
            this.minutyLabel.TabIndex = 19;
            this.minutyLabel.Text = ":00";
            this.minutyLabel.Visible = false;
            // 
            // casLabel
            // 
            this.casLabel.AutoSize = true;
            this.casLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.casLabel.Location = new System.Drawing.Point(522, 167);
            this.casLabel.Name = "casLabel";
            this.casLabel.Size = new System.Drawing.Size(50, 25);
            this.casLabel.TabIndex = 18;
            this.casLabel.Text = "Čas";
            this.casLabel.Visible = false;
            // 
            // cas
            // 
            this.cas.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cas.Location = new System.Drawing.Point(527, 195);
            this.cas.Name = "cas";
            this.cas.Size = new System.Drawing.Size(47, 29);
            this.cas.TabIndex = 17;
            this.cas.Visible = false;
            // 
            // ZpetButton
            // 
            this.ZpetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ZpetButton.Location = new System.Drawing.Point(462, 327);
            this.ZpetButton.Name = "ZpetButton";
            this.ZpetButton.Size = new System.Drawing.Size(217, 30);
            this.ZpetButton.TabIndex = 20;
            this.ZpetButton.Text = "Zpět";
            this.ZpetButton.UseVisualStyleBackColor = true;
            this.ZpetButton.Click += new System.EventHandler(this.ZpetButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(309, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Seznam příhlašených cvičenců";
            this.label2.Visible = false;
            // 
            // upravaLekceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 369);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ZpetButton);
            this.Controls.Add(this.minutyLabel);
            this.Controls.Add(this.casLabel);
            this.Controls.Add(this.cas);
            this.Controls.Add(this.zrusitLekciButton);
            this.Controls.Add(this.ulozitZmenuButton);
            this.Controls.Add(this.treninkComboBox);
            this.Controls.Add(this.treninkLabel);
            this.Controls.Add(this.mistnostiComboBox);
            this.Controls.Add(this.datumPicker);
            this.Controls.Add(this.mistoLabel);
            this.Controls.Add(this.datumLabel);
            this.Controls.Add(this.prihlasitCvicenceButton);
            this.Controls.Add(this.odhlasitCvicenceButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.zmenyComboBox);
            this.Controls.Add(this.seznamUcastniku);
            this.Name = "upravaLekceForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Úprava lekce";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UpravaLekce_Closed);
            this.Load += new System.EventHandler(this.upravaLekce_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seznamUcastniku)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView seznamUcastniku;
        private System.Windows.Forms.ComboBox zmenyComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button odhlasitCvicenceButton;
        private System.Windows.Forms.Button prihlasitCvicenceButton;
        private System.Windows.Forms.Label datumLabel;
        private System.Windows.Forms.Label mistoLabel;
        private System.Windows.Forms.DateTimePicker datumPicker;
        private System.Windows.Forms.ComboBox mistnostiComboBox;
        private System.Windows.Forms.Label treninkLabel;
        private System.Windows.Forms.ComboBox treninkComboBox;
        private System.Windows.Forms.Button ulozitZmenuButton;
        private System.Windows.Forms.Button zrusitLekciButton;
        private System.Windows.Forms.Label minutyLabel;
        private System.Windows.Forms.Label casLabel;
        private System.Windows.Forms.NumericUpDown cas;
        private System.Windows.Forms.Button ZpetButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cvicence;
        private System.Windows.Forms.DataGridViewTextBoxColumn s;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label2;
    }
}