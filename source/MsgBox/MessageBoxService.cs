namespace MsgBox
{
  using System;
  using System.Windows;
  using MsgBox.Internal.ViewModel;

  /// <summary>
  /// A service that shows message boxes.
  /// 
  /// Source: http://www.codeproject.com/Articles/70223/Using-a-Service-Locator-to-Work-with-MessageBoxes
  /// </summary>
  public sealed class MessageBoxService : IMessageBoxService
  {
    #region fields
    private MsgBoxStyle mStyle;
    #endregion fields

    #region constructor
    /// <summary>
    /// Class constructor
    /// </summary>
    public MessageBoxService()
    {
      this.mStyle = MsgBoxStyle.System;
    }
    #endregion constructor

    #region properties
    /// <summary>
    /// Get/set property to determine whether message box can be styled in WPF or not.
    /// </summary>
    public MsgBoxStyle Style
    {
      get
      {
        return this.mStyle;
      }

      set
      {
        if (this.mStyle != value)
          this.mStyle = value;
      }
    }
    #endregion properties

    #region methods
    #region IMsgBoxService methods
    MsgBoxResult IMessageBoxService.Show(string messageBoxText,
                                     MsgBoxResult btnDefault,
                                     object helpLink,
                                     string helpLinkTitle, string helpLinkLabel,
                                     Func<object, bool> navigateHelplinkMethod,
                                     bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, string.Empty, string.Empty,
                                        MsgBoxButtons.OK, MsgBoxImage.Default, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    MsgBoxResult IMessageBoxService.Show(string messageBoxText,
                                     string caption,
                                     MsgBoxResult btnDefault,
                                     object helpLink,
                                     string helpLinkTitle, string helpLinkLabel,
                                     Func<object, bool> navigateHelplinkMethod,
                                     bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, caption, "",
                                        MsgBoxButtons.OK, MsgBoxImage.Default, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    MsgBoxResult IMessageBoxService.Show(string messageBoxText,
                                     string caption,
                                     MsgBoxButtons buttonOption,
                                     MsgBoxResult btnDefault,
                                     object helpLink,
                                     string helpLinkTitle, string helpLinkLabel,
                                     Func<object, bool> navigateHelplinkMethod,
                                     bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, caption, "",
                                        buttonOption, MsgBoxImage.Default, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    MsgBoxResult IMessageBoxService.Show(string messageBoxText,
                                     string caption,
                                     MsgBoxButtons buttonOption,
                                     MsgBoxImage image,
                                     MsgBoxResult btnDefault,
                                     object helpLink,
                                     string helpLinkTitle, string helpLinkLabel,
                                     Func<object, bool> navigateHelplinkMethod,
                                     bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, caption, "",
                                        buttonOption, image, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage);

      switch(this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    /// <summary>
    /// Show a messagebox with details (such as a stacktrace or other information that can be kept in an expander).
    /// </summary>
    /// <param name="details"></param>
    /// <param name="buttonOption"></param>
    /// <param name="image"></param>
    /// <param name="btnDefault"></param>
    /// <param name="caption"></param>
    /// <param name="helpLink"></param>
    /// <param name="helpLinkLabel"></param>
    /// <param name="helpLinkTitle"></param>
    /// <param name="messageBoxText"></param>
    /// <param name="navigateHelplinkMethod"></param>
    /// <param name="showCopyMessage"></param>
    /// <returns></returns>
    MsgBoxResult IMessageBoxService.Show(string messageBoxText,
                                     string caption,
                                     string details,
                                     MsgBoxButtons buttonOption,
                                     MsgBoxImage image,
                                     MsgBoxResult btnDefault,
                                     object helpLink,
                                     string helpLinkTitle, string helpLinkLabel,
                                     Func<object, bool> navigateHelplinkMethod,
                                     bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, caption, null,
                                        buttonOption, image, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    MsgBoxResult IMessageBoxService.Show(Exception exp, string caption,
                                     MsgBoxButtons buttonOption, MsgBoxImage image,
                                     MsgBoxResult btnDefault,
                                     object helpLink,
                                     string helpLinkTitle,
                                     string helpLabel,
                                     Func<object, bool> navigateHelplinkMethod,
                                     bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(exp, "", caption, "",
                                        buttonOption, image, btnDefault,
                                        helpLink, helpLinkTitle, helpLabel, navigateHelplinkMethod,
                                        showCopyMessage);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    MsgBoxResult IMessageBoxService.Show(Exception exp, string messageBoxText, string caption,
                                     MsgBoxButtons buttonOption, MsgBoxImage image,
                                     MsgBoxResult btnDefault,
                                     object helpLink,
                                     string helpLinkTitle,
                                     string helpLinkLabel,
                                     Func<object, bool> navigateHelplinkMethod,
                                     bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(exp, messageBoxText, caption, "",
                                        buttonOption, image, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    /// <summary>
    /// Show message box with explicit referenc to owner window.
    /// </summary>
    /// <param name="owner"></param>
    /// <param name="messageBoxText"></param>
    /// <param name="caption"></param>
    /// <param name="buttonOption"></param>
    /// <param name="image"></param>
    /// <param name="btnDefault"></param>
    /// <param name="helpLink"></param>
    /// <param name="helpLinkTitle"></param>
    /// <param name="helpLinkLabel"></param>
    /// <param name="navigateHelplinkMethod"></param>
    /// <param name="showCopyMessage"></param>
    /// <returns></returns>
    MsgBoxResult IMessageBoxService.Show(Window owner,
                                     string messageBoxText, string caption, 
                                     MsgBoxButtons buttonOption,
                                     MsgBoxImage image,
                                     MsgBoxResult btnDefault,
                                     object helpLink,
                                     string helpLinkTitle,
                                     string helpLinkLabel,
                                     Func<object, bool> navigateHelplinkMethod ,
                                     bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, caption, "",
                                        buttonOption, image, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm, owner);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm, owner);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    MsgBoxResult IMessageBoxService.Show(Window owner,
                                     string messageBoxText, string caption,
                                     MsgBoxResult defaultCloseResult,
                                     bool dialogCanCloseViaChrome,
                                     MsgBoxButtons buttonOption,
                                     MsgBoxImage image,
                                     MsgBoxResult btnDefault,
                                     object helpLink,
                                     string helpLinkTitle,
                                     string helpLinkLabel,
                                     Func<object, bool> navigateHelplinkMethod,
                                     bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, caption, string.Empty,
                                        buttonOption, image, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage,
                                        defaultCloseResult, dialogCanCloseViaChrome);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm, owner);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm, owner);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    MsgBoxResult IMessageBoxService.Show(string messageBoxText,
                                     MsgBoxResult defaultCloseResult,
                                     bool dialogCanCloseViaChrome,
                                     MsgBoxResult btnDefault,
                                     object helpLink,
                                     string helpLinkTitle,
                                     string helpLinkLabel,
                                     Func<object, bool> navigateHelplinkMethod,
                                     bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, string.Empty, string.Empty,
                                        MsgBoxButtons.OK, MsgBoxImage.Default, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage,
                                        defaultCloseResult, dialogCanCloseViaChrome);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    MsgBoxResult IMessageBoxService.Show(string messageBoxText, string caption,
                                     MsgBoxResult defaultCloseResult,
                                     bool dialogCanCloseViaChrome,
                                     MsgBoxResult btnDefault,
                                     object helpLink,
                                     string helpLinkTitle,
                                     string helpLinkLabel,
                                     Func<object, bool> navigateHelplinkMethod,
                                     bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, caption, string.Empty,
                                        MsgBoxButtons.OK, MsgBoxImage.Default, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage,
                                        defaultCloseResult, dialogCanCloseViaChrome);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    MsgBoxResult IMessageBoxService.Show(string messageBoxText, string caption,
                                      MsgBoxButtons buttonOption,
                                      MsgBoxResult defaultCloseResult,
                                      bool dialogCanCloseViaChrome,
                                      MsgBoxResult btnDefault,
                                      object helpLink,
                                      string helpLinkTitle,
                                      string helpLinkLabel,
                                      Func<object, bool> navigateHelplinkMethod,
                                      bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, caption, string.Empty,
                                        buttonOption, MsgBoxImage.Default, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage,
                                        defaultCloseResult, dialogCanCloseViaChrome);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    MsgBoxResult IMessageBoxService.Show(string messageBoxText, string caption,
                                      MsgBoxButtons buttonOption, MsgBoxImage image,
                                      MsgBoxResult defaultCloseResult,
                                      bool dialogCanCloseViaChrome,
                                      MsgBoxResult btnDefault,
                                      object helpLink,
                                      string helpLinkTitle,
                                      string helpLinkLabel,
                                      Func<object, bool> navigateHelplinkMethod,
                                      bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, caption, string.Empty,
                                        buttonOption, image, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage,
                                        defaultCloseResult, dialogCanCloseViaChrome);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }

    MsgBoxResult IMessageBoxService.Show(string messageBoxText, string caption,
                                      string details,
                                      MsgBoxButtons buttonOption, MsgBoxImage image,
                                      MsgBoxResult defaultCloseResult,
                                      bool dialogCanCloseViaChrome,
                                      MsgBoxResult btnDefault,
                                      object helpLink,
                                      string helpLinkTitle,
                                      string helpLinkLabel,
                                      Func<object, bool> navigateHelplinkMethod,
                                      bool showCopyMessage)
    {
      var vm = this.InitializeViewModel(null, messageBoxText, caption, details,
                                        buttonOption, image, btnDefault,
                                        helpLink, helpLinkTitle, helpLinkLabel, navigateHelplinkMethod,
                                        showCopyMessage,
                                        defaultCloseResult, dialogCanCloseViaChrome);

      switch (this.Style)
      {
        case MsgBoxStyle.System:
          return View.MsgBoxDialog.Show(vm);

        case MsgBoxStyle.WPFThemed:
          return MsgBox.View.Modern.ModernDialog.Show(vm);

        default:
          throw new NotImplementedException(this.Style.ToString());
      }
    }
    #endregion IMsgBoxService methods

    #region private methods
    /// <summary>
    /// Construct a new message box viewmodel
    /// </summary>
    /// <returns></returns>
    private MsgBoxViewModel InitializeViewModel(
      Exception exp,
      string messageBoxText,
      string caption,
      string details,
      MsgBoxButtons buttonOption,
      MsgBoxImage image,
      MsgBoxResult btnDefault = MsgBoxResult.None,
      object helpLink = null,
      string helpLinkTitle = "",
      string helpLabel = "",
      Func<object, bool> navigateHelplinkMethod = null,
      bool enableCopyFunction = false,
      MsgBoxResult defaultCloseResult = MsgBoxResult.None,
      bool dialogCanCloseViaChrome = true)
    {
      if (exp == null)
      {
        // Construct the message box viewmodel WITHOUT System.Exception details
        var viewModel = new MsgBox.Internal.ViewModel.MsgBoxViewModel
        (
          messageBoxText, caption, details,
          buttonOption,
          image,
          btnDefault,
          helpLink, helpLinkTitle, navigateHelplinkMethod,
          enableCopyFunction,
          defaultCloseResult, dialogCanCloseViaChrome
        );

        viewModel.HyperlinkLabel = helpLabel;

        return viewModel;
      }
      else
      {
        string sMess = MsgBox.Local.Strings.Unknown_Error_Message;
        messageBoxText = string.Empty;

        messageBoxText = MsgBoxViewModel.GetExceptionDetails(exp, messageBoxText, out sMess);

        // Construct the message box viewmodel WITH System.Exception details
        var viewModel = new MsgBox.Internal.ViewModel.MsgBoxViewModel
        (
          messageBoxText, caption, sMess,
          buttonOption, image, btnDefault,
          helpLink, helpLinkTitle, navigateHelplinkMethod,
          enableCopyFunction,
          defaultCloseResult, dialogCanCloseViaChrome
        );

        viewModel.HyperlinkLabel = helpLabel;

        return viewModel;
      }
    }
    #endregion private methods
    #endregion methods
  }
}
