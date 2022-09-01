namespace MauiFails;

public partial class MainPage : ContentPage
{
       int count =

       public MainPag
    {
              InitializeCompon
    }

       Random rand = new Random
       private async void OnCounterClicked(object sender, EventArgs
    {
              co

              if (count
                     CounterBtn.Text = $"Clicked {coun
        else
                     CounterBtn.Text = $"Clicked {count

              SemanticScreenReader.Announce(CounterBtn.

              await MovingBtnGrid.TranslateTo(rand.Next(0, 200), rand.Next(0, 200), 250, Easing.Bounc
              MovingBtn.WidthTo(rand.Next(30, 200), 400, Easing.Boun
    }

       private void OnMovingButtonClicked(object sender, EventArgs
    {
              MovingBtn.Text = DateTime.Now.ToStr
              Console.WriteLine("click");
    }

       private void BorderTapped(object sender, EventArgs
    {
              Console.WriteLine("border tapped");
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