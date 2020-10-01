using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WpfApp1.Models;
using WpfApp1.Services;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\ToDoDataList.json";
        private BindingList<ToDoModel> _ToDoData; 
        private BindingList<ToDoModel> _ToDoDataMonday = new BindingList<ToDoModel>();
        private BindingList<ToDoModel> _ToDoDataTuesday = new BindingList<ToDoModel>();
        private BindingList<ToDoModel> _ToDoDataWednesday = new BindingList<ToDoModel>();
        private BindingList<ToDoModel> _ToDoDataThursday = new BindingList<ToDoModel>();
        private BindingList<ToDoModel> _ToDoDataFriday = new BindingList<ToDoModel>();
        private FileIOServices _fileIOServices;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOServices = new FileIOServices(PATH);
            try
            {
                _ToDoData = _fileIOServices.LoadData();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Close();
            }
            if(_ToDoData != null)
            {
                for (int i = 0; i < _ToDoData.Count(); i++)
                {
                    switch (_ToDoData[i].Day)
                    {
                        case 1:
                            _ToDoDataMonday.Add(_ToDoData[i]);
                            break;
                        case 2:
                            _ToDoDataTuesday.Add(_ToDoData[i]);
                            break;
                        case 3:
                            _ToDoDataWednesday.Add(_ToDoData[i]);
                            break;
                        case 4:
                            _ToDoDataThursday.Add(_ToDoData[i]);
                            break;
                        case 5:
                            _ToDoDataFriday.Add(_ToDoData[i]);
                            break;
                        default:
                            break;
                    }

                }
                

            }
            else
                {
                if (_ToDoDataMonday.Count == 0)
                {
                    _ToDoDataMonday.Add(new ToDoModel());
                    _ToDoDataMonday[0].Day = 1;
                    _ToDoDataMonday.Add(new ToDoModel());
                    _ToDoDataMonday[1].Day = 1;
                    _ToDoDataMonday.Add(new ToDoModel());
                    _ToDoDataMonday[2].Day = 1;
                }
                if (_ToDoDataTuesday.Count == 0)
                {
                    _ToDoDataTuesday.Add(new ToDoModel());
                    _ToDoDataTuesday[0].Day = 2;
                    _ToDoDataTuesday.Add(new ToDoModel());
                    _ToDoDataTuesday[1].Day = 2;
                    _ToDoDataTuesday.Add(new ToDoModel());
                    _ToDoDataTuesday[2].Day = 2;
                }
                if (_ToDoDataWednesday.Count == 0)
                {
                    _ToDoDataWednesday.Add(new ToDoModel());
                    _ToDoDataWednesday[0].Day = 3;
                    _ToDoDataWednesday.Add(new ToDoModel());
                    _ToDoDataWednesday[1].Day = 3;
                    _ToDoDataWednesday.Add(new ToDoModel());
                    _ToDoDataWednesday[2].Day = 3;
                }
                if (_ToDoDataThursday.Count == 0)
                {
                    _ToDoDataThursday.Add(new ToDoModel());
                    _ToDoDataThursday[0].Day = 4;
                    _ToDoDataThursday.Add(new ToDoModel());
                    _ToDoDataThursday[1].Day = 4;
                    _ToDoDataThursday.Add(new ToDoModel());
                    _ToDoDataThursday[2].Day = 4;
                }
                if (_ToDoDataFriday.Count == 0)
                {
                    _ToDoDataFriday.Add(new ToDoModel());
                    _ToDoDataFriday[0].Day = 5;
                    _ToDoDataFriday.Add(new ToDoModel());
                    _ToDoDataFriday[1].Day = 5;
                    _ToDoDataFriday.Add(new ToDoModel());
                    _ToDoDataFriday[2].Day = 5;
                }
            }
            dgToDoListMonday.ItemsSource = _ToDoDataMonday;
            dgToDoListTuesday.ItemsSource = _ToDoDataTuesday;
            dgToDoListWednesday.ItemsSource = _ToDoDataWednesday;
            dgToDoListThursday.ItemsSource = _ToDoDataThursday;
            dgToDoListFriday.ItemsSource = _ToDoDataFriday;
        }
            

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindingList<ToDoModel> _ToDoDataOutput = _ToDoDataMonday;
            for (int i = 3; i<15; i++)
            {
                if(i > 2 && i < 6)
                {
                    _ToDoDataOutput.Add(_ToDoDataTuesday[i - 3]);
                }
                if(i > 5 && i < 9)
                {
                    _ToDoDataOutput.Add(_ToDoDataWednesday[i - 6]);
                }
                if (i > 8 && i < 12)
                {
                    _ToDoDataOutput.Add(_ToDoDataThursday[i - 9]);
                }
                if (i > 11)
                {
                    _ToDoDataOutput.Add(_ToDoDataFriday[i - 12]);
                }
            }
            try
            {
                _fileIOServices.SaveData(_ToDoData);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Close();
            }
        }
    }
}
