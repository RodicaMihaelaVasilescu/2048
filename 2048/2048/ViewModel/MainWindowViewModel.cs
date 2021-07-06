using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048.ViewModel
{
  class MainWindowViewModel
  {
    public GameBoardViewModel GameBoardViewModel { get; set; }
    public MainWindowViewModel()
    {
      GameBoardViewModel = new GameBoardViewModel();
    }
  }
}
