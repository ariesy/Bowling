using Sirius.Bowling.Core;
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

namespace Sirius.Bowling.UI.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BowlingMachine machine = new BowlingMachine(new BowlingRecorder());
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnThrow_Click(object sender, RoutedEventArgs e)
        {
            machine.Throw();
            for (int i = 0; i < 11; i++)
            {
                var scores = machine.GetFrameScore(i);
                //this.ScoreGrid.Children[
            }
        }
    }
}
