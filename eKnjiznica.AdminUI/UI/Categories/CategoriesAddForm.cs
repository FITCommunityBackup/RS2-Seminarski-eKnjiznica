using eKnjiznica.AdminUI.Services.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eKnjiznica.AdminUI.UI.Categories
{
    public partial class CategoriesAddForm : Form
    {
        private IApiClient apiClient;

        public CategoriesAddForm(IApiClient apiClient)
        {
            this.apiClient = apiClient;
            InitializeComponent();

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            var result = await apiClient.CreateCategory(inputCategoryName.Text.Trim());
            if (result.IsSuccessStatusCode)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }

        }
    }
}
