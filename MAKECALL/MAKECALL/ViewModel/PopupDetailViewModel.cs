

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using System.ComponentModel;
using MAKECALL.Models;

namespace MAKECALL.ViewModel
{
    public class PopupDetailViewModel : INotifyPropertyChanged
    {
        INavigation Navigation = null;

        public PopupDetailViewModel(INavigation Navigation)
        {
            this.Navigation = Navigation;
            _employeemodel = new EmployeeModel();
            EnableEditPassword=false;
        }
        public PopupDetailViewModel(INavigation Navigation, Employee employeeforupdate)
        {
            this.Navigation = Navigation;
            _employeemodel = new EmployeeModel() { EmployeeId=employeeforupdate.EmployeeId, EmployeeName = employeeforupdate.EmployeeName, Email = employeeforupdate.Email, Password = employeeforupdate.Password, Mobile = employeeforupdate.Mobile };
            SaveButtonText = "Edit";
            EnableEditPassword = true;
        }


        private EmployeeModel _employeemodel;
        public EmployeeModel Employeemodel
        {
            get { return _employeemodel; }
            set { _employeemodel = value; UpdateProperty("Employeemodel"); }
        }

        private bool _enableEditPassword = false;
        public bool EnableEditPassword
        {
            get { return _enableEditPassword; }
            set { _enableEditPassword = value; UpdateProperty("EnableEditPassword"); }
        }

        private string saveButtonText = "Save";
        public string SaveButtonText {
            get { return saveButtonText; }
            set { saveButtonText = value; UpdateProperty("SaveButtonText"); }
        }
        public ICommand ClosePopupCommand
        {
            get
            {
                return new Command(() =>
                    {
                        Navigation.PopAllPopupAsync();
                    }
                );
            }
        }

        public ICommand SaveDataCommand
        {
            get
            {
                return new Command(() =>
                 {
                     if(SaveButtonText=="Save")
                     {
                         MessagingCenter.Send(Employeemodel, "RECEIVE_EMPLOYEE_DATA");
                         Navigation.PopAllPopupAsync();
                     }
                     else
                     {
                         MessagingCenter.Send(Employeemodel, "UPDATE_EMPLOYEE_DATA");
                         Navigation.PopAllPopupAsync();
                     }

                 }
                );
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void UpdateProperty(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
