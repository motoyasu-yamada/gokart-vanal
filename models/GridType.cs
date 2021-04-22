using gokart_vanal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace gokart_vanal.models
{
  [Serializable()]
  public enum GridType
  {
    None,
    Grid10x4,
    Grid20x8
  }
  public static class GridTypeStatic
  {
    public static (int,int) NumberOfGrids(this GridType gridType)
    {
      switch (gridType)
      {
        case GridType.None:
        default:
          return (0,0);
        case GridType.Grid10x4:
          return (10,4);
        case GridType.Grid20x8:
          return (20,8);
      }
    }

    public static int ToIndex(this GridType gridType)
    {
      switch(gridType)
      {
        case GridType.None:
        default:
          return 0;
        case GridType.Grid10x4:
          return 1;
        case GridType.Grid20x8:
          return 2;
      }
    }

    public static GridType FromIndex(int n)
    {
      switch (n)
      {
        case 0:
        default:
          return GridType.None;
        case 1:
          return GridType.Grid10x4;
        case 2:
          return GridType.Grid20x8;
      }
    }
  }
}
