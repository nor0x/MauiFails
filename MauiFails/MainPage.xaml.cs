namespace MauiFails;

public partial class MainPage : ContentPage
{
    int count = 0;
    Image secondImage;
    public MainPage()
    {
        InitializeComponent();

        var mycontrol = new Border()
        {
            WidthRequest = 400,
            HeightRequest = 400,
            Background = Colors.Green,
            Content = new Grid()
            {
                Children =
                {
                    new Image()
                    {
                        Source = "grid.png",
                        WidthRequest = 800,
                        HeightRequest = 800,
                    }
                }
            }
        };
        if(mycontrol.Content is Grid g && g.Children.FirstOrDefault() is Image img)
        {
            secondImage = img;
        }
        //ContainerGrid.Add(mycontrol, 1, 0);
    }

    Random rand = new Random();
    private async void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);

        await MovingBtnGrid.TranslateTo(rand.Next(0, 200), rand.Next(0, 200), 250, Easing.BounceOut);
        MovingBtn.WidthTo(rand.Next(30, 200), 400, Easing.BounceIn);
    }

    private void OnMovingButtonClicked(object sender, EventArgs e)
    {
        MovingBtn.Text = DateTime.Now.ToString();
        Console.WriteLine("click");
    }

    private void BorderTapped(object sender, EventArgs e)
    {
        Console.WriteLine("border tapped");
    }
    
    private void MoveImagesClicked(object sender, EventArgs e)
    {
        firstImage.TranslateTo(300, 300, 1000, Easing.Linear);
        secondImage.TranslateTo(300, 300, 1000, Easing.Linear);
    }
}

public static class Extensions
{
    public static async Task<bool> HeightTo(this View view, double height, uint duration = 250, Easing easing = null)
    {
        var tcs = new TaskCompletionSource<bool>();

        var heightAnimation = new Animation(x => view.HeightRequest = x, view.Height, height);
        heightAnimation.Commit(view, "HeightAnimation", 10, duration, easing, (finalValue, finished) => { tcs.SetResult(finished); });

        return await tcs.Task;
    }

    public static async Task<bool> WidthTo(this View view, double width, uint duration = 250, Easing easing = null)
    {
        var tcs = new TaskCompletionSource<bool>();

        var heightAnimation = new Animation(x => view.WidthRequest = x, view.Height, width);
        heightAnimation.Commit(view, "WidthAnimation", 10, duration, easing, (finalValue, finished) => { tcs.SetResult(finished); });

        return await tcs.Task;
    }
}