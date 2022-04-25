using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MAKECALL
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SqlLiteSystem : ContentPage
    {
        public SQLiteConnection con = null;
        public SqlLiteSystem()
        {
            InitializeComponent();
            con = DependencyService.Get<ISqlLite>().CreateConnection();
        }

        protected override void OnAppearing()
        {
            PopulateData();
        }
        public void PopulateData()
        {
            listEmployee.ItemsSource = null;
            listEmployee.ItemsSource = DependencyService.Get<ISqlLite>().GetAllEmployee();
        }

        private async void BtnAddNew_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SqlLiteCRUD());
        }

        private async void menuDelete_Clicked(object sender, EventArgs e)
        {
           bool res= await DisplayAlert("Alart", "Do You Want Delate Record!", "YES", "NO");
            if(res)
            {
                var menu = sender as MenuItem;
                Employee emp = menu.CommandParameter as Employee;
                if (emp != null)
                {
                    DependencyService.Get<ISqlLite>().DeleteEmployee(emp.EmployeeId);
                    PopulateData();
                }
            }

        }

        private async void listEmployee_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Employee emp=  e.Item as Employee;
            if(emp!=null)
            {
              await  Navigation.PushAsync(new SqlLiteCRUD(emp));
            }
        }
    }
}