namespace MsgBox.Behaviour
{
  using System.Windows;

  /// <summary>
  /// Attachable behaviour class that can be used to tell a View (window) to close itself
  /// when the ViewModel has determined that. Usage in XAML and ViewModel:
  /// 
  /// ViewModel:
  /// private this.mDialogCloseResult = null;
  /// 
  /// public bool? DialogCloseResult
  /// {
  ///   get
  ///   {
  ///     return this.mmDialogCloseResult;
  ///   }
  ///
  ///   private set
  ///   {
  ///     if (this.mDialogCloseResult != value)
  ///     {
  ///       this.mDialogCloseResult = value;
  ///       this.NotifyPropertyChanged(() => this.DialogCloseResult);
  ///     }
  ///   }
  /// }
  /// 
  /// View:
  ///  
  /// &lt;Window ...
  /// xmlns:xc="clr-namespace:MsgBox.Internal.ViewModel"
  /// xc:DialogCloser.DialogResult="{Binding DialogCloseResult}"&gt;
  /// 
  /// Source: http://stackoverflow.com/questions/501886/wpf-mvvm-newbie-how-should-the-viewmodel-close-the-form
  /// </summary>
  public static class DialogCloser
  {
    private static readonly DependencyProperty DialogResultProperty =
        DependencyProperty.RegisterAttached(
            "DialogResult",
            typeof(bool?),
            typeof(DialogCloser),
            new PropertyMetadata(DialogResultChanged));

    /// <summary>
    /// Set portion of the dependency property
    /// </summary>
    /// <param name="target"></param>
    /// <param name="value"></param>
    public static void SetDialogResult(Window target, bool? value)
    {
      target.SetValue(DialogResultProperty, value);
    }

    private static void DialogResultChanged(DependencyObject d,
                                            DependencyPropertyChangedEventArgs e)
    {
      var window = d as Window;

      if (window != null)
      {
        // Setting the DialogResult property invokes the close method of the corresponding dialog
        window.DialogResult = e.NewValue as bool?;
      }
    }
  }
}
