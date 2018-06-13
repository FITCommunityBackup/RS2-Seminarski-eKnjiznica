using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.API;
using eKnjiznica.Commons.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace eKnjiznica.AdminUI.UI.Books
{
    public partial class BooksForm : Form
    {
        private IApiClient apiClient;
        private IList<BooksVM> Books;
        private IUnityContainer UnityContainer;
        public BooksForm(IApiClient apiClient,IUnityContainer unityContainer)
        {
            this.apiClient = apiClient;
            this.UnityContainer = unityContainer;

            InitializeComponent();
            gvBooks.AutoGenerateColumns = false;
            gvBooks.AutoSize = true;
            gvBooks.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCells);
        }

        private async void BooksForm_Load(object sender, EventArgs e)
        {
            await BindData();
        }

     
        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await BindData();
        }


        private async Task BindData()
        {
            var result = await apiClient.GetBooks(inputBookTitle.Text.Trim(),inputAuthorName.Text.Trim());
            if (result.IsSuccessStatusCode)
            {
                Books = await result.Content.ReadAsAsync <IList<BooksVM>>();
                gvBooks.DataSource = Books;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            var form = UnityContainer.Resolve<BooksEditForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await BindData();
            }
        }

        private async void btnDetails_Click(object sender, EventArgs e)
        {
            if (Books == null || gvBooks.CurrentCell == null)
                return;
            var selectedRow = gvBooks.CurrentCell.RowIndex;

            var form = UnityContainer.Resolve<BooksEditForm>();
            form.Book = Books[selectedRow];
            if (form.ShowDialog() == DialogResult.OK)
            {
                await BindData();
            }

        }
    }
}
