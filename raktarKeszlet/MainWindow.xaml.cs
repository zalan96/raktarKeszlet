using System.Text;
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
		private readonly string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "zebra.txt");
		public MainWindow()
		{
			InitializeComponent();
		}
		private void hozzaadBtn_Click(object sender, RoutedEventArgs e)
		{
			{
				if (!int.TryParse(mennyiseg.Text.Trim(), out int db) || db < 1 || string.IsNullOrWhiteSpace(mennyiseg.Text))
				{
					MessageBox.Show("0-nál csak nagyobb számot írhatsz", "Hiba!");
				}
				else
				{
					string nev = termekNev.Text.ToString();
					string mennyiSeg = mennyiseg.Text.ToString();
					string egysegAr = egysegar.Text.ToString();
					string szoveg = $"{nev}-{mennyiSeg}-{egysegAr}";
					termekLista.Items.Add(szoveg);
					try
					{
						File.AppendAllText(filepath, szoveg + Environment.NewLine, Encoding.UTF8);
						MessageBox.Show("Sikeres mentés!", "Mentés!", MessageBoxButton.OK, MessageBoxImage.Information);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Hiba!", "Hiba!");
					}
				}
			}
		}
	}
}