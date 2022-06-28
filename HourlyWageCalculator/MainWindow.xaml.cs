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

namespace HourlyWageCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rand = new Random();
        
        public MainWindow()
        {
            InitializeComponent();

            employeeID.Text = rand.Next(10000, 99999).ToString();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Employee emp = new Employee();
                emp.name = firstName.Text + " " + lastName.Text;
                emp.hourlyRate = Decimal.Parse(hourlyRate.Text);
                emp.hoursWorked = Decimal.Parse(hoursWorked.Text);

                firstName.IsEnabled = false;
                lastName.IsEnabled = false;

                displayEmpID.Text = "Emp ID: " + employeeID.Text;
                displayName.Text = "Name: " + emp.name.ToString();
                displayDept.Text = "Department: " + departmentComboBox.Text;

                if (emp.hoursWorked > 40)
                {
                    decimal a = emp.hoursWorked - 40;
                    decimal overTime = emp.hourlyRate * 1.5m;
                    decimal otAmount = overTime * a;
                    decimal otPay = (emp.hourlyRate * 40) + otAmount;

                    displayPay.Text = "Total Pay: " + otPay.ToString("C");
                    displayOT.Text = "OT Pay: " + otAmount.ToString("C");

                }
                else
                {
                    decimal regPay = emp.hourlyRate * emp.hoursWorked;
                    displayPay.Text = "Total Pay: " + regPay.ToString("C");
                    displayOT.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter a decimal number for the hourly rate and hours worked.", "Error!");
                clearButton_Click(sender, e);
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            employeeID.Text = rand.Next(10000, 99999).ToString();

            departmentComboBox.Text = "";
            firstName.Text = "";
            lastName.Text = "";
            hourlyRate.Text = "";
            hoursWorked.Text = "";

            firstName.IsEnabled = true;
            lastName.IsEnabled = true;

            displayEmpID.Text = "";
            displayName.Text = "";
            displayDept.Text = "";
            displayPay.Text = "";
            displayOT.Text = "";
        }
    }

    public class Employee
    {
        public string name;
        public decimal hourlyRate;
        public decimal hoursWorked;
    }
}