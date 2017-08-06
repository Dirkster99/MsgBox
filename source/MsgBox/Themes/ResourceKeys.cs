namespace MsgBox.Themes
{
    using System.Windows;

    /// <summary>
    /// Resource key management class to keep track of all resources
    /// that can be re-styled in applications that make use of the implemented controls.
    /// </summary>
    public static class ResourceKeys
    {
        #region Accent Keys
        /// <summary>
        /// Accent Color Key - This Color key is used to accent elements in the UI
        /// (e.g.: Color of Activated Normal Window Frame, ResizeGrip, Focus or MouseOver input elements)
        /// </summary>
        public static readonly ComponentResourceKey ControlAccentColorKey = new ComponentResourceKey(typeof(ResourceKeys), "ControlAccentColorKey");

        /// <summary>
        /// Accent Brush Key - This Brush key is used to accent elements in the UI
        /// (e.g.: Color of Activated Normal Window Frame, ResizeGrip, Focus or MouseOver input elements)
        /// </summary>
        public static readonly ComponentResourceKey ControlAccentBrushKey = new ComponentResourceKey(typeof(ResourceKeys), "ControlAccentBrushKey");
        #endregion Accent Keys

        #region Brush Keys
        /// <summary>
        /// Brush key of the message text shown in the message box.
        /// </summary>
        public static readonly ComponentResourceKey MsgBox_MessageColor = new ComponentResourceKey(typeof(ResourceKeys), "MsgBox_MessageColor");

        /// <summary>
        /// Brush key of the background of the message box dialog.
        /// </summary>
        public static readonly ComponentResourceKey MsgBoxDialog_BackgroundKey = new ComponentResourceKey(typeof(ResourceKeys), "MsgBoxDialog_BackgroundKey");

        /// <summary>
        /// Brush key of the background of the message view inside the message box dialog.
        /// </summary>
        public static readonly ComponentResourceKey MsgBoxView_BackgroundKey = new ComponentResourceKey(typeof(ResourceKeys), "MsgBoxView_BackgroundKey");

        /// <summary>
        /// Brush key of the foreground of the message view inside the message box dialog.
        /// </summary>
        public static readonly ComponentResourceKey MsgBoxView_ForegroundKey = new ComponentResourceKey(typeof(ResourceKeys), "MsgBoxView_ForegroundKey");
        #endregion Brush Keys
    }
}
