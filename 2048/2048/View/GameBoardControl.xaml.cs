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

namespace _2048.View
{
  /// <summary>
  /// Interaction logic for GameBoardControl.xaml
  /// </summary>
  public partial class GameBoardControl : UserControl
  {
    public GameBoardControl()
    {
      InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      NewGameButton.Focusable = false;
    }
  }
}
