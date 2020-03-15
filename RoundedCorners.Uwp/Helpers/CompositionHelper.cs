using System.Numerics;

using Microsoft.Graphics.Canvas.Effects;

using Windows.UI;
using Windows.UI.Composition;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Hosting;

namespace RoundedCorners.Uwp.Helpers
{
  public static class CompositionHelper
  {
    private static Page Page;
    private static UIElement UiElement;
    private static Compositor Compositor;
    private static SpriteVisual SpriteVisual;
    private static ContainerVisual ContainerVisual;

    public static void Initialize(Page page, UIElement uiElement)
    {
      Page = page;
      UiElement = uiElement;

      Initialize();
    }

    private static void Initialize()
    {
      Compositor = ElementCompositionPreview.GetElementVisual(UiElement).Compositor;

      ContainerVisual = Compositor.CreateContainerVisual();

      SpriteVisual = Compositor.CreateSpriteVisual();
      SpriteVisual.Size = new Vector2((float)Window.Current.Bounds.Width, (float)Window.Current.Bounds.Height);
      SpriteVisual.Brush = CreateBackdropBrush();

      ContainerVisual.Children.InsertAtTop(SpriteVisual);

      ElementCompositionPreview.SetElementChildVisual(UiElement, ContainerVisual);

      Page.SizeChanged += OnSizeChanged;
    }

    private static void OnSizeChanged(object sender, SizeChangedEventArgs e)
    {
      if (SpriteVisual != null)
      {
        SpriteVisual.Size = new Vector2((float)e.NewSize.Width, (float)e.NewSize.Height);
      }
    }

    private static CompositionEffectBrush CreateBackdropBrush()
    {
      var systemChromeMediumColor = (Color)Application.Current.Resources["SystemChromeMediumColor"];

      var effect = new ArithmeticCompositeEffect
      {
        Source1 = new CompositionEffectSourceParameter("hostbackdrop"),
        Source2 = new ColorSourceEffect
        {
          Color = systemChromeMediumColor,
        },
        Source1Amount = 0.75f,
        Source2Amount = 0.25f
      };

      var factory = Compositor.CreateEffectFactory(effect, null);

      var brush = factory.CreateBrush();
      brush.SetSourceParameter("hostbackdrop", Compositor.CreateHostBackdropBrush());

      return brush;
    }
  }
}