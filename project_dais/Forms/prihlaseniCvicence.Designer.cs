namespace project_dais.Forms
{
    partial class prihlaseniCvicence
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
            this.label2 = new System.Windows.Forms.Label();
            this.prihlasitCvicenceButton = new System.Windows.Forms.Button();
            this.zpetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.seznamUcastniku)).BeginInit();
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
            this.seznamUcastniku.Location = new System.Drawing.Point(17, 37);
            this.seznamUcastniku.Name = "seznamUcastniku";
            this.seznamUcastniku.ReadOnly = true;
            this.seznamUcastniku.Size = new System.Drawing.Size(554, 124);
            this.seznamUcastniku.TabIndex = 1;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 25);
            this.label2.TabIndex = 22;
            this.label2.Text = "Seznam cvičenců";
            this.label2.Visible = false;
            // 
            // prihlasitCvicenceButton
            // 
            this.prihlasitCvicenceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.prihlasitCvicenceButton.Location = new System.Drawing.Point(577, 37);
            this.prihlasitCvicenceButton.Name = "prihlasitCvicenceButton";
            this.prihlasitCvicenceButton.Size = new System.Drawing.Size(106, 59);
            this.prihlasitCvicenceButton.TabIndex = 23;
            this.prihlasitCvicenceButton.Text = "Přihlásit cvičence";
            this.prihlasitCvicenceButton.UseVisualStyleBackColor = true;
            this.prihlasitCvicenceButton.Click += new System.EventHandler(this.PrihlasitCvicenceButton_Click);
            // 
            // zpetButton
            // 
            this.zpetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.zpetButton.Location = new System.Drawing.Point(577, 102);
            this.zpetButton.Name = "zpetButton";
            this.zpetButton.Size = new System.Drawing.Size(106, 59);
            this.zpetButton.TabIndex = 24;
            this.zpetButton.Text = "Zpět";
            this.zpetButton.UseVisualStyleBackColor = true;
            this.zpetButton.Click += new System.EventHandler(this.ZpetButton_Click);
            // 
            // prihlaseniCvicence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 171);
            this.Controls.Add(this.zpetButton);
            this.Controls.Add(this.prihlasitCvicenceButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.seznamUcastniku);
            this.Name = "prihlaseniCvicence";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Přihlášení cvičence";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PrihlaseniCvicence_FormClosing);
            this.Load += new System.EventHandler(this.PrihlaseniCvicence_Load);
            ((System.ComponentModel.ISupportInitialize)(this.seznamUcastniku)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView seznamUcastniku;
        private System.Windows.Forms.DataGridViewTextBoxColumn id_cvicence;
        private System.Windows.Forms.DataGridViewTextBoxColumn s;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button prihlasitCvicenceButton;
        private System.Windows.Forms.Button zpetButton;
    }
}