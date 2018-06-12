using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.AdminUI.Services.User;
using eKnjiznica.AdminUI.UI.Administrators;
using eKnjiznica.AdminUI.UI.Auctions;
using eKnjiznica.AdminUI.UI.Books;
using eKnjiznica.AdminUI.UI.Categories;
using eKnjiznica.AdminUI.UI.Clients;
using eKnjiznica.AdminUI.UI.Logs;
using eKnjiznica.AdminUI.UI.Transactions;
using eKnjiznica.AdminUI.UI.UserBooks;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace eKnjiznica.AdminUI
{ 
    public partial class MainForm : Form
    {
        Form currentForm;
        private IUnityContainer unityContainer;
        private IUserService userService;
        private IApiClient apiClient;
        public MainForm(IUnityContainer unityContainer, IUserService userService,IApiClient apiClient)
        {
            this.userService = userService;
            this.unityContainer = unityContainer;
            this.apiClient = apiClient;
            InitializeComponent();
            if (!userService.IsUserLogged())
                loginUser();
        }

        private void loginUser()
        {
            var loginForm =unityContainer.Resolve<LoginForm>();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                this.Close();
            }
        }

        private void odjaviSeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userService.LogoutUser();
            loginUser();
        }

        private void administratoriToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
                currentForm.Close();
            currentForm = unityContainer.Resolve<AdministratorsForm>();
            currentForm.MdiParent = this;
            currentForm.Show();
        }

        private void logoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
                currentForm.Close();
            currentForm = unityContainer.Resolve<LogsForm>();
            currentForm.MdiParent = this;
            currentForm.Show();
        }

        private void kategorijeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (currentForm != null)
                currentForm.Close();
            currentForm = unityContainer.Resolve<CategoriesForm>();
            currentForm.MdiParent = this;
            currentForm.Show();
        }

        private void pregledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
                currentForm.Close();
            currentForm = unityContainer.Resolve<BooksForm>();
            currentForm.MdiParent = this;
            currentForm.Show();
        }

        private void prodajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
                currentForm.Close();
            currentForm = unityContainer.Resolve<BooksSellForm>();
            currentForm.MdiParent = this;
            currentForm.Show();
        }

        private void korisniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
                currentForm.Close();
            currentForm = unityContainer.Resolve<ClientsForm>();
            currentForm.MdiParent = this;
            currentForm.Show();
        }

        private void transakcijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
                currentForm.Close();
            currentForm = unityContainer.Resolve<TransactionsForm>();
            currentForm.MdiParent = this;
            currentForm.Show();
        }

        private void kupovineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
                currentForm.Close();
            currentForm = unityContainer.Resolve<UserBooksForm>();
            currentForm.MdiParent = this;
            currentForm.Show();
        }

        private void aukcijeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentForm != null)
                currentForm.Close();
            currentForm = unityContainer.Resolve<AuctionsForms>();
            currentForm.MdiParent = this;
            currentForm.Show();
        }
    }
}
