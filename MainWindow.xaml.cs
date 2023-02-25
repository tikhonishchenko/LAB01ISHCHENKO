using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
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

namespace LAB01ISHCHENKO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DateChanged(object sender, SelectionChangedEventArgs e)
        {            
            CalculateAge();
            CalculateHoroscopes();
        }

        private void CalculateHoroscopes()
        {
            DateTime? birthDate = DatePicker.SelectedDate;
            if (birthDate != null)
            {
                HoroscopeEnglish.Text = "Західний гороскоп: " + GetWesternSigns(birthDate);
                HoroscopeAsian.Text = "Китайський гороскоп: " + GetAsianSigns(birthDate);
            }
        }

        private string GetAsianSigns(DateTime? birthDate)
        {
            int chineseHoroscopeIndex = (birthDate.Value.Year - 4) % 12;

            switch (chineseHoroscopeIndex)
            {
                case 0:
                    return "Щур";
                case 1:
                    return "Бик";
                case 2:
                    return"Тигр";
                case 3:
                    return "Кролик";
                case 4:
                    return "Дракон";
                case 5:
                    return "Змія";
                case 6:
                    return "Кінь";
                case 7:
                    return "Коза";
                case 8:
                    return "Мавпа";
                case 9:
                    return "Півень";
                case 10:
                    return "Собака";
                case 11:
                    return "Свиня";
                default:
                    return "Неправильна дата";
            }

        }
        private string GetWesternSigns(DateTime? birthDate)
        {
            int month = birthDate.Value.Month;
                int day = birthDate.Value.Day;

                if ((month == 3 && day >= 21) || (month == 4 && day <= 19))
                {
                    return "Овен";
                }
                else if ((month == 4 && day >= 20) || (month == 5 && day <= 20))
                {
                    return "Телець";
                }
                else if ((month == 5 && day >= 21) || (month == 6 && day <= 20))
                {
                    return "Близнюки";
                }
                else if ((month == 6 && day >= 21) || (month == 7 && day <= 22))
                {
                    return "Рак";
                }
                else if ((month == 7 && day >= 23) || (month == 8 && day <= 22))
                {
                    return "Лев";
                }
                else if ((month == 8 && day >= 23) || (month == 9 && day <= 22))
                {
                    return "Діва";
                }
                else if ((month == 9 && day >= 23) || (month == 10 && day <= 22))
                {
                    return "Терези";
                }
                else if ((month == 10 && day >= 23) || (month == 11 && day <= 21))
                {
                    return "Скорпіон";
                }
                else if ((month == 11 && day >= 22) || (month == 12 && day <= 21))
                {
                    return "Стрілець";
                }
                else if ((month == 12 && day >= 22) || (month == 1 && day <= 19))
                {
                    return "Козоріг";
                }
                else if ((month == 1 && day >= 20) || (month == 2 && day <= 18))
                {
                    return "Водолій";
                }
                else if ((month == 2 && day >= 19) || (month == 3 && day <= 20))
                {
                    return "Риби";
                }
                else
                {
                    return "Неправильна дата";
                }
            
        }

        private void CalculateAge()
        {
            DateTime? birthDate = DatePicker.SelectedDate;
            if (birthDate != null)
            {
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Value.Year;
                if (birthDate > today.AddYears(-age)) age--;
                if (age > 135)
                {
                    MessageBox.Show("Та ти точно не такий старий, давай пиши справжній");
                }
                else if (age < 0)
                {
                    MessageBox.Show("Ти що з утроба пишеш?");
                }
                else
                {
                    if (birthDate.Value.Month == today.Month && birthDate.Value.Day == today.Day)
                        MessageBox.Show("З днем народження!");
                    AgeTextBlock.Text = "Вік користувача: " + age.ToString();

                }
            }
        }
    }
}
