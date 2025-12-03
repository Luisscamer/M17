namespace M17
{
    partial class menujogadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menujogadores));
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_jogadores = new System.Windows.Forms.DataGridView();
            this.br_apagar = new System.Windows.Forms.Button();
            this.bt_adicionar = new System.Windows.Forms.Button();
            this.bt_editar = new System.Windows.Forms.Button();
            this.bt_imprimir = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jogadores)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Jogadores:";
            // 
            // dgv_jogadores
            // 
            this.dgv_jogadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_jogadores.Location = new System.Drawing.Point(15, 47);
            this.dgv_jogadores.Name = "dgv_jogadores";
            this.dgv_jogadores.Size = new System.Drawing.Size(552, 376);
            this.dgv_jogadores.TabIndex = 1;
            // 
            // br_apagar
            // 
            this.br_apagar.Location = new System.Drawing.Point(585, 244);
            this.br_apagar.Name = "br_apagar";
            this.br_apagar.Size = new System.Drawing.Size(192, 78);
            this.br_apagar.TabIndex = 4;
            this.br_apagar.Text = "Apagar";
            this.br_apagar.UseVisualStyleBackColor = true;
            this.br_apagar.Click += new System.EventHandler(this.br_apagar_Click);
            // 
            // bt_adicionar
            // 
            this.bt_adicionar.Location = new System.Drawing.Point(585, 47);
            this.bt_adicionar.Name = "bt_adicionar";
            this.bt_adicionar.Size = new System.Drawing.Size(192, 78);
            this.bt_adicionar.TabIndex = 6;
            this.bt_adicionar.Text = "Novo";
            this.bt_adicionar.UseVisualStyleBackColor = true;
            this.bt_adicionar.Click += new System.EventHandler(this.bt_adicionar_Click);
            // 
            // bt_editar
            // 
            this.bt_editar.Location = new System.Drawing.Point(585, 143);
            this.bt_editar.Name = "bt_editar";
            this.bt_editar.Size = new System.Drawing.Size(192, 78);
            this.bt_editar.TabIndex = 7;
            this.bt_editar.Text = "Editar";
            this.bt_editar.UseVisualStyleBackColor = true;
            this.bt_editar.Click += new System.EventHandler(this.bt_editar_Click);
            // 
            // bt_imprimir
            // 
            this.bt_imprimir.Location = new System.Drawing.Point(585, 345);
            this.bt_imprimir.Name = "bt_imprimir";
            this.bt_imprimir.Size = new System.Drawing.Size(192, 78);
            this.bt_imprimir.TabIndex = 8;
            this.bt_imprimir.Text = "Imprimir";
            this.bt_imprimir.UseVisualStyleBackColor = true;
            this.bt_imprimir.Click += new System.EventHandler(this.bt_imprimir_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // menujogadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bt_imprimir);
            this.Controls.Add(this.bt_editar);
            this.Controls.Add(this.bt_adicionar);
            this.Controls.Add(this.br_apagar);
            this.Controls.Add(this.dgv_jogadores);
            this.Controls.Add(this.label1);
            this.Name = "menujogadores";
            this.Text = "menujogadores";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_jogadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgv_jogadores;
        private System.Windows.Forms.Button br_apagar;
        private System.Windows.Forms.Button bt_adicionar;
        private System.Windows.Forms.Button bt_editar;
        private System.Windows.Forms.Button bt_imprimir;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}