using OSGeo.OGR;
using USACE.HEC.Consequences;

namespace Geospatial;

// process an OGR driver into a stream of structures and apply a process to the structure
public class SpatialStructureProcessor : IFileStreamingProcessor
{
  public void Process(string filePath, Action<IConsequencesReceptor> consequenceReceptorProcess)
  {
    GDALAssist.GDALSetup.InitializeMultiplatform();

    using DataSource ds = Ogr.Open(filePath, 0);
    if (ds == null)
    {
      Console.WriteLine("error");
      return;
    }

    Layer layer = ds.GetLayerByIndex(0);
    if (layer == null)
    {
      Console.WriteLine("error");
      return;
    }

    Feature structure;
    while ((structure = layer.GetNextFeature()) != null)
    {
      Structure s = new();
      for (int i = 0; i < structure.GetFieldCount(); i++)
      {
        switch (structure.GetFieldDefnRef(i).GetFieldType())
        {
          // these are the valid types for fields of a structure
          case FieldType.OFTInteger:
            InitializeStructureField(s, structure.GetFieldDefnRef(i).GetName(), structure.GetFieldAsInteger(i));
            break;
          case FieldType.OFTInteger64:
            InitializeStructureField(s, structure.GetFieldDefnRef(i).GetName(), structure.GetFieldAsInteger64(i));
            break;
          case FieldType.OFTReal:
            InitializeStructureField(s, structure.GetFieldDefnRef(i).GetName(), structure.GetFieldAsDouble(i));
            break;
          case FieldType.OFTString:
            InitializeStructureField(s, structure.GetFieldDefnRef(i).GetName(), structure.GetFieldAsString(i));
            break;
          default:
            break;
        }
      }
      consequenceReceptorProcess(s);
      structure.Dispose();
    }
  }

  private static void InitializeStructureField<T>(Structure s, string fieldName, T value)
  {
    if (value == null)
    {
      return;
    }
    switch (fieldName)
    {
      case "fd_id":
        s.Name = (int)Convert.ChangeType(value, typeof(int));
        break;
      case "st_damcat":
        s.DamCat = (string)Convert.ChangeType(value, typeof(string));
        break;
      case "cbfips":
        s.CBFips = (string)Convert.ChangeType(value, typeof(string));
        break;
      case "x":
        s.X = (double)Convert.ChangeType(value, typeof(double));
        break;
      case "y":
        s.Y = (double)Convert.ChangeType(value, typeof(double));
        break;
      case "ground_elv":
        s.GroundElevation = (double)Convert.ChangeType(value, typeof(double));
        break;
      case "occtype":
        s.Occtype = (string)Convert.ChangeType(value, typeof(string));
        break;
      case "found_type":
        s.FoundationType = (string)Convert.ChangeType(value, typeof(string));
        break;
      case "firmzone":
        s.FirmZone = (string)Convert.ChangeType(value, typeof(string));
        break;
      case "bldgtype":
        s.ConstructionType = (string)Convert.ChangeType(value, typeof(string));
        break;
      case "val_struct":
        s.StructVal = (double)Convert.ChangeType(value, typeof(double));
        break;
      case "val_cont":
        s.ContVal = (double)Convert.ChangeType(value, typeof(double));
        break;
      case "found_ht":
        s.FoundHt = (double)Convert.ChangeType(value, typeof(double));
        break;
      case "num_story":
        s.NumStories = (int)Convert.ChangeType(value, typeof(int));
        break;
      case "pop2pmo65":
        s.Popo65day = (int)Convert.ChangeType(value, typeof(int));
        break;
      case "pop2pmu65":
        s.Popu65day = (int)Convert.ChangeType(value, typeof(int));
        break;
      case "pop2amo65":
        s.Popo65night = (int)Convert.ChangeType(value, typeof(int));
        break;
      case "pop2amu65":
        s.Popu65night = (int)Convert.ChangeType(value, typeof(int));
        break;
      default:
        break;
    }
  }
}