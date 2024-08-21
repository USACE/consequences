namespace USACE.HEC.Geography;
public class BoundingBox
{
  private Location _upperLeft;
  private Location _lowerRight;

  public BoundingBox(Location upperLeft, Location lowerRight)
  {
    _upperLeft = upperLeft;
    _lowerRight = lowerRight;
  }

  public Location GetUpperLeft() { return _upperLeft; }
  public Location GetLowerRight() { return _lowerRight; }

  public string NSIFormat()
  {
    return string.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
                         _upperLeft.X, _upperLeft.Y,
                         _lowerRight.X, _upperLeft.Y,
                         _lowerRight.X, _lowerRight.Y,
                         _upperLeft.X, _lowerRight.Y,
                         _upperLeft.X, _upperLeft.Y);
  }

  // not sure about this functionality right now, just a placeholder
  public string GDALFormat()
  {
    return string.Format("{0}{1}{2}{3}",
                         _upperLeft.X, _upperLeft.Y,
                         _lowerRight.X, _lowerRight.X);
  }
}
