﻿namespace MsgBox.Behaviour
{
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Input;

  /// <summary>
  /// This attached property can be used to set the keyboard focus on a button that has
  /// IsDefault="True". Keyboard focus is required to support keyboard navigation with cursor keys.
  /// </summary>
  public static class SetKeyboardFocusWhenIsDefault
  {
    private static readonly DependencyProperty SetFocusProperty =
        DependencyProperty.RegisterAttached("SetFocus",
                                            typeof(bool),
                                            typeof(SetKeyboardFocusWhenIsDefault),
                                            new UIPropertyMetadata(false, OnSetFocusChanged));

    /// <summary>
    /// Get portion of dependency property
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    public static bool GetSetFocus(DependencyObject obj)
    {
      return (bool)obj.GetValue(SetFocusProperty);
    }

    /// <summary>
    /// Set portion of dependency property
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="value"></param>
    public static void SetSetFocus(DependencyObject obj, bool value)
    {
      obj.SetValue(SetFocusProperty, value);
    }

    /// <summary>
    /// Attach event handler when the attached property is set to true
    /// </summary>
    /// <param name="d"></param>
    /// <param name="e"></param>
    private static void OnSetFocusChanged(DependencyObject d,
                                          DependencyPropertyChangedEventArgs e)
    {
      var button = d as Button;

      if (e.NewValue != null)
      {
        if (e.NewValue is bool)
        {
          if (button != null && ((bool)e.NewValue) == true)
          {
            button.Loaded += new RoutedEventHandler(button_Loaded);
            button.Unloaded += new RoutedEventHandler(button_Unloaded);
          }
        }
      }
    }

    /// <summary>
    /// Detach eventhandlers when button is about to be destroyed
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void button_Unloaded(object sender, RoutedEventArgs e)
    {
      var button = sender as Button;
      
      if (button.IsDefault == true)
      {
        button.Unloaded -= button_Unloaded;
        button.Loaded -= button_Loaded;
      }
    }

    /// <summary>
    /// Attach to the onloaded event and set keyboard focus on this button if it is already a default
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private static void button_Loaded(object sender, RoutedEventArgs e)
    {
      var button = sender as Button;

      if (button.IsDefault == true)
      {
        Keyboard.Focus(button);
      }      
    }
  }
}
