using _2048.Helper;
using _2048.Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace _2048.ViewModel
{
  class GameBoardViewModel : INotifyPropertyChanged
  {
    public ObservableCollection<ObservableCollection<Square>> Board
    {
      get { return _board; }

      set
      {
        if (_board == value) return;
        _board = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Board"));
      }

    }

    public int BestScore
    {
      get { return _bestScore; }

      set
      {
        if (_bestScore == value) return;
        _bestScore = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BestScore"));
      }
    }

    public int NextTile
    {
      get { return _nextTile; }

      set
      {
        if (_nextTile == value) return;
        _nextTile = value;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NextTile"));
      }
    }

    public int Score
    {
      get { return _score; }

      set
      {
        if (_score == value) return;
        _score = value;
        if (Score > BestScore)
          BestScore = Score;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Score"));
      }
    }

    private ObservableCollection<ObservableCollection<Square>> matrix;
    private List<int> emptyPlaces;

    public ICommand NewGameCommand { get; set; }

    private ColorMapper colorMapper = new ColorMapper();
    private ObservableCollection<ObservableCollection<Square>> _board;
    private int _score;
    private int _bestScore;
    private int _nextTile = 4;

    public GameBoardViewModel()
    {
      NewGameCommand = new DelegateCommand(NewGameCommandExecute);
      InitializeBoard();
    }



    private void NewGameCommandExecute()
    {
      InitializeBoard();
    }

    public void InitializeBoard()
    {
      Score = 0;
      Board = new ObservableCollection<ObservableCollection<Square>>();
      matrix = new ObservableCollection<ObservableCollection<Square>>();
      emptyPlaces = new List<int>();
      for (int i = 0; i < 4; i++)
      {
        var list = new ObservableCollection<Square>();
        for (int j = 0; j < 4; j++)
        {
          list.Add(new Square());
        }
        matrix.Add(list);
      }

      Random random = new Random();
      PlaceSquare(random);
      PlaceSquare(random);

      Board = matrix;
    }

    public void PlaceSquare(Random random)
    {
      var emptyPlaces = getListOfEmptyPlaces();
      if (!emptyPlaces.Any())
      {
        //NewGameCommandExecute();
        return;
      }
      var randomPlace = random.Next(emptyPlaces.Count());
      var element = emptyPlaces[randomPlace];
      matrix[element / 10][element % 10] = colorMapper.ColorMapping[random.Next(2) * 2 + 2];
      emptyPlaces.Remove(element);
    }

    private List<int> getListOfEmptyPlaces()
    {
      var list = new List<int>();

      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; j < 4; j++)
        {
          if (matrix[i][j].Number == null)
          {

            list.Add(i * 10 + j);
          }
        }
      }

      return list;
    }

    private void CheckIfBestScore(int addition)
    {
      Score += addition;
      if (addition >= NextTile)
      {
        NextTile = addition * 2 ;
      }
    }


    public void MoveRight()
    {
      MoveSquaresToTheRight();
      AddValuesForTheRight();
      MoveSquaresToTheRight();
    }

    public void MoveLeft()
    {
      MoveSquaresToTheLeft();
      AddValuesForTheLeft();
      MoveSquaresToTheLeft();
    }
    public void MoveUp()
    {
      MoveSquaresUp();
      AddValuesUp();
      MoveSquaresUp();
    }
    public void MoveDown()
    {
      MoveSquaresDown();
      AddValuesDown();
      MoveSquaresDown();
    }


    private void AddValuesForTheRight()
    {
      for (int line = 0; line < 4; line++)
      {
        for (int column = 3; column >= 0; column--)
        {
          int auxColumn = column - 1;
          while (auxColumn >= 0)
          {
            if (matrix[line][column].Number != null && matrix[line][auxColumn].Number == matrix[line][column].Number)
            {
              var addition = int.Parse(matrix[line][auxColumn].Number) + int.Parse(matrix[line][auxColumn].Number);
              CheckIfBestScore(addition);
              matrix[line][column] = colorMapper.ColorMapping[addition];
              matrix[line][auxColumn] = new Square();
              column--;
            }
            else if (matrix[line][column].Number != null && matrix[line][auxColumn].Number != null)
            {
              break;
            }
            auxColumn--;

          }
        }
      }
    }
    private void MoveSquaresToTheRight()
    {
      for (int line = 0; line < 4; line++)
      {
        for (int column = 3; column >= 0; column--)
        {
          int auxColumn = column - 1;
          while (auxColumn >= 0)
          {
            if (matrix[line][column].Number == null && matrix[line][auxColumn].Number != null)
            {
              matrix[line][column] = colorMapper.ColorMapping[int.Parse(matrix[line][auxColumn].Number)];
              matrix[line][auxColumn] = new Square();
              break;
            }
            auxColumn--;

          }
        }
      }
    }


    private void AddValuesForTheLeft()
    {
      for (int line = 0; line < 4; line++)
      {
        for (int column = 0; column < 4; column++)
        {
          int auxColumn = column + 1;
          while (auxColumn <= 3)
          {
            if (matrix[line][column].Number != null && matrix[line][auxColumn].Number == matrix[line][column].Number)
            {
              var addition = int.Parse(matrix[line][auxColumn].Number) + int.Parse(matrix[line][auxColumn].Number);
              CheckIfBestScore(addition);
              matrix[line][column] = colorMapper.ColorMapping[addition];
              matrix[line][auxColumn] = new Square();
              column++;
            }
            else if (matrix[line][column].Number != null && matrix[line][auxColumn].Number != null)
            {
              break;
            }
            auxColumn++;
          }
        }
      }
    }

    private void MoveSquaresToTheLeft()
    {
      for (int line = 0; line < 4; line++)
      {
        for (int column = 0; column < 4; column++)
        {
          int auxColumn = column + 1;
          while (auxColumn <= 3)
          {
            if (matrix[line][column].Number == null && matrix[line][auxColumn].Number != null)
            {
              matrix[line][column] = colorMapper.ColorMapping[int.Parse(matrix[line][auxColumn].Number)];
              matrix[line][auxColumn] = new Square();
              break;
            }

            auxColumn++;
          }
        }
      }

    }


    private void AddValuesUp()
    {

      for (int column = 0; column < 4; column++)
      {
        for (int line = 0; line < 4; line++)
        {
          int auxLine = line + 1;
          while (auxLine < 4)
          {
            if (matrix[line][column].Number != null && matrix[auxLine][column].Number == matrix[line][column].Number)
            {
              var addition = int.Parse(matrix[auxLine][column].Number) + int.Parse(matrix[auxLine][column].Number);
              CheckIfBestScore(addition);
              matrix[line][column] = colorMapper.ColorMapping[addition];
              matrix[auxLine][column] = new Square();
              line++;
            }
            else if (matrix[line][column].Number != null && matrix[auxLine][column].Number != null)
            {
              break;
            }
            auxLine++;

          }
        }
      }
    }

    private void MoveSquaresUp()
    {
      for (int column = 0; column < 4; column++)
      {
        for (int line = 0; line < 4; line++)
        {
          int auxLine = line + 1;
          while (auxLine < 4)
          {
            if (matrix[line][column].Number == null && matrix[auxLine][column].Number != null)
            {
              matrix[line][column] = colorMapper.ColorMapping[int.Parse(matrix[auxLine][column].Number)];
              matrix[auxLine][column] = new Square();
              break;
            }

            auxLine++;

          }
        }
      }

    }


    private void MoveSquaresDown()
    {
      for (int column = 0; column < 4; column++)
      {
        for (int line = 3; line >= 0; line--)
        {
          int auxLine = line - 1;
          while (auxLine >= 0)
          {
            if (matrix[line][column].Number == null && matrix[auxLine][column].Number != null)
            {
              matrix[line][column] = colorMapper.ColorMapping[int.Parse(matrix[auxLine][column].Number)];
              matrix[auxLine][column] = new Square();
              break;
            }

            auxLine--;

          }
        }
      }
    }

    private void AddValuesDown()
    {

      for (int column = 0; column < 4; column++)
      {
        for (int line = 3; line >= 0; line--)
        {
          int auxLine = line - 1;
          while (auxLine >= 0)
          {
            if (matrix[line][column].Number != null && matrix[auxLine][column].Number == matrix[line][column].Number)
            {

              var addition = int.Parse(matrix[auxLine][column].Number) + int.Parse(matrix[auxLine][column].Number);
              CheckIfBestScore(addition);
              matrix[line][column] = colorMapper.ColorMapping[addition];
              matrix[auxLine][column] = new Square();
              line--;
            }
            else if (matrix[line][column].Number != null && matrix[auxLine][column].Number != null)
            {
              break;
            }
            auxLine--;

          }
        }
      }
    }

    public event PropertyChangedEventHandler PropertyChanged;
  }
}
