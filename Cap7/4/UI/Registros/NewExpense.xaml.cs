using System;
using System.Collections;
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
using _4.Entidades;

namespace _4.UI.Registros;

public partial class NewExpense : Window
{
    public DateTime? Date { get; set; }
    public float Amount { get; set; }
    public NewExpense()
    {
        InitializeComponent();
    }

    private void OnAddBtnClick(object sender, EventArgs e)
    {
        float n = float.TryParse(AmountTextBox.Text, out n) ? n : 0;
        Amount = n;
        this.Close();
    }
    private void OnTextBoxTextChanged(object sender, EventArgs e)
    {
        var textBox = sender as TextBox;
        float n = float.TryParse(textBox.Text, out n) ? n : -1;
        AddBtn.IsEnabled = n > -1;
    }

    private void OnDPSelectedDateChanged(object sender, EventArgs e)
    {
        var picker = sender as DatePicker;
        Date = picker.SelectedDate;
AddBtn.IsEnabled = DPControl.SelectedDate is not null;
    }

    public static Expense ShowNuevoGasto()
    {
        var newExpenseView = new NewExpense();
        newExpenseView.ShowDialog();
        return new Expense() { Amount = newExpenseView.Amount, Date = newExpenseView?.Date};
    }
}