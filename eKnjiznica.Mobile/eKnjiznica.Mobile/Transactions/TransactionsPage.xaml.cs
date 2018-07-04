using CommonServiceLocator;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels;
using eKnjiznica.Commons.ViewModels.TransactionVM;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKnjiznica.Mobile.Transactions
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TransactionsPage : ContentPage
	{
        private IApiClient apiClient;
        private List<TransactionVM> transactionVMs;
        public TransactionsPage ()
		{
            this.apiClient = ServiceLocator.Current.GetInstance<IApiClient>();
			InitializeComponent ();
		}

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            HttpResponseMessage result = await apiClient.GetMyTransactions();
            if (result.IsSuccessStatusCode)
            {
                var json = await result.Content.ReadAsStringAsync();
                transactionVMs = JsonConvert.DeserializeObject<List<TransactionVM>>(json);
                transactionVMs.ForEach(x =>
                {
                    x.TransactionTypeString = (GetStringName(x.TransactionType));
                });
                lvTransactions.ItemsSource= transactionVMs;
            }

        }

        private string GetStringName(TransactionType transactionType)
        {
            switch (transactionType)
            {
                case TransactionType.PAY_IN:
                    return Commons.Resources.TRANSACTION_TYPE_PAY_IN;
                case TransactionType.BUY:
                    return Commons.Resources.TRANSACTION_TYPE_BUY;
            }
            throw new NotImplementedException();
        }
    }
}