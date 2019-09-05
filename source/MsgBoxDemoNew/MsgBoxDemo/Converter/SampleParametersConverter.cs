﻿namespace MsgBoxSamples.Converter
{
  using System;
  using System.Globalization;
  using System.Windows.Data;

  /// <summary>
  /// Source: http://stackoverflow.com/questions/15952812/multiple-command-parameters-wpf-button-object
  /// </summary>
  public class SampleParametersConverter: IMultiValueConverter
  {
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {

      return new object[] { values[0], values[1] };
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
      return null;
    }
  }
}
