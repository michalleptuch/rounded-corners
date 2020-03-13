using System;
using System.Windows;

namespace RoundedCorners
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();
    }

    private void OnChildChanged(object sender, EventArgs e)
    {
      var windowsXamlHost = sender as Microsoft.Toolkit.Wpf.UI.XamlHost.WindowsXamlHost;
      var userControl = windowsXamlHost.GetUwpInternalObject() as Uwp.MainPage;

      if (userControl != null)
      {
        userControl.ExitButton.Click += (s, e) =>
        {
          App.Current.Shutdown();
        };
      }
    }
  }
}