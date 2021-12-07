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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Date
    {
        public int iDay;
        public int iMonth;
        public int iYear;
        public Date(int Day, int Month, int Year)
        {
            if (Month == 1 || Month == 4 || Month == 6 || Month == 9 || Month == 11)
            {
                if (Day > 0 && Day < 31)
                    iDay = Day;
            }
            else if (Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12)
            {
                if (Day > 0 && Day < 32)
                    iDay = Day;
            }
            else if (Month == 2)
            {
                if (Year % 4 == 0 && Day > 0 && Day < 30)
                    iDay = Day;
                else if (Year % 4 != 0 && Day > 0 && Day < 29)
                    iDay = Day;
            }
            if (iDay == 0)
            {
                MessageBox.Show("Проверьте корректность данных!");
                iDay = 0;
            }

            iMonth = Month;
            if (Year > 0)
                iYear = Year;
            else
                MessageBox.Show("Проверьте корректность данных!");
        }

        public override string ToString()
        {
            string name_month;

            switch (iMonth)
            {
                case 1:
                    name_month = "Январь";
                    break;
                case 2:
                    name_month = "Февраль";
                    break;
                case 3:
                    name_month = "Март";
                    break;
                case 4:
                    name_month = "Апрель";
                    break;
                case 5:
                    name_month = "Май";
                    break;
                case 6:
                    name_month = "Июнь";
                    break;
                case 7:
                    name_month = "Июль";
                    break;
                case 8:
                    name_month = "Август";
                    break;
                case 9:
                    name_month = "Сентябрь";
                    break;
                case 10:
                    name_month = "Октябрь";
                    break;
                case 11:
                    name_month = "Ноябрь";
                    break;
                case 12:
                    name_month = "Декабрь";
                    break;
                default:
                    name_month = "нет такого месяца!";
                    break;
            }
            return $"{iDay}  {name_month}  {iYear}";
        }
    }

    public partial class MainWindow : Window
    {
        DateTime today = DateTime.Now;
        Date date;

        static int Check(string str, ref int k)  //Проверка на число
        {
            int num;
            if (!int.TryParse(str, out num))
            {
                if (k == 0)
                    MessageBox.Show("Необходимо целое число");
                k = 1;
                num = 0;
            }
            return num;
        }
        public MainWindow()
        {
            InitializeComponent();
            date = new Date(today.Day, today.Month, today.Year);
            TBDATE.Text = date.ToString();
            TBDATE.IsReadOnly = true;
            CBMONTH.SelectedIndex = today.Month - 1;
            TBDAY.Text = $"{today.Day}";
            TBYEAR.Text = $"{today.Year}";
            BTCH.IsEnabled = false;           
            CBMONTH.IsEnabled = false;
            TBDAY.IsEnabled = false;
            TBYEAR.IsEnabled = false;
        }
        private void BTCH1_Click(object sender, RoutedEventArgs e)
        {
            CBMONTH.IsEnabled = true;
            TBDAY.IsEnabled = true;
            TBYEAR.IsEnabled = true;
            BTCH.IsEnabled = true;
            
            CBMONTH.Opacity = 100;
            TBDATE.Opacity = 100;
            BTCH.Opacity = 100;                    
            BTCH1.Opacity = 50;       
            TBDAY.Opacity = 100;
            TBYEAR.Opacity = 100;           
            TBDAY.Text = $"{date.iDay}";
            TBYEAR.Text = $"{date.iYear}";
        }

        private void BTCH_Click(object sender, RoutedEventArgs e)
        {
            {
                string str_d = TBDAY.Text,
                          str_y = TBYEAR.Text;
                int k = 0,
                    d = Check(str_d, ref k),
                    y = Check(str_y, ref k),
                    m = CBMONTH.SelectedIndex + 1;

                date = new Date(d, m, y);
                if (date.iDay == 0)
                    date.iDay = today.Day;
                if (date.iYear == 0)
                    date.iYear = today.Year;


                TBDATE.Opacity = 50;
                CBMONTH.Opacity = 25;
                TBDAY.Opacity = 50;
                TBYEAR.Opacity = 50;
                BTCH1.Opacity = 100;
                BTCH.Opacity = 50;
                CBMONTH.IsEnabled = false;
                TBDAY.IsEnabled = false;
                TBYEAR.IsEnabled = false;                
                BTCH.IsEnabled = false;
                BTCH1.IsEnabled = true;
                TBDATE.Text = date.ToString();                                
            }
        }
    }
}


    
    



