using System;
using System.Collections.Generic;
using System.Collections;
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
using _4.UI.Registros;
using _4.Entidades;

namespace _4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Expense> expenses;
        public MainWindow()
        {
            InitializeComponent();
            expenses = new List<Expense>() { new Expense() { Date = DateTime.Today, Amount = 100234f } };
            ExpensesDG.ItemsSource = expenses;
        }

        private void SetExpenses()
        {
            expenses = SortByDateAscending(expenses);
            ExpensesDG.ItemsSource = null;
            ExpensesDG.ItemsSource = expenses;
        }

        private List<Expense> SortByDateAscending(List<Expense> expenses)
        {
            return expenses.OrderBy(e => e.Date).ToList();
        }

        private void OnNuevoGastoClick(object sender, EventArgs e)
        {
            var expense = NewExpense.ShowNuevoGasto();
            expenses.Add(expense);
            SetExpenses();
        }
    }
}
