namespace MauiFails;

public partial class MyView : ContentView
{
    MyViewModel vm => BindingContext as MyViewModel;

    public MyView(MyViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
		SizeChanged += (s, e) =>
		{
			mylabel.Text = vm.GetMyValue();
		};
	}
}