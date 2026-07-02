using System.Windows;
using System.Windows.Controls;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool playing = true;
        long saldo = 0;
        long quant = 1;
        int precoInfinito = 500;
        int InfBonus = 2;
        int rebirthPreco = 5000;
        int multi = 1;

        public void Saldo(long saldo1)
        {
            if (saldo1 < 0)
            {
                saldo += saldo1;
            }
            else
            {
                saldo += (saldo1*multi);
            }
            textozin.Text = saldo.ToString("N0");
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Click_vl(object sender, RoutedEventArgs e)
        {
            if (!playing)
            {
                return;
            }
            Saldo(quant);
            if (saldo >= 10_000_000_000)
            {
                textozin.Text = "10.000.000.000 (MAX)";
                playing = false;
            }

        }
        public void Click_Upgrade(object sender, RoutedEventArgs e)
        {
            if (!playing)
            {
                return;
            }
            Button Click_Button = (Button)sender;
            string txtbutton = Click_Button.Content?.ToString() ?? string.Empty;
            string buttonName = Click_Button.Name.ToString();

            if (saldo >= 50 && txtbutton == "Comprar (50)")
            {
                Saldo(-50);
                FirstUp.Content = "Comprado";
                quant += 1;

            }
            else if (saldo >= 300 && txtbutton == "Comprar (300)")
            {
                Saldo(-300);
                SecondUp.Content = "Comprado";
                quant += 3;
            }
            else if (saldo >= precoInfinito && buttonName == "InfUp")
            {
                Saldo(-precoInfinito);
                quant += InfBonus;
                InfBonus+= 6;
                precoInfinito = (int)(precoInfinito * 1.5) + 20;

                InfTexto.Text = $"+{InfBonus * multi} Clicks (inf)";
                Click_Button.Content = $"Comprar ({precoInfinito:N0})";
            }
            else if (saldo >= rebirthPreco && buttonName == "RebirthButton")
            {
                saldo = 0;
                multi++;
                rebirthPreco = (int)(rebirthPreco * 2.5);
                quant = 1;
                precoInfinito = 500;
                InfBonus = 2;

                textozin.Text = "0";
                RebirthText.Text = $"Rebirth (Multi: {multi}x)";
                Click_Button.Content = $"Resetar ({rebirthPreco:N0})";
                InfTexto.Text = $"+{InfBonus} Clicks (inf)";
                InfUp.Content = $"Comprar ({precoInfinito:N0})";

                Upgrade1.Text = $"+{1*multi} Click";
                Upgrade2.Text = $"+{3 * multi} Clicks";
                InfTexto.Text = $"+{InfBonus * multi} Clicks (inf)";
                FirstUp.Content = "Comprar (50)";
                SecondUp.Content = "Comprar (300)";
            }
            ClickPS.Text = $"{quant * multi} Clicks";
        }
    }
}