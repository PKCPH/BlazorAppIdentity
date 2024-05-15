using BlazorApp.Test.Components.Pages;
using Bunit;
using Bunit.TestDoubles;

namespace BlazorApp.UnitTest;

public class AuthenticationTest
{
    [Fact]
    public void Authentication()
    {
        //Arange

        var ctx = new TestContext();
        var authContext = ctx.AddTestAuthorization();
        authContext.SetAuthorized("");

        //Act
        //cut = code under test
        var cut = ctx.RenderComponent<Home>();
        
        //Assert
        cut.MarkupMatches("<h1>Hello, world!</h1>");
    }
}