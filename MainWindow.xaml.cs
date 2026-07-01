using System.Diagnostics.Tracing;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int saldo = 0;
        int quant = 1000;
        int precoInfinito = 500;
        int InfBonus = 2;
        public void Saldo(int saldo1)
        {
            saldo += saldo1;
            textozin.Text = saldo.ToString();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        public void Click_vl(object sender, RoutedEventArgs e)
        {
            if (saldo >= 10_000_000){
                textozin.Text = "GANHOU!";
            }
            else
            {
                Saldo(quant);
            }
            
        }
        public void Click_Upgrade(object sender, RoutedEventArgs e)
        {
            Button Click_Button = (Button)sender;
            string txtbutton = Click_Button.Content.ToString();
            string infbutton = Click_Button.Name.ToString();

            if (saldo >= 100 && txtbutton == "Comprar (100)")
            {
                Saldo(-100);
                FirstUp.Content = "Comprado";
                quant += 1;

            }
            else if (saldo >= 400 && txtbutton == "Comprar (400)")
            {
                Saldo(-400);
                SecondUp.Content = "Comprado";
                quant += 3;
            }
            else if (saldo >= precoInfinito && infbutton == "InfUp")
            {
                Saldo(-precoInfinito);
                quant += InfBonus;
                InfBonus+= 9;
                precoInfinito = (int)(precoInfinito * 1.5) + 20;

                InfTexto.Text = $"+{InfBonus} Clicks (inf)";
                Click_Button.Content = $"Comprar ({precoInfinito})";
            }
        }
    }
}