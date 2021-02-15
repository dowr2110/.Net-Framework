using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
namespace lab_7_8_new
{
    public class Command : ICommand
    {
        Action<object> executeMethod;
        Func<object, bool> canexecuteMethod;

        public Command(Action<object> executeMethod,    Func<object, bool> canexecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canexecuteMethod = canexecuteMethod;
        }
       

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }
        public event EventHandler CanExecuteChanged;

    }

    /*nikitos*/

    //        CommandBinding createcommandBinding = new CommandBinding();
    //        CommandBinding deletecommandBinding = new CommandBinding();
    //        CommandBinding editcommandBinding = new CommandBinding();
    //        CommandBinding savecommand = new CommandBinding();
    //        CommandBinding opencommandbin = new CommandBinding();
    //        CommandBinding ExitcommandBinding = new CommandBinding();
    //        CommandBinding SearchCommandBinding = new CommandBinding();
    //        ///////////////////////////
    //        SearchCommandBinding.Command = ApplicationCommands.Find;
    //SearchCommandBinding.Executed += Search;
    //Find.CommandBindings.Add(SearchCommandBinding);
    /////////////////////////////////
    //savecommand.Command = ApplicationCommands.Save;
    //savecommand.Executed += savecommand_Executed;
    //Save.CommandBindings.Add(savecommand);
    //////////////////////////////
    //opencommandbin.Command = ApplicationCommands.Open;
    //opencommandbin.Executed += Open_Executed;
    //Open.CommandBindings.Add(opencommandbin);
    //////////////////////////////
    //ExitcommandBinding.Command = ApplicationCommands.Close;
    //ExitcommandBinding.Executed += ExitcommandBinding_execute;
    //Exit.CommandBindings.Add(ExitcommandBinding);

    //// устанавливаем команду
    //createcommandBinding.Command = ApplicationCommands.New;
    //// устанавливаем метод, который будет выполняться при вызове команды
    //createcommandBinding.Executed += Create_Executed;
    //// добавляем привязку к коллекции привязок элемента Button
    //Add.CommandBindings.Add(createcommandBinding);


    //////////////////////
    //deletecommandBinding.Command = ApplicationCommands.Delete;
    //deletecommandBinding.Executed += Delete_Executed;
    ////delete.CommandBindings.Add(deletecommandBinding);
    ///////////////////////
    //editcommandBinding.Command = ApplicationCommands.Replace;
    //editcommandBinding.Executed += Edit_Executed;
    //Edit.CommandBindings.Add(editcommandBinding);


    //            private void Edit_Executed(object sender, ExecutedRoutedEventArgs e)
    //        {
    //            TODOList CurrentTask = (TODOList)TODOLIST.SelectedItem;
    //            CurrentTask.Name = name.Text;
    //            CurrentTask.Info = info.Text;
    //            CurrentTask.Done = Convert.ToBoolean(Done.Header);
    //            CurrentTask.Categoria = cat.Text;
    //            CurrentTask.Difficult = phonesList.Text;
    //            TODOLIST.ItemsSource = lists;
    //        }






}
