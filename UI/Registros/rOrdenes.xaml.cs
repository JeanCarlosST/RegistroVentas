using System.Windows;
using RegistroVentas.Entidades;
using RegistroVentas.BLL;
using System.Linq;
using System.Drawing;
using System.Windows.Media;
using System.Windows.Controls;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using RegistroVentas.DAL;

namespace RegistroVentas.UI.Registro
{
    public partial class rOrdenes : Window {
        Ordenes orden;

        public rOrdenes()
        {
            InitializeComponent();
            Limpiar();
        }

        public void BuscarBoton_Click(object sender, RoutedEventArgs e){
            // var orden = OrdenesBLL.Buscar(Utilities.ToInt(OrdenIDTextBox.Text));

            // if(orden != null)
            //     this.orden = orden;
            // else{
            //     this.orden = new Ordenes();
            //     MessageBox.Show("No se encontró ningún registro", "Sin coincidencias", 
            //                     MessageBoxButton.OK, MessageBoxImage.Information);
            // }

            // this.DataContext = this.orden;
        }

        private void Limpiar(){
            this.orden = new Ordenes();
            this.DataContext = this.orden;
        }

        // private bool Validar(){

        // }
        public void NuevoBoton_Click(object sender, RoutedEventArgs e){
            Limpiar();
        }
        public void GuardarBoton_Click(object sender, RoutedEventArgs e)
        {
            Contexto contexto = new Contexto();

            var orden = new Ordenes();

            orden.Fecha = DateTime.Now;
            orden.Monto = 250;

            orden.Detalle.Add(new OrdenesDetalle() { ArticuloId = 3, Cantidad = 2, Precio = 50});
            orden.Detalle.Add(new OrdenesDetalle() { ArticuloId = 1, Cantidad = 1, Precio = 150});

            contexto.Ordenes.Add(orden);

            contexto.SaveChanges();
        }
        public void EliminarBoton_Click(object sender, RoutedEventArgs e){
        }
    }
}