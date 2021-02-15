using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfApp7.Commands;
using WpfApp7.pages;
namespace WpfApp7.ViewModels
{
    class AddOrderViewModel : ViewModelBase
    {
        private readonly Model1 _db = new Model1();
        public Distiplina selectedFuel;
        private string userName;
        private string familyName;
        private string email;
        private ObservableCollection<Distiplina> dists;

        public AddOrderViewModel()
        { 
            AddOrderCommand = new RellayCommand(AddOrder);
            ToOrdersCommand = new RellayCommand(ToOrders);

            var outter = from dict in _db.Dists select dict;//linq  
            Distss = new ObservableCollection<Distiplina>(outter); 
        }

        public RellayCommand AddOrderCommand { get; } 
        public RellayCommand ToOrdersCommand { get; }

        public ObservableCollection<Distiplina> Distss
        {
            get => dists;
            set
            {
                dists = value;
                OnPropertyChanged(nameof(Distss));
            }
        }
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string FamilyName
        {
            get => familyName;
            set
            {
                familyName = value;
                OnPropertyChanged(nameof(FamilyName));
            }
        }
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public Distiplina SelectedFuel
        {
            get => selectedFuel;
            set
            {
                selectedFuel = value;
                OnPropertyChanged("SelectedFuel");
            }
        }

        private async void AddOrder(object o)
        { 
            if (selectedFuel == null)
            {
                MessageBox.Show("Выберите дистиплину"); 
            }
            else if (UserName == null ||UserName.Equals(""))
            {
                MessageBox.Show("Укажите Имя студента"); 
            }
            else if (FamilyName == null || FamilyName.Equals(""))
            {
                MessageBox.Show("Укажите Фамилию студента");
            }
            else if (Email == null || Email.Equals(""))
            {
                MessageBox.Show("Укажите Эмеил студента");
            }
            
            else
            {
                if (selectedFuel.Left <= 0)
                {
                    MessageBox.Show("выбранная группа переполнена");
                }
                else
                {
                    var add = new Order
                    {
                        StdudentName = UserName,
                        StdudentFamilyName = FamilyName,
                        Email = Email,
                        When = DateTime.Now,
                        DistiplinaId = selectedFuel.DistiplinaId,

                    };
                    _db.Orders.Add(add);//добавляем 
                    var d = from dict in _db.Dists select dict;
                    var user = d.FirstOrDefault(x => x.DistiplinaId == selectedFuel.DistiplinaId);
                    var e = (Distiplina)user;
                    e.Left = e.Left - 1;
                    await _db.SaveChangesAsync();

                    MessageBox.Show("студент добавлен");
                    var outter = from dict in _db.Dists select dict;//linq  
                    Distss = new ObservableCollection<Distiplina>(outter);
                }
            }
        }
        
        private void ToOrders(object obj)
        {
            App.HomePage = new home();
            App.MainWindowViewModel.CurrentPage = App.HomePage;
        }
    }
}
