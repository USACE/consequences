using OSGeo.OGR;
using OSGeo.OSR;

namespace Geospatial;
public class Utilities
{
  public static void StructureFieldTypes(Feature feature, string fieldName, object value)
  {
    switch (fieldName)
    {
      case "fd_id" or "num_story" or "pop2pmo65" or "pop2pmu65" or "pop2amo65" or "pop2amu65":
        feature.SetField(fieldName, (int)value);
        break;
      case "x" or "y" or "ground_elv" or "val_struct" or "val_cont" or "found_ht":
        feature.SetField(fieldName, (double)value);
        break;
      case "st_damcat" or "cbfips" or "occtype" or "found_type" or "firmzone" or "bldgtype":
        feature.SetField(fieldName, (string)value);
        break;
    }
  }
}

