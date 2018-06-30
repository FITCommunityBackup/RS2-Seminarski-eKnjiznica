using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKnjiznica.Mobile
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RegisterMePage : ContentPage
	{
		public RegisterMePage ()
		{
			InitializeComponent ();

            BirthdayDate.MaximumDate = DateTime.Now;
            BirthdayDate.MinimumDate = DateTime.Now.AddYears(-150);
            BirthdayDate.Date = DateTime.Now;

        }
	}
}