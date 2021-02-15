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
using System.Windows.Shapes;

namespace lab12
{
    /// <summary>
    /// Логика взаимодействия для Orders.xaml
    /// </summary>
    public partial class Orders : Window
    {
        private readonly Model1 _db = new Model1();
        public Orders()
        {
            InitializeComponent();
            var outter = from dict in _db.Orders select dict;//linq
            Data.DataContext = outter.ToList();
        }
        private async void Dobavit(object sender, RoutedEventArgs e)
        { 
            var lastt = from dict in _db.Orders where dict.UserId==Convert.ToInt32(Id.Text) select dict;//linq
            
            if (Id.Text.Equals("") || Text.Text.Equals("") || Kolic.Text.Equals(""))
            {
                MessageBox.Show("Нужно заполнить все поля перед добавлением");
            }
            else if (lastt.Count() > 0)
            {
                MessageBox.Show("Такой пользователь не существует");
            }
            else
            {
                var add = new Order
                {
                    UserId =Convert.ToInt32(Id.Text),
                    Amount = Convert.ToInt32(Kolic.Text),
                    Text = Text.Text
                };

                _db.Orders.Add(add);//добавляем 
                await _db.SaveChangesAsync();//сохраняем
            }
            var last = from dict in _db.Orders select dict;//linq
            Data.DataContext = last.ToList();
        }
        private void Obnovit(object sender, RoutedEventArgs e)
        {
            var outter = from dict in _db.Orders select dict;//linq
            Data.DataContext = outter.ToList();
        }
        private async void Udalit(object sender, RoutedEventArgs e)
        {
            var p1 = (Order)Data.SelectedItem;//полнчаем выбранное поле с datagrid(явно указываем тип)
            if (p1 != null)
            {
                _db.Orders.Remove(p1);
                await _db.SaveChangesAsync();
                var last = from dict in _db.Orders select dict;
                Data.DataContext = last.ToList();
            }
            else
            {
                MessageBox.Show("Выберите какую строку удалить");
            }

        }
        private async void Izmenit(object sender, RoutedEventArgs e)
        {
            var p1 = (Order)Data.SelectedItem;
            if (p1 == null)
            {
                MessageBox.Show("Нужно выбрать элемент который хотим изменить!\n(Можно изменить только Количесто и Текст)");
            }
            else
            {
                if (!Kolic.Text.Equals(""))
                {
                    p1.Amount = Convert.ToInt32(Kolic.Text);
                    await _db.SaveChangesAsync();
                    var outter = from dict in _db.Orders select dict;
                    Data.DataContext = outter.ToList();
                    MessageBox.Show("Количество изменено");
                }

                else if (!Text.Text.Equals(""))
                {
                    p1.Text = Text.Text;
                    await _db.SaveChangesAsync();
                    var outter = from dict in _db.Orders select dict;
                    Data.DataContext = outter.ToList();
                    MessageBox.Show("Пороль изменен");
                }
                else
                {
                    MessageBox.Show("Поля пустые\n(Можно изменить только Количесто и Текст)");
                }
            }
        }
         
        private void Poisk1(object sender, RoutedEventArgs e)
        {
            var outter = from dict in _db.Orders select dict;
            var serch = outter.ToList();
            Regex r = new Regex(Id.Text);
            Regex r2 = new Regex(Kolic.Text);
            Regex r3 = new Regex(Text.Text);
            var list = new List<Order>();
            foreach (var item in serch)
            {
                if (r.IsMatch(Convert.ToString(item.OrderId)) && Id.Text.Equals("") != true)
                { list.Add(item); continue; }
                if ( r2.IsMatch(Convert.ToString(item.Amount)) && Kolic.Text.Equals("") != true)
                { list.Add(item); continue; }
                if (r3.IsMatch(item.Text) && Text.Text.Equals("") != true)
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
            var outter = from dict in _db.Orders select dict;
            var serch = outter.ToList();
            var list = new List<Order>();
            Regex r = new Regex(Id.Text);
            Regex r2 = new Regex(Kolic.Text);
            Regex r3 = new Regex(Text.Text);//name=UsrId Email=Amount Password=Text
            foreach (var item in serch)
            {
                if ((r.IsMatch(Convert.ToString(item.OrderId)) && !Id.Text.Equals("")) &&
                    (r2.IsMatch(Convert.ToString(item.Amount)) && !Kolic.Text.Equals("")))
                { list.Add(item); continue; }
                if ((r2.IsMatch(Convert.ToString(item.Amount)) && !Kolic.Text.Equals("")) &&
                    (r3.IsMatch(item.Text)) && !Text.Text.Equals(""))
                { list.Add(item); continue; }
                if ((r.IsMatch(Convert.ToString(item.OrderId)) && !Id.Text.Equals("")) &&
                    (r3.IsMatch(item.Text)) && !Text.Text.Equals(""))
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
            Id.Clear();
            Text.Clear();
            Kolic.Clear();
        }
    }
}
