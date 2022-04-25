using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAKECALL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SqlLiteCRUD : ContentPage
    {
        Employee employeeDetail = null;
        public SqlLiteCRUD()
        {
            InitializeComponent();

        }
        public SqlLiteCRUD(Employee employeeDetail)
        {
            InitializeComponent();
            this.employeeDetail = employeeDetail;
            BtnSave.Text = "Update";
            entryPassword.IsReadOnly = true;
            entryName.Text = employeeDetail.EmployeeName;
            entryEmail.Text = employeeDetail.Email;
            entryMobile.Text = employeeDetail.Mobile;
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            if (BtnSave.Text == "Save")
            {
                Employee employee = new Employee()
                {
                    EmployeeName = entryName.Text,
                    Email = entryEmail.Text,
                    Mobile = entryMobile.Text,
                    Password = entryPassword.Text
                };
                bool count = DependencyService.Get<ISqlLite>().SaveEmployee(employee);
                if (count)
                {
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Message", "Oops Something went wrong !", "ok");
                }
            }
            else if (BtnSave.Text == "Update")
            {
                Employee employee = employeeDetail;
                employee.EmployeeName = entryName.Text;
                employee.Email = entryEmail.Text;
                employee.Mobile = entryMobile.Text;
                bool count = DependencyService.Get<ISqlLite>().UpdateEmployee(employee);
                if (count)
                {
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Message", "Oops Something went wrong for update !", "ok");
                }
            }


        }
    }
}