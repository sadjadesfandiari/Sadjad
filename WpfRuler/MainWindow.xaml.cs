using System;
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

namespace WpfRuler
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            double xStepCM = (double)new LengthConverter().ConvertFrom("1cm");
            double xStepMM = xStepCM / 10;

            for (int i = 0; i <= 20; i++)
            {
                TextBlock tb = new TextBlock();
                Canvas.SetLeft(tb, i * xStepCM);
                Canvas.SetTop(tb, 15);
                tb.Text = i.ToString();
                Ruler.Children.Add(tb);

                Line l = new Line();
                l.X1 = i * xStepCM;
                l.X2 = i * xStepCM;
                l.Y1 = 0;
                l.Y2 = 15;
                l.StrokeThickness = 1;
                l.Stroke = Brushes.Red;
                Ruler.Children.Add(l);

                if (i < 20)
                    for (int j = 1; j < 10; j++)
                    {
                        Line lm = new Line();
                        lm.X1 = (i * xStepCM) + (j * xStepMM);
                        lm.X2 = (i * xStepCM) + (j * xStepMM);
                        lm.Y1 = 0;
                        lm.Y2 = (j == 5) ? 10 : 5;
                        lm.StrokeThickness = 1;
                        lm.Stroke = Brushes.Gray;
                        Ruler.Children.Add(lm);
                    }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if(printDialog.ShowDialog() == true)
            {
                printDialog.PrintVisual(Ruler, "WpfRuler");
            }
        }
    }
}
