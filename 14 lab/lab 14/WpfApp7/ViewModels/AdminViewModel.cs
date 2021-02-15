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
    class AdminViewModel :ViewModelBase
    {
        private readonly Model1 _db = new Model1();
        private ObservableCollection<Distiplina> dists;
        private string searchtbx;
        private string teacherName;
        private double left;
        private double hours;
        public Distiplina selectedDist;

        public AdminViewModel()
        {
            Updatecommand = new RellayCommand(Update); 
            ToOrdersCommand = new RellayCommand(ToOrders);
            Addcommand = new RellayCommand(Add);
            RefreshCommand = new RellayCommand(refresh);
            DeleteCommand = new RellayCommand(Delete);

            var outter = from dict in _db.Dists select dict;//linq   
            Dists = new ObservableCollection<Distiplina>(outter);
        }

        public RellayCommand Updatecommand { get; } 
        public RellayCommand RefreshCommand { get; } 
        public RellayCommand ToOrdersCommand { get; set; }
        public RellayCommand Addcommand { get; set; } 
        public RellayCommand DeleteCommand { get; set; }

        public ObservableCollection<Distiplina> Dists
        {
            get => dists;
            set
            {
                dists = value;
                OnPropertyChanged(nameof(Dists));
            }
        }
        public Distiplina SelectedDist
        {
            get { return selectedDist; }
            set
            {
                selectedDist = value;
                OnPropertyChanged(nameof(SelectedDist));
            }
        }
        public string Name
        {
            get { return searchtbx; }
            set
            {
                searchtbx = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string TeacherName
        {
            get { return teacherName; }
            set
            {
                teacherName = value;
                OnPropertyChanged(nameof(TeacherName));
            }
        }
        public double Hours
        {
            get { return hours; }
            set
            {
                hours = value;
                OnPropertyChanged(nameof(TeacherName));
            }
        }
        public double Left
        {
            get { return left; } 
            set
            {
                left = value;
                OnPropertyChanged(nameof(TeacherName));
            }
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
        private void refresh(object o)
        {
            App.Addists = new addists();
            App.MainWindowViewModel.CurrentPage = App.Addists;
        }
        private void Delete(object o)
        {
            if (selectedDist == null)
            {
                MessageBox.Show("Выберите какую запись удалять");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить выбранную дисциплину?", "Предупреждение!", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        _db.Dists.Remove(selectedDist);
                        _db.SaveChanges();
                        break;
                    case MessageBoxResult.No:
                        break;
                }
                var outter = from dict in _db.Dists select dict;//linq 
                Dists = new ObservableCollection<Distiplina>(outter);
            }

        }
        private void Add(object o)
        {
            if (Name == null ||Name.Equals(""))
            {
                MessageBox.Show("Выберите Имя");
            }
            else if (TeacherName == null || TeacherName.Equals(""))
            {
                MessageBox.Show("Укажите Имя Преподователя");
            }
            else if (Left == 0)
            {
                MessageBox.Show("Укажите остаток занятии");
            }
            else if (Hours == 0)
            {
                MessageBox.Show("Укажите количество часов");
            }

            else
            {

                var add = new Distiplina
                {
                    Name = Name,
                    TeacherName = TeacherName,
                    Hours = Hours,
                    Left=Left

                };
                _db.Dists.Add(add);//добавляем 
               
             
                 _db.SaveChanges();

                MessageBox.Show("дистиплина добавлена");
                var outter = from dict in _db.Dists select dict;//linq  
                Dists = new ObservableCollection<Distiplina>(outter);
            }
        }



    }
}




//var fuel =_db.Fuels.Find(1);
//_db.Fuels.Remove(fuel);
//_db.SaveChanges();

     

//private string namee;
//public string Namee
//{
//    get { return namee; }
//    set
//    {
//        namee = value;
//        OnPropertyChanged(nameof(Namee));
//    }
//}

//var datagrid = o as DataGrid;

//var p1 = (Order)datagrid.SelectedItem;
//if (p1 == null)
//{
//    MessageBox.Show("Нужно выбрать элемент который хотим изменить!");
//}
//else
//{
//    p1.Status = Namee;
//    await _db.SaveChangesAsync();

//}