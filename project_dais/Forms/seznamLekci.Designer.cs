namespace project_dais
{
    partial class seznamLekci
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
            this.seznamLekciDGW = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id_treninku = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PridejLekciButton = new System.Windows.Forms.Button();
            this.UpravLekciButton = new System.Windows.Forms.Button();
            this.DetailButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.mistnostiComboBox = new System.Windows.Forms.ComboBox();
            this.druhTreninkuComboBox = new System.Windows.Forms.ComboBox();
            this.datumPicker = new System.Windows.Forms.DateTimePicker();
            this.cenaTextBox = new System.Windows.Forms.TextBox();
            this.clenstviCheckBox = new System.Windows.Forms.CheckBox();
            this.CasPicker = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.zpetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.seznamLekciDGW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CasPicker)).BeginInit();
            this.SuspendLayout();
            // 
            // seznamLekciDGW
            // 
            this.seznamLekciDGW.AllowUserToAddRows = false;
            this.seznamLekciDGW.AllowUserToDeleteRows = false;
            this.seznamLekciDGW.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seznamLekciDGW.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4,
            this.Column5,
            this.id_treninku});
            this.seznamLekciDGW.Location = new System.Drawing.Point(12, 282);
            this.seznamLekciDGW.Name = "seznamLekciDGW";
            this.seznamLekciDGW.ReadOnly = true;
            this.seznamLekciDGW.Size = new System.Drawing.Size(360, 140);
            this.seznamLekciDGW.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Místnost";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Datum konání";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Cena";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // id_treninku
            // 
            this.id_treninku.HeaderText = "id";
            this.id_treninku.Name = "id_treninku";
            this.id_treninku.ReadOnly = true;
            this.id_treninku.Visible = false;
            // 
            // PridejLekciButton
            // 
            this.PridejLekciButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PridejLekciButton.Location = new System.Drawing.Point(17, 230);
            this.PridejLekciButton.Name = "PridejLekciButton";
            this.PridejLekciButton.Size = new System.Drawing.Size(135, 46);
            this.PridejLekciButton.TabIndex = 1;
            this.PridejLekciButton.Text = "Přidej lekci";
            this.PridejLekciButton.UseVisualStyleBackColor = true;
            this.PridejLekciButton.Click += new System.EventHandler(this.PridejLekciButton_Click);
            // 
            // UpravLekciButton
            // 
            this.UpravLekciButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.UpravLekciButton.Location = new System.Drawing.Point(378, 324);
            this.UpravLekciButton.Name = "UpravLekciButton";
            this.UpravLekciButton.Size = new System.Drawing.Size(135, 46);
            this.UpravLekciButton.TabIndex = 2;
            this.UpravLekciButton.Text = "Uprav lekci";
            this.UpravLekciButton.UseVisualStyleBackColor = true;
            this.UpravLekciButton.Click += new System.EventHandler(this.UpravLekciButton_Click);
            // 
            // DetailButton
            // 
            this.DetailButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.DetailButton.Location = new System.Drawing.Point(378, 376);
            this.DetailButton.Name = "DetailButton";
            this.DetailButton.Size = new System.Drawing.Size(135, 46);
            this.DetailButton.TabIndex = 3;
            this.DetailButton.Text = "Detail";
            this.DetailButton.UseVisualStyleBackColor = true;
            this.DetailButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Místnost";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(347, 205);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 25);
            this.label2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(12, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cena";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 25);
            this.label4.TabIndex = 7;
            this.label4.Text = "Datum konání";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(111, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 25);
            this.label5.TabIndex = 8;
            this.label5.Text = "Trénink";
            // 
            // mistnostiComboBox
            // 
            this.mistnostiComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mistnostiComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.mistnostiComboBox.FormattingEnabled = true;
            this.mistnostiComboBox.Location = new System.Drawing.Point(17, 42);
            this.mistnostiComboBox.Name = "mistnostiComboBox";
            this.mistnostiComboBox.Size = new System.Drawing.Size(93, 33);
            this.mistnostiComboBox.TabIndex = 9;
            // 
            // druhTreninkuComboBox
            // 
            this.druhTreninkuComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.druhTreninkuComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.druhTreninkuComboBox.FormattingEnabled = true;
            this.druhTreninkuComboBox.Location = new System.Drawing.Point(116, 42);
            this.druhTreninkuComboBox.Name = "druhTreninkuComboBox";
            this.druhTreninkuComboBox.Size = new System.Drawing.Size(125, 33);
            this.druhTreninkuComboBox.TabIndex = 10;
            // 
            // datumPicker
            // 
            this.datumPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.datumPicker.Location = new System.Drawing.Point(17, 118);
            this.datumPicker.Name = "datumPicker";
            this.datumPicker.Size = new System.Drawing.Size(224, 31);
            this.datumPicker.TabIndex = 11;
            // 
            // cenaTextBox
            // 
            this.cenaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cenaTextBox.Location = new System.Drawing.Point(17, 193);
            this.cenaTextBox.Name = "cenaTextBox";
            this.cenaTextBox.Size = new System.Drawing.Size(100, 31);
            this.cenaTextBox.TabIndex = 12;
            // 
            // clenstviCheckBox
            // 
            this.clenstviCheckBox.AutoSize = true;
            this.clenstviCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.clenstviCheckBox.Location = new System.Drawing.Point(133, 193);
            this.clenstviCheckBox.Name = "clenstviCheckBox";
            this.clenstviCheckBox.Size = new System.Drawing.Size(108, 29);
            this.clenstviCheckBox.TabIndex = 13;
            this.clenstviCheckBox.Text = "Člentsví";
            this.clenstviCheckBox.UseVisualStyleBackColor = true;
            // 
            // CasPicker
            // 
            this.CasPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CasPicker.Location = new System.Drawing.Point(247, 118);
            this.CasPicker.Name = "CasPicker";
            this.CasPicker.Size = new System.Drawing.Size(47, 29);
            this.CasPicker.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(242, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Čas";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(296, 119);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 25);
            this.label7.TabIndex = 16;
            this.label7.Text = ":00";
            // 
            // zpetButton
            // 
            this.zpetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zpetButton.Location = new System.Drawing.Point(374, 12);
            this.zpetButton.Name = "zpetButton";
            this.zpetButton.Size = new System.Drawing.Size(135, 46);
            this.zpetButton.TabIndex = 17;
            this.zpetButton.Text = "Zpět";
            this.zpetButton.UseVisualStyleBackColor = true;
            this.zpetButton.Click += new System.EventHandler(this.ZpetClick);
            // 
            // seznamLekci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 434);
            this.Controls.Add(this.zpetButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CasPicker);
            this.Controls.Add(this.clenstviCheckBox);
            this.Controls.Add(this.cenaTextBox);
            this.Controls.Add(this.datumPicker);
            this.Controls.Add(this.druhTreninkuComboBox);
            this.Controls.Add(this.mistnostiComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DetailButton);
            this.Controls.Add(this.UpravLekciButton);
            this.Controls.Add(this.PridejLekciButton);
            this.Controls.Add(this.seznamLekciDGW);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "seznamLekci";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seznam lekcí";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SeznamLekci_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.VisibleChanged += new System.EventHandler(this.SeznamLekci_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.seznamLekciDGW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CasPicker)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView seznamLekciDGW;
        private System.Windows.Forms.Button PridejLekciButton;
        private System.Windows.Forms.Button UpravLekciButton;
        private System.Windows.Forms.Button DetailButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox mistnostiComboBox;
        private System.Windows.Forms.ComboBox druhTreninkuComboBox;
        private System.Windows.Forms.DateTimePicker datumPicker;
        private System.Windows.Forms.TextBox cenaTextBox;
        private System.Windows.Forms.CheckBox clenstviCheckBox;
        private System.Windows.Forms.NumericUpDown CasPicker;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button zpetButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_treninku;
    }
}