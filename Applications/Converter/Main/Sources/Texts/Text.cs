/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU Affero General Public License as published
// by the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Affero General Public License for more details.
//
// You should have received a copy of the GNU Affero General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
/* ------------------------------------------------------------------------- */
namespace Cube.Pdf.Converter;

using Cube.Globalization;

/* ------------------------------------------------------------------------- */
///
/// Text
///
/// <summary>
/// Represents the text used by the CubePDF.
/// </summary>
///
/* ------------------------------------------------------------------------- */
internal class Text : TextProvider
{
    #region Properties

    /* --------------------------------------------------------------------- */
    // Buttons
    /* --------------------------------------------------------------------- */
    public string Ui_Convert => Get();
    public string Ui_Cancel => Get();
    public string Ui_SaveSettings => Get();

    /* --------------------------------------------------------------------- */
    // Tabs
    /* --------------------------------------------------------------------- */
    public string Ui_General => Get();
    public string Ui_Metadata => Get();
    public string Ui_Security => Get();
    public string Ui_Others => Get();

    /* --------------------------------------------------------------------- */
    // Labels for General tab
    /* --------------------------------------------------------------------- */
    public string Ui_Source => Get();
    public string Ui_Destination => Get();
    public string Ui_Format => Get();
    public string Ui_Color => Get();
    public string Ui_Resolution => Get();
    public string Ui_Orientation => Get();
    public string Ui_Options => Get();
    public string Ui_PostProcess => Get();

    /* --------------------------------------------------------------------- */
    // Labels for Metadata tab
    /* --------------------------------------------------------------------- */
    public string Ui_Title => Get();
    public string Ui_Author => Get();
    public string Ui_Subject => Get();
    public string Ui_Keyword => Get();
    public string Ui_PageLayout => Get();

    /* --------------------------------------------------------------------- */
    // Labels for Security tab
    /* --------------------------------------------------------------------- */
    public string Ui_OwnerPassword => Get();
    public string Ui_UserPassword => Get();
    public string Ui_ConfirmPassword => Get();
    public string Ui_Operations => Get();

    /* --------------------------------------------------------------------- */
    // Labels for Others tab
    /* --------------------------------------------------------------------- */
    public string Ui_About => Get();
    public string Ui_Language => Get();

    /* --------------------------------------------------------------------- */
    // Menus for General tab (ComboBox, CheckBox, ...)
    /* --------------------------------------------------------------------- */
    public string Menu_Overwrite => Get();
    public string Menu_MergeHead => Get();
    public string Menu_MergeTail => Get();
    public string Menu_Rename => Get();
    public string Menu_Auto => Get();
    public string Menu_Rgb => Get();
    public string Menu_Grayscale => Get();
    public string Menu_Monochrome => Get();
    public string Menu_Portrait => Get();
    public string Menu_Landscape => Get();
    public string Menu_Jpg => Get();
    public string Menu_Linearization => Get();
    public string Menu_Open => Get();
    public string Menu_OpenDirectory => Get();
    public string Menu_None => Get();
    public string Menu_UserProgram => Get();

    /* --------------------------------------------------------------------- */
    // Menus for Metadata tab (ComboBox, CheckBox, ...)
    /* --------------------------------------------------------------------- */
    public string Menu_SinglePage => Get();
    public string Menu_OneColumn => Get();
    public string Menu_TwoPageLeft => Get();
    public string Menu_TwoPageRight => Get();
    public string Menu_TwoColumnLeft => Get();
    public string Menu_TwoColumnRight => Get();

    /* --------------------------------------------------------------------- */
    // Menus for Security tab (ComboBox, CheckBox, ...)
    /* --------------------------------------------------------------------- */
    public string Menu_EnableSecurity => Get();
    public string Menu_OpenWithPassword => Get();
    public string Menu_SharePassword => Get();
    public string Menu_AllowPrint => Get();
    public string Menu_AllowCopy => Get();
    public string Menu_AllowModify => Get();
    public string Menu_AllowAccessibility => Get();
    public string Menu_AllowForm => Get();
    public string Menu_AllowAnnotation => Get();

    /* --------------------------------------------------------------------- */
    // Menus for Others tab (ComboBox, CheckBox, ...)
    /* --------------------------------------------------------------------- */
    public string Menu_CheckUpdate => Get();

    /* --------------------------------------------------------------------- */
    // Titles for dialogs
    /* --------------------------------------------------------------------- */
    public string Title_Source => Get();
    public string Title_Destination => Get();
    public string Title_UserProgram => Get();

    /* --------------------------------------------------------------------- */
    // Error messages
    /* --------------------------------------------------------------------- */
    public string Error_Source => Get();
    public string Error_Digest => Get();
    public string Error_Ghostscript => Get();
    public string Error_InvalidChars => Get();
    public string Error_OwnerPassword => Get();
    public string Error_UserPassword => Get();
    public string Error_MergePassword => Get();
    public string Error_PostProcess => Get();

    /* --------------------------------------------------------------------- */
    // Warning/Confirm messages
    /* --------------------------------------------------------------------- */
    public string Warn_Exist => Get();
    public string Warn_Overwrite => Get();
    public string Warn_MergeHead => Get();
    public string Warn_MergeTail => Get();
    public string Warn_Metadata => Get();

    /* --------------------------------------------------------------------- */
    // File filters
    /* --------------------------------------------------------------------- */
    public string Filter_All => Get();
    public string Filter_Pdf => Get();
    public string Filter_Ps => Get();
    public string Filter_Eps => Get();
    public string Filter_Bmp => Get();
    public string Filter_Png => Get();
    public string Filter_Jpg => Get();
    public string Filter_Tiff => Get();
    public string Filter_Exe => Get();

    #endregion

    #region Others
    public Text() : base(_ => default, default) { }
    #endregion
}
