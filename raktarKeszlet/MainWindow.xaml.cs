using System;
using System.IO;
using System.Text;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes; 

namespace raktarKeszlet
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private readonly string filepath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "raktar.txt");
		public MainWindow()
		{
			InitializeComponent();
		}
		private void hozzaadBtn_Click(object sender, RoutedEventArgs e)
		{
			if (string.IsNullOrWhiteSpace(termekNev?.Text) ||
				string.IsNullOrWhiteSpace(mennyiseg?.Text) ||
				string.IsNullOrWhiteSpace(egysegar?.Text))
			{
				MessageBox.Show("Kérlek tölts ki minden mezőt.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (!int.TryParse(mennyiseg.Text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out int db) || db < 1)
			{
				MessageBox.Show("A darabszámnak pozitív egész számnak kell lennie.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			if (!decimal.TryParse(egysegar.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal ar))
			{
				MessageBox.Show("Az árnak számnak kell lennie.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
				return;
			}
			string nev = termekNev.Text.Trim();
			string mennyiSeg = db.ToString();
			string egysegAr = ar.ToString(CultureInfo.CurrentCulture);
			string szoveg = $"{nev}-{mennyiSeg}Ft-{egysegAr}db";
			termekLista.Items.Add(szoveg);
			try
			{
				File.AppendAllText(filepath, szoveg + Environment.NewLine, Encoding.UTF8);
				MessageBox.Show("Sikeres mentés!", "Mentés", MessageBoxButton.OK, MessageBoxImage.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Mentési hiba: {ex.Message}", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
			}
		}
		private void torlesBtn_Click(object sender, RoutedEventArgs e)
		{
			if (termekLista.SelectedItem == null)
			{
				MessageBox.Show("Nincs kijelölt elem!", "Figyelem");
				return;
			}

			string selected = termekLista.SelectedItem.ToString();

			var result = MessageBox.Show($"Biztosan törlöd a kiválasztott elemet?\n\n{selected}", "Megerősítés", MessageBoxButton.YesNo, MessageBoxImage.Question);
			if (result != MessageBoxResult.Yes)
				return;
			termekLista.Items.Remove(termekLista.SelectedItem);
			
		}

		private void mentesBtn_Click(object sender, RoutedEventArgs e)
		{

		}
	}
}