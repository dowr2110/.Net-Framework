using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
 
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.IO;
using Microsoft.Win32;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DataTable _studTable = new DataTable();
        private readonly DataTable _studTable1 = new DataTable();
        private readonly SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
      //  private readonly SqlConnection connection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public MainWindow()
        {
            InitializeComponent();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Scet", connection);
            SqlDataAdapter adapter1 = new SqlDataAdapter("Select * from InfoUser", connection);
            adapter.Fill(_studTable);
            adapter1.Fill(_studTable1);
            DGrid.ItemsSource = _studTable.DefaultView;
            DGrid1.ItemsSource = _studTable1.DefaultView;
            


            // устанавливаем команду на вставку
            adapter.InsertCommand = new SqlCommand("tb", connection);
            // это будет зранимая процедура
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
            // добавляем параметры
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Nomer", SqlDbType.Int, 0, "Nomer"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Tip_vklada", SqlDbType.NVarChar, 100, "Tip_vklada"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Balans", SqlDbType.Int, 0, "Balans"));
            adapter.InsertCommand.Parameters.Add(new SqlParameter("@Data_otryt", SqlDbType.Date,100, "Data_otryt"));


            //установка команды на добавление для вызова хранимой процедуры
            adapter1.InsertCommand = new SqlCommand("tb1", connection);
            adapter1.InsertCommand.CommandType = CommandType.StoredProcedure;
            adapter1.InsertCommand.Parameters.Add(new SqlParameter("@Nomer", SqlDbType.Int, 0, "Nomer"));
            adapter1.InsertCommand.Parameters.Add(new SqlParameter("@Family_name", SqlDbType.NVarChar, 100, "Family_name"));
            adapter1.InsertCommand.Parameters.Add(new SqlParameter("@Name_name", SqlDbType.NVarChar, 100, "Name_name"));
            adapter1.InsertCommand.Parameters.Add(new SqlParameter("@Pasport_no", SqlDbType.NVarChar, 100, "Pasport_no"));
            adapter1.InsertCommand.Parameters.Add(new SqlParameter("@Mesto_rojdeniya", SqlDbType.NVarChar, 100, "Mesto_rojdeniya"));
            adapter1.InsertCommand.Parameters.Add(new SqlParameter("@Data_rojd", SqlDbType.Date, 100, "Data_rojd"));

             
            connection.Close();
        }

        private  void Obnovit(object sender, RoutedEventArgs e)
        {
            _studTable.Clear();
            _studTable1.Clear();
             connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Scet", connection);
            SqlDataAdapter adapter1 = new SqlDataAdapter("Select * from InfoUser", connection);
            adapter.Fill(_studTable);
            adapter1.Fill(_studTable1);
            DGrid.ItemsSource = _studTable.DefaultView;
            DGrid1.ItemsSource = _studTable1.DefaultView;
            connection.Close();
        }

        private  void Dobavit(object sender, RoutedEventArgs e)
        {
             connection.Open();
            if (nomer.Text.Equals("") ||
                tip.Text.Equals("") ||
                balans.Text.Equals("") ||
                data_otk.Text.Equals(""))
            { MessageBox.Show("Чтобы добавить элемент нужно заполнить все поля!"); }
            else
            {
                string Value =
                $"Insert into Scet(Nomer,Tip_vklada,Balans,Data_otryt) values({nomer.Text},'{tip.Text}','{balans.Text}','{data_otk.Text}')";
                SqlCommand command = new SqlCommand(Value, connection);
                 command.ExecuteNonQuery();
                _studTable.Clear();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Scet", connection);
                adapter.Fill(_studTable);
                DGrid.ItemsSource = _studTable.DefaultView;
            }

            connection.Close();
        }
        private  void Dobavit1(object sender, RoutedEventArgs e)
        {
          
            if (nomer1.Text.Equals("") ||
                familiya.Text.Equals("") ||
                imya.Text.Equals("") ||
                pasport.Text.Equals("") ||
                dataroj.Text.Equals("") ||
                mestoroj.Text.Equals(""))
            { MessageBox.Show("Чтобы добавить элемент нужно заполнить все поля!"); }
            else
            {
                 connection.Open();
                string Value =
                $"Insert into InfoUser(Nomer, Family_name, Name_name,Pasport_no,Mesto_rojdeniya,Data_rojd) values({nomer1.Text},'{familiya.Text}','{imya.Text}','{pasport.Text}','{mestoroj.Text}','{dataroj.Text}')";
                SqlCommand command = new SqlCommand(Value, connection);
                 command.ExecuteNonQuery();
                _studTable1.Clear();
                SqlDataAdapter adapter12 = new SqlDataAdapter("Select * from InfoUser", connection);
                adapter12.Fill(_studTable1);
                DGrid1.ItemsSource = _studTable1.DefaultView;
                connection.Close();
            }
         
        
        }
        private  void Delete(object sender, RoutedEventArgs e)
        {
             connection.Open();
            string Value =
                $"Delete From Scet where (Nomer = '{nomer.Text}' or Tip_vklada= '{tip.Text}' or Balans= '{balans.Text}' or Data_otryt = '{data_otk.Text}')";
            SqlCommand command = new SqlCommand(Value, connection);
             command.ExecuteNonQuery();
            _studTable.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Scet", connection);
            adapter.Fill(_studTable);
            DGrid.ItemsSource = _studTable.DefaultView;
            connection.Close();
        }
        private  void Delete1(object sender, RoutedEventArgs e)
        {
             connection.Open();
            string Value =
                $"Delete From InfoUser where (Nomer = '{nomer1.Text}' or Family_name= '{familiya.Text}' or Name_name= '{imya.Text}' or Pasport_no = '{pasport.Text}'or Mesto_rojdeniya = '{mestoroj.Text}'or Data_rojd = '{dataroj.Text}')";
            SqlCommand command = new SqlCommand(Value, connection);
             command.ExecuteNonQuery();
            _studTable1.Clear();
            SqlDataAdapter adapter1 = new SqlDataAdapter("Select * from InfoUser", connection);
            adapter1.Fill(_studTable);
            DGrid1.ItemsSource = _studTable1.DefaultView;   
            connection.Close();
        }
        private  void Izmenit(object sender, RoutedEventArgs e)
        {
             connection.Open();
            if (nomer.Text.Equals("") )
            { MessageBox.Show("Чтобы изменить элемент нужно заполнить поля 'Номер счета' !"); }
            else
            {
              
                if (!tip.Text.Equals(""))
                {
                    string v= $"Update Scet Set Tip_vklada='{tip.Text}'  where Nomer='{nomer.Text}'";
                    SqlCommand command = new SqlCommand(v, connection);
                    command.ExecuteNonQuery();
                }
                if (!balans.Text.Equals(""))
                {
                    string v = $"Update Scet Set Balans='{balans.Text}'  where Nomer='{nomer.Text}'";
                    SqlCommand command = new SqlCommand(v, connection);
                    command.ExecuteNonQuery();
                }
                if (!data_otk.Text.Equals(""))
                {
                    string v = $"Update Scet Set Data_otryt='{data_otk.Text}'  where Nomer='{nomer.Text}'";
                    SqlCommand command = new SqlCommand(v, connection);
                    command.ExecuteNonQuery();
                }
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Scet", connection);
                adapter.Fill(_studTable);
                DGrid.ItemsSource = _studTable.DefaultView;
                MessageBox.Show("Изменено");
            }
            connection.Close();
        }
        private  void Izmenit1(object sender, RoutedEventArgs e)
        {
             connection.Open();
            if (nomer1.Text.Equals(""))
            { MessageBox.Show("Чтобы изменить элемент нужно заполнить поля 'Номер счета' !"); }
            else
            {
 
                if (!familiya.Text.Equals(""))
                {
                    string v = $"Update InfoUser Set Family_name='{familiya.Text}'  where Nomer='{nomer1.Text}'";
                    SqlCommand command = new SqlCommand(v, connection);
                    command.ExecuteNonQuery();
                }
                if (!imya.Text.Equals(""))
                {
                    string v = $"Update InfoUser Set Name_name='{imya.Text}'  where Nomer='{nomer1.Text}'";
                    SqlCommand command = new SqlCommand(v, connection);
                    command.ExecuteNonQuery();
           
                }
                if (!pasport.Text.Equals(""))
                {
                    string v = $"Update InfoUser Set Pasport_no='{pasport.Text}'  where Nomer='{nomer1.Text}'";
                    SqlCommand command = new SqlCommand(v, connection);
                    command.ExecuteNonQuery();
         
                }
                if (!mestoroj.Text.Equals(""))
                {
                    string v = $"Update InfoUser Set Mesto_rojdeniya='{mestoroj.Text}'  where Nomer='{nomer1.Text}'";
                    SqlCommand command = new SqlCommand(v, connection);
                    command.ExecuteNonQuery();
            
                }
                if (!dataroj.Text.Equals(""))
                {
                    string v = $"Update Scet InfoUser Data_rojd='{dataroj.Text}'  where Nomer='{nomer1.Text}'";
                    SqlCommand command = new SqlCommand(v, connection);
                    command.ExecuteNonQuery();
                   
                }
               
                SqlDataAdapter adapter1 = new SqlDataAdapter("Select * from InfoUser", connection);
                adapter1.Fill(_studTable);
                DGrid1.ItemsSource = _studTable1.DefaultView;
                MessageBox.Show("Изменено");
            }
            connection.Close();
        }
        private  void Tranzaks(object sender, RoutedEventArgs e)
        {

            connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            SqlCommand command = connection.CreateCommand();
            command.Transaction = transaction;

            try
            {
                command.CommandText = "INSERT INTO Scet (Nomer, Tip_vklada, Balans,Data_otryt) VALUES(2, 'Чета ТАМ', 5000,'01.01.2001')";
                command.ExecuteNonQuery();
                command.CommandText = "INSERT INTO InfoUser (Nomer, Family_name, Name_name,Pasport_no,Mesto_rojdeniya,Data_rojd) VALUES(2, 'Атаев', 'Довр','254DGF4','Ашгабат','21.03.2000')";
                command.ExecuteNonQuery(); 


                transaction.Commit();
                MessageBox.Show("Data added to database");
                TransactionButton.IsEnabled = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                transaction.Rollback();
            }
            _studTable.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from Scet", connection);
            adapter.Fill(_studTable);
            DGrid.ItemsSource = _studTable.DefaultView;

            _studTable1.Clear();
            SqlDataAdapter adapter1 = new SqlDataAdapter("Select * from InfoUser", connection);
            adapter1.Fill(_studTable1);
            DGrid1.ItemsSource = _studTable1.DefaultView;
            connection.Close();

        }

        private void ocistit(object sender, RoutedEventArgs e)
        {
            nomer1.Clear();
            familiya.Clear();
            imya.Clear();
            dataroj.Clear();
            pasport.Clear();
            mestoroj.Clear();
            nomer.Clear();
            tip.Clear();
            balans.Clear();
            data_otk.Clear();
        }

        private async void Sort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await connection.OpenAsync();
            if (Combo.SelectedIndex == 0)
            {
                _studTable1.Clear();
                SqlDataAdapter adapter1 = new SqlDataAdapter("Select * from InfoUser order by Family_name", connection);
                adapter1.Fill(_studTable1);
                DGrid1.ItemsSource = _studTable1.DefaultView;
            }
            else if (Combo.SelectedIndex == 1)
            {
                _studTable1.Clear();
                SqlDataAdapter adapter1 = new SqlDataAdapter("Select * from InfoUser order by Name_name", connection);
                adapter1.Fill(_studTable1);
                DGrid1.ItemsSource = _studTable1.DefaultView;
            }
            else if (Combo.SelectedIndex == 2)
            {
                _studTable1.Clear();
                SqlDataAdapter adapter1 = new SqlDataAdapter("Select * from InfoUser order by Pasport_no", connection);
                adapter1.Fill(_studTable1);
                DGrid1.ItemsSource = _studTable1.DefaultView;
            }
            else if (Combo.SelectedIndex == 3)
            {
                _studTable1.Clear();
                SqlDataAdapter adapter1 = new SqlDataAdapter("Select * from InfoUser order by Mesto_rojdeniya", connection);
                adapter1.Fill(_studTable1);
                DGrid1.ItemsSource = _studTable1.DefaultView;
            }
            else if (Combo.SelectedIndex == 4)
            {
                _studTable1.Clear();
                SqlDataAdapter adapter1 = new SqlDataAdapter("Select * from InfoUser order by Data_rojd", connection);
                adapter1.Fill(_studTable1);
                DGrid1.ItemsSource = _studTable1.DefaultView;
            }
            else if (Combo.SelectedIndex == 5)
            {
                _studTable1.Clear();
                SqlDataAdapter adapter1 = new SqlDataAdapter("Select * from InfoUser order by Nomer", connection);
                adapter1.Fill(_studTable1);
                DGrid1.ItemsSource = _studTable1.DefaultView;
                _studTable.Clear();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from Scet order by Nomer", connection);
                adapter.Fill(_studTable);
                DGrid.ItemsSource = _studTable.DefaultView;
            }

            connection.Close();


        }

        private void Dobavit_fotky(object sender, RoutedEventArgs e)
        {

            connection.Open();
            if (!nomer1.Text.Equals(""))
            {
                //    if (Combo_Copy.SelectedIndex == 0)
                //    {
                string filename="";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files|*.png;*.jpg";
            if (openFileDialog.ShowDialog() == true)
            {
                filename = openFileDialog.FileName;
            }


                    SqlCommand command = new SqlCommand();
                    command.Connection = connection;
                    command.Parameters.Add("@Picture", SqlDbType.Image, 1000000);
                    //string filename = @"C:\Users\Админ\Desktop\Новая папка\0.PNG";

                    string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); // cats.jpg
                                                                                               // массив для хранения бинарных данных файла
                    byte[] imageData;
                    using (System.IO.FileStream fs = new System.IO.FileStream(filename, FileMode.Open))
                    {
                        imageData = new byte[fs.Length];
                        fs.Read(imageData, 0, imageData.Length);
                    }
                    command.Parameters["@Picture"].Value = imageData;
                    command.CommandText = $"Update InfoUser Set Picture= @Picture where Nomer='{nomer1.Text}'";
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Картинка добавлена!!");
                //}
                //else if (Combo_Copy.SelectedIndex == 1)
                //{

                //    SqlCommand command = new SqlCommand();
                //    command.Connection = connection;
                //    command.Parameters.Add("@Picture", SqlDbType.Image, 1000000);
                //    string filename = @"C:\Users\Админ\Desktop\Новая папка\1.PNG";

                //    string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); // cats.jpg
                //                                                                               // массив для хранения бинарных данных файла
                //    byte[] imageData;
                //    using (System.IO.FileStream fs = new System.IO.FileStream(filename, FileMode.Open))
                //    {
                //        imageData = new byte[fs.Length];
                //        fs.Read(imageData, 0, imageData.Length);
                //    }
                //    command.Parameters["@Picture"].Value = imageData;
                //    command.CommandText = $"Update InfoUser Set Picture= @Picture where Nomer='{nomer1.Text}'";
                //    command.ExecuteNonQuery();
                //    connection.Close();
                //    MessageBox.Show("Картинка добавлена!!");
                //}
                //else if (Combo_Copy.SelectedIndex == 2)
                //{

                //    SqlCommand command = new SqlCommand();
                //    command.Connection = connection;
                //    command.Parameters.Add("@Picture", SqlDbType.Image, 1000000);
                //    string filename = @"C:\Users\Админ\Desktop\Новая папка\2.PNG";

                //    string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); // cats.jpg
                //                                                                               // массив для хранения бинарных данных файла
                //    byte[] imageData;
                //    using (System.IO.FileStream fs = new System.IO.FileStream(filename, FileMode.Open))
                //    {
                //        imageData = new byte[fs.Length];
                //        fs.Read(imageData, 0, imageData.Length);
                //    }
                //    command.Parameters["@Picture"].Value = imageData;
                //    command.CommandText = $"Update InfoUser Set Picture= @Picture where Nomer='{nomer1.Text}'";
                //    command.ExecuteNonQuery();
                //    connection.Close();
                //    MessageBox.Show("Картинка добавлена!!");
                //}
                //else if (Combo_Copy.SelectedIndex == 3)
                //{

                //    SqlCommand command = new SqlCommand();
                //    command.Connection = connection;
                //    command.Parameters.Add("@Picture", SqlDbType.Image, 1000000);
                //    string filename = @"C:\Users\Админ\Desktop\Новая папка\3.PNG";

                //    string shortFileName = filename.Substring(filename.LastIndexOf('\\') + 1); // cats.jpg
                //                                                                               // массив для хранения бинарных данных файла
                //    byte[] imageData;
                //    using (System.IO.FileStream fs = new System.IO.FileStream(filename, FileMode.Open))
                //    {
                //        imageData = new byte[fs.Length];
                //        fs.Read(imageData, 0, imageData.Length);
                //    }
                //    command.Parameters["@Picture"].Value = imageData;
                //    command.CommandText = $"Update InfoUser Set Picture= @Picture where Nomer='{nomer1.Text}'";
                //    command.ExecuteNonQuery();
                //    connection.Close();
                //    MessageBox.Show("Картинка добавлена!!");
                //}
            }
            else
            {
                MessageBox.Show("Выберите номер счета");
            }
        }
    }
}
