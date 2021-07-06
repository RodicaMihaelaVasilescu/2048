using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _2048.Constants
{
 public static class ColorConstants
  {
    static public Brush Background2 = new SolidColorBrush(Color.FromRgb(0xEE, 0XE4, 0XDA)); // #eee4da
    static public Brush Background4 = new SolidColorBrush(Color.FromRgb(0xEB, 0XDF, 0XC5)); // #ebdfc5
    static public Brush Background8 = new SolidColorBrush(Color.FromRgb(0xF0, 0XAF, 0X7E)); // #f0af7e
    static public Brush Background16 = new SolidColorBrush(Color.FromRgb(0xEB, 0X8C, 0X54)); // #eb8c54
    static public Brush Background32 = new SolidColorBrush(Color.FromRgb(0xf7, 0X7b, 0X61)); // #f77b61
    static public Brush Background64 = new SolidColorBrush(Color.FromRgb(0xE9, 0X59, 0X37)); // #e95937
    static public Brush Background128 = new SolidColorBrush(Color.FromRgb(0xF2, 0XD7, 0X6C)); // #f2d76c
    static public Brush Background256 = new SolidColorBrush(Color.FromRgb(0xF1, 0XD0, 0X4B)); // #f1d04b
    static public Brush Background512 = new SolidColorBrush(Color.FromRgb(0xE3, 0XBA, 0X14)); // #e95937
    static public Brush Background1024 = new SolidColorBrush(Color.FromRgb(0xE3, 0XBA, 0X14)); // #e3ba14
    static public Brush Background2048 = new SolidColorBrush(Color.FromRgb(0xEC, 0XC4, 0X00)); // #ecc400

    static public Brush Foreground2 = new SolidColorBrush(Color.FromRgb(0x7C, 0X70, 0X64)); // #7c7064
    static public Brush Foreground4 = new SolidColorBrush(Color.FromRgb(0x7C, 0X70, 0X64)); // #7c7064
    static public Brush Foreground8 = Brushes.White;
    static public Brush Foreground16 = Brushes.White;
    static public Brush Foreground32 = Brushes.White;


  }
}
