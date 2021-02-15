using System;
using System.Collections.Generic; 
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text; 
using System.Windows;
using System.Windows.Controls;
using WpfApp7.Commands;
using WpfApp7.pages;
namespace WpfApp7.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private readonly Model1 _db = new Model1();
        public Order selectedOrder;
        public HomeViewModel()
        {
            TozapasiCommand = new RellayCommand(Tozapisi);
            AddDistsCommand = new RellayCommand(AddDists);
            AddOrderCommand = new RellayCommand(AddOrder);
            DeleteComand = new RellayCommand(Delete);
            var outter = from dict in _db.Orders select dict;//linq
            Orders = new ObservableCollection<Order>(outter);

        }
        public ObservableCollection<Order> Orders { get; set; }
        public RellayCommand AddOrderCommand { get; }
        public RellayCommand AddDistsCommand { get; }
        public RellayCommand TozapasiCommand { get; }
        public RellayCommand DeleteComand { get; }

        public Order SelectedOrder
        {
            get => selectedOrder;
            set
            {
                selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }
        public void Tozapisi(object o)
        {
            App.ZapisiPage = new zapisi();
            App.MainWindowViewModel.CurrentPage = App.ZapisiPage;
        }
        public void AddDists(object o)
        {
            App.Addists = new addists();
            App.MainWindowViewModel.CurrentPage = App.Addists;
        }
        public void AddOrder(object o)
        {
            App.AddorderPage = new addorder();
            App.MainWindowViewModel.CurrentPage = App.AddorderPage;
        }
        public void Delete(object o)
        {
            if (selectedOrder == null)
            {
                MessageBox.Show("Выберите какую запись удалять");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить выбранную запись?", "Предупреждение!", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        _db.Orders.Remove(selectedOrder);
                        _db.SaveChanges();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
                var outter = from dict in _db.Orders select dict;//linq 
                Orders = new ObservableCollection<Order>(outter);
            }

        }
    }
}
