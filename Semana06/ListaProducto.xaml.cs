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
    /// Interaction logic for ListaProducto.xaml
    /// </summary>
    public partial class ListaProducto : Window
    {
        public ListaProducto()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();
        }

        private void Cargar()
        {
            BProducto bProducto = null;

            try
            {
                //listar todas las categorias
                bProducto = new BProducto();
                dgvProducto.ItemsSource = bProducto.Listar(0);
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

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            //se coloca 0 pq es nuevo
            ManProducto manProducto = new ManProducto(0);
            manProducto.ShowDialog();
            Cargar();
        }

        private void dgvProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int idProducto = 0;
            var item = (Producto)dgvProducto.SelectedItem;
            if (null == item) return;
            idProducto = Convert.ToInt32(item.IdProducto);

            ManProducto manProducto = new ManProducto(idProducto);
            manProducto.ShowDialog();
            Cargar();

        }
    }
}
