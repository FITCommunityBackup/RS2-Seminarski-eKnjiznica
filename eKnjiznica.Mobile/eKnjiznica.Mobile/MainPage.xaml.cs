using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Xamarin.Forms;

namespace eKnjiznica.Mobile
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            
		}

        private void Register_Me_EventHandler(object sender, EventArgs e)
        {

        }

        private void Log_In_Event_Handler(object sender, EventArgs e)
        {
            var user= username.Text;
            var pass= password.Text;
            DisplayAlert(user, pass, "CANCEL");
        }
    }
}
    