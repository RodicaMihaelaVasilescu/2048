using _2048.Model;
using System;
using _2048.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace _2048.Helper
{
  class ColorMapper
  {
    public Dictionary<int, Square> ColorMapping;
    public ColorMapper()
    {
      ColorMapping = new Dictionary<int, Square>();

      ColorMapping[2] = new Square
      {
        Background = ColorConstants.Background2,
        Foreground = ColorConstants.Foreground2,
        Number = "2"
      };

      ColorMapping[4] = new Square
      {
        Background = ColorConstants.Background4,
        Foreground = ColorConstants.Foreground4,
        Number = "4"
      };
      ColorMapping[8] = new Square
      {
        Background = ColorConstants.Background8,
        Foreground = ColorConstants.Foreground8,
        Number = "8"
      };

      ColorMapping[16] = new Square
      {
        Background = ColorConstants.Background16,
        Foreground = ColorConstants.Foreground16,
        Number = "16"
      };

      ColorMapping[32] = new Square
      {
        Background = ColorConstants.Background32,
        Foreground = ColorConstants.Foreground32,
        Number = "32"
      };   
      
      ColorMapping[64] = new Square
      {
        Background = ColorConstants.Background32,
        Foreground = ColorConstants.Foreground32,
        Number = "64"
      };   
      
      ColorMapping[128] = new Square
      {
        Background = ColorConstants.Background128,
        Foreground = ColorConstants.Foreground32,
        Number = "128"
      };    
      
      ColorMapping[256] = new Square
      {
        Background = ColorConstants.Background256,
        Foreground = ColorConstants.Foreground32,
        Number = "256"
      };     
      
      ColorMapping[512] = new Square
      {
        Background = ColorConstants.Background512,
        Foreground = ColorConstants.Foreground32,
        Number = "512"
      };      
      ColorMapping[1024] = new Square
      {
        Background = ColorConstants.Background1024,
        Foreground = ColorConstants.Foreground32,
        Number = "1024"
      };      
      ColorMapping[2048] = new Square
      {
        Background = ColorConstants.Background2048,
        Foreground = ColorConstants.Foreground32,
        Number = "2048"
      };



    }


  }


}
