namespace Geospatial;

using System.Diagnostics.Contracts;
using MaxRev.Gdal.Core;
using OSGeo.GDAL;
using OSGeo.OGR;
using USACE.HEC.Consequences;
using USACE.HEC.Results;

public class TestClass
{ 
  public void Do()
  {
    GdalBase.ConfigureAll();

    Ogr.RegisterAll();
    using DataSource? ds = Ogr.Open("nsi_2022_44.gpkg", 0);
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
