namespace Geospatial;

using System.Diagnostics.Contracts;
using MaxRev.Gdal.Core;
//using MaxRev.Gdal.Core;
using OSGeo.GDAL;
using OSGeo.OGR;
using USACE.HEC.Consequences;
using USACE.HEC.Results;

public class SpatialReader
{ 
  public void Read()
  {
    GdalBase.ConfigureAll();

    Ogr.RegisterAll();
    using DataSource? ds = Ogr.Open(@"C:\Data\Muncie_WS6_Solution_PART2\Muncie_WS6_Part1_Solution_PART2\Muncie_WS6_Part1_Solution\Structure Inventories\Existing_BaseSI\BaseMuncieStructsFinal.shp", 0);
    if (ds == null)
    {
      Console.WriteLine("error");
    } 
    Layer layer = ds.GetLayerByIndex(0);

    int count = 0;
    layer.ResetReading();
    Feature f;
    do
    {
      f = layer.GetNextFeature();
      if (f != null)
        count++;
      if (count == 1)
      {
        int fieldCount = f.GetFieldCount();
        for (int i = 0; i < fieldCount; i++)
        {
          FieldDefn fd = f.GetFieldDefnRef(i);
          string key = fd.GetName();
          object? value = null;
          FieldType ft = fd.GetFieldType();
          switch (ft)
          {
            case FieldType.OFTString:
              value = f.GetFieldAsString(i);
              break;
            case FieldType.OFTReal:
              value = f.GetFieldAsDouble(i);
              break;
            case FieldType.OFTInteger:
              value = f.GetFieldAsInteger(i);
              break;
            case FieldType.OFTInteger64:
              value = f.GetFieldAsInteger64(i);
              break;
              // Note this is only a sub-set of the possible field types
          }
          Console.WriteLine($"{key}: {value}");
        }
      }
    } 
    while (f != null);
    Console.WriteLine(count);
  }
}
