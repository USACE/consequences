using USACE.HEC.Geography;

namespace ConsequencesTest;
public class BoundingBoxTest
{
  [Fact]
  public void TestNSI()
  {
    Location upperLeft = new Location { X = -40, Y = 50 };
    Location lowerRight = new Location { X = 60, Y = -50 };
    BoundingBox boundingBox = new BoundingBox(upperLeft, lowerRight);

    string NSIFormat = boundingBox.NSIFormat();

    string expected = "-40,50,60,50,60,-50,-40,-50,-40,50";
    Assert.Equal(expected, NSIFormat);
  }
}
