namespace MsgBoxSamples
{
  using System.Windows;
  using MsgBoxSamples.ViewModel;

  /// <summary>
  /// Interaction logic for Window1.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    #region constructor
    public MainWindow()
    {
      this.InitializeComponent();

      this.DataContext = new MsgBoxTestViewModel();
    }
    #endregion constructor
  }
}
