using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Model1 _db = new Model1();
        public MainWindow()
        {
            InitializeComponent();
            var outter = from dict in _db.MyEntities select dict;//linq
            Data.DataContext = outter.ToList();
        }
        private async void Dobavit(object sender, RoutedEventArgs e)
        {
            if (Name.Text.Equals("") || Email.Text.Equals("") || Password.Password.Equals(""))
            {
                MessageBox.Show("Нужно заполнить все поля перед добавлением");
            }
            else
            {
                var add = new MyEntity
                {
                    Name = Name.Text,
                    Email = Email.Text,
                    Password = Password.Password
                };
            
                _db.MyEntities.Add(add);//добавляем 
                await _db.SaveChangesAsync();//сохраняем
            }
            var last = from dict in _db.MyEntities select dict;//linq
            Data.DataContext = last.ToList();
        }
        private void Obnovit(object sender, RoutedEventArgs e)
        {
            var outter = from dict in _db.MyEntities select dict;//linq
            Data.DataContext = outter.ToList();
        }
        private async void Udalit(object sender, RoutedEventArgs e)
        {
            var p1 = (MyEntity)Data.SelectedItem;//полнчаем выбранное поле с datagrid(явно указываем тип)
            if (p1 != null)
            {
                _db.MyEntities.Remove(p1);
                await _db.SaveChangesAsync();
                var last = from dict in _db.MyEntities select dict;
                Data.DataContext = last.ToList();
            }
            else
            {
                MessageBox.Show("Выберите какую строку удалить");
            }
          
        }
        private async void Izmenit(object sender, RoutedEventArgs e)
        {
            var p1 = (MyEntity)Data.SelectedItem;
            if (p1 == null)
            {
                MessageBox.Show("Нужно выбрать элемент который хотим изменить!");
            }
            else
            {
                if (!Name.Text.Equals(""))
                { 
                    p1.Name = Name.Text;
                    await _db.SaveChangesAsync();
                    var outter = from dict in _db.MyEntities select dict;
                    Data.DataContext = outter.ToList();
                    MessageBox.Show("Имя изменено");
                } 
               else if (!Email.Text.Equals(""))
                {
                    p1.Email = Email.Text;
                    await _db.SaveChangesAsync();
                    var outter = from dict in _db.MyEntities select dict;
                    Data.DataContext = outter.ToList();
                    MessageBox.Show("Эмеил изменен");
                }
               
               else if (!Password.Password.Equals(""))
                {
                    p1.Password = Password.Password;
                    await _db.SaveChangesAsync();
                    var outter = from dict in _db.MyEntities select dict;
                    Data.DataContext = outter.ToList();
                    MessageBox.Show("Пороль изменен");
                }
                else
                {
                    MessageBox.Show("Поля пустые");
                }
            }
        }

        private async void sql(object sender, RoutedEventArgs e)
        {
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Database.ExecuteSqlCommand(@"UPDATE dbo.MyEntities SET Email = 'sobaka@mail.ru' WHERE Name = 'Sobaka'");
                    _db.MyEntities.Add(new MyEntity { Email = "bob@mail.ru", Name = "Bob", Id = 20, Password = "9832" });
                    await _db.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                }
            }
            var last = from dict in _db.MyEntities select dict;
            Data.DataContext = last.ToList();
            tranzak.IsEnabled = false;
        }
        private void Poisk1(object sender, RoutedEventArgs e)
        {
            var outter = from dict in _db.MyEntities select dict;
            var serch = outter.ToList();
            var list = new List<MyEntity>();
            Regex r = new Regex(Name.Text);
            Regex r2 = new Regex(Email.Text);
            Regex r3 = new Regex(Password.Password);
            foreach (var item in serch)
            {
                if (r.IsMatch(item.Name) && Name.Text.Equals("") != true)
                { list.Add(item); continue; }
                if (r2.IsMatch(item.Email) && Email.Text.Equals("") != true)
                { list.Add(item); continue; }
                if (r3.IsMatch(item.Password) && Password.Password.Equals("") != true)
                { list.Add(item); }
            }
            if (list.Count > 0)
                Data.DataContext = list;
            else
                MessageBox.Show("Введите информацию для поиска хотя бы в одну из полей или проверьте корректность ввода! !");
            var last = from dict in list select dict;
            Data.DataContext = last.ToList();
        }
        private void Poisk2(object sender, RoutedEventArgs e)
        {
            var outter = from dict in _db.MyEntities select dict;
            var serch = outter.ToList();
            var list = new List<MyEntity>();
            Regex r = new Regex(Name.Text);
            Regex r2 = new Regex(Email.Text);//r2.IsMatch(item.Email)
            Regex r3 = new Regex(Password.Password);//r3.IsMatch(item.Password)
            foreach (var item in serch)
            {
                if ((r.IsMatch(item.Name) && !Name.Text.Equals("")) &&
                    (r2.IsMatch(item.Email) && !Email.Text.Equals("")))
                { list.Add(item); continue; }
                if ((r2.IsMatch(item.Email) && !Email.Text.Equals("")) &&
                    (r3.IsMatch(item.Password) && !Password.Password.Equals("")))
                { list.Add(item); continue; }
                if ((r.IsMatch(item.Name) && !Name.Text.Equals("")) &&
                    (r3.IsMatch(item.Password) && !Password.Password.Equals("")))
                { list.Add(item); }
            }
            if (list.Count > 0)
                Data.DataContext = list;
            else
                MessageBox.Show("Введите информацию для поиска хотя бы в двух полей или проверьте корректность ввода!");
            var last = from dict in list select dict;
            Data.DataContext = last.ToList();
        }

        private void Ocistit(object sender, RoutedEventArgs e)
        {
            Password.Clear();
            Email.Clear();
            Name.Clear();
        }

        private void ToOrders(object sender, RoutedEventArgs e)
        {
            Orders o = new Orders();
            o.Show(); 
        }
    }
}
