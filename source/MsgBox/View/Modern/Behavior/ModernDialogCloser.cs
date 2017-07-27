namespace MsgBox.View.Modern.Behavior
{
  using System.Windows;

  /// <summary>
  /// Implements an attached property that enables cloasing a
  /// <seealso cref="ModernDialog"/> view view viewmodel implementation.
  /// </summary>
  public static class ModernDialogCloser
  {
    /// <summary>
    /// Backing store of the Dialog closer dependency property.
    /// </summary>
    public static readonly DependencyProperty DialogCloserProperty =
        DependencyProperty.RegisterAttached("DialogCloser",
                                            typeof(bool?),
                                            typeof(ModernDialogCloser),
                                            new PropertyMetadata(null, DialogResultChanged));

    /// <summary>
    /// Get portion of the Dialog closer dependency property.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static int GetDialogCloser(DependencyObject obj)
    {
      return (int)obj.GetValue(DialogCloserProperty);
    }

    /// <summary>
    /// Set portion of the Dialog closer dependency property.
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="value"></param>
    public static void SetDialogCloser(DependencyObject obj, int value)
    {
      obj.SetValue(DialogCloserProperty, value);
    }

    private static void DialogResultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
      var window = d as ModernDialog;

      if (window != null)
      {
        // Setting the DialogResult property invokes the close method of the corresponding dialog
        window.DialogResult = e.NewValue as bool?;
      }
    }    
  }
}
