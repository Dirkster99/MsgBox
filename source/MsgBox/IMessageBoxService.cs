namespace MsgBox
{
    using System;
    using System.Windows;

    /// <summary>
    /// Implements the interface that supplies the API for showing a modal messagebox.
    /// </summary>
    public interface IMessageBoxService
    {
        #region properties
        /// <summary>
        /// Get/set property to determine whether message box can be styled in WPF or not.
        /// </summary>
        MsgBoxStyle Style
        {
            get; set;
        }
        #endregion properties

        #region methods
        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(string messageBoxText,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="caption"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(string messageBoxText, string caption,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="caption"></param>
        /// <param name="buttonOption"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(string messageBoxText, string caption,
                          MsgBoxButtons buttonOption,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="caption"></param>
        /// <param name="buttonOption"></param>
        /// <param name="image"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(string messageBoxText, string caption,
                          MsgBoxButtons buttonOption, MsgBoxImage image,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="caption"></param>
        /// <param name="details"></param>
        /// <param name="buttonOption"></param>
        /// <param name="image"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(string messageBoxText, string caption,
                          string details,
                          MsgBoxButtons buttonOption, MsgBoxImage image,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="caption"></param>
        /// <param name="buttonOption"></param>
        /// <param name="image"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(Exception exp, string caption,
                          MsgBoxButtons buttonOption, MsgBoxImage image,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="exp"></param>
        /// <param name="textMessage"></param>
        /// <param name="caption"></param>
        /// <param name="buttonOption"></param>
        /// <param name="image"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="enableCopyFunction"></param>
        /// <returns></returns>
        MsgBoxResult Show(Exception exp,
                          string textMessage = "", string caption = "",
                          MsgBoxButtons buttonOption = MsgBoxButtons.OK,
                          MsgBoxImage image = MsgBoxImage.Error,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool enableCopyFunction = false);

        /// <summary>
        /// Show a model message box dialog.
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
        MsgBoxResult Show(Window owner,
                          string messageBoxText, string caption = "",
                          MsgBoxButtons buttonOption = MsgBoxButtons.OK,
                          MsgBoxImage image = MsgBoxImage.Error,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLinkLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="messageBoxText"></param>
        /// <param name="caption"></param>
        /// <param name="defaultCloseResult"></param>
        /// <param name="dialogCanCloseViaChrome"></param>
        /// <param name="buttonOption"></param>
        /// <param name="image"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLinkLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(Window owner,
                          string messageBoxText, string caption,
                          MsgBoxResult defaultCloseResult,
                          bool dialogCanCloseViaChrome,
                          MsgBoxButtons buttonOption = MsgBoxButtons.OK,
                          MsgBoxImage image = MsgBoxImage.Error,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLinkLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="defaultCloseResult"></param>
        /// <param name="dialogCanCloseViaChrome"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(string messageBoxText,
                          MsgBoxResult defaultCloseResult,
                          bool dialogCanCloseViaChrome,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="caption"></param>
        /// <param name="defaultCloseResult"></param>
        /// <param name="dialogCanCloseViaChrome"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(string messageBoxText, string caption,
                          MsgBoxResult defaultCloseResult,
                          bool dialogCanCloseViaChrome,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="caption"></param>
        /// <param name="buttonOption"></param>
        /// <param name="defaultCloseResult"></param>
        /// <param name="dialogCanCloseViaChrome"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(string messageBoxText, string caption,
                          MsgBoxButtons buttonOption,
                          MsgBoxResult defaultCloseResult,
                          bool dialogCanCloseViaChrome,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="caption"></param>
        /// <param name="buttonOption"></param>
        /// <param name="image"></param>
        /// <param name="defaultCloseResult"></param>
        /// <param name="dialogCanCloseViaChrome"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(string messageBoxText, string caption,
                          MsgBoxButtons buttonOption, MsgBoxImage image,
                          MsgBoxResult defaultCloseResult,
                          bool dialogCanCloseViaChrome,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);

        /// <summary>
        /// Show a model message box dialog.
        /// </summary>
        /// <param name="messageBoxText"></param>
        /// <param name="caption"></param>
        /// <param name="details"></param>
        /// <param name="buttonOption"></param>
        /// <param name="image"></param>
        /// <param name="defaultCloseResult"></param>
        /// <param name="dialogCanCloseViaChrome"></param>
        /// <param name="btnDefault"></param>
        /// <param name="helpLink"></param>
        /// <param name="helpLinkTitle"></param>
        /// <param name="helpLabel"></param>
        /// <param name="navigateHelplinkMethod"></param>
        /// <param name="showCopyMessage"></param>
        /// <returns></returns>
        MsgBoxResult Show(string messageBoxText, string caption,
                          string details,
                          MsgBoxButtons buttonOption, MsgBoxImage image,
                          MsgBoxResult defaultCloseResult,
                          bool dialogCanCloseViaChrome,
                          MsgBoxResult btnDefault = MsgBoxResult.None,
                          object helpLink = null,
                          string helpLinkTitle = "",
                          string helpLabel = "",
                          Func<object, bool> navigateHelplinkMethod = null,
                          bool showCopyMessage = false);
        #endregion methods
    }
}
