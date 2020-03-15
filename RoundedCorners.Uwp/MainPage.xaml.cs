using RoundedCorners.Uwp.Helpers;

using Windows.UI.Xaml.Controls;

namespace RoundedCorners.Uwp
{
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();

      CompositionHelper.Initialize(this, HostBackDropGrid);
    }
  }
}