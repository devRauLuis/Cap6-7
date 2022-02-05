using System;
using System.Collections;
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

namespace Ejercicio1;
public partial class MainWindow : Window
{

    ArrayList salones = new ArrayList();
    int selectedSalon;

    public MainWindow()
    {
        InitializeComponent();

        AddInitialData(); // This call adds some initial data to the jagged array
    }

    private void AddInitialData()
    {
        // salones = new float[][] { new float[] { 19.3f, 39f }, new float[] { 18f, 7f, 29f } };

        // salones.Add()
        var salon1 = new ArrayList();
        salon1.Add(9.8f);
        salon1.Add(9.9f);
        salon1.Add(8.2f);
        var salon2 = new ArrayList();
        salon2.Add(7.8f);
        salon2.Add(6.8f);
        salon2.Add(5.7f);
        salones.Add(salon1);
        salones.Add(salon2);
        SalonesListBox.ItemsSource = Enumerable.Range(1, salones.Count);
        if (salones is not null)
            NewCalifTextBox.IsEnabled = true;
        Calculate();
    }

    private void OnAddSalonClick(object sender, EventArgs e)
    {
        // if (salones is null)
        // {
        //     salones = new float[1][];
        // }
        // else
        // {
        //     Array.Resize(ref salones, salones.GetLength(0) + 1);
        // }
        salones.Add(new ArrayList());
        SalonesListBox.ItemsSource = Enumerable.Range(1, salones.Count);
        NewCalifTextBox.IsEnabled = true;
    }

    private void OnAddCalificacionClick(object sender, EventArgs e)
    {
        var arr = salones[selectedSalon] as ArrayList;
        float n = float.TryParse(NewCalifTextBox.Text, out n) ? n : -1;
        // MessageBox.Show(arr.GetLength(0) + "");

        // if (arr is null)
        // {
        //     arr = new float[1];
        //     arr[0] = n;
        // }
        // else
        // {
        //     Array.Resize(ref arr, arr.GetLength(0) + 1);
        //     arr[arr.GetLength(0) - 1] = n;
        // }
        arr.Add(n);
        // salones[selectedSalon] = arr;
        CalifListBox.ItemsSource = arr;
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
        CalifListBox.ItemsSource = salones[selectedSalon] as ArrayList;
    }

    private void Calculate()
    {
        float? avg = Utils.GetAvg(salones);
        float? min = Utils.GetMin(salones);
        float? max = Utils.GetMax(salones);
        PromedioTextBlock.Text = $"{avg:N2}";
        MenorTextBlock.Text = $"{min:N2}";
        MayorTextBlock.Text = $"{max:N2}";
    }
}
