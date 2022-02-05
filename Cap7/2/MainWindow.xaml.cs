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
using _2.UI.Registros;

namespace _2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Hashtable dictionary;
        public MainWindow()
        {
            InitializeComponent();
            dictionary = new Hashtable() { { "Programador", "Persona que se dedica a programar" } };
            WordsListBox.ItemsSource = dictionary.Keys;
        }
        private void OnWordsListBoxSelectionChanged(object sender, EventArgs e)
        {
            var selectedKey = WordsListBox.SelectedItem as string;

            SelectedWordTextBlock.Text = selectedKey;
            SelectedDefinitionTextBlock.Text = dictionary[selectedKey] as string;
        }
        private void OnNuevaDefinicionClick(object sender, EventArgs e)
        {
            // var nuevaDefinicionView = new NuevaDefinicion();

            // if (nuevaDefinicionView.ShowDialog() == true)
            // {
            //     var word = nuevaDefinicionView.word;
            //     var definition = nuevaDefinicionView.definition;
            //     dictionary.Add(word, definition);
            // }

            string[] newDefinition = NuevaDefinicion.ShowNuevaDefinicion();

            dictionary.Add(newDefinition[0], newDefinition[1]);
            WordsListBox.ItemsSource = null;
            WordsListBox.ItemsSource = dictionary.Keys;
        }
    }
}
