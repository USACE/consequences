namespace USACE.HEC.Geography;
public class BoundingBox
{
  public Location UpperLeft { get; }
  public Location LowerRight { get; }

  public BoundingBox(Location upperLeft, Location lowerRight)
  {
    UpperLeft = upperLeft;
    LowerRight = lowerRight;
  }

  public string NSIFormat()
  {
    return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                         UpperLeft.X, UpperLeft.Y,
                         LowerRight.X, UpperLeft.Y,
                         LowerRight.X, LowerRight.Y,
                         UpperLeft.X, LowerRight.Y,
                         UpperLeft.X, UpperLeft.Y);
  }

  // not sure about this functionality right now, just a placeholder
  public string GDALFormat()
  {
    return string.Format("{0}{1}{2}{3}",
                         UpperLeft.X, UpperLeft.Y,
                         LowerRight.X, LowerRight.X);
  }
}
