namespace Consequences;
[Flags]
public enum HazardParameter
{
  NoHazard,
  Depth          = 2,
  Velocity       = 4,
  ArrivalTime    = 8,
  ArrivalTime2ft = 16
}
