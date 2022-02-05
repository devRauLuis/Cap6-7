// Hice el capítulo integrado en una sola app, 
// los ejercicios del 1-5 se encuentran en Utils/Utils.cs

using System;
using System.Collections.Generic;
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
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Cap6
{
    public partial class MainWindow : Window
    {

        float[][] salones;
        int selectedSalon;

        public MainWindow()
        {
            InitializeComponent();

            AddInitialData(); // This call adds some initial data to the jagged array
        }

        private void AddInitialData()
        {
            salones = new float[][] { new float[] { 19.3f, 39f }, new float[] { 18f, 7f, 29f } };
            var list = Enumerable.Range(1, salones.GetLength(0));
            SalonesListBox.ItemsSource = list;
            if (salones is not null)
                NewCalifTextBox.IsEnabled = true;
            Calculate();
        }

        private void OnAddSalonClick(object sender, EventArgs e)
        {
            if (salones is null)
            {
                salones = new float[1][];
            }
            else
            {
                Array.Resize(ref salones, salones.GetLength(0) + 1);
            }
            var list = Enumerable.Range(1, salones.GetLength(0));
            SalonesListBox.ItemsSource = list;
            NewCalifTextBox.IsEnabled = true;
        }

        private void OnAddCalificacionClick(object sender, EventArgs e)
        {
            var arr = salones[selectedSalon];
            float n = float.TryParse(NewCalifTextBox.Text, out n) ? n : -1;
            // MessageBox.Show(arr.GetLength(0) + "");

            if (arr is null)
            {
                arr = new float[1];
                arr[0] = n;
            }
            else
            {
                Array.Resize(ref arr, arr.GetLength(0) + 1);
                arr[arr.GetLength(0) - 1] = n;
            }

            salones[selectedSalon] = arr;
            CalifListBox.ItemsSource = arr.ToList();
            Calculate();
        }

        private void OnNewCalifTextBoxChanged(object sender, EventArgs e)
        {
            float n = float.TryParse(NewCalifTextBox.Text, out n) ? n : -1;
            AddCalificacionBtn.IsEnabled = n > 0;
        }
        private void OnSalonesListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedSalon = (int)SalonesListBox.SelectedItem - 1;
            CalifListBox.ItemsSource = salones[selectedSalon];
        }

        private void Calculate()
        {
            float avg = Utils.GetAvg(ref salones);
            float min = Utils.GetMin(ref salones);
            float max = Utils.GetMax(ref salones);
            PromedioTextBlock.Text = $"{avg:N2}";
            MenorTextBlock.Text = $"{min:N2}";
            MayorTextBlock.Text = $"{max:N2}";
        }
    }
}