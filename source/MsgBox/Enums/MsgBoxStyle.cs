namespace MsgBox
{
  /// <summary>
  /// A message box can be presented using different WPF styles.
  /// </summary>
  public enum MsgBoxStyle
  {
    /// <summary>
    /// Use the native Windows system look &amp; feel to show message box dialogs (standard window chrome).
    /// </summary>
    System = 0,

    /// <summary>
    /// Use a custom WPF look &amp; feel to show message box dialogs (custom window chrome).
    /// </summary>
    WPFThemed = 1
  }
}
