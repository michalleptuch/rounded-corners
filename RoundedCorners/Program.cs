namespace RoundedCorners
{
  public class Program
  {
    [System.STAThread()]
    public static void Main()
    {
      using (new Uwp.App())
      {
        App app = new App();
        app.InitializeComponent();
        app.Run();
      }
    }
  }
}
