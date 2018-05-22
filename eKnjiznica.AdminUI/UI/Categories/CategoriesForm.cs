using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.ViewModels.Category;
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

namespace eKnjiznica.AdminUI.UI.Categories
{
    public partial class CategoriesForm : Form
    {
        private IApiClient apiClient;
        private IList<CategoryVM> categories;
        public CategoriesForm(IApiClient apiClient)
        {
            this.apiClient = apiClient;
            InitializeComponent();
        }

        private async void CategoriesForm_Load(object sender, EventArgs e)
        {

            await BindCategories();
        }

        private async Task BindCategories()
        {
            var result = await this.apiClient.GetCategories(inputCategoryName.Text.Trim(),cbIncludeInactive.Checked);
            if (result.IsSuccessStatusCode)
            {
                var re = await result.Content.ReadAsAsync<IList<CategoryVM>>();
                this.categories = re;
                gvCategories.DataSource = re;
            }
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await BindCategories();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
