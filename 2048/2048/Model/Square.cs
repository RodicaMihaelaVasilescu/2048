using System;
using System.Windows.Media;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.ComponentModel;

namespace _2048.Model
{
  public class Square: INotifyPropertyChanged
  {
    private double _size = 80;

    //public Brush Background { get; set; } = new SolidColorBrush(Color.FromRgb(0xEE, 0XE4, 0XDA)); // #eee4da
    public Brush Background { get; set; } = new SolidColorBrush(Color.FromRgb(0xCC, 0XC0, 0XB4)); // #ccc0b4
    public Brush Foreground { get; set; } = new SolidColorBrush(Color.FromRgb(0x7C, 0X70, 0X64)); // #7c7064
    public string Number { get; set; }
    public double Size
    {
      get { return _size; }
      set
      {
        if (_size == value) return;
        _size = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Size"));
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
