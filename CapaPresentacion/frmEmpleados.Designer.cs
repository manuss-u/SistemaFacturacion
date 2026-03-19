namespace PantallasSistemaFacturacion
{
    partial class frmEmpleados
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
            pnlFormulario = new Panel();
            btnSalir = new Button();
            pnlDatosCliente = new Panel();
            txtDetalles = new TextBox();
            dtpFechaRetiro = new DateTimePicker();
            txtDocumento = new TextBox();
            label9 = new Label();
            dtpFechaIngreso = new DateTimePicker();
            label8 = new Label();
            label7 = new Label();
            cmbRol = new ComboBox();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label2 = new Label();
            label5 = new Label();
            txtEmail = new TextBox();
            label6 = new Label();
            txtTelefono = new TextBox();
            txtNombreEmpleado = new TextBox();
            txtDireccion = new TextBox();
            txtGuardar = new Button();
            lblTitulo = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            panel2 = new Panel();
            panel4 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            pnlFormulario.SuspendLayout();
            pnlDatosCliente.SuspendLayout();
            SuspendLayout();
            // 
            // pnlFormulario
            // 
            pnlFormulario.BackColor = Color.GhostWhite;
            pnlFormulario.Controls.Add(btnSalir);
            pnlFormulario.Controls.Add(pnlDatosCliente);
            pnlFormulario.Controls.Add(txtGuardar);
            pnlFormulario.Controls.Add(lblTitulo);
            pnlFormulario.Location = new Point(68, 29);
            pnlFormulario.Name = "pnlFormulario";
            pnlFormulario.Size = new Size(896, 528);
            pnlFormulario.TabIndex = 21;
            // 
            // btnSalir
            // 
            btnSalir.BackColor = Color.SteelBlue;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.Location = new Point(536, 402);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(123, 39);
            btnSalir.TabIndex = 22;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = false;
            btnSalir.Click += btnSalir_Click;
            // 
            // pnlDatosCliente
            // 
            pnlDatosCliente.BorderStyle = BorderStyle.FixedSingle;
            pnlDatosCliente.Controls.Add(panel6);
            pnlDatosCliente.Controls.Add(panel2);
            pnlDatosCliente.Controls.Add(panel4);
            pnlDatosCliente.Controls.Add(panel5);
            pnlDatosCliente.Controls.Add(panel1);
            pnlDatosCliente.Controls.Add(panel3);
            pnlDatosCliente.Controls.Add(txtDetalles);
            pnlDatosCliente.Controls.Add(dtpFechaRetiro);
            pnlDatosCliente.Controls.Add(txtDocumento);
            pnlDatosCliente.Controls.Add(label9);
            pnlDatosCliente.Controls.Add(dtpFechaIngreso);
            pnlDatosCliente.Controls.Add(label8);
            pnlDatosCliente.Controls.Add(label7);
            pnlDatosCliente.Controls.Add(cmbRol);
            pnlDatosCliente.Controls.Add(label1);
            pnlDatosCliente.Controls.Add(label3);
            pnlDatosCliente.Controls.Add(label4);
            pnlDatosCliente.Controls.Add(label2);
            pnlDatosCliente.Controls.Add(label5);
            pnlDatosCliente.Controls.Add(txtEmail);
            pnlDatosCliente.Controls.Add(label6);
            pnlDatosCliente.Controls.Add(txtTelefono);
            pnlDatosCliente.Controls.Add(txtNombreEmpleado);
            pnlDatosCliente.Controls.Add(txtDireccion);
            pnlDatosCliente.Location = new Point(28, 65);
            pnlDatosCliente.Name = "pnlDatosCliente";
            pnlDatosCliente.Size = new Size(839, 290);
            pnlDatosCliente.TabIndex = 17;
            // 
            // txtDetalles
            // 
            txtDetalles.Font = new Font("Segoe UI", 12F);
            txtDetalles.Location = new Point(449, 179);
            txtDetalles.Multiline = true;
            txtDetalles.Name = "txtDetalles";
            txtDetalles.Size = new Size(293, 100);
            txtDetalles.TabIndex = 18;
            // 
            // dtpFechaRetiro
            // 
            dtpFechaRetiro.Format = DateTimePickerFormat.Short;
            dtpFechaRetiro.Location = new Point(579, 118);
            dtpFechaRetiro.Name = "dtpFechaRetiro";
            dtpFechaRetiro.ShowCheckBox = true;
            dtpFechaRetiro.Checked = false;
            dtpFechaRetiro.Size = new Size(163, 23);
            dtpFechaRetiro.TabIndex = 18;
            dtpFechaRetiro.Value = new DateTime(2026, 2, 25, 21, 45, 33, 0);
            // 
            // txtDocumento
            // 
            txtDocumento.BorderStyle = BorderStyle.None;
            txtDocumento.Font = new Font("Segoe UI", 12F);
            txtDocumento.Location = new Point(125, 87);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(251, 22);
            txtDocumento.TabIndex = 17;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label9.Location = new Point(449, 155);
            label9.Name = "label9";
            label9.Size = new Size(181, 21);
            label9.TabIndex = 17;
            label9.Text = "DETALLES ADICIONALES";
            // 
            // dtpFechaIngreso
            // 
            dtpFechaIngreso.Format = DateTimePickerFormat.Short;
            dtpFechaIngreso.Location = new Point(579, 84);
            dtpFechaIngreso.Name = "dtpFechaIngreso";
            dtpFechaIngreso.Size = new Size(163, 23);
            dtpFechaIngreso.TabIndex = 16;
            dtpFechaIngreso.Value = new DateTime(2026, 2, 25, 21, 45, 33, 0);
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.ForeColor = Color.DimGray;
            label8.Location = new Point(488, 118);
            label8.Name = "label8";
            label8.Size = new Size(67, 21);
            label8.TabIndex = 14;
            label8.Text = "F. Retiro";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F);
            label7.ForeColor = Color.DimGray;
            label7.Location = new Point(478, 77);
            label7.Name = "label7";
            label7.Size = new Size(77, 21);
            label7.TabIndex = 13;
            label7.Text = "F. Ingreso";
            // 
            // cmbRol
            //
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRol.Font = new Font("Segoe UI", 12F);
            cmbRol.Location = new Point(561, 38);
            cmbRol.Name = "cmbRol";
            cmbRol.Size = new Size(235, 29);
            cmbRol.TabIndex = 12;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.DimGray;
            label1.Location = new Point(449, 43);
            label1.Name = "label1";
            label1.Size = new Size(106, 21);
            label1.TabIndex = 11;
            label1.Text = "Rol Empleado";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.DimGray;
            label3.Location = new Point(28, 46);
            label3.Name = "label3";
            label3.Size = new Size(141, 21);
            label3.TabIndex = 2;
            label3.Text = "Nombre Empleado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.DimGray;
            label4.Location = new Point(28, 87);
            label4.Name = "label4";
            label4.Size = new Size(91, 21);
            label4.TabIndex = 3;
            label4.Text = "Documento";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.DimGray;
            label2.Location = new Point(28, 132);
            label2.Name = "label2";
            label2.Size = new Size(75, 21);
            label2.TabIndex = 1;
            label2.Text = "Dirección";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F);
            label5.ForeColor = Color.DimGray;
            label5.Location = new Point(28, 174);
            label5.Name = "label5";
            label5.Size = new Size(68, 21);
            label5.TabIndex = 4;
            label5.Text = "Teléfono";
            // 
            // txtEmail
            // 
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 12F);
            txtEmail.Location = new Point(92, 219);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(284, 22);
            txtEmail.TabIndex = 10;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F);
            label6.ForeColor = Color.DimGray;
            label6.Location = new Point(28, 219);
            label6.Name = "label6";
            label6.Size = new Size(48, 21);
            label6.TabIndex = 5;
            label6.Text = "Email";
            // 
            // txtTelefono
            // 
            txtTelefono.BorderStyle = BorderStyle.None;
            txtTelefono.Font = new Font("Segoe UI", 12F);
            txtTelefono.Location = new Point(109, 174);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(267, 22);
            txtTelefono.TabIndex = 9;
            // 
            // txtNombreEmpleado
            // 
            txtNombreEmpleado.BorderStyle = BorderStyle.None;
            txtNombreEmpleado.Font = new Font("Segoe UI", 12F);
            txtNombreEmpleado.Location = new Point(175, 45);
            txtNombreEmpleado.Name = "txtNombreEmpleado";
            txtNombreEmpleado.Size = new Size(201, 22);
            txtNombreEmpleado.TabIndex = 7;
            // 
            // txtDireccion
            // 
            txtDireccion.BorderStyle = BorderStyle.None;
            txtDireccion.Font = new Font("Segoe UI", 12F);
            txtDireccion.Location = new Point(109, 132);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(267, 22);
            txtDireccion.TabIndex = 8;
            // 
            // txtGuardar
            // 
            txtGuardar.BackColor = Color.SteelBlue;
            txtGuardar.BackgroundImageLayout = ImageLayout.None;
            txtGuardar.FlatStyle = FlatStyle.Flat;
            txtGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            txtGuardar.ForeColor = SystemColors.ButtonFace;
            txtGuardar.Location = new Point(246, 402);
            txtGuardar.Margin = new Padding(10);
            txtGuardar.Name = "txtGuardar";
            txtGuardar.Size = new Size(123, 39);
            txtGuardar.TabIndex = 21;
            txtGuardar.Text = "Actualizar";
            txtGuardar.UseVisualStyleBackColor = false;
            txtGuardar.Click += txtGuardar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(896, 50);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Administración De Empleados";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            panel3.BackColor = Color.Gray;
            panel3.BackgroundImageLayout = ImageLayout.None;
            panel3.ForeColor = Color.DimGray;
            panel3.Location = new Point(29, 70);
            panel3.Name = "panel3";
            panel3.Size = new Size(350, 2);
            panel3.TabIndex = 25;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.BackgroundImageLayout = ImageLayout.None;
            panel1.ForeColor = Color.DimGray;
            panel1.Location = new Point(28, 246);
            panel1.Name = "panel1";
            panel1.Size = new Size(350, 2);
            panel1.TabIndex = 26;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.BackgroundImageLayout = ImageLayout.None;
            panel2.ForeColor = Color.DimGray;
            panel2.Location = new Point(29, 198);
            panel2.Name = "panel2";
            panel2.Size = new Size(350, 2);
            panel2.TabIndex = 26;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Gray;
            panel4.BackgroundImageLayout = ImageLayout.None;
            panel4.ForeColor = Color.DimGray;
            panel4.Location = new Point(29, 156);
            panel4.Name = "panel4";
            panel4.Size = new Size(350, 2);
            panel4.TabIndex = 26;
            // 
            // panel5
            // 
            panel5.BackColor = Color.Gray;
            panel5.BackgroundImageLayout = ImageLayout.None;
            panel5.ForeColor = Color.DimGray;
            panel5.Location = new Point(29, 111);
            panel5.Name = "panel5";
            panel5.Size = new Size(350, 2);
            panel5.TabIndex = 26;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Gray;
            panel6.BackgroundImageLayout = ImageLayout.None;
            panel6.ForeColor = Color.DimGray;
            panel6.Location = new Point(449, 67);
            panel6.Name = "panel6";
            panel6.Size = new Size(350, 2);
            panel6.TabIndex = 27;
            // 
            // frmEmpleados
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 587);
            Controls.Add(pnlFormulario);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmEmpleados";
            Text = "Empleados";
            pnlFormulario.ResumeLayout(false);
            pnlDatosCliente.ResumeLayout(false);
            pnlDatosCliente.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlFormulario;
        private Button btnSalir;
        private Panel pnlDatosCliente;
        private DateTimePicker dtpFechaIngreso;
        private Label label8;
        private Label label7;
        private ComboBox cmbRol;
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label2;
        private Label label5;
        private TextBox txtEmail;
        private Label label6;
        private TextBox txtTelefono;
        private TextBox txtNombreEmpleado;
        private TextBox txtDireccion;
        private Button txtGuardar;
        private Label lblTitulo;
        private TextBox txtDetalles;
        private Label label9;
        private TextBox txtDocumento;
        private DateTimePicker dtpFechaRetiro;
        private Panel panel2;
        private Panel panel4;
        private Panel panel5;
        private Panel panel1;
        private Panel panel3;
        private Panel panel6;
    }
}