namespace MsgBox
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Security;
	using System.Text;
	using MsgBox.Internal;

	/// <summary>
	/// Class implements ...
	/// </summary>
	public class MessageBox : IMsgBox
	{
		#region fields
		#endregion fields

		#region constructor
		/// <summary>
		/// Class constructor
		/// </summary>
		public MessageBox()
		{
		}
		#endregion constructor

		#region properties
		#endregion properties

		#region methods
		#endregion methods


		MsgBoxStyle IMsgBox.Style
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, string caption)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(System.Windows.Window owner, string messageBoxText)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, string caption, MsgBoxButtons button)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(System.Windows.Window owner, string messageBoxText, string caption)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, string caption, MsgBoxButtons button, MsgBoxImage icon)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(System.Windows.Window owner, string messageBoxText, string caption, MsgBoxButtons button)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, string caption, MsgBoxButtons button, MsgBoxImage icon, MsgBoxResult defaultResult)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(System.Windows.Window owner, string messageBoxText, string caption, MsgBoxButtons button, MsgBoxImage icon)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(System.Windows.Window owner, string messageBoxText, string caption, MsgBoxButtons button, MsgBoxImage icon, MsgBoxResult defaultResult)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, string caption, MsgBoxButtons buttonOption, MsgBoxResult btnDefault, object helpLink, string helpLinkTitle, string helpLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, string caption, MsgBoxButtons button, MsgBoxImage icon, MsgBoxResult defaultResult, object helpLink, string helpLinkTitle, string helpLinkLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, string caption, string details, MsgBoxButtons button, MsgBoxImage icon, MsgBoxResult defaultResult, object helpLink, string helpLinkTitle, string helpLinkLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(Exception ex, string caption, MsgBoxButtons button, MsgBoxImage icon, MsgBoxResult defaultResult, object helpLink, string helpLinkTitle, string helpLinkLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, MsgBoxResult btnDefault, object helpLink, string helpLinkTitle, string helpLinkLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(Exception ex, string messageBoxText, string caption, MsgBoxButtons button, MsgBoxImage icon, MsgBoxResult defaultResult, object helpLink, string helpLinkTitle, string helpLinkLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(System.Windows.Window owner, string messageBoxText, string caption, MsgBoxResult defaultCloseResult, bool dialogCanCloseViaChrome, MsgBoxButtons buttonOption, MsgBoxImage image, MsgBoxResult btnDefault, object helpLink, string helpLinkTitle, string helpLinkLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, MsgBoxResult defaultCloseResult, bool dialogCanCloseViaChrome, MsgBoxResult btnDefault, object helpLink, string helpLinkTitle, string helpLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, string caption, MsgBoxResult defaultCloseResult, bool dialogCanCloseViaChrome, MsgBoxResult btnDefault, object helpLink, string helpLinkTitle, string helpLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, string caption, MsgBoxButtons buttonOption, MsgBoxResult defaultCloseResult, bool dialogCanCloseViaChrome, MsgBoxResult btnDefault, object helpLink, string helpLinkTitle, string helpLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, string caption, MsgBoxButtons buttonOption, MsgBoxImage image, MsgBoxResult defaultCloseResult, bool dialogCanCloseViaChrome, MsgBoxResult btnDefault, object helpLink, string helpLinkTitle, string helpLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}

		MsgBoxResult IMsgBox.Show(string messageBoxText, string caption, string details, MsgBoxButtons buttonOption, MsgBoxImage image, MsgBoxResult defaultCloseResult, bool dialogCanCloseViaChrome, MsgBoxResult btnDefault, object helpLink, string helpLinkTitle, string helpLabel, Func<object, bool> navigateHelplinkMethod, bool showCopyMessage)
		{
			throw new NotImplementedException();
		}
	}
}
