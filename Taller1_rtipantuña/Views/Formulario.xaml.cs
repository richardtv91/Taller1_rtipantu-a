using System.Globalization;

namespace Taller1_rtipantuña.Views;

public partial class Formulario : ContentPage
{
	public Formulario()
	{
		InitializeComponent();
	}
    public void btnGuardar_Clicked(object sender, EventArgs e)
    {
        string numIdentificacion = txtIdentificacion.Text?.Trim() ?? string.Empty;
   
        string apellidoP=txtApellidoP.Text?.Trim() ?? string.Empty;
        string apellidoM=txtApellidoM.Text?.Trim() ?? string.Empty;
        string nombre=txtNombres.Text?.Trim() ?? string.Empty;
        string correo = txtCorreo.Text?.Trim() ?? string.Empty;
        string confirmacionCorreo = txtCorreoCo.Text?.Trim() ?? string.Empty;
        string telefono = txtTelefono.Text?.Trim() ?? string.Empty;
        string identificacion = identificacionPiker.SelectedItem as string;
        string modalidad = modalidadPiker.SelectedItem as string;
        string carrera = carreraPiker.SelectedItem as string;
        string campus = campusPiker.SelectedItem as string;

        // Validate emails not empty and equal
        if (string.IsNullOrEmpty(correo) || 
            string.IsNullOrEmpty(confirmacionCorreo)||
            string.IsNullOrEmpty(numIdentificacion)||
            String.IsNullOrEmpty(apellidoM)||
            String.IsNullOrEmpty(apellidoP) ||
            String.IsNullOrEmpty(nombre) ||
            String.IsNullOrEmpty(telefono) ||
            String.IsNullOrEmpty(modalidad) ||
            String.IsNullOrEmpty(carrera)||string.IsNullOrEmpty(campus))
        {
             DisplayAlert("Error", "Por favor,ingresar todos los datos.", "OK");
            return;
        }

        if (!correo.Equals(confirmacionCorreo, StringComparison.OrdinalIgnoreCase))
        {
             DisplayAlert("Error", "Los correos electrónicos no coinciden.", "OK");
            return;
        }

        // Validate phone only digits
        if (string.IsNullOrEmpty(telefono))
        {
             DisplayAlert("Error", "Por favor, ingrese su teléfono.", "OK");
            return;
        }

        foreach (char c in telefono)
        {
            if (!char.IsDigit(c))
            {
                 DisplayAlert("Error", "El teléfono debe contener solo números.", "OK");
                return;
            }
        }

        // Validate picker selected
        if (string.IsNullOrEmpty(identificacion))
        {
             DisplayAlert("Error", "Por favor, seleccione una opción de identificacion.", "OK");
            return;
        }
        if(string.IsNullOrEmpty(modalidad)|| string.IsNullOrEmpty(campus) || string.IsNullOrEmpty(carrera))
        {
            DisplayAlert("Error", "Por favor, seleccione una opción.", "OK");
            return;
        }

        // Show all data in alert
        string message = $"Tipo:{identificacion}\n Numero:{numIdentificacion}\n Nombre:{nombre} {apellidoP} {apellidoM}\n Correo: {correo}\nTeléfono: {telefono}\n Modalidad: {modalidad}\n Carrera:{carrera}\n Campus:{campus}";

         DisplayAlert("Datos Guardados", message, "OK");
    }
}

	
