namespace MsgBoxSamples
{
    using System.Windows;
    using MsgBox;
    using MsgBoxSamples.ViewModel;
    using ServiceLocator;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region constructor
        public MainWindow()
        {
            this.InitializeComponent();

            ////Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            ////Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            ////Thread.CurrentThread.CurrentCulture = new CultureInfo("de-DE");
            ////Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-DE");

            ServiceContainer.Instance.AddService<IMessageBoxService>(new MessageBoxService());

            this.DataContext = new MsgBoxTestViewModel();
        }
        #endregion constructor
    }
}
