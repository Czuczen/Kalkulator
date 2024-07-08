using NUnit.Framework;
using Soneta.Business;
using Soneta.Business.App;
using System.Reflection;
using System;

// cannot create login
// error not resolved
//[SetUpFixture]
public class TestSessionFixture
{
    public static Session TestSession { get; private set; }
    public static Context TestContext { get; private set; }
    private static Login TestLogin { get; set; }


    [OneTimeSetUp]
    public void GlobalSetup()
    {
        var app = BusApplication.Instance;
        TestLogin = CreateLoginInstance(app);
        TestSession = CreateSessionInstance(TestLogin);
        TestContext = new TestContext(TestSession);
    }

    [OneTimeTearDown]
    public void GlobalTeardown()
    {
        TestSession?.Dispose();
        TestLogin?.Dispose();
    }

    private Login CreateLoginInstance(BusApplication app)
    {
        //var login = BusApplication.Instance.Login(false);

        var loginConstructor = typeof(Login).GetConstructor(
            BindingFlags.NonPublic | BindingFlags.Instance,
            null,
            new Type[] { typeof(BusApplication) },
            null);

        // cannot create login
        if (loginConstructor == null)
            throw new InvalidOperationException("Login constructor not found.");

        return (Login)loginConstructor.Invoke(new object[] { app });
    }

    private Session CreateSessionInstance(Login login)
    {
        var sessionConstructor = typeof(Session).GetConstructor(
            BindingFlags.NonPublic | BindingFlags.Instance,
            null,
            new Type[] { typeof(Login), typeof(bool), typeof(bool), typeof(string) },
            null);

        if (sessionConstructor == null)
            throw new InvalidOperationException("Session constructor not found.");

        return (Session)sessionConstructor.Invoke(new object[] { login, false, false, "TestSession" });
    }
}
