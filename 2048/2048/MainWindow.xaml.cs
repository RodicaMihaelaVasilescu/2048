using _2048.ViewModel;
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

namespace _2048
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    GameBoardViewModel GameBoardViewModel;
    public MainWindow()
    {
      InitializeComponent();
      DataContext = new MainWindowViewModel();
      GameBoardViewModel = new GameBoardViewModel();
      GameBoardView.DataContext = GameBoardViewModel;
    }

    private void Window_OnKeyDown(object sender, KeyEventArgs e)
    {
      if (e.Key == Key.Down)
      {
        GameBoardViewModel.MoveDown();
      }
      if (e.Key == Key.Right)
      {
        GameBoardViewModel.MoveRight();
      }
      if (e.Key == Key.Up)
      {
        GameBoardViewModel.MoveUp();
      }
      if (e.Key == Key.Left)
      {
        GameBoardViewModel.MoveLeft();
      }

      GameBoardViewModel.PlaceSquare(new Random());
    }
  }
}
