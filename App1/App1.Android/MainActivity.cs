using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App1.Droid
{
	[Activity (Label = "UNED", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            SetContentView (Resource.Layout.Main);

            // se instancia un objeto de una clase que simula realizar la matrícula
            // al tener la misma lógica entonces se tiene en una librería aparte
            // al que tanto el proyecto de iOS como el de Android hacen referencia
            UNED api = new UNED();
			
            // se obtiene la referencia a cada componente de la vista
			Button btnMatricular = FindViewById<Button>(Resource.Id.btnMatricular);
            EditText edtCentroUniversitario = FindViewById<EditText>(Resource.Id.edtCentroUniversitario);
            EditText edtNumCedula = FindViewById<EditText>(Resource.Id.edtCedula);
            EditText edtNombre = FindViewById<EditText>(Resource.Id.edtNombre);
            EditText edtCodigoMateria = FindViewById<EditText>(Resource.Id.edtCodigoMateria);
            EditText edtNombreMateria = FindViewById<EditText>(Resource.Id.edtNombreMateria);
            EditText edtCuatrimestre = FindViewById<EditText>(Resource.Id.edtCuatrimestre);
            EditText edtCosto = FindViewById<EditText>(Resource.Id.edtCosto);
            EditText edtResidencia = FindViewById<EditText>(Resource.Id.edtResidencia);
            
            // se establece el método onClick del botón
            btnMatricular.Click += delegate {

                string mensajeRealizarMatricula = String.Empty;
                
                // verificamos si todos los campos están con texto
                if (!String.IsNullOrEmpty(edtCentroUniversitario.Text) &&
                    !String.IsNullOrEmpty(edtNumCedula.Text) &&
                    !String.IsNullOrEmpty(edtNombre.Text) &&
                    !String.IsNullOrEmpty(edtCodigoMateria.Text) &&
                    !String.IsNullOrEmpty(edtNombreMateria.Text) &&
                    !String.IsNullOrEmpty(edtCuatrimestre.Text) &&
                    !String.IsNullOrEmpty(edtCosto.Text) &&
                    !String.IsNullOrEmpty(edtResidencia.Text))
                {
                    // realizamos la acción de matricular
                    if (api.RealizarMatricula())
                    {
                        // restablecemos los campos limpios
                        edtCentroUniversitario.Text = "";
                        edtNumCedula.Text = "";
                        edtNombre.Text = "";
                        edtCodigoMateria.Text = "";
                        edtNombreMateria.Text = "";
                        edtCuatrimestre.Text = "";
                        edtCosto.Text = "";
                        edtResidencia.Text = "";
                        
                        // obtenemos el mensaje de que se ha matriculado exitosamente
                        mensajeRealizarMatricula = Resources.GetString(Resource.String.ExitoProcesarMatricula);
                    }
                    else
                    {
                        // obtenemos el mensaje de que ha ocurrido un error al matricular
                        mensajeRealizarMatricula = Resources.GetString(Resource.String.ErrorProcesarMatricula);
                    }
                    
                }
                else
                {
                    // obtenemos el mensaje de que se necesitan todos los campos con valores para matricular
                    mensajeRealizarMatricula = Resources.GetString(Resource.String.CamposRequeridos);
                }
                
                // desplegamos el mensaje en pantalla
                Toast.MakeText(this, mensajeRealizarMatricula, ToastLength.Long).Show();
                
            };
		}
	}
}


