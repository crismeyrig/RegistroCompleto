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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Registro_Completo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Personas Persona;
        public MainWindow()
        {
            InitializeComponent();
             Persona = new Personas();
            DataContext = Persona;
        }
        public void  GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (!Validar())
             return ;

             var paso = PersonasBLL.Guardar(Persona);

             if (paso)
             {
                 Limpiar();
                 MessageBox.Show("Transacion  Exitosa","Exito", MessageBoxButton.OK,MessageBoxImage.Information);
             }
             else
             MessageBox.Show("Transacio Fallida","Fallo",MessageBoxButton.OK, MessageBoxImage.Error);
        }
    private void  Limpiar()
    {
        this.Persona = new Personas();
        this.DataContext = Persona;
    }
    
    private void BuscarButton_Click(object sender, RoutedEventArgs e)
    {
        var persona = PersonasBLL.Buscar(Utilidades.ToInt(PersonaIdTextBox.Text));
        if (persona != null)
        {
            this.Persona = persona;
        }
        
        else
        {
        this.Persona = new Personas(); 
        }
        
        this.DataContext = this.Persona;
    }
    private void EliminarButton_Click(object sender, RoutedEventArgs e)
    {
        if (PersonasBLL.Eliminar(Utilidades.ToInt(PersonaIdTextBox.Text)))
        {
            Limpiar();
            MessageBox.Show("Registro eliminado!","Exito", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        else
        MessageBox.Show("No fue posible Eliminar", "fallo", MessageBoxButton.OK, MessageBoxImage.Error);
    }
    
    private void NuevoButton_Click(object sender, RoutedEventArgs e)
    {
        Limpiar();
    }
    
    private bool Validar()
    {
        bool esValido = true;

        if (NombreTextBox.Text.Length ==0)
        {
            esValido = false;
            MessageBox.Show("Transacion fallida","fallo", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        return esValido;
    }
}
}
