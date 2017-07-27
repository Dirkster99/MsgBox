namespace MsgBox.View.Modern
{
  using System;
  using System.Windows;
  using System.Windows.Input;
  using MsgBox.Internal.ViewModel;

  /// <summary>
  /// Represents a Modern UI styled dialog window.
  /// </summary>
  public class ModernDialog : UserNotification.View.NotifyableWindow
  {
    #region fields
    /// <summary>
    /// Identifies the BackgroundContent dependency property.
    /// </summary>
    public static readonly DependencyProperty BackgroundContentProperty = DependencyProperty.Register("BackgroundContent", typeof(object), typeof(ModernDialog));

    [ThreadStatic]
    private static ModernDialog mMessageBox;
    #endregion fields

    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="ModernDialog"/> class.
    /// </summary>
    public ModernDialog()
    {
      this.DefaultStyleKey = typeof(ModernDialog);
    }
    #endregion constructor

    #region properties
    /// <summary>
    /// Gets or sets the background content of this window instance.
    /// </summary>
    public object BackgroundContent
    {
      get { return GetValue(BackgroundContentProperty); }
      set { SetValue(BackgroundContentProperty, value); }
    }
    #endregion properties

    #region methods
    /// <summary>
    /// Display a message box based on a given view model.
    /// </summary>
    /// <param name="viewModel">The viewmodel contains additional
    /// parameters for the message view.</param>
    /// <param name="owner">The message view will be attached to this owning window
    /// of this parameter is non-null, otherwise Application.Current.MainWindow
    /// is being used.</param>
    /// <returns></returns>
    internal static MsgBoxResult Show(MsgBoxViewModel viewModel,
                                      Window owner = null)
    {
      // Construct the message box view and add the viewmodel to it
      ModernDialog.mMessageBox = new ModernDialog() { DataContext = viewModel };


      if (owner == null)
      {
        if (Application.Current != null)
        {
          if (ModernDialog.mMessageBox != Application.Current.MainWindow)
            ModernDialog.mMessageBox.Owner = Application.Current.MainWindow;
        }
      }
      else
      {
        if (ModernDialog.mMessageBox != owner)
          ModernDialog.mMessageBox.Owner = owner;
      }

      // Last resourt check to mack sire window opens without main window (eg.: in start-up sequence)
      if (ModernDialog.mMessageBox.Owner == ModernDialog.mMessageBox)
        ModernDialog.mMessageBox.Owner = null;

      ModernDialog.mMessageBox.Content = new MsgBoxView();
      ModernDialog.mMessageBox.DataContext = viewModel;

      // Add key binding to close dialog via Escape key
      InputGesture g = new KeyGesture(Key.Escape, ModifierKeys.None);
      InputBinding input = new InputBinding(viewModel.CloseCommand, g) { CommandParameter = viewModel.DefaultCloseResult };
      ModernDialog.mMessageBox.InputBindings.Add(input);

      // Add key binding to copy message text via CONTROL-C key gesture
      g = new KeyGesture(Key.C, ModifierKeys.Control);
      input = new InputBinding(viewModel.CopyText, g) { CommandParameter = viewModel.AllToString };
      ModernDialog.mMessageBox.InputBindings.Add(input);

      ModernDialog.mMessageBox.WindowStartupLocation = WindowStartupLocation.CenterOwner;

      ModernDialog.mMessageBox.Closing += viewModel.MessageBox_Closing;

      ModernDialog.mMessageBox.ShowDialog();

      return viewModel.Result;
    }
    #endregion methods
  }
}
