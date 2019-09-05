namespace MsgBoxSamples.ViewModel
{
  using System;
  using System.Collections.ObjectModel;
  using System.Diagnostics;
  using System.Globalization;
  using System.Linq;
  using System.Threading;
  using System.Windows;
  using System.Windows.Controls;
  using System.Windows.Input;
  using MsgBox;
	using MsgBoxSamples.Commands;
	using ServiceLocator;

  #region Helper Test Classes
  /// <summary>
  /// This class is uses to create a type safe list
  /// of enumeration members for selection in combobox.
  /// </summary>
  public class MessageImageCollection
  {
    public string Name { get; set; }
    public MsgBoxImage EnumKey { get; set; }
  }

  /// <summary>
  /// Test class to enumerate over message box buttons enumeration.
  /// </summary>
  public class MessageButtonCollection
  {
    public string Name { get; set; }
    public MsgBoxButtons EnumKey { get; set; }
  }

  /// <summary>
  /// Test class to enumerate over message box result enumeration.
  /// The <seealso cref="MsgBoxResult"/> enumeration is used to define
  /// a default button (if any).
  /// </summary>
  public class MessageResultCollection
  {
    public string Name { get; set; }
    public MsgBoxResult EnumKey { get; set; }
  }

  /// <summary>
  /// Test class to enumerate over languages (and their locale) that
  /// are supported with specific (non-English) button and tool tip strings.
  /// 
  /// The class definition is based on BCP 47 which in turn is used to
  /// set the UI and thread culture (which in turn selects the correct string resource in MsgBox assembly).
  /// </summary>
  public class LanguageCollection
  {
    public string Language { get; set; }
    public string Locale { get; set; }
    public string Name { get; set; }

    /// <summary>
    /// Get BCP47 language tag for this language
    /// See also http://en.wikipedia.org/wiki/IETF_language_tag
    /// </summary>
    public string BCP47
    {
      get
      {
        if (string.IsNullOrEmpty(this.Locale) == false)
          return String.Format("{0}-{1}", this.Language, this.Locale);
        else
          return String.Format("{0}", this.Language);
      }
    }

    /// <summary>
    /// Get BCP47 language tag for this language
    /// See also http://en.wikipedia.org/wiki/IETF_language_tag
    /// </summary>
    public string DisplayName
    {
      get
      {
        return String.Format("{0} {1}", this.Name, this.BCP47);
      }
    }
  }

  public class MessageBoxStyleCollection
  {
    public string Name { get; set; }
    public MsgBoxStyle EnumKey { get; set; }
  }
  #endregion Helper Test Classes

  /// <summary>
  /// This viewmodel manages some parameters to test the MsgBox implementation with.
  /// </summary>
  public class MsgBoxTestViewModel : MsgBoxSamples.ViewModel.Base.ViewModelBase
  {
    #region fields
    private MessageImageCollection mMessageImageSelected;
    private ObservableCollection<MessageImageCollection> mMessageImages = null;

    private MessageButtonCollection mMessageButtonSelected;
    private ObservableCollection<MessageButtonCollection> mMessageButtons = null;

    private MessageResultCollection mDefaultMessageButtonSelected;
    private ObservableCollection<MessageResultCollection> mDefaultMessageButtons = null;

		private RelayCommand<object> mTestMsgBoxParameters = null;
    private RelayCommand<object> mTestSamplMsgBox = null;

    private string mMessageText, mCaptionText;

    private bool mShowCopyButton;

    private string mResult;

    private ObservableCollection<LanguageCollection> mButtonLanguages;
    private LanguageCollection mButtonLanguageSelected;

    private ObservableCollection<MessageBoxStyleCollection> mMessageBoxStyles;
    private MessageBoxStyleCollection mMessageBoxStyleSelected;
    #endregion fields

    #region constructor
    /// <summary>
    /// Class constructor
    /// </summary>
    public MsgBoxTestViewModel()
    {
      this.mMessageImages = new ObservableCollection<MessageImageCollection>();

      foreach (var item in Enum.GetNames(typeof(MsgBoxImage)))
      {
        MsgBoxImage enumItem;
        Enum.TryParse<MsgBoxImage>(item, out enumItem);

        this.mMessageImages.Add(new MessageImageCollection() { Name = item.ToString(), EnumKey = enumItem });
      }

      this.mMessageText = "This is an important anouncement from your computer(!).";
      this.mCaptionText = "An Important Anouncement";

      this.mMessageButtons = new ObservableCollection<MessageButtonCollection>();

      foreach (var item in Enum.GetNames(typeof(MsgBoxButtons)))
      {
        MsgBoxButtons enumItem;
        Enum.TryParse<MsgBoxButtons>(item, out enumItem);

        this.mMessageButtons.Add(new MessageButtonCollection() { Name = item.ToString(), EnumKey = enumItem });
      }

      this.mDefaultMessageButtons = new ObservableCollection<MessageResultCollection>();

      foreach (var item in Enum.GetNames(typeof(MsgBoxResult)))
      {
        MsgBoxResult enumItem;
        Enum.TryParse<MsgBoxResult>(item, out enumItem);

        this.mDefaultMessageButtons.Add(new MessageResultCollection() { Name = item.ToString(), EnumKey = enumItem });
      }

      this.mShowCopyButton = false;
      this.mResult = string.Empty;

      // Addd supported test languages for localization and attempt to select
      // language from current culture
      //
      // Add a MsgBox/Local string resource with the name String.<Language>-<Local>.resx
      // when adding entries here...
      this.mButtonLanguages = new ObservableCollection<LanguageCollection>();

      this.mButtonLanguages.Add(new LanguageCollection() { Language = "de", Locale = "DE", Name = "Deutsch (German)" });
      this.mButtonLanguages.Add(new LanguageCollection() { Language = "en", Locale = "US", Name = "English (English)" });
      this.mButtonLanguages.Add(new LanguageCollection() { Language = "es", Locale = "ES", Name = "Spanish (Español)" });
      this.mButtonLanguages.Add(new LanguageCollection() { Language = "fr", Locale = "FR", Name = "Français (French)" });
      this.mButtonLanguages.Add(new LanguageCollection() { Language = "hi", Locale = "", Name = "हिंदी (Hindi)" });
      this.mButtonLanguages.Add(new LanguageCollection() { Language = "it", Locale = "IT", Name = "Italiano (Italian)" });
      this.mButtonLanguages.Add(new LanguageCollection() { Language = "nl", Locale = "NL", Name = "Nederland (Dutch)" });
      this.mButtonLanguages.Add(new LanguageCollection() { Language = "zh", Locale = "Hans", Name = "中文 - 简体 (Chinese - Simplified)" });

      // Attempt to set selected language to current language as identified via BCP 47 code
      // http://en.wikipedia.org/wiki/IETF_language_tag
      string BCP47 = Thread.CurrentThread.CurrentCulture.ToString();

      try
      {
        this.mButtonLanguageSelected = this.mButtonLanguages.FirstOrDefault(lang => lang.BCP47 == BCP47);
      }
      catch
      {
      }

      // List Message Box Styles
      this.mMessageBoxStyles = new ObservableCollection<MessageBoxStyleCollection>();

      foreach (var item in Enum.GetNames(typeof(MsgBoxStyle)))
      {
        MsgBoxStyle enumItem;
        Enum.TryParse<MsgBoxStyle>(item, out enumItem);

        this.mMessageBoxStyles.Add(new MessageBoxStyleCollection() { Name = item.ToString(), EnumKey = enumItem });
      }

      this.mMessageBoxStyleSelected = this.mMessageBoxStyles.FirstOrDefault(style => style.EnumKey == MsgBoxStyle.System);
    }
    #endregion constructor

    #region properties
    #region MsgBox Parameters
    #region Image
    /// <summary>
    /// Select an item from the collection of MessageImages listed below.
    /// </summary>
    public MessageImageCollection MessageImageSelected
    {
      get
      {
        if (this.mMessageImageSelected == null)
        {
          this.mMessageImageSelected =
            this.mMessageImages.FirstOrDefault(cat => cat.EnumKey == MsgBoxImage.Default);
        }

        return this.mMessageImageSelected;
      }

      set
      {
        if (this.mMessageImageSelected != value)
        {
          this.mMessageImageSelected = value;
          this.RaisePropertyChanged(() => this.MessageImageSelected);
        }
      }
    }

    /// <summary>
    /// Provide a collection of MessageImages to select one item from (see previous property).
    /// </summary>
    public ObservableCollection<MessageImageCollection> MessageImages
    {
      get
      {
        return this.mMessageImages;
      }
    }
    #endregion Image

    #region text and caption
    /// <summary>
    /// Text displayed in test message box.
    /// </summary>
    public string MessageText
    {
      get
      {
        return this.mMessageText;
      }

      set
      {
        if (this.mMessageText != value)
        {
          this.mMessageText = value;
          this.RaisePropertyChanged(() => this.MessageText);
        }
      }
    }

    /// <summary>
    /// Caption displayed in test message box.
    /// </summary>
    public string CaptionText
    {
      get
      {
        return this.mCaptionText;
      }

      set
      {
        if (this.mCaptionText != value)
        {
          this.mCaptionText = value;
          this.RaisePropertyChanged(() => this.CaptionText);
        }
      }
    }
    #endregion text and caption

    #region Buttons
    /// <summary>
    /// Select an item from the collection of MessageImages listed below.
    /// </summary>
    public MessageButtonCollection MessageButtonSelected
    {
      get
      {
        if (this.mMessageButtonSelected == null)
        {
          this.mMessageButtonSelected =
            this.mMessageButtons.FirstOrDefault(cat => cat.EnumKey == MsgBoxButtons.OK);
        }

        return this.mMessageButtonSelected;
      }

      set
      {
        if (this.mMessageButtonSelected != value)
        {
          this.mMessageButtonSelected = value;
          this.RaisePropertyChanged(() => this.MessageButtonSelected);
        }
      }
    }

    /// <summary>
    /// Provide a collection of MessageImages to select one item from (see previous property).
    /// </summary>
    public ObservableCollection<MessageButtonCollection> MessageButtons
    {
      get
      {
        return this.mMessageButtons;
      }
    }
    #endregion Buttons

    #region DefaultButtons
    /// <summary>
    /// Select an item from the collection of MessageImages listed below.
    /// </summary>
    public MessageResultCollection DefaultMessageButtonSelected
    {
      get
      {
        if (this.mDefaultMessageButtonSelected == null)
        {
          this.mDefaultMessageButtonSelected =
            this.mDefaultMessageButtons.FirstOrDefault(cat => cat.EnumKey == MsgBoxResult.OK);
        }

        return this.mDefaultMessageButtonSelected;
      }

      set
      {
        if (this.mDefaultMessageButtonSelected != value)
        {
          this.mDefaultMessageButtonSelected = value;
          this.RaisePropertyChanged(() => this.DefaultMessageButtonSelected);
        }
      }
    }

    /// <summary>
    /// Provide a collection of MessageImages to select one item from (see previous property).
    /// </summary>
    public ObservableCollection<MessageResultCollection> DefaultMessageButtons
    {
      get
      {
        return this.mDefaultMessageButtons;
      }
    }
    #endregion DefaultButtons

    /// <summary>
    /// Get/set property to determine whether the message box sports a copy button or not.
    /// This button can be used to copy the dsipaly content of the message box into the windows clipboard.
    /// </summary>
    public bool ShowCopyButton
    {
      get
      {
        return this.mShowCopyButton;
      }

      set
      {
        if (this.mShowCopyButton != value)
        {
          this.mShowCopyButton = value;
          this.RaisePropertyChanged(() => this.ShowCopyButton);
        }
      }
    }

    /// <summary>
    /// Get/set result of message box display.
    /// </summary>
    public string Result
    {
      get
      {
        return this.mResult;
      }

      set
      {
        if (this.mResult != value)
        {
          this.mResult = value;
          this.RaisePropertyChanged(() => this.Result);
        }
      }
    }

    #region LanguageButtons
    /// <summary>
    /// Get/set language of message box buttons for display in localized form.
    /// </summary>
    public LanguageCollection ButtonLanguageSelected
    {
      get
      {
        return this.mButtonLanguageSelected;
      }

      set
      {
        if (this.mButtonLanguageSelected != value)
        {
          this.mButtonLanguageSelected = value;
          this.RaisePropertyChanged(() => this.ButtonLanguageSelected);
        }
      }
    }

    /// <summary>
    /// 
    /// </summary>
    public ObservableCollection<LanguageCollection> ButtonLanguages
    {
      get
      {
        return this.mButtonLanguages;
      }
    }
    #endregion LanguageButtons

    #region MessageBox Styles
    /// <summary>
    /// Select an item from the collection of MessageBox styles (see next property).
    /// </summary>
    public MessageBoxStyleCollection MessageBoxStyleSelected
    {
      get
      {
        return this.mMessageBoxStyleSelected;
      }

      set
      {
        if (this.mMessageBoxStyleSelected != value)
        {
          this.mMessageBoxStyleSelected = value;

          // set the style of the message box display in back-end system.
					var msg = ServiceContainer.Instance.GetService<IMessageBoxService>();

          msg.Style = value.EnumKey;

          this.RaisePropertyChanged(() => this.MessageBoxStyleSelected);
        }
      }
    }

    /// <summary>
    /// Provide a collection of MessageBox styles to select one item from (see previous property).
    /// </summary>
    public ObservableCollection<MessageBoxStyleCollection> MessageBoxStyles
    {
      get
      {
        return this.mMessageBoxStyles;
      }
    }
    #endregion MessageBox Styles
    #endregion MsgBox Parameters

    #region Commands
    /// <summary>
    /// Implements a test command to test the message box
    /// display with different parameters.
    /// </summary>
    public ICommand TestMsgBoxParameters
    {
      get
      {
        if (this.mTestMsgBoxParameters == null)
					this.mTestMsgBoxParameters = new RelayCommand<object>((p) => this.TestMsgBoxParameters_Executed());

        return this.mTestMsgBoxParameters;
      }
    }

    /// <summary>
    /// Implements a test command to test the fixed 1-17... sample message box
    /// displays with different pre-defined parameters.
    /// </summary>
    public ICommand TestSamplMsgBox
    {
      get
      {
        if (this.mTestSamplMsgBox == null)
          this.mTestSamplMsgBox = new RelayCommand<object>((p) => this.TestSamplMsgBox_Executed(p));

        return this.mTestSamplMsgBox;
      }
    }
    #endregion Commands
    #endregion properties

    #region methods
    /// <summary>
    /// Method is executed when TestMsgBoxParameters command is invoked.
    /// </summary>
    private void TestMsgBoxParameters_Executed()
    {
      MsgBoxImage image;
      image = this.MessageImageSelected.EnumKey;

      // Set the current culture and UI culture to the currently selected languages
      Thread.CurrentThread.CurrentCulture = new CultureInfo(this.ButtonLanguageSelected.BCP47);
      Thread.CurrentThread.CurrentUICulture = new CultureInfo(this.ButtonLanguageSelected.BCP47);

			var msg = ServiceContainer.Instance.GetService<IMessageBoxService>();

      MsgBoxResult result = msg.Show(this.MessageText, this.CaptionText,
                                     this.mMessageButtonSelected.EnumKey,
                                     image,
                                     this.DefaultMessageButtonSelected.EnumKey,
                                     null,
                                     "", "", null,
                                     this.ShowCopyButton);

      this.Result = result.ToString();
    }

    #region Sample Tests
    /// <summary>
    /// Convert command parameters and call backend samples method
    /// with actual parameters.
    /// </summary>
    /// <param name="p"></param>
    private void TestSamplMsgBox_Executed(object p)
    {
      object[] param = p as object[];

      if (param != null)
      {
        if (param.Length == 2)
        {
          Button b = param[0] as Button;
          Window w = param[1] as Window;

          this.ShowTestSampleMsgBox(b.Content.ToString(), w);
        }
      }
    }

    private void ShowTestSampleMsgBox(string sampleID, Window sampleWindow)
    {
      MsgBoxResult result = MsgBoxResult.None;
			var msg = ServiceContainer.Instance.GetService<IMessageBoxService>();

      switch (sampleID)
      {
        case "Sample 1":
          result = msg.Show("This options displays a message box with only message." +
                            "\nThis is the message box with minimal options (just an OK button and no caption).");
          break;

        case "Sample 2":
          result = msg.Show("This options displays a message box with both title and message.\nA default image and OK button are displayed.",
                            "WPF MessageBox");
          break;

        case "Sample 3":
          result = msg.Show("This options displays a message box with YES, NO, CANCEL option.",
                    "WPF MessageBox",
                    MsgBoxButtons.YesNoCancel, MsgBoxImage.Question);
          break;

        case "Sample 4":
          {
            Exception exp = this.CreateDemoException();

            result = msg.Show(exp.Message, "Unexpected Error",
                      exp.ToString(), MsgBoxButtons.OK, MsgBoxImage.Error, MsgBoxResult.NoDefaultButton,
                      "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                      "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                      "Click the link to report this problem:");
          }
          break;

        case "Sample 5":
          result = msg.Show("This options displays a message box with YES, NO buttons.",
                    "WPF MessageBox",
                    MsgBoxButtons.YesNo, MsgBoxImage.Question);

          break;

        case "Sample 6":
          result = msg.Show("This options displays a message box with Yes, No (No as default) options.",
                   "WPF MessageBox",
                   MsgBoxButtons.YesNo, MsgBoxImage.Question, MsgBoxResult.No);
          break;

        case "Sample 7":
          result = msg.Show("Are you sure? Click the hyperlink to review the get more details.",
                    "WPF MessageBox with Hyperlink",
                    MsgBoxButtons.YesNo, MsgBoxImage.Question, MsgBoxResult.Yes,
                    "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                    "Code Project Articles by Dirkster99");
          break;

        case "Sample 8":
          result = msg.Show("Are you sure? Click the hyperlink to review the get more details.",
                    "WPF MessageBox with Custom Hyperlink Navigation",
                    MsgBoxButtons.YesNo, MsgBoxImage.Question, MsgBoxResult.Yes,
                    "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                    "Code Project Articles by Dirkster99", "Help Topic:", this.MyCustomHyperlinkNaviMethod);
          break;

        case "Sample 9":
          result = msg.Show("WPF MessageBox without Copy Button (OK and Cancel [default])",
                    "Are you sure this right?",
                    MsgBoxButtons.OKCancel, MsgBoxImage.Question, MsgBoxResult.Cancel,
                    null, string.Empty, string.Empty, null, false);
          break;

        case "Sample 10":
          result = msg.Show("Are you sure? Click the hyperlink to review the get more details.",
                    "WPF MessageBox without Default Button",
                    MsgBoxButtons.YesNo, MsgBoxImage.Question, MsgBoxResult.NoDefaultButton,
                    null, string.Empty, string.Empty, null, false);
          break;

        case "Sample 11":
          result = msg.Show("...display a messageBox with a close button and TakeNote icon.",
                   "WPF MessageBox with a close button",
                   MsgBoxButtons.Close, MsgBoxImage.Warning);
          break;

        case "Sample 12":
          {
            Exception exp = this.CreateDemoException();

            result = msg.Show(exp, "Unexpected Error",
                      MsgBoxButtons.OK, MsgBoxImage.Error, MsgBoxResult.NoDefaultButton,
                      "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                      "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                      "Please click on the link to check if this is a known problem (and report it if not):", null, true);
          }
          break;

        case "Sample 13":
          {
            Exception exp = this.CreateDemoException();

            result = msg.Show(exp, "Reading file 'x' was not succesful.", "Unexpected Error",
                      MsgBoxButtons.OK, MsgBoxImage.Error, MsgBoxResult.NoDefaultButton,
                      "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                      "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                      "Please click on the link to check if this is a known problem (and report it if not):", null, true);
          }
          break;

        case "Sample 14":
          {
            Exception exp = this.CreateDemoException();

            result = msg.Show(sampleWindow, "...display a messageBox with an explicit reference to the owning window.",
                             "MessageBox with a owner reference",
                             MsgBoxButtons.OK, MsgBoxImage.Default_OffLight);
          }
          break;

        case "Sample 15":
          {
            result = msg.Show("...display a messageBox with a default image.",
                     "MessageBox with default image",
                     MsgBoxButtons.YesNoCancel, MsgBoxResult.No,
                     "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                     "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                     "Please click on the link to check if this is a known problem (and report it if not):",
                     null, true);
          }
          break;

        // Display a message box that will not close via
        // Esc, F4, or Window Close (x) button.
        case "Sample 16":
          {
            result = msg.Show("...Display a message box that will not close via Esc, F4, or Window Close (x) button.",
                     "MessageBox with default image",
                     MsgBoxButtons.YesNoCancel,
                     MsgBoxResult.None, false,
                     MsgBoxResult.No,
                     "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                     "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                     "Please click on the link to check if this is a known problem (and report it if not):",
                     null, true);
          }
          break;

        //    Display a message box that WILL CLOSE
        //    via Esc, F4, or Window Close (x) button leaving with a No result.
        case "Sample 17":
          {
            result = msg.Show("...Display a message box that will close via Esc, F4, or Window Close (x) butto resulting in a No Answer",
                     "MessageBox with default image",
                     MsgBoxButtons.YesNoCancel,
                     MsgBoxResult.No, true,
                     MsgBoxResult.No,
                     "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                     "http://www.codeproject.com/script/Articles/MemberArticles.aspx?amid=7799028",
                     "Please click on the link to check if this is a known problem (and report it if not):",
                     null, true);
          }
          break;
      }

      this.Result = result.ToString();
    }

    /// <summary>
    /// This is just a mockup test method to test whether custom
    /// hyperlink navigation will work when using custom hyperlink
    /// navigation methods.
    /// </summary>
    /// <param name="uriTarget"></param>
    /// <returns></returns>
    private bool MyCustomHyperlinkNaviMethod(object uriTarget)
    {
      MessageBox.Show("Starting Navigation to: " + uriTarget.ToString(), "Mockup Test Info");

      string uriTargetString = uriTarget as string;

      try
      {
        if (uriTargetString != null)
        {
          Process.Start(new ProcessStartInfo(uriTargetString));
          return true;
        }
      }
      catch
      {
      }

      return false;
    }
    #endregion Sample Tests

    #region DemoException
    private Exception CreateDemoException()
    {
      try
      {
        this.CreateDemoException1();
      }
      catch (Exception exp)
      {
        return exp;
      }

      return null;
    }

    private void CreateDemoException1()
    {
      try
      {
        this.CreateDemoException2();
      }
      catch (Exception exp)
      {
        throw new Exception("A sub-system failure occured.", exp);
      }
    }

    private void CreateDemoException2()
    {
      int i = 0;

      try
      {
        int x = 1 / i;
      }
      catch (Exception exp)
      {
        throw new Exception("A sub-sub-system failure occured.", exp);
      }
    }
    #endregion DemoException
    #endregion methods
  }
}
