using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.Commons.API;
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
using Unity;

namespace eKnjiznica.AdminUI.UI.Categories
{
    public partial class CategoriesForm : Form
    {
        private IApiClient apiClient;
        private IList<CategoryVM> categories;
        private IUnityContainer unityContainer;
        public CategoriesForm(IApiClient apiClient,IUnityContainer unityContainer)
        {
            this.apiClient = apiClient;
            this.unityContainer = unityContainer;
           
            InitializeComponent();
            //gvCategories.AutoGenerateColumns = false;
            gvCategories.AutoSize = true;
            gvCategories.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
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
                gvCategories.DataSource = re;
            }
           
        }

        private async void btnFilter_Click(object sender, EventArgs e)
        {
            await BindCategories();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var form = this.unityContainer.Resolve<CategoriesAddForm>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                await BindCategories();
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (categories== null || gvCategories.CurrentCell == null)
                return;
            var selectedRow = gvCategories.CurrentCell.RowIndex;

            var form = unityContainer.Resolve<CategoriesEditForm>();
            form.Category = categories[selectedRow];
            if (form.ShowDialog() == DialogResult.OK)
            {
                await BindCategories();
            }
        }
    }
}
