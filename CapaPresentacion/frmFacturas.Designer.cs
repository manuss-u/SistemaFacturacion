namespace PantallasSistemaFacturacion
{
    partial class frmFacturas
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
            btnSalir = new Button();
            btnGuardar = new Button();
            pnlFormulario = new Panel();
            gbFactura = new GroupBox();
            dgvDetalleFactura = new DataGridView();
            pnlDatosCliente = new Panel();
            txtEmpleado = new TextBox();
            panel2 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            panel1 = new Panel();
            panel3 = new Panel();
            dtpFechaRegistro = new DateTimePicker();
            cmbEstadoFactura = new ComboBox();
            label8 = new Label();
            label7 = new Label();
            txtTotal = new TextBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label5 = new Label();
            txtIva = new TextBox();
            label6 = new Label();
            txtDescuento = new TextBox();
            txtFactura = new TextBox();
            txtCliente = new TextBox();
            lblTitulo = new Label();
            pnlFormulario.SuspendLayout();
            gbFactura.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleFactura).BeginInit();
            pnlDatosCliente.SuspendLayout();
            SuspendLayout();
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.SteelBlue;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.Location = new Point(747, 398);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(123, 39);
            btnSalir.TabIndex = 22;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.SteelBlue;
            btnGuardar.BackgroundImageLayout = ImageLayout.None;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGuardar.ForeColor = SystemColors.ButtonFace;
            btnGuardar.Location = new Point(747, 152);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(123, 39);
            btnGuardar.TabIndex = 21;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // pnlFormulario
            // 
            pnlFormulario.BackColor = Color.GhostWhite;
            pnlFormulario.Controls.Add(btnSalir);
            pnlFormulario.Controls.Add(gbFactura);
            pnlFormulario.Controls.Add(pnlDatosCliente);
            pnlFormulario.Controls.Add(btnGuardar);
            pnlFormulario.Controls.Add(lblTitulo);
            pnlFormulario.Location = new Point(70, 35);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(896, 528);
            pnlFormulario.TabIndex = 20;
            // 
            // gbFactura
            // 
            gbFactura.Controls.Add(dgvDetalleFactura);
            gbFactura.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbFactura.Location = new Point(28, 323);
            gbFactura.Name = "gbFactura";
            gbFactura.Size = new Size(684, 202);
            gbFactura.TabIndex = 22;
            gbFactura.TabStop = false;
            gbFactura.Text = "Detalle Factura";
            // 
            // dgvDetalleFactura
            // 
            dgvDetalleFactura.BackgroundColor = Color.White;
            dgvDetalleFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleFactura.Location = new Point(18, 28);
            dgvDetalleFactura.Name = "dgvDetalleFactura";
            dgvDetalleFactura.Size = new Size(646, 168);
            dgvDetalleFactura.TabIndex = 0;
            // 
            // pnlDatosCliente
            // 
            pnlDatosCliente.BorderStyle = BorderStyle.FixedSingle;
            pnlDatosCliente.Controls.Add(txtEmpleado);
            pnlDatosCliente.Controls.Add(panel2);
            pnlDatosCliente.Controls.Add(panel4);
            pnlDatosCliente.Controls.Add(panel5);
            pnlDatosCliente.Controls.Add(panel6);
            pnlDatosCliente.Controls.Add(panel1);
            pnlDatosCliente.Controls.Add(panel3);
            pnlDatosCliente.Controls.Add(dtpFechaRegistro);
            pnlDatosCliente.Controls.Add(cmbEstadoFactura);
            pnlDatosCliente.Controls.Add(label8);
            pnlDatosCliente.Controls.Add(label7);
            pnlDatosCliente.Controls.Add(txtTotal);
            pnlDatosCliente.Controls.Add(label1);
            pnlDatosCliente.Controls.Add(label3);
            pnlDatosCliente.Controls.Add(label4);
            pnlDatosCliente.Controls.Add(label2);
            pnlDatosCliente.Controls.Add(label5);
            pnlDatosCliente.Controls.Add(txtIva);
            pnlDatosCliente.Controls.Add(label6);
            pnlDatosCliente.Controls.Add(txtDescuento);
            pnlDatosCliente.Controls.Add(txtFactura);
            pnlDatosCliente.Controls.Add(txtCliente);
            pnlDatosCliente.Location = new Point(28, 65);
            pnlDatosCliente.Name = "pnlDatosCliente";
            pnlDatosCliente.Size = new Size(684, 240);
            pnlDatosCliente.TabIndex = 17;
            pnlDatosCliente.Paint += panel1_Paint;
            // 
            // txtEmpleado
            // 
            txtEmpleado.BorderStyle = BorderStyle.None;
            txtEmpleado.Font = new Font("Segoe UI", 12F);
            txtEmpleado.Location = new Point(106, 97);
            txtEmpleado.Name = "txtEmpleado";
            txtEmpleado.Size = new Size(246, 22);
            txtEmpleado.TabIndex = 28;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.BackgroundImageLayout = ImageLayout.None;
            panel2.ForeColor = Color.DimGray;
            panel2.Location = new Point(17, 192);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 2);
            panel2.TabIndex = 27;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gray;
            panel4.BackgroundImageLayout = ImageLayout.None;
            panel4.ForeColor = Color.DimGray;
            panel4.Location = new Point(17, 159);
            panel4.Name = "panel4";
            panel4.Size = new Size(350, 2);
            panel4.TabIndex = 27;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Gray;
            panel5.BackgroundImageLayout = ImageLayout.None;
            panel5.ForeColor = Color.DimGray;
            panel5.Location = new Point(17, 121);
            panel5.Name = "panel5";
            panel5.Size = new Size(350, 2);
            panel5.TabIndex = 27;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Gray;
            panel6.BackgroundImageLayout = ImageLayout.None;
            panel6.ForeColor = Color.DimGray;
            panel6.Location = new Point(17, 86);
            panel6.Name = "panel6";
            panel6.Size = new Size(350, 2);
            panel6.TabIndex = 27;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.ForeColor = Color.DimGray;
            panel1.Location = new Point(17, 227);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 2);
            panel1.TabIndex = 27;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gray;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.ForeColor = Color.DimGray;
            panel3.Location = new Point(17, 43);
            panel3.Name = "panel3";
            panel3.Size = new Size(350, 2);
            panel3.TabIndex = 26;
            // 
            // dtpFechaRegistro
            // 
            dtpFechaRegistro.Format = DateTimePickerFormat.Short;
            dtpFechaRegistro.Location = new Point(447, 40);
            dtpFechaRegistro.Name = "dtpFechaRegistro";
            dtpFechaRegistro.Size = new Size(137, 23);
            dtpFechaRegistro.TabIndex = 16;
            dtpFechaRegistro.Value = new DateTime(2026, 2, 25, 21, 45, 33, 0);
            // 
            // cmbEstadoFactura
            // 
            cmbEstadoFactura.FormattingEnabled = true;
            cmbEstadoFactura.Location = new Point(447, 119);
            cmbEstadoFactura.Name = "cmbEstadoFactura";
            cmbEstadoFactura.Size = new Size(137, 23);
            cmbEstadoFactura.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.ForeColor = Color.DimGray;
            label8.Location = new Point(447, 93);
            label8.Name = "label8";
            label8.Size = new Size(110, 21);
            label8.TabIndex = 14;
            label8.Text = "Estado Factura";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.ForeColor = Color.DimGray;
            label7.Location = new Point(447, 16);
            label7.Name = "label7";
            label7.Size = new Size(112, 21);
            label7.TabIndex = 13;
            label7.Text = "Fecha Registro";
            label7.Click += label7_Click;
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = BorderStyle.None;
            txtTotal.Font = new Font("Segoe UI", 12F);
            txtTotal.Location = new Point(119, 202);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(229, 22);
            txtTotal.TabIndex = 12;
            txtTotal.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(17, 203);
            label1.Name = "label1";
            label1.Size = new Size(96, 21);
            label1.TabIndex = 11;
            label1.Text = "Total Factura";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(17, 19);
            label3.Name = "label3";
            label3.Size = new Size(91, 21);
            label3.TabIndex = 2;
            label3.Text = "Nro Factura";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(17, 62);
            label4.Name = "label4";
            label4.Size = new Size(58, 21);
            label4.TabIndex = 3;
            label4.Text = "Cliente";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(17, 98);
            label2.Name = "label2";
            label2.Size = new Size(79, 21);
            label2.TabIndex = 1;
            label2.Text = "Empleado";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.ForeColor = Color.DimGray;
            label5.Location = new Point(17, 135);
            label5.Name = "label5";
            label5.Size = new Size(83, 21);
            label5.TabIndex = 4;
            label5.Text = "Descuento";
            // 
            // txtIva
            // 
            txtIva.BorderStyle = BorderStyle.None;
            txtIva.Font = new Font("Segoe UI", 12F);
            txtIva.Location = new Point(92, 168);
            txtIva.Name = "txtIva";
            txtIva.Size = new Size(256, 22);
            txtIva.TabIndex = 10;
            txtIva.TextChanged += txtStock_TextChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(17, 169);
            label6.Name = "label6";
            label6.Size = new Size(69, 21);
            label6.TabIndex = 5;
            label6.Text = "Total IVA";
            // 
            // txtDescuento
            // 
            txtDescuento.BorderStyle = BorderStyle.None;
            txtDescuento.Font = new Font("Segoe UI", 12F);
            txtDescuento.Location = new Point(106, 134);
            txtDescuento.Name = "txtDescuento";
            txtDescuento.Size = new Size(242, 22);
            txtDescuento.TabIndex = 9;
            // 
            // txtFactura
            // 
            txtFactura.BorderStyle = BorderStyle.None;
            txtFactura.Font = new Font("Segoe UI", 12F);
            txtFactura.Location = new Point(114, 18);
            txtFactura.Name = "txtFactura";
            txtFactura.Size = new Size(234, 22);
            txtFactura.TabIndex = 7;
            // 
            // txtCliente
            // 
            txtCliente.BorderStyle = BorderStyle.None;
            txtCliente.Font = new Font("Segoe UI", 12F);
            txtCliente.Location = new Point(92, 61);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(267, 22);
            txtCliente.TabIndex = 8;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(896, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Administración Facturas";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Click += label1_Click;
            // 
            // frmFacturas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 587);
            Controls.Add(pnlFormulario);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmFacturas";
            Text = "frmFacturas";
            pnlFormulario.ResumeLayout(false);
            gbFactura.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDetalleFactura).EndInit();
            pnlDatosCliente.ResumeLayout(false);
            pnlDatosCliente.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnSalir;
        private Button btnGuardar;
        private Panel pnlFormulario;
        private TextBox txtIva;
        private TextBox txtDescuento;
        private TextBox txtCliente;
        private TextBox txtFactura;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label lblTitulo;
        private Panel pnlDatosCliente;
        private GroupBox gbFactura;
        private DataGridView dgvDetalleFactura;
        private Label label8;
        private Label label7;
        private TextBox txtTotal;
        private Label label1;
        private ComboBox cmbEstadoFactura;
        private DateTimePicker dtpFechaRegistro;
        private Panel panel2;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private Panel panel1;
        private Panel panel3;
        private TextBox txtEmpleado;
    }
}