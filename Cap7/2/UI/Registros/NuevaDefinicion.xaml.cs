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

namespace _2.UI.Registros;

public partial class NuevaDefinicion : Window
{
    public string word { get; set; } = "";
    public string definition { get; set; } = "";
    public NuevaDefinicion()
    {
        InitializeComponent();
    }

    private void OnAddBtnClick(object sender, EventArgs e)
    {
        word = WordTextBox.Text;
        definition = DefTextBox.Text;
        this.Close();
    }
    private void OnTextBoxTextChanged(object sender, EventArgs e)
    {
        var textBox = sender as TextBox;
        AddBtn.IsEnabled = !(textBox.Text.Length < 1);
    }

    public static string[] ShowNuevaDefinicion()
    {
        var nuevaDefinicionView = new NuevaDefinicion();
        nuevaDefinicionView.ShowDialog();
        return new string[] { nuevaDefinicionView.word, nuevaDefinicionView.definition };
    }
}