using System.Windows;
using RegistroVentas.Entidades;
using RegistroVentas.BLL;
using System.Linq;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore.Internal;

namespace RegistroVentas.UI.Registro
{
    public partial class rArticulos : Window {
        Articulos articulo;

        public rArticulos(){
            InitializeComponent();
            articulo = new Articulos();
            this.DataContext = articulo;
        }

        public void BuscarBoton_Click(object sender, RoutedEventArgs e){
            var articulo = ArticuloBLL.Buscar(Utilities.ToInt(ArticuloIDTextBox.Text));

            if(articulo != null)
                this.articulo = articulo;
            else{
                this.articulo = new Articulos();
                MessageBox.Show("No se encontró ningún registro", "Sin coincidencias", 
                                MessageBoxButton.OK, MessageBoxImage.Information);
            }

            this.DataContext = this.articulo;
        }

        private void Limpiar(){
            this.articulo = new Articulos();
            this.DataContext = this.articulo;
        }

        private bool Validar(){

            if (DescripcionTextBox.Text.Length == 0)
            {
                MessageBox.Show("Introduzca un nombre válido", "Datos incorrectos",
                                MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
            else
                return true;
        }
        public void NuevoBoton_Click(object sender, RoutedEventArgs e){
            Limpiar();
        }
        public void GuardarBoton_Click(object sender, RoutedEventArgs e){
            if(!Validar())
                return;

            var found = ArticuloBLL.Guardar(articulo);

            if(found){
                MessageBox.Show("Registro guardado", "Guardado exitoso", 
                                MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            
            } else 
                MessageBox.Show("Error", "Hubo un error al guardar", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public void EliminarBoton_Click(object sender, RoutedEventArgs e){
            if(ArticuloBLL.Eliminar(Utilities.ToInt(ArticuloIDTextBox.Text))){
                Limpiar();
                MessageBox.Show("Registro borrado", "Borrado exitoso", 
                                MessageBoxButton.OK, MessageBoxImage.Information);
            
            } else 
                MessageBox.Show("Error", "Hubo un error al borrar", 
                                MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}