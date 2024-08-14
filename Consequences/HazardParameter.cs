namespace Consequences;
[Flags]
public enum HazardParameter // backed by an int by default
{
  NoHazard       = 0,
  Depth          = 1,
  Velocity       = 2,
  ArrivalTime    = 4,
  ArrivalTime2ft = 8
}
