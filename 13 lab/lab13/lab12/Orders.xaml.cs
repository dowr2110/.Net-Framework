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
        // private readonly Model1 _db = new Model1();
        private readonly UnitOfWork un = new UnitOfWork();
        public Orders()
        {
            InitializeComponent();
            var outter = un.Orders.GetAll();
            Data.DataContext = outter.ToList();
        }
        public void Update()
        {
            var outter = un.Orders.GetAll();
            Data.DataContext = outter.ToList();
        }
        private void Dobavit(object sender, RoutedEventArgs e)
        {
            if (Id.Text.Equals("") || Text.Text.Equals("") || Kolic.Text.Equals(""))
            {
                MessageBox.Show("Нужно заполнить все поля перед добавлением");
            }
            else
            {
                var add = new Order
                {
                    UserId =Convert.ToInt32(Id.Text),
                    Amount = Convert.ToInt32(Kolic.Text),
                    Text = Text.Text
                };
                un.Orders.Create(add);
                un.Save();
                //_db.Orders.Add(add);//добавляем 
                //await _db.SaveChangesAsync();//сохраняем
            }
            Update();
        }
        private void Obnovit(object sender, RoutedEventArgs e)
        {
            Update();
        }
        private  void Udalit(object sender, RoutedEventArgs e)
        {
            var p1 = (Order)Data.SelectedItem;//полнчаем выбранное поле с datagrid(явно указываем тип)
            if (p1 != null)
            {
                //_db.Orders.Remove(p1);
                //await _db.SaveChangesAsync();
                un.Orders.Delete(p1.OrderId);
                un.Save();
                Update();
            }
            else
            {
                MessageBox.Show("Выберите какую строку удалить");
            }

        }
        private void Izmenit(object sender, RoutedEventArgs e)
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
                    //await _db.SaveChangesAsync();
                    un.Save();
                    Update();
                    MessageBox.Show("Количество изменено");
                }

                else if (!Text.Text.Equals(""))
                {
                    p1.Text = Text.Text;
                    un.Save();
                    Update();
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
            var outter = un.Orders.GetAll();
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
            var outter = un.Orders.GetAll();
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
