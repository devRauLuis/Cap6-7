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
using _5.UI.Registros;
using _5.Entidades;

namespace _5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> _contacts;
        public MainWindow()
        {
            InitializeComponent();
            _contacts = new List<Contact>() {new Contact() {PhoneNumber = "809-000-0123", FullName = "Fulano de Tal"}};
            ContactsDG.ItemsSource = _contacts;
        }

        private void SetContactsToDG()
        {
            ContactsDG.ItemsSource = null;
            ContactsDG.ItemsSource = _contacts;
        }

        private void OnNuevoContactoClick(object sender, EventArgs e)
        {
            var contact = NewContact.ShowNewContact();
            _contacts.Add(contact);
            SetContactsToDG();
        }
    }
}