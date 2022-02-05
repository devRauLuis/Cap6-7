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
using _5.Entidades;

namespace _5.UI.Registros;

public partial class NewContact : Window
{
    public string PhoneNumber { get; set; }
    public string FullName { get; set; }
    public NewContact()
    {
        InitializeComponent();
    }

    private void OnAddBtnClick(object sender, EventArgs e)
    {
        FullName = NameTextBox.Text;
        PhoneNumber = NumberTextBox.Text;
        this.Close();
    }

    private void OnTextBoxTextChanged(object sender, EventArgs e)
    {
        var textBox = sender as TextBox;
        AddBtn.IsEnabled = textBox.Text.Length > 0;

    }

    public static Contact ShowNewContact()
    {
        var newContactView = new NewContact();
        newContactView.ShowDialog();
        return new Contact()
        {
            FullName = newContactView.FullName,
            PhoneNumber = newContactView.PhoneNumber
        };
    }
}