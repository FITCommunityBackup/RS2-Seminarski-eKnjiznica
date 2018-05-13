using eKnjiznica.AdminUI.model;
using eKnjiznica.AdminUI.Services.API;
using eKnjiznica.AdminUI.Services.ErrorHandling;
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
using Unity.Attributes;

namespace eKnjiznica.AdminUI
{
    public partial class LoginForm : Form
    {
        private IUnityContainer UnityContainer;
        private IApiClient ApiClient;
        private ErrorHandlingUtil errorHandlingUtil;

        public LoginForm(IUnityContainer unityContainer, IApiClient apiClient,ErrorHandlingUtil errorHandlingUtil)
        {
            this.UnityContainer = unityContainer;
            this.ApiClient = apiClient;
            this.errorHandlingUtil = errorHandlingUtil;

            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {

        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            LoginVM loginVM = new LoginVM
            {
                Password = txtPassword.Text,
                Username = txtUsername.Text
            };

            var result = await this.ApiClient.LoginUser(loginVM);

            this.Cursor = Cursors.Default;

            if (result.IsSuccessStatusCode)
            {
                MessageBox.Show("Bravo login ok");
            }
            else
            {
                lblError.Text = errorHandlingUtil.GetErrorMessage(result);
            }
        }
    }
}
