using System;
using System.Windows;
using System.Windows.Controls;

namespace CommissionCalculator
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateCommission_Click(object sender, RoutedEventArgs e)
        {
            if (surname.SelectedItem != null &&
                dpHireDate.SelectedDate.HasValue &&
                double.TryParse(txtMoneyOfDay.Text, out double moneyOfDay))
            {
                string surname = (this.surname.SelectedItem as ComboBoxItem).Content.ToString();
                DateTime hireDate = dpHireDate.SelectedDate.Value;

                double commissionPercent = moneyOfDay < 50000 ? 0.03 : 0.06;
                int years = DateTime.Now.Year - hireDate.Year;
                if (DateTime.Now < hireDate.AddYears(years)) years--;

                if (years >= 0)
                {

                    if (years > 3)
                    {
                        commissionPercent += 0.05;
                    }

                    double commission = moneyOfDay * commissionPercent;

                    txtResult.Text = $"ООО АвтоШинТех - Расчетный лист\n" +
                                     $"Фамилия продавца: {surname}\n" +
                                     $"Процент комиссионного вознаграждения: {commissionPercent * 100}%\n" +
                                     $"Комиссионное вознаграждение: {commission} руб.\n" +
                                     $"Размер дневной выручки: {moneyOfDay} руб.\n" +
                                     $"Стаж работы: {years} лет";
                }
                else
                {
                    txtResult.Text = "Некорректно заполнены поля!";
                }
            }
        }


    }
}

