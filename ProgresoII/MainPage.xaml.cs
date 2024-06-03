using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace ProgresoII
{
    public partial class MainPage : ContentPage
    {
        private int montoSeleccionado;

        public MainPage()
        {
            InitializeComponent();

        }

        private void OnCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (LC_RadioButton3.IsChecked)
            {
                montoSeleccionado = 3;
            }
            else if (LC_RadioButton5.IsChecked)
            {
                montoSeleccionado = 5;
            }
            else if (LC_RadioButton10.IsChecked)
            {
                montoSeleccionado = 10;
            }
            LC_LabelRecargaSeleccionada.Text = $"Ha seleccionado una recarga de: {montoSeleccionado} dólares";
        }

        private async void OnRecargarClicked(object sender, EventArgs e)
        {
            bool confirmacion = await DisplayAlert("Confirmación", $"¿Desea recargar {montoSeleccionado}?", "Sí", "No");

            if (confirmacion)
            {
                
                await RecargarTelefonoAsync();

                GuardarRecarga();

                await DisplayAlert("Finalizado", "Recarga exitosa", "OK");
            }
        }

        private async Task RecargarTelefonoAsync()
        {
            await Task.Delay(2000); 
        }

        private void GuardarRecarga()
        {
            string numeroTelefono = LC_EntryTelefono.Text;
            string operador = LC_PickerOperador.SelectedItem.ToString();

            
            string fecha = DateTime.Now.ToString("dd/MM/yyyy");

            string texto = $"Se hizo una recarga de {montoSeleccionado} dólares en la siguiente fecha: {fecha}";
            string nombreArchivo = Path.Combine(FileSystem.AppDataDirectory, $"{numeroTelefono}.txt");

            File.WriteAllText(nombreArchivo, texto);
        }
    }
}
