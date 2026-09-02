using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GestorProductos;

public partial class Form1 : Form
{
    private readonly ProductoController _controller;

    private bool _modoEdicion = false;

    private Producto? _productoEditando = null;


    // =========================================================
    // CONSTRUCTOR
    // =========================================================

    public Form1(ProductoController controller)
    {
        InitializeComponent();

        _controller = controller;

        ConfigurarFormulario();

        ConfigurarTabla();

        ConfigurarRubros();

        ConfigurarNumericos();

        ActualizarTabla();

        ActualizarBotones();
    }


    // =========================================================
    // CONFIGURAR FORMULARIO
    // =========================================================

    private void ConfigurarFormulario()
    {
        StartPosition =
            FormStartPosition.CenterScreen;

        FormBorderStyle =
            FormBorderStyle.FixedSingle;

        MaximizeBox = false;

        Text = "Gestor de Productos";

        BackColor =
            Color.WhiteSmoke;
    }


    // =========================================================
    // CONFIGURAR NUMERIC UP DOWN
    // =========================================================

    private void ConfigurarNumericos()
    {
        // PRECIO

        nudPrecio.Minimum = 0;

        nudPrecio.Maximum = 100000000;

        nudPrecio.DecimalPlaces = 2;

        nudPrecio.Increment = 0.01M;

        nudPrecio.Value = 0;


        // STOCK

        // IMPORTANTE:
        // El mínimo es 1.
        // Por lo tanto NO se puede crear
        // un producto con stock 0.

        nudStock.Minimum = 1;

        nudStock.Maximum = 1000000;

        nudStock.DecimalPlaces = 0;

        nudStock.Increment = 1;

        nudStock.Value = 1;


        // STOCK LIMITE

        nudStockLimite.Minimum = 0;

        nudStockLimite.Maximum = 1000000;

        nudStockLimite.DecimalPlaces = 0;

        nudStockLimite.Increment = 1;

        nudStockLimite.Value = 1;
    }


    // =========================================================
    // CONFIGURAR TABLA
    // =========================================================

    private void ConfigurarTabla()
    {
        dgvProductos.SelectionMode =
            DataGridViewSelectionMode.FullRowSelect;

        dgvProductos.MultiSelect = false;

        dgvProductos.ReadOnly = true;

        dgvProductos.AllowUserToAddRows = false;

        dgvProductos.AllowUserToDeleteRows = false;

        dgvProductos.AllowUserToResizeRows = false;

        dgvProductos.RowHeadersVisible = false;

        dgvProductos.AutoSizeColumnsMode =
            DataGridViewAutoSizeColumnsMode.Fill;

        dgvProductos.BackgroundColor =
            Color.White;

        dgvProductos.BorderStyle =
            BorderStyle.FixedSingle;

        dgvProductos.EnableHeadersVisualStyles = false;

        dgvProductos.ColumnHeadersDefaultCellStyle.BackColor =
            Color.LightSteelBlue;

        dgvProductos.ColumnHeadersDefaultCellStyle.Font =
            new Font(
                "Segoe UI",
                9F,
                FontStyle.Bold);

        dgvProductos.DefaultCellStyle.Font =
            new Font(
                "Segoe UI",
                9F);

        dgvProductos.DefaultCellStyle.SelectionForeColor =
            Color.Black;
    }


    // =========================================================
    // CONFIGURAR RUBROS
    // =========================================================

    private void ConfigurarRubros()
    {
        txtRubro.Items.Clear();

        txtRubro.Items.Add("Alimentos");

        txtRubro.Items.Add("Bebidas");

        txtRubro.Items.Add("Limpieza");

        txtRubro.Items.Add("Electrónica");

        txtRubro.Items.Add("Indumentaria");

        txtRubro.DropDownStyle =
            ComboBoxStyle.DropDownList;

        txtRubro.SelectedIndex = -1;
    }


    // =========================================================
    // ACTUALIZAR TABLA
    // =========================================================

    private void ActualizarTabla()
    {
        List<Producto> lista =
            _controller.ObtenerTodos();

        dgvProductos.DataSource = null;

        dgvProductos.DataSource = lista;

        ConfigurarColumnas();

        ActualizarContador(lista);

        ColorearFilasSegunStock();
    }


    // =========================================================
    // MOSTRAR RESULTADOS
    // =========================================================

    private void MostrarResultados(
        List<Producto> lista)
    {
        dgvProductos.DataSource = null;

        dgvProductos.DataSource = lista;

        ConfigurarColumnas();

        ActualizarContador(lista);

        ColorearFilasSegunStock();
    }


    // =========================================================
    // CONFIGURAR COLUMNAS
    // =========================================================

    private void ConfigurarColumnas()
    {
        if (dgvProductos.Columns.Count == 0)
        {
            return;
        }


        if (dgvProductos.Columns["Id"] != null)
        {
            dgvProductos.Columns["Id"].HeaderText =
                "ID";
        }


        if (dgvProductos.Columns["Nombre"] != null)
        {
            dgvProductos.Columns["Nombre"].HeaderText =
                "Nombre";
        }


        if (dgvProductos.Columns["Precio"] != null)
        {
            dgvProductos.Columns["Precio"].HeaderText =
                "Precio";

            dgvProductos.Columns["Precio"]
    .DefaultCellStyle.Format = "$ #,##0.00";
        }


        if (dgvProductos.Columns["Stock"] != null)
        {
            dgvProductos.Columns["Stock"].HeaderText =
                "Stock";
        }


        if (dgvProductos.Columns["Rubro"] != null)
        {
            dgvProductos.Columns["Rubro"].HeaderText =
                "Rubro";
        }
    }


    // =========================================================
    // CONTADOR
    // =========================================================

    private void ActualizarContador(
        List<Producto> lista)
    {
        lblContador.Text =
            $"{lista.Count} productos";
    }


    // =========================================================
    // COLOREAR FILAS SEGÚN STOCK
    // =========================================================

    private void ColorearFilasSegunStock()
    {
        foreach (DataGridViewRow fila in dgvProductos.Rows)
        {
            if (fila.DataBoundItem is not Producto producto)
            {
                continue;
            }

            // STOCK DE 1 A 25 → ROJO
            if (producto.Stock >= 1 && producto.Stock <= 25)
            {
                fila.DefaultCellStyle.BackColor =
                    Color.LightCoral;
            }
            // STOCK DE 26 A 100 → AMARILLO
            else if (producto.Stock >= 26 && producto.Stock <= 100)
            {
                fila.DefaultCellStyle.BackColor =
                    Color.LightYellow;
            }
            // STOCK 101 O MÁS → VERDE
            else if (producto.Stock >= 101)
            {
                fila.DefaultCellStyle.BackColor =
                    Color.LightGreen;
            }

            // Mantener el color cuando se selecciona la fila
            fila.DefaultCellStyle.SelectionBackColor =
                fila.DefaultCellStyle.BackColor;

            fila.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            fila.DefaultCellStyle.ForeColor =
                Color.Black;
        }
    }


    // =========================================================
    // LIMPIAR CAMPOS
    // =========================================================

    private void LimpiarCampos()
    {
        txtNombre.Clear();

        nudPrecio.Value = 0;

        // IMPORTANTE:
        // El stock vuelve a 1, no a 0.

        nudStock.Value = 1;

        txtRubro.SelectedIndex = -1;

        dgvProductos.ClearSelection();

        txtNombre.Focus();
    }


    // =========================================================
    // OBTENER SELECCIONADO
    // =========================================================

    private Producto? ObtenerSeleccionado()
    {
        if (dgvProductos.SelectedRows.Count == 0)
        {
            return null;
        }

        return dgvProductos
            .SelectedRows[0]
            .DataBoundItem as Producto;
    }


    // =========================================================
    // VALIDAR CAMPOS
    // =========================================================

    private bool ValidarCampos(
        out string nombre,
        out decimal precio,
        out int stock,
        out string rubro)
    {
        nombre =
            txtNombre.Text.Trim();

        precio =
            nudPrecio.Value;

        stock =
            (int)nudStock.Value;

        rubro =
            txtRubro.Text.Trim();


        // -----------------------------------------------------
        // NOMBRE
        // -----------------------------------------------------

        if (string.IsNullOrWhiteSpace(nombre))
        {
            MessageBox.Show(
                "El nombre no puede estar vacío.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtNombre.Focus();

            return false;
        }


        if (nombre.Length < 2)
        {
            MessageBox.Show(
                "El nombre debe tener al menos 2 caracteres.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtNombre.Focus();

            return false;
        }


        if (nombre.Length > 100)
        {
            MessageBox.Show(
                "El nombre no puede superar los 100 caracteres.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtNombre.Focus();

            return false;
        }


        // -----------------------------------------------------
        // PRECIO
        // -----------------------------------------------------

        if (precio <= 0)
        {
            MessageBox.Show(
                "El precio debe ser mayor a 0.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            nudPrecio.Focus();

            return false;
        }


        // -----------------------------------------------------
        // STOCK
        // -----------------------------------------------------

        if (stock <= 0)
        {
            MessageBox.Show(
                "El stock debe ser mayor a 0.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            nudStock.Focus();

            return false;
        }


        // -----------------------------------------------------
        // RUBRO
        // -----------------------------------------------------

        if (txtRubro.SelectedIndex == -1)
        {
            MessageBox.Show(
                "Debe seleccionar un rubro.",
                "Validación",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            txtRubro.Focus();

            return false;
        }


        return true;
    }


    // =========================================================
    // AGREGAR / GUARDAR CAMBIOS
    // =========================================================

    private void btnAgregar_Click(
        object sender,
        EventArgs e)
    {
        if (!ValidarCampos(
            out string nombre,
            out decimal precio,
            out int stock,
            out string rubro))
        {
            return;
        }


        // -----------------------------------------------------
        // MODO EDICIÓN
        // -----------------------------------------------------

        if (_modoEdicion)
        {
            if (_productoEditando == null)
            {
                return;
            }


            _productoEditando.Nombre =
                nombre;

            _productoEditando.Precio =
                precio;

            _productoEditando.Stock =
                stock;

            _productoEditando.Rubro =
                rubro;


            _controller.Modificar(
                _productoEditando);


            MessageBox.Show(
                "Producto modificado correctamente.",
                "Gestor de Productos",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);


            SalirModoEdicion();

            LimpiarCampos();

            ActualizarTabla();

            return;
        }


        // -----------------------------------------------------
        // AGREGAR
        // -----------------------------------------------------

        _controller.Agregar(
            nombre,
            precio,
            stock,
            rubro);


        MessageBox.Show(
            "Producto agregado correctamente.",
            "Gestor de Productos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);


        LimpiarCampos();

        ActualizarTabla();
    }


    // =========================================================
    // EDITAR
    // =========================================================

    private void btnEditar_Click(
        object sender,
        EventArgs e)
    {
        Producto? producto =
            ObtenerSeleccionado();


        if (producto == null)
        {
            MessageBox.Show(
                "Seleccione un producto para editar.",
                "Editar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }


        _modoEdicion = true;

        _productoEditando =
            producto;


        txtNombre.Text =
            producto.Nombre;


        if (producto.Precio >= nudPrecio.Minimum &&
            producto.Precio <= nudPrecio.Maximum)
        {
            nudPrecio.Value =
                producto.Precio;
        }


        if (producto.Stock >= nudStock.Minimum &&
            producto.Stock <= nudStock.Maximum)
        {
            nudStock.Value =
                producto.Stock;
        }
        else
        {
            nudStock.Value = 1;
        }


        int indiceRubro =
            txtRubro.Items.IndexOf(
                producto.Rubro);


        if (indiceRubro >= 0)
        {
            txtRubro.SelectedIndex =
                indiceRubro;
        }
        else
        {
            txtRubro.SelectedIndex = -1;
        }


        ActualizarBotones();

        txtNombre.Focus();
    }


    // =========================================================
    // CANCELAR
    // =========================================================

    private void btnCancelar_Click(
        object sender,
        EventArgs e)
    {
        SalirModoEdicion();

        LimpiarCampos();
    }


    // =========================================================
    // SALIR DE EDICIÓN
    // =========================================================

    private void SalirModoEdicion()
    {
        _modoEdicion = false;

        _productoEditando = null;

        ActualizarBotones();
    }


    // =========================================================
    // BOTONES
    // =========================================================

    private void ActualizarBotones()
    {
        if (_modoEdicion)
        {
            btnAgregar.Text =
                "Guardar cambios";

            btnCancelar.Visible =
                true;

            btnEditar.Enabled =
                false;
        }
        else
        {
            btnAgregar.Text =
                "Agregar";

            btnCancelar.Visible =
                false;

            btnEditar.Enabled =
                true;
        }
    }


    // =========================================================
    // ELIMINAR
    // =========================================================

    private void btnEliminar_Click(
    object sender,
    EventArgs e)
    {
        if (!int.TryParse(
            txtIdEliminar.Text.Trim(),
            out int id))
        {
            MessageBox.Show(
                "Ingrese un ID válido.",
                "Eliminar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        Producto? producto =
            _controller.ObtenerTodos()
                .Find(p => p.Id == id);

        if (producto == null)
        {
            MessageBox.Show(
                $"No existe ningún producto con ID {id}.",
                "Eliminar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);

            return;
        }

        DialogResult confirmar =
            MessageBox.Show(
                $"¿Está seguro de eliminar el producto \"{producto.Nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

        if (confirmar != DialogResult.Yes)
        {
            return;
        }

        _controller.Eliminar(id);

        if (_modoEdicion)
        {
            SalirModoEdicion();
        }

        txtIdEliminar.Clear();

        LimpiarCampos();

        ActualizarTabla();

        MessageBox.Show(
            "Producto eliminado correctamente.",
            "Gestor de Productos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }


    // =========================================================
    // BUSCAR
    // =========================================================

    private void btnBuscar_Click(
        object sender,
        EventArgs e)
    {
        BuscarProductos();
    }


    private void txtBuscar_TextChanged(
        object sender,
        EventArgs e)
    {
        BuscarProductos();
    }


    private void BuscarProductos()
    {
        string texto =
            txtBuscar.Text.Trim();


        List<Producto> resultados =
            _controller.Buscar(texto);


        MostrarResultados(resultados);
    }


    // =========================================================
    // ELIMINAR SEGÚN STOCK
    // =========================================================

    private void btnEliminarStock_Click(
        object sender,
        EventArgs e)
    {
        int limite =
            (int)nudStockLimite.Value;


        List<Producto> productos =
            _controller.ObtenerTodos();


        if (productos.Count == 0)
        {
            MessageBox.Show(
                "No hay productos para eliminar.",
                "Stock",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }


        int cantidad = 0;


        foreach (Producto producto
                 in productos)
        {
            if (producto.Stock <= limite)
            {
                cantidad++;
            }
        }


        if (cantidad == 0)
        {
            MessageBox.Show(
                $"No hay productos con stock menor o igual a {limite}.",
                "Stock",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }


        DialogResult confirmar =
            MessageBox.Show(
                $"Se eliminarán {cantidad} producto(s) con stock menor o igual a {limite}. ¿Desea continuar?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);


        if (confirmar != DialogResult.Yes)
        {
            return;
        }


        _controller.EliminarSegunStock(
            limite);


        if (_modoEdicion)
        {
            SalirModoEdicion();
        }


        LimpiarCampos();

        ActualizarTabla();


        MessageBox.Show(
            "Productos eliminados según el stock.",
            "Gestor de Productos",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information);
    }


    // =========================================================
    // EXPORTAR TXT
    // =========================================================

    private void btnExportar_Click(
        object sender,
        EventArgs e)
    {
        List<Producto> lista =
            _controller.ObtenerTodos();


        if (lista.Count == 0)
        {
            MessageBox.Show(
                "No hay productos para exportar.",
                "Exportar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            return;
        }


        using SaveFileDialog dialogo =
            new SaveFileDialog();


        dialogo.Filter =
            "Archivo de texto (*.txt)|*.txt";


        dialogo.FileName =
            "productos.txt";


        dialogo.Title =
            "Exportar productos";


        dialogo.DefaultExt =
            "txt";


        if (dialogo.ShowDialog()
            != DialogResult.OK)
        {
            return;
        }


        List<string> lineas =
            new List<string>();


        lineas.Add(
            "==============================================================");

        lineas.Add(
            "                    GESTOR DE PRODUCTOS");

        lineas.Add(
            "==============================================================");

        lineas.Add("");


        lineas.Add(
            string.Format(
                "{0,-5} | {1,-25} | {2,12} | {3,8} | {4,-20}",
                "ID",
                "NOMBRE",
                "PRECIO",
                "STOCK",
                "RUBRO"));


        lineas.Add(
            "------+---------------------------+--------------+----------+---------------------");


        foreach (Producto producto
                 in lista)
        {
            lineas.Add(
                string.Format(
                    "{0,-5} | {1,-25} | {2,12:N2} | {3,8} | {4,-20}",
                    producto.Id,
                    LimitarTexto(
                        producto.Nombre,
                        25),
                    producto.Precio,
                    producto.Stock,
                    LimitarTexto(
                        producto.Rubro,
                        20)));
        }


        lineas.Add("");

        lineas.Add(
            "==============================================================");

        lineas.Add(
            $"Total de productos: {lista.Count}");

        lineas.Add(
            "==============================================================");


        try
        {
            File.WriteAllLines(
                dialogo.FileName,
                lineas);


            MessageBox.Show(
                "Productos exportados correctamente.",
                "Exportar",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"No se pudo exportar el archivo.\n\n{ex.Message}",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }


    // =========================================================
    // LIMITAR TEXTO
    // =========================================================

    private string LimitarTexto(
        string texto,
        int cantidad)
    {
        if (string.IsNullOrEmpty(texto))
        {
            return string.Empty;
        }


        if (texto.Length <= cantidad)
        {
            return texto;
        }


        return texto.Substring(
            0,
            cantidad - 3)
            + "...";
    }

    private void txtNombre_TextChanged(object sender, EventArgs e)
    {

    }

    private void lblContador_Click(object sender, EventArgs e)
    {

    }

    private void imagen_Click(object sender, EventArgs e)
    {

    }
}