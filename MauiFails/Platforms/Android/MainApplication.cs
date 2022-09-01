using Android.App;
using Android.Runtime;

namespace MauiFails;

[Application]
public class MainApplication : MauiApplication
{
       public MainApplication(IntPtr handle, JniHandleOwnership ownersh
              : base(handle, owne
    {
    }

       protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
