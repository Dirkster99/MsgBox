namespace MsgBox
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security;
	using System.Text;
	using System.Windows;

	/// <summary>
	/// Interface to non-static message box class methods and properties.
	/// </summary>
	public interface IMsgBox
	{
		#region properties
		/// <summary>
		/// Get/set property to determine whether message box can be styled in WPF or not.
		/// </summary>
		MsgBoxStyle Style { get; set; }
		#endregion properties

		#region methods
		#region System.MessageBox replacements
		/// <summary>
		/// Displays a message box that has a message and that returns a result.
		/// </summary>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(string messageBoxText);

		/// <summary>
		/// Displays a message box that has a message and that returns a result.
		/// </summary>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(string messageBoxText, string caption);

		/// <summary>
		/// Displays a message box that has a message and that returns a result.
		/// </summary>
		/// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(Window owner, string messageBoxText);

		/// <summary>
		/// Displays a message box that has a message, title bar caption, and button; and that returns a result.
		/// </summary>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <param name="button">A Msg.MessageBoxButton value that specifies which button or buttons to display.</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(string messageBoxText, string caption, MsgBoxButtons button);

		/// <summary>
		/// Displays a message box in front of the specified window.
		/// The message box displays a message and title bar caption; and it returns a result.
		/// </summary>
		/// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(Window owner, string messageBoxText, string caption);

		/// <summary>
		/// Displays a message box that has a message, title bar caption, button, and icon; and that returns a result.
		/// </summary>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <param name="button">A Msg.MessageBoxButton value that specifies which button or buttons to display.</param>
		/// <param name="icon">A Msg.MsgBoxImage value that specifies the icon to display.</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(string messageBoxText, string caption, MsgBoxButtons button, MsgBoxImage icon);

		/// <summary>
		/// Displays a message box in front of the specified window. The message box displays a message,
		/// title bar caption, and button; and it also returns a result.
		/// </summary>
		/// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <param name="button">A Msg.MsgBoxButtons value that specifies which button or buttons to display.</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(Window owner, string messageBoxText, string caption, MsgBoxButtons button);

		/// <summary>
		/// Displays a message box that has a message, title bar caption, button, and icon;
		/// and that accepts a default message box result and returns a result.
		/// </summary>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <param name="button">A Msg.MessageBoxButton value that specifies which button or buttons to display.</param>
		/// <param name="icon">A Msg.MessageBoxImage value that specifies the icon to display.</param>
		/// <param name="defaultResult">A MsgBox.MsgBoxResult value that specifies the default result of the message box.</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(string messageBoxText, string caption, MsgBoxButtons button, MsgBoxImage icon, MsgBoxResult defaultResult);

		/// <summary>
		/// Displays a message box in front of the specified window. The message box displays
		/// a message, title bar caption, button, and icon; and it also returns a result.
		/// </summary>
		/// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <param name="button">A Msg.MessageBoxButton value that specifies which button or buttons to display.</param>
		/// <param name="icon">A Msg.MessageBoxImage value that specifies the icon to display.</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(Window owner, string messageBoxText, string caption, MsgBoxButtons button, MsgBoxImage icon);

		/// <summary>
		/// Displays a message box in front of the specified window. The message box displays a message,
		/// title bar caption, button, and icon; and accepts a default message box result and returns a result.
		/// </summary>
		/// <param name="owner">A System.Windows.Window that represents the owner window of the message box.</param>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <param name="button">A Msg.MessageBoxButton value that specifies which button or buttons to display.</param>
		/// <param name="icon">A Msg.MessageBoxImage value that specifies the icon to display.</param>
		/// <param name="defaultResult">A MsgBox.MsgBoxResult value that specifies the default result of the message box.</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(Window owner, string messageBoxText, string caption, MsgBoxButtons button, MsgBoxImage icon, MsgBoxResult defaultResult);
		#endregion System.MessageBox replacements

		#region custom messagebox methods
		/// <summary>
		/// Display a message box. The message box displays a message, title bar caption, button, and icon.
		/// Further options, such as, link to background information + naviagtion function, and copy button
		/// can be displayed.
		/// 
		/// The mothod accepts a default message box <seealso cref="MsgBoxResult"/> result and returns a result.
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
		[SecurityCritical]
		MsgBoxResult Show(string messageBoxText,
																		string caption,
																		MsgBoxButtons buttonOption,
																		MsgBoxResult btnDefault = MsgBoxResult.None,
																		object helpLink = null,
																		string helpLinkTitle = "",
																		string helpLabel = "",
																		Func<object, bool> navigateHelplinkMethod = null,
																		bool showCopyMessage = false);

		/// <summary>
		/// Displays a message box that has a message, title bar caption, button, and icon;
		/// and that accepts a default message box result and returns a result.
		/// </summary>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <param name="button">A Msg.MessageBoxButton value that specifies which button or buttons to display.</param>
		/// <param name="icon">A Msg.MessageBoxImage value that specifies the icon to display.</param>
		/// <param name="defaultResult">A MsgBox.MsgBoxResult value that specifies the default result of the message box.</param>
		/// <param name="helpLink">Determines the address to browsed to when displaying a help link. This parameter can be a URI or string object.</param>
		/// <param name="helpLinkTitle">Determines the text for displaying a help link.
		/// By default the text is the toString() content of the <paramref name="helpLink"/>
		/// but it can also be a different text set here.</param>
		/// <param name="helpLinkLabel">Text label of the displayed hyperlink (if any)</param>
		/// <param name="navigateHelplinkMethod">Method to execute when the user clicked the hyperlink</param>
		/// <param name="showCopyMessage">Show a UI element (e.g. button) that lets the user copy the displayed message into the Windows clipboard</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(string messageBoxText, string caption, MsgBoxButtons button, MsgBoxImage icon, MsgBoxResult defaultResult,
																		object helpLink = null,
																		string helpLinkTitle = "",
																		string helpLinkLabel = "",
																		Func<object, bool> navigateHelplinkMethod = null,
																		bool showCopyMessage = false);

		/// <summary>
		/// Displays a message box that has a message, title bar caption, button, and icon;
		/// and that accepts a default message box result and returns a result.
		/// </summary>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <param name="details">Displays a details section (e.g. expander) where a long message, such as, a stacktrace can be displayed within a scrollviewer.</param>
		/// <param name="button">A Msg.MessageBoxButton value that specifies which button or buttons to display.</param>
		/// <param name="icon">A Msg.MessageBoxImage value that specifies the icon to display.</param>
		/// <param name="defaultResult">A MsgBox.MsgBoxResult value that specifies the default result of the message box.</param>
		/// <param name="helpLink">Determines the address to browsed to when displaying a help link. This parameter can be a URI or string object.</param>
		/// <param name="helpLinkTitle">Determines the text for displaying a help link.
		/// By default the text is the toString() content of the <paramref name="helpLink"/>
		/// but it can also be a different text set here.</param>
		/// <param name="helpLinkLabel">Text label of the displayed hyperlink (if any)</param>
		/// <param name="navigateHelplinkMethod">Method to execute when the user clicked the hyperlink</param>
		/// <param name="showCopyMessage">Show a UI element (e.g. button) that lets the user copy the displayed message into the Windows clipboard</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(string messageBoxText,
																		string caption = "",
																		string details = "",
																		MsgBoxButtons button = MsgBoxButtons.OK,
																		MsgBoxImage icon = MsgBoxImage.Error,
																		MsgBoxResult defaultResult = MsgBoxResult.OK,
																		object helpLink = null,
																		string helpLinkTitle = "",
																		string helpLinkLabel = "",
																		Func<object, bool> navigateHelplinkMethod = null,
																		bool showCopyMessage = false);

		/// <summary>
		/// Displays a message box that has a message, title bar caption, button, and icon;
		/// and that accepts a default message box result and returns a result.
		/// </summary>
		/// <param name="ex">Exception object (details: stacktrace and messages are displayed in details section)</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <param name="button">A Msg.MessageBoxButton value that specifies which button or buttons to display.</param>
		/// <param name="icon">A Msg.MessageBoxImage value that specifies the icon to display.</param>
		/// <param name="defaultResult">A MsgBox.MsgBoxResult value that specifies the default result of the message box.</param>
		/// <param name="helpLink">Determines the address to browsed to when displaying a help link. This parameter can be a URI or string object.</param>
		/// <param name="helpLinkTitle">Determines the text for displaying a help link.
		/// By default the text is the toString() content of the <paramref name="helpLink"/>
		/// but it can also be a different text set here.</param>
		/// <param name="helpLinkLabel">Text label of the displayed hyperlink (if any)</param>
		/// <param name="navigateHelplinkMethod">Method to execute when the user clicked the hyperlink</param>
		/// <param name="showCopyMessage">Show a UI element (e.g. button) that lets the user copy the displayed message into the Windows clipboard</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(Exception ex,
																		string caption = "",
																		MsgBoxButtons button = MsgBoxButtons.OK,
																		MsgBoxImage icon = MsgBoxImage.Error,
																		MsgBoxResult defaultResult = MsgBoxResult.OK,
																		object helpLink = null,
																		string helpLinkTitle = "",
																		string helpLinkLabel = "",
																		Func<object, bool> navigateHelplinkMethod = null,
																		bool showCopyMessage = false);

		/// <summary>
		/// Displays a message box that has a message, title bar caption, button, and icon;
		/// and that accepts a default message box result and returns a result.
		/// </summary>
		/// <param name="messageBoxText">A System.String that specifies the text to display.</param>
		/// <param name="btnDefault">A MsgBox.MsgBoxResult value that specifies the default result of the message box.</param>
		/// <param name="helpLink">Determines the address to browsed to when displaying a help link. This parameter can be a URI or string object.</param>
		/// <param name="helpLinkTitle">Determines the text for displaying a help link.
		/// By default the text is the toString() content of the <paramref name="helpLink"/>
		/// but it can also be a different text set here.</param>
		/// <param name="helpLinkLabel">Text label of the displayed hyperlink (if any)</param>
		/// <param name="navigateHelplinkMethod">Method to execute when the user clicked the hyperlink</param>
		/// <param name="showCopyMessage">Show a UI element (e.g. button) that lets the user copy the displayed message into the Windows clipboard</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(string messageBoxText,
																		MsgBoxResult btnDefault = MsgBoxResult.None,
																		object helpLink = null,
																		string helpLinkTitle = "",
																		string helpLinkLabel = "",
																		Func<object, bool> navigateHelplinkMethod = null,
																		bool showCopyMessage = false);

		/// <summary>
		/// Displays a message box that has a message, title bar caption, button, and icon;
		/// and that accepts a default message box result and returns a result.
		/// </summary>
		/// <param name="ex">Exception object (details: stacktrace and messages are displayed in details section)</param>
		/// <param name="messageBoxText">A System.String that specifies the details to display.</param>
		/// <param name="caption">A System.String that specifies the title bar caption to display.</param>
		/// <param name="button">A Msg.MessageBoxButton value that specifies which button or buttons to display.</param>
		/// <param name="icon">A Msg.MessageBoxImage value that specifies the icon to display.</param>
		/// <param name="defaultResult">A MsgBox.MsgBoxResult value that specifies the default result of the message box.</param>
		/// <param name="helpLink">Determines the address to browsed to when displaying a help link. This parameter can be a URI or string object.</param>
		/// <param name="helpLinkTitle">Determines the text for displaying a help link.
		/// By default the text is the toString() content of the <paramref name="helpLink"/>
		/// but it can also be a different text set here.</param>
		/// <param name="helpLinkLabel">Text label of the displayed hyperlink (if any)</param>
		/// <param name="navigateHelplinkMethod">Method to execute when the user clicked the hyperlink</param>
		/// <param name="showCopyMessage">Show a UI element (e.g. button) that lets the user copy the displayed message into the Windows clipboard</param>
		/// <returns>A MsgBox.MsgBoxResult value that specifies which message box button is clicked by the user.</returns>
		[SecurityCritical]
		MsgBoxResult Show(Exception ex,
																		string messageBoxText = "",
																		string caption = "",
																		MsgBoxButtons button = MsgBoxButtons.OK,
																		MsgBoxImage icon = MsgBoxImage.Error,
																		MsgBoxResult defaultResult = MsgBoxResult.OK,
																		object helpLink = null,
																		string helpLinkTitle = "",
																		string helpLinkLabel = "",
																		Func<object, bool> navigateHelplinkMethod = null,
																		bool showCopyMessage = false);

		/// <summary>
		/// Displays a message box in front of the specified window.
		/// 
		/// The caller can specify with <paramref name="dialogCanCloseViaChrome"/> whether users can close the
		/// message box dialog view via F4 key, esc key or window close (x) button. Use the <paramref name="defaultCloseResult"/>
		/// parameter to define the results being returned if the user is allowed to close the message box via
		/// F4 key, esc key or window close (x) [Window chrome accessibility].
		/// 
		/// The message box displays a message,
		/// title bar caption, button, and icon; and accepts a default message box result and returns a result.
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
		[SecurityCritical]
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
		/// Displays a message box in front of the current window being shown.
		/// 
		/// The caller can specify with <paramref name="dialogCanCloseViaChrome"/> whether users can close the
		/// message box dialog view via F4 key, esc key or window close (x) button. Use the <paramref name="defaultCloseResult"/>
		/// parameter to define the results being returned if the user is allowed to close the message box via
		/// F4 key, esc key or window close (x) [Window chrome accessibility].
		/// 
		/// The message box can display a message,
		/// a hyperlink, and copy bitton; and accepts a default message box botton and returns a result.
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
		[SecurityCritical]
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
		/// Displays a message box in front of the current window being shown.
		/// 
		/// The caller can specify with <paramref name="dialogCanCloseViaChrome"/> whether users can close the
		/// message box dialog view via F4 key, esc key or window close (x) button. Use the <paramref name="defaultCloseResult"/>
		/// parameter to define the results being returned if the user is allowed to close the message box via
		/// F4 key, esc key or window close (x) [Window chrome accessibility].
		/// 
		/// The message box can display a message, caption,
		/// a hyperlink, and copy bitton; and accepts a default message box botton and returns a result.
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
		[SecurityCritical]
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
		/// Displays a message box in front of the current window being shown.
		/// 
		/// The caller can specify with <paramref name="dialogCanCloseViaChrome"/> whether users can close the
		/// message box dialog view via F4 key, esc key or window close (x) button. Use the <paramref name="defaultCloseResult"/>
		/// parameter to define the results being returned if the user is allowed to close the message box via
		/// F4 key, esc key or window close (x) [Window chrome accessibility].
		/// 
		/// The message box can display a message, caption, custom buttons (yes, no etc...),
		/// a hyperlink, and copy bitton; and accepts a default message box botton and returns a result.
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
		[SecurityCritical]
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
		/// Displays a message box in front of the current window being shown.
		/// 
		/// The caller can specify with <paramref name="dialogCanCloseViaChrome"/> whether users can close the
		/// message box dialog view via F4 key, esc key or window close (x) button. Use the <paramref name="defaultCloseResult"/>
		/// parameter to define the results being returned if the user is allowed to close the message box via
		/// F4 key, esc key or window close (x) [Window chrome accessibility].
		/// 
		/// The message box can display a message, caption, custom buttons (yes, no etc...), an image,
		/// a hyperlink, and copy bitton; and accepts a default message box botton and returns a result.
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
		[SecurityCritical]
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
		/// Displays a message box in front of the current window being shown.
		/// 
		/// The caller can specify with <paramref name="dialogCanCloseViaChrome"/> whether users can close the
		/// message box dialog view via F4 key, esc key or window close (x) button. Use the <paramref name="defaultCloseResult"/>
		/// parameter to define the results being returned if the user is allowed to close the message box via
		/// F4 key, esc key or window close (x) [Window chrome accessibility].
		/// 
		/// The message box can display a message, caption, additional details, custom buttons (yes, no etc...), an image,
		/// a hyperlink, and copy bitton; and accepts a default message box botton and returns a result.
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
		[SecurityCritical]
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
		#endregion custom messagebox methods
		#endregion methods
	}
}
