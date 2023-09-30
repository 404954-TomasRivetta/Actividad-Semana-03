namespace problema1_1.Presentaciones
{
    partial class FrmConsultarCarreras
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
            this.dgvCarrera = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCarrera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColNombreCarrera = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTitulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColAcciones = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnSalir = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrera)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCarrera
            // 
            this.dgvCarrera.AllowUserToAddRows = false;
            this.dgvCarrera.AllowUserToDeleteRows = false;
            this.dgvCarrera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCarrera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCarrera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.ColCarrera,
            this.ColNombreCarrera,
            this.ColTitulo,
            this.ColAcciones});
            this.dgvCarrera.Location = new System.Drawing.Point(12, 144);
            this.dgvCarrera.Name = "dgvCarrera";
            this.dgvCarrera.ReadOnly = true;
            this.dgvCarrera.Size = new System.Drawing.Size(573, 159);
            this.dgvCarrera.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Column1";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            // 
            // ColCarrera
            // 
            this.ColCarrera.HeaderText = "Carrera#";
            this.ColCarrera.Name = "ColCarrera";
            this.ColCarrera.ReadOnly = true;
            // 
            // ColNombreCarrera
            // 
            this.ColNombreCarrera.HeaderText = "Nombre Carrera";
            this.ColNombreCarrera.Name = "ColNombreCarrera";
            this.ColNombreCarrera.ReadOnly = true;
            // 
            // ColTitulo
            // 
            this.ColTitulo.HeaderText = "Titulo";
            this.ColTitulo.Name = "ColTitulo";
            this.ColTitulo.ReadOnly = true;
            // 
            // ColAcciones
            // 
            this.ColAcciones.HeaderText = "Acciones";
            this.ColAcciones.Name = "ColAcciones";
            this.ColAcciones.ReadOnly = true;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(493, 309);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(92, 31);
            this.btnSalir.TabIndex = 1;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnConsultar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 126);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(475, 89);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(92, 31);
            this.btnConsultar.TabIndex = 2;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            // 
            // FrmConsultarCarreras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 352);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvCarrera);
            this.Name = "FrmConsultarCarreras";
            this.Text = "FrmConsultarCarreras";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCarrera)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCarrera;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCarrera;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColNombreCarrera;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTitulo;
        private System.Windows.Forms.DataGridViewButtonColumn ColAcciones;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnConsultar;
    }
}