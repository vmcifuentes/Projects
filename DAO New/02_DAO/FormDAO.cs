using _02_DAO.Model;
using MetroFramework.Forms;
using System;

namespace _02_DAO
{
    public partial class FormDAO : MetroForm
    {
        // Campo privado de implementación DAO
        private DAOImplementation dao;

        public FormDAO()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Instancia de implementación DAO
            dao = new DAOImplementation(); 
        }

        private void metroTabPage1_MouseEnter(object sender, EventArgs e)
        {
            textBoxCodigo.Focus();
        }

        private void metroTabPage2_MouseEnter(object sender, EventArgs e)
        {
            TextBoxBuscar.Focus();
        }

        // READ - Búsqueda de producto
        private void ButtonBuscar_Click(object sender, EventArgs e)
        {
            string codigo = TextBoxBuscar.Text;
            Producto p = dao.ConsultarProducto(codigo);

            if (p!=null)
            {
                TextBoxConsultaDescripcion.Text = p.Desc;
                TextBoxConsultaPrecio.Text = "Q " + p.Precio.ToString("#,##0.00");
                TextBoxConsultaCantidad.Text = p.Cantidad.ToString();
                TextBoxBuscar.Clear();
                TextBoxBuscar.Focus();
            }
            else
            {
                TextBoxBuscar.Clear();
                TextBoxBuscar.Focus();
            }
        }

        private void TextBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            // Validación para habilitar botón
            if (String.IsNullOrEmpty(TextBoxBuscar.Text))
            {
                ButtonBuscar.Enabled = false;
            }
            else
            {
                ButtonBuscar.Enabled = true;
            }
        }

        private void ButtonConsultarLimpiar_Click(object sender, EventArgs e)
        {
            TextBoxConsultaDescripcion.Clear();
            TextBoxConsultaPrecio.Clear();
            TextBoxConsultaCantidad.Clear();
            TextBoxBuscar.Focus();
        }

        // CREATE - Registrar producto
        private void ButtonCrear_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            p.Codigo = textBoxCodigo.Text;
            p.Desc = textBoxDescripcion.Text;
            p.Precio = Decimal.Parse(textBoxPrecio.Text);
            p.Cantidad = Int32.Parse(textBoxCantidad.Text);

            dao.CrearProducto(p);

            textBoxCodigo.Clear();
            textBoxDescripcion.Clear();
            textBoxPrecio.Clear();
            textBoxCantidad.Clear();
            textBoxCodigo.Focus();
        }

        private void ButtonActualizarBuscar_Click(object sender, EventArgs e)
        {
            string codigo = TextBoxActualizarBuscar.Text;
            Producto p = dao.ConsultarProducto(codigo);

            if (p != null)
            {
                TextBoxActualizarDesc.Text = p.Desc;
                TextBoxActualizarPrecio.Text = p.Precio.ToString("#,##0.00");
                TextBoxActualizarCantidad.Text = p.Cantidad.ToString();
                TextBoxActualizarDesc.Focus();
                TextBoxActualizarDesc.SelectAll();
                TextBoxActualizarBuscar.Enabled = true;

                ButtonActualizar.Enabled = true;
                ButtonActualizarBuscar.Enabled = false;
            }
            else
            {
                TextBoxActualizarBuscar.Clear();
                TextBoxActualizarBuscar.Focus();
            }
        }

        private void TextBoxActualizarBuscar_TextChanged(object sender, EventArgs e)
        {
            // Validación para habilitar botón
            if (string.IsNullOrEmpty(TextBoxActualizarBuscar.Text))
            {
                ButtonActualizarBuscar.Enabled = false;
            }
            else
            {
                ButtonActualizarBuscar.Enabled = true;
            }
        }

        private void ButtonActualizar_Click(object sender, EventArgs e)
        {
            Producto p = new Producto();
            p.Codigo = TextBoxActualizarBuscar.Text;
            p.Desc = TextBoxActualizarDesc.Text;
            p.Precio = Decimal.Parse(TextBoxActualizarPrecio.Text);
            p.Cantidad = Int32.Parse(TextBoxActualizarCantidad.Text);

            dao.ActualizarProducto(p);

            ButtonActualizar.Enabled = false;
            ButtonActualizarBuscar.Enabled = true;
            TextBoxActualizarBuscar.Enabled = true;
            TextBoxActualizarBuscar.Clear();
            TextBoxActualizarDesc.Clear();
            TextBoxActualizarPrecio.Clear();
            TextBoxActualizarCantidad.Clear();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            TextBoxActualizarBuscar.Clear();
            TextBoxActualizarDesc.Clear();
            TextBoxActualizarPrecio.Clear();
            TextBoxActualizarCantidad.Clear();
            TextBoxActualizarBuscar.Focus();
        }

        private void metroTabPage4_MouseHover(object sender, EventArgs e) => TextBoxEliminarBuscar.Focus();

        // DELETE - Elliminar producto
        private void ButtonEliminarBuscar_Click(object sender, EventArgs e)
        {
            string codigo = TextBoxEliminarBuscar.Text;
            Producto p = dao.ConsultarProducto(codigo);

            if (p != null)
            {
                TextBoxEliminarDesc.Text = p.Desc;
                TextBoxEliminarPrecio.Text = "Q " + p.Precio.ToString("#,##0.00");
                TextBoxEliminarCantidad.Text = p.Cantidad.ToString();
                TextBoxEliminarBuscar.Enabled = false;
                ButtonEliminarDelete.Enabled = true;

            }
            else
            {
                TextBoxEliminarBuscar.Clear();
                TextBoxEliminarBuscar.Focus();
            }
        }

        private void TextBoxEliminarBuscar_TextChanged(object sender, EventArgs e)
        {
            // Validación para habilitar botón
            if (string.IsNullOrEmpty(TextBoxEliminarBuscar.Text))
            {
                ButtonEliminarBuscar.Enabled = false;
            }
            else
            {
                ButtonEliminarBuscar.Enabled = true;
            }
        }

        private void ButtonEliminarDelete_Click(object sender, EventArgs e)
        {
            string codigo = TextBoxEliminarBuscar.Text;
            dao.EliminarProducto(codigo);

            // UI
            TextBoxEliminarBuscar.Clear();
            TextBoxEliminarDesc.Clear();
            TextBoxEliminarPrecio.Clear();
            TextBoxEliminarCantidad.Clear();
            TextBoxEliminarBuscar.Enabled = true;

            TextBoxEliminarBuscar.Focus();
            ButtonEliminarDelete.Enabled = false;
        }

        // Resultados por medio de un solo DataGridView
        private void metroButtonVerProductos(object sender, EventArgs e)
        {
            metroGrid1.DataSource = dao.makeQuery("EXEC VerProductos");
        }

        private void metroButtonPreciosBajos_Click(object sender, EventArgs e)
        {
            metroGrid1.DataSource = dao.makeQuery("EXEC ProductosPreciosBajos");
        }

        private void metroButtonAnalisisBD_Click(object sender, EventArgs e)
        {
            metroGrid1.DataSource = dao.makeQuery("EXEC BDAnalisis");
        }
    }
}
