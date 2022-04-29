using Business;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Semana06
{
    /// <summary>
    /// Interaction logic for ManProducto.xaml
    /// </summary>
    public partial class ManProducto : Window
    {
        public int ID { get; set; }

        public ManProducto(int Id)
        {
            InitializeComponent();
            ID = Id;

            if (ID > 0)
            {
                BProducto bProducto = new BProducto();
                List<Producto> productos = new List<Producto>();
                productos = bProducto.Listar(ID);

                if (productos.Count > 0)
                {
                    lblID.Content = productos[0].IdProducto.ToString();
                    txtNombre.Text = productos[0].NombreProducto;
                    txtProveedor.Text = productos[0].IdProveedor.ToString();
                    txtCategoria.Text = productos[0].IdCategoria.ToString();
                    txtCantUnid.Text = productos[0].CantidadPorUnidad;
                    txtPrecUnid.Text = productos[0].PrecioUnidad.ToString();
                    txtUniExistencia.Text = productos[0].UnidadesEnExistencia.ToString();
                    txtUnidPedido.Text = productos[0].UnidadesEnPedido.ToString();
                    txtNivNuePedido.Text = productos[0].NivelNuevoPedido.ToString();
                    txtSuspendido.Text = productos[0].Suspendido.ToString();
                    txtCateProducto.Text = productos[0].CategoriaProducto;

                }
            }
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = null;
            bool result = true;

            try
            {
                //listar todas las productos
                bProducto = new BProducto();

                if (ID > 0)
                {
                    result = bProducto.Actualizar(new Producto
                    {
                        IdProducto = ID,
                        NombreProducto = txtNombre.Text,
                        IdProveedor = Convert.ToInt32(txtProveedor.Text),
                        IdCategoria = Convert.ToInt32(txtCategoria.Text),
                        CantidadPorUnidad = txtCantUnid.Text,
                        PrecioUnidad = Convert.ToDouble(txtPrecUnid.Text),
                        UnidadesEnExistencia = Convert.ToInt32(txtUniExistencia.Text),
                        UnidadesEnPedido = Convert.ToInt32(txtUnidPedido.Text),
                        NivelNuevoPedido = Convert.ToInt32(txtNivNuePedido.Text),
                        CategoriaProducto = txtCateProducto.Text
                    });
                }
                else
                {
                    result = bProducto.Insertar(new Producto
                    {
                        NombreProducto = txtNombre.Text,
                        IdProveedor = Convert.ToInt32(txtProveedor.Text),
                        IdCategoria = Convert.ToInt32(txtCategoria.Text),
                        CantidadPorUnidad = txtCantUnid.Text,
                        PrecioUnidad = Convert.ToDouble(txtPrecUnid.Text),
                        UnidadesEnExistencia = Convert.ToInt32(txtUniExistencia.Text),
                        UnidadesEnPedido = Convert.ToInt32(txtUnidPedido.Text),
                        NivelNuevoPedido = Convert.ToInt32(txtNivNuePedido.Text),
                        CategoriaProducto = txtCateProducto.Text
                    });
                }

                if (!result)
                {
                    MessageBox.Show("Comunicarse con el Administrador");
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Comunicarse con el Administrador -> {ex}");
            }
            finally
            {
                bProducto = null;
            }
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}