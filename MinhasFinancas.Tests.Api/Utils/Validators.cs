using Xunit;
using System.Net;

public static class Validators
{

    public static void AssertThatStatusCodeIsEqualTo(HttpStatusCode returnedStatus, HttpStatusCode expectedStatusCode)
    {
        Assert.Equal(expectedStatusCode, returnedStatus);
       
    }

    public static void AssertThatStatusCodeIsSuccessful(HttpStatusCode returnedStatus)
    {
        int statusCode = (int)returnedStatus;
        Assert.InRange(statusCode, 200, 299);
    }


    public static void AssertThatIsEqualTo(string property, string returnedValue, string expectedValue)
    {
        Assert.Equal(expectedValue, returnedValue);
    }

    public static void AssertThatIsEqualToInt(string property, int returnedValue, int expectedValue)
    {
        Assert.Equal(expectedValue, returnedValue);
    }

}
