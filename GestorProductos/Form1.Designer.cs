﻿using System.Windows.Forms;

namespace GestorProductos;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }


    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        lblNombre = new Label();
        txtNombre = new TextBox();
        lblPrecio = new Label();
        nudPrecio = new NumericUpDown();
        lblStock = new Label();
        nudStock = new NumericUpDown();
        lblRubro = new Label();
        txtRubro = new ComboBox();
        btnAgregar = new Button();
        btnEditar = new Button();
        btnCancelar = new Button();
        btnEliminar = new Button();
        lblIdEliminar = new Label();
        txtIdEliminar = new TextBox();
        dgvProductos = new DataGridView();
        lblContador = new Label();
        lblBuscar = new Label();
        txtBuscar = new TextBox();
        btnBuscar = new Button();
        lblStockLimite = new Label();
        nudStockLimite = new NumericUpDown();
        btnEliminarStock = new Button();
        btnExportar = new Button();
        imagen = new PictureBox();
        nombrePrograma = new Label();
        nombre = new Label();
        label1 = new Label();
        ((System.ComponentModel.ISupportInitialize)nudPrecio).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudStockLimite).BeginInit();
        ((System.ComponentModel.ISupportInitialize)imagen).BeginInit();
        SuspendLayout();
        // 
        // lblNombre
        // 
        lblNombre.AutoSize = true;
        lblNombre.Font = new Font("Segoe UI", 10F);
        lblNombre.Location = new Point(25, 25);
        lblNombre.Name = "lblNombre";
        lblNombre.Size = new Size(89, 28);
        lblNombre.TabIndex = 31;
        lblNombre.Text = "Nombre:";
        // 
        // txtNombre
        // 
        txtNombre.Location = new Point(120, 22);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(220, 31);
        txtNombre.TabIndex = 1;
        txtNombre.TextChanged += txtNombre_TextChanged;
        // 
        // lblPrecio
        // 
        lblPrecio.AutoSize = true;
        lblPrecio.Font = new Font("Segoe UI", 10F);
        lblPrecio.Location = new Point(25, 70);
        lblPrecio.Name = "lblPrecio";
        lblPrecio.Size = new Size(70, 28);
        lblPrecio.TabIndex = 30;
        lblPrecio.Text = "Precio:";
        // 
        // nudPrecio
        // 
        nudPrecio.DecimalPlaces = 2;
        nudPrecio.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
        nudPrecio.Location = new Point(120, 67);
        nudPrecio.Maximum = new decimal(new int[] { 100000000, 0, 0, 0 });
        nudPrecio.Name = "nudPrecio";
        nudPrecio.Size = new Size(220, 31);
        nudPrecio.TabIndex = 3;
        nudPrecio.ThousandsSeparator = true;
        // 
        // lblStock
        // 
        lblStock.AutoSize = true;
        lblStock.Font = new Font("Segoe UI", 10F);
        lblStock.Location = new Point(12, 109);
        lblStock.Name = "lblStock";
        lblStock.Size = new Size(64, 28);
        lblStock.TabIndex = 29;
        lblStock.Text = "Stock:";
        // 
        // nudStock
        // 
        nudStock.Location = new Point(120, 110);
        nudStock.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        nudStock.Name = "nudStock";
        nudStock.Size = new Size(220, 31);
        nudStock.TabIndex = 5;
        nudStock.ThousandsSeparator = true;
        // 
        // lblRubro
        // 
        lblRubro.AutoSize = true;
        lblRubro.Font = new Font("Segoe UI", 10F);
        lblRubro.Location = new Point(6, 146);
        lblRubro.Name = "lblRubro";
        lblRubro.Size = new Size(70, 28);
        lblRubro.TabIndex = 28;
        lblRubro.Text = "Rubro:";
        // 
        // txtRubro
        // 
        txtRubro.DropDownStyle = ComboBoxStyle.DropDownList;
        txtRubro.FormattingEnabled = true;
        txtRubro.Location = new Point(120, 147);
        txtRubro.Name = "txtRubro";
        txtRubro.Size = new Size(220, 33);
        txtRubro.TabIndex = 7;
        // 
        // btnAgregar
        // 
        btnAgregar.BackColor = Color.Green;
        btnAgregar.Location = new Point(382, 25);
        btnAgregar.Name = "btnAgregar";
        btnAgregar.Size = new Size(111, 36);
        btnAgregar.TabIndex = 27;
        btnAgregar.Text = "Agregar";
        btnAgregar.UseVisualStyleBackColor = false;
        btnAgregar.Click += btnAgregar_Click;
        // 
        // btnEditar
        // 
        btnEditar.BackColor = Color.Yellow;
        btnEditar.Location = new Point(516, 25);
        btnEditar.Name = "btnEditar";
        btnEditar.Size = new Size(106, 36);
        btnEditar.TabIndex = 26;
        btnEditar.Text = "Editar";
        btnEditar.UseVisualStyleBackColor = false;
        btnEditar.Click += btnEditar_Click;
        // 
        // btnCancelar
        // 
        btnCancelar.Location = new Point(659, 28);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(106, 33);
        btnCancelar.TabIndex = 25;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = true;
        btnCancelar.Visible = false;
        btnCancelar.Click += btnCancelar_Click;
        // 
        // btnEliminar
        // 
        btnEliminar.BackColor = Color.Red;
        btnEliminar.Location = new Point(706, 112);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(111, 38);
        btnEliminar.TabIndex = 24;
        btnEliminar.Text = "Eliminar";
        btnEliminar.UseVisualStyleBackColor = false;
        btnEliminar.Click += btnEliminar_Click;
        // 
        // lblIdEliminar
        // 
        lblIdEliminar.AutoSize = true;
        lblIdEliminar.Font = new Font("Segoe UI", 10F);
        lblIdEliminar.Location = new Point(368, 110);
        lblIdEliminar.Name = "lblIdEliminar";
        lblIdEliminar.Size = new Size(125, 28);
        lblIdEliminar.TabIndex = 23;
        lblIdEliminar.Text = "ID a eliminar:";
        // 
        // txtIdEliminar
        // 
        txtIdEliminar.Location = new Point(493, 112);
        txtIdEliminar.Name = "txtIdEliminar";
        txtIdEliminar.Size = new Size(195, 31);
        txtIdEliminar.TabIndex = 22;
        // 
        // dgvProductos
        // 
        dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProductos.Location = new Point(25, 186);
        dgvProductos.Name = "dgvProductos";
        dgvProductos.RowHeadersWidth = 51;
        dgvProductos.Size = new Size(802, 281);
        dgvProductos.TabIndex = 13;
        // 
        // lblContador
        // 
        lblContador.AutoSize = true;
        lblContador.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        lblContador.Location = new Point(792, 146);
        lblContador.Name = "lblContador";
        lblContador.Size = new Size(125, 28);
        lblContador.TabIndex = 22;
        lblContador.Text = "0 productos";
        lblContador.Click += lblContador_Click;
        // 
        // lblBuscar
        // 
        lblBuscar.AutoSize = true;
        lblBuscar.Font = new Font("Segoe UI", 10F);
        lblBuscar.Location = new Point(470, 498);
        lblBuscar.Name = "lblBuscar";
        lblBuscar.Size = new Size(72, 28);
        lblBuscar.TabIndex = 19;
        lblBuscar.Text = "Buscar:";
        // 
        // txtBuscar
        // 
        txtBuscar.Location = new Point(548, 501);
        txtBuscar.Name = "txtBuscar";
        txtBuscar.Size = new Size(153, 31);
        txtBuscar.TabIndex = 18;
        txtBuscar.TextChanged += txtBuscar_TextChanged;
        // 
        // btnBuscar
        // 
        btnBuscar.Location = new Point(717, 504);
        btnBuscar.Name = "btnBuscar";
        btnBuscar.Size = new Size(110, 38);
        btnBuscar.TabIndex = 1;
        btnBuscar.Text = "Buscar";
        btnBuscar.UseVisualStyleBackColor = true;
        btnBuscar.Click += btnBuscar_Click;
        // 
        // lblStockLimite
        // 
        lblStockLimite.AutoSize = true;
        lblStockLimite.Font = new Font("Segoe UI", 10F);
        lblStockLimite.Location = new Point(25, 494);
        lblStockLimite.Name = "lblStockLimite";
        lblStockLimite.Size = new Size(118, 28);
        lblStockLimite.TabIndex = 21;
        lblStockLimite.Text = "Stock límite:";
        // 
        // nudStockLimite
        // 
        nudStockLimite.Location = new Point(149, 495);
        nudStockLimite.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
        nudStockLimite.Name = "nudStockLimite";
        nudStockLimite.Size = new Size(100, 31);
        nudStockLimite.TabIndex = 15;
        // 
        // btnEliminarStock
        // 
        btnEliminarStock.Location = new Point(255, 494);
        btnEliminarStock.Name = "btnEliminarStock";
        btnEliminarStock.Size = new Size(200, 38);
        btnEliminarStock.TabIndex = 20;
        btnEliminarStock.Text = "Eliminar según Stock";
        btnEliminarStock.UseVisualStyleBackColor = true;
        btnEliminarStock.Click += btnEliminarStock_Click;
        // 
        // btnExportar
        // 
        btnExportar.Location = new Point(817, 574);
        btnExportar.Name = "btnExportar";
        btnExportar.Size = new Size(150, 38);
        btnExportar.TabIndex = 0;
        btnExportar.Text = "Exportar TXT";
        btnExportar.UseVisualStyleBackColor = true;
        btnExportar.Click += btnExportar_Click;
        // 
        // imagen
        // 
        imagen.Anchor = AnchorStyles.Bottom;
        imagen.Image = (Image)resources.GetObject("imagen.Image");
        imagen.Location = new Point(25, 563);
        imagen.Name = "imagen";
        imagen.Size = new Size(423, 149);
        imagen.SizeMode = PictureBoxSizeMode.Zoom;
        imagen.TabIndex = 32;
        imagen.TabStop = false;
        imagen.Click += imagen_Click;
        // 
        // nombrePrograma
        // 
        nombrePrograma.AutoSize = true;
        nombrePrograma.Font = new Font("Segoe UI", 14F);
        nombrePrograma.Location = new Point(490, 570);
        nombrePrograma.Name = "nombrePrograma";
        nombrePrograma.Size = new Size(327, 38);
        nombrePrograma.TabIndex = 33;
        nombrePrograma.Text = "GESTOR DE PRODUCTOS";
        // 
        // nombre
        // 
        nombre.AutoSize = true;
        nombre.Font = new Font("Segoe UI", 11F);
        nombre.Location = new Point(502, 623);
        nombre.Name = "nombre";
        nombre.Size = new Size(209, 30);
        nombre.TabIndex = 34;
        nombre.Text = "JAVIER ANIBAL RIOS";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Font = new Font("Segoe UI", 11F);
        label1.Location = new Point(502, 675);
        label1.Name = "label1";
        label1.Size = new Size(257, 30);
        label1.TabIndex = 35;
        label1.Text = "PROGRAMADOR JUNIOR";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(10F, 25F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.WhiteSmoke;
        ClientSize = new Size(979, 731);
        Controls.Add(label1);
        Controls.Add(nombre);
        Controls.Add(nombrePrograma);
        Controls.Add(imagen);
        Controls.Add(btnExportar);
        Controls.Add(btnBuscar);
        Controls.Add(txtBuscar);
        Controls.Add(lblBuscar);
        Controls.Add(btnEliminarStock);
        Controls.Add(nudStockLimite);
        Controls.Add(lblStockLimite);
        Controls.Add(dgvProductos);
        Controls.Add(lblContador);
        Controls.Add(txtIdEliminar);
        Controls.Add(lblIdEliminar);
        Controls.Add(btnEliminar);
        Controls.Add(btnCancelar);
        Controls.Add(btnEditar);
        Controls.Add(btnAgregar);
        Controls.Add(txtRubro);
        Controls.Add(lblRubro);
        Controls.Add(nudStock);
        Controls.Add(lblStock);
        Controls.Add(nudPrecio);
        Controls.Add(lblPrecio);
        Controls.Add(txtNombre);
        Controls.Add(lblNombre);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Gestor de Productos";
        ((System.ComponentModel.ISupportInitialize)nudPrecio).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudStockLimite).EndInit();
        ((System.ComponentModel.ISupportInitialize)imagen).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }


    #endregion


    private System.Windows.Forms.Label lblNombre;
    private System.Windows.Forms.TextBox txtNombre;

    private System.Windows.Forms.Label lblPrecio;
    private System.Windows.Forms.NumericUpDown nudPrecio;

    private System.Windows.Forms.Label lblStock;
    private System.Windows.Forms.NumericUpDown nudStock;

    private System.Windows.Forms.Label lblRubro;
    private System.Windows.Forms.ComboBox txtRubro;

    private System.Windows.Forms.Button btnAgregar;
    private System.Windows.Forms.Button btnEditar;
    private System.Windows.Forms.Button btnCancelar;
    private System.Windows.Forms.Button btnEliminar;

    private System.Windows.Forms.Label lblIdEliminar;
    private System.Windows.Forms.TextBox txtIdEliminar;

    private System.Windows.Forms.DataGridView dgvProductos;

    private System.Windows.Forms.Label lblContador;

    private System.Windows.Forms.Label lblBuscar;
    private System.Windows.Forms.TextBox txtBuscar;
    private System.Windows.Forms.Button btnBuscar;

    private System.Windows.Forms.Label lblStockLimite;
    private System.Windows.Forms.NumericUpDown nudStockLimite;
    private System.Windows.Forms.Button btnEliminarStock;

    private System.Windows.Forms.Button btnExportar;
    private PictureBox imagen;
    private Label nombrePrograma;
    private Label nombre;
    private Label label1;
}

