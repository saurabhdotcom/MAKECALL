using MAKECALL.Models;
using MAKECALL.View;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace MAKECALL.ViewModel
{
    public class PopupSystemViewModel : INotifyPropertyChanged
    {
        private INavigation Nevigation;
        private ObservableCollection<Employee> _EmployeeList;
        private ObservableCollection<Employee> _searchEmployeeList;
        public PopupSystemViewModel(INavigation Nevigation)
        {
            this.Nevigation = Nevigation;
            _EmployeeList = new ObservableCollection<Employee>();
            _searchEmployeeList = new ObservableCollection<Employee>();
            DependencyService.Get<ISqlLite>().CreateConnection();
            PopulateEmployeeData();

        }

        public ObservableCollection<Employee> EmployeeList
        {
            get { return _EmployeeList; }
            set { _EmployeeList = value; UpdateProperty("EmployeeList"); }
        }
        public ObservableCollection<Employee> SearchmployeeList
        {
            get
            {
                return _searchEmployeeList;
            }
            set { _searchEmployeeList = value; UpdateProperty("SearchmployeeList"); }
        }

        public Employee _EmployeeSelectedRecord = new Employee();
        public Employee SelectedRecord
        {
            get { return _EmployeeSelectedRecord; }
            set { _EmployeeSelectedRecord = value; UpdateProperty("SelectedRecord"); }
        }

        private string _searchText = "";
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; UpdateProperty(SearchText); }
        }
        private bool _isVisualRecordNotFound = false;
        public bool IsVisualRecordNotFound
        {
            get { return _isVisualRecordNotFound; }
            set { _isVisualRecordNotFound = value; UpdateProperty("IsVisualRecordNotFound"); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateProperty(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public ICommand AddEmployeeCommand
        {
            get
            {
                return new Command(() =>
                    {
                        MessagingCenter.Unsubscribe<EmployeeModel>(this, "RECEIVE_EMPLOYEE_DATA");
                        Nevigation.PushPopupAsync(new PopupDetail());
                        MessagingCenter.Subscribe<EmployeeModel>(this, "RECEIVE_EMPLOYEE_DATA", (_empmodel) =>
                            {
                                Employee employee = new Employee() { EmployeeName = _empmodel.EmployeeName, Email = _empmodel.Email, Password = _empmodel.Password, Mobile = _empmodel.Mobile };
                                bool result = DependencyService.Get<ISqlLite>().SaveEmployee(employee);
                                if (result)
                                {
                                    DependencyService.Get<IMessage>().ShortTime("Detail save Successfully");
                                    PopulateEmployeeData();
                                }
                                else
                                {
                                    DependencyService.Get<IMessage>().ShortTime("Detail Not Saved.");
                                }
                                MessagingCenter.Unsubscribe<EmployeeModel>(this, "RECEIVE_EMPLOYEE_DATA");
                            }
                        );
                    }
                );
            }

        }

        private void PopulateEmployeeData()
        {
            List<Employee> listemp = DependencyService.Get<ISqlLite>().GetAllEmployee();
            EmployeeList = new ObservableCollection<Employee>(listemp);
            SearchmployeeList = EmployeeList;
        }

        public Command<object> DeleteRecordCommand
        {
            get
            {
                return new Command<object>((emp) =>
                  {
                      Employee var = emp as Employee;
                      bool result = DependencyService.Get<ISqlLite>().DeleteEmployee(var.EmployeeId);
                      if (result)
                      {
                          DependencyService.Get<IMessage>().ShortTime("Record Deleted Successfully.");
                          PopulateEmployeeData();
                      }
                      else
                      {
                          DependencyService.Get<IMessage>().ShortTime("Record not Deleted.");
                      }
                  }
                );
            }
        }

        public ICommand ItemTapedCommand
        {
            get
            {
                return new Command(async () =>
                       {
                           MessagingCenter.Unsubscribe<EmployeeModel>(this, "UPDATE_EMPLOYEE_DATA");
                           await Nevigation.PushPopupAsync(new PopupDetail(SelectedRecord));
                           MessagingCenter.Subscribe<EmployeeModel>(this, "UPDATE_EMPLOYEE_DATA", (_empmodel) =>
                           {
                               Employee employee = new Employee() { EmployeeName = _empmodel.EmployeeName, Email = _empmodel.Email, Password = _empmodel.Password, Mobile = _empmodel.Mobile, EmployeeId = _empmodel.EmployeeId };
                               bool result = DependencyService.Get<ISqlLite>().UpdateEmployee(employee);
                               if (result)
                               {
                                   DependencyService.Get<IMessage>().ShortTime("Detail Update Successfully");
                                   PopulateEmployeeData();
                               }
                               else
                               {
                                   DependencyService.Get<IMessage>().ShortTime("Detail Not Updated.");
                               }
                               MessagingCenter.Unsubscribe<EmployeeModel>(this, "UPDATE_EMPLOYEE_DATA");
                           }
);
                       }
                     );
            }


        }

        public ICommand TextChangedCommand
        {
            get
            {
                return new Command(async () =>
                  {
                      if (!String.IsNullOrEmpty(SearchText))
                      {
                          List<Employee> emp = EmployeeList.Where(e => e.EmployeeName.ToLower().Contains(SearchText.ToLower())).ToList();
                          SearchmployeeList = new ObservableCollection<Employee>(emp);
                          if (emp.Count != 0)
                          {
                              IsVisualRecordNotFound = false;
                          }
                          else
                          {
                              IsVisualRecordNotFound = true;
                          }

                      }
                      else
                      {
                          SearchmployeeList = EmployeeList;
                      }

                  });
            }

        }

        public ICommand SearchButtonPressedCommand
        {
            get
            {
                return new Command(async () =>
          {
              if (!String.IsNullOrEmpty(SearchText))
              {
                  List<Employee> emp = EmployeeList.Where(e => e.EmployeeName.ToLower().Contains(SearchText.ToLower())).ToList();
                  SearchmployeeList = new ObservableCollection<Employee>(emp);
                  if (emp.Count != 0)
                  {
                      IsVisualRecordNotFound = false;
                  }
                  else
                  {
                      IsVisualRecordNotFound = true;
                  }

              }
              else
              {
                  SearchmployeeList = EmployeeList;
                  IsVisualRecordNotFound = false;
              }

          });
            }





        }
    }
}