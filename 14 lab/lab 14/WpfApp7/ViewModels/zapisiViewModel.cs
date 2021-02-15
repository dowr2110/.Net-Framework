using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
using WpfApp7.Commands;
using WpfApp7.pages;
using System.Windows.Controls;
using System.Text.RegularExpressions;

namespace WpfApp7.ViewModels
{
    class zapisiViewModel: ViewModelBase
    {
        private readonly Model1 _db = new Model1();
        private ObservableCollection<Order> orders; 

        public zapisiViewModel()
        {
            Updatecommand = new RellayCommand(Update);
            ToOrdersCommand = new RellayCommand(ToOrders);
            RefreshCommand = new RellayCommand(refresh);

            var outter = from dict in _db.Orders select dict;//linq   
            Orders = new ObservableCollection<Order>(outter);
        }

        public RellayCommand Updatecommand { get; }
        public RellayCommand RefreshCommand { get; }    
        public RellayCommand ToOrdersCommand { get; set; }

        public ObservableCollection<Order> Orders
        {
            get => orders;
            set
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
       
        private void refresh(object o)
        {
            App.ZapisiPage = new zapisi();
            App.MainWindowViewModel.CurrentPage = App.ZapisiPage;
        }
        private void ToOrders(object o)
        {
            App.HomePage = new home();
            App.MainWindowViewModel.CurrentPage = App.HomePage;
        }

        private async void Update(object o)
        {
            MessageBox.Show("Изменении сохранены");
            await _db.SaveChangesAsync();
           
        }
        

    }
}
