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
/// EnglishText
///
/// <summary>
/// Provides the functionality to get the English text group.
/// </summary>
///
/* ------------------------------------------------------------------------- */
internal static class EnglishText
{
    /* --------------------------------------------------------------------- */
    ///
    /// Get
    ///
    /// <summary>
    /// Gets the English text group.
    /// </summary>
    ///
    /// <returns>Text group.</returns>
    ///
    /* --------------------------------------------------------------------- */
    public static TextGroup Get() => new()
    {
        // Buttons
        { nameof(Text.Ui_Convert), "Convert" },
        { nameof(Text.Ui_Cancel), "Cancel" },
        { nameof(Text.Ui_SaveSettings), "Save Settings" },

        // Tabs
        { nameof(Text.Ui_General), "General" },
        { nameof(Text.Ui_Metadata), "Metadata" },
        { nameof(Text.Ui_Security), "Security" },
        { nameof(Text.Ui_Others), "Others" },

        // Labels for General tab
        { nameof(Text.Ui_Source), "Source" },
        { nameof(Text.Ui_Destination), "Destination" },
        { nameof(Text.Ui_Format), "Format" },
        { nameof(Text.Ui_Color), "Color" },
        { nameof(Text.Ui_Resolution), "Resolution" },
        { nameof(Text.Ui_Orientation), "Orientation" },
        { nameof(Text.Ui_Options), "Options" },
        { nameof(Text.Ui_PostProcess), "Post Process" },

        // Labels for Metadata tab
        { nameof(Text.Ui_Title), "Title" },
        { nameof(Text.Ui_Author), "Author" },
        { nameof(Text.Ui_Subject), "Subject" },
        { nameof(Text.Ui_Keyword), "Keywords" },
        { nameof(Text.Ui_PageLayout), "Layout" },

        // Labels for Security tab
        { nameof(Text.Ui_OwnerPassword), "Password" },
        { nameof(Text.Ui_UserPassword), "Password" },
        { nameof(Text.Ui_ConfirmPassword), "Confirm" },
        { nameof(Text.Ui_Operations), "Operations" },

        // Labels for Others tab
        { nameof(Text.Ui_About), "About" },
        { nameof(Text.Ui_Language), "Language" },

        // Menus for General tab (ComboBox, CheckBox, ...)
        { nameof(Text.Menu_Overwrite), "Overwrite" },
        { nameof(Text.Menu_MergeHead), "Merge at the beginning" },
        { nameof(Text.Menu_MergeTail), "Merge at the end" },
        { nameof(Text.Menu_Rename), "Rename" },
        { nameof(Text.Menu_Auto), "Auto" },
        { nameof(Text.Menu_Rgb), "RGB" },
        { nameof(Text.Menu_Grayscale), "Grayscale" },
        { nameof(Text.Menu_Monochrome), "Monochrome" },
        { nameof(Text.Menu_Portrait), "Portrait" },
        { nameof(Text.Menu_Landscape), "Landscape" },
        { nameof(Text.Menu_Jpg), "Compress PDF images as JPEG" },
        { nameof(Text.Menu_Linearization), "Optimize PDF for fast Web view" },
        { nameof(Text.Menu_Open), "Open" },
        { nameof(Text.Menu_OpenDirectory), "Open directory" },
        { nameof(Text.Menu_None), "None" },
        { nameof(Text.Menu_UserProgram), "Others" },

        // Menus for Metadata tab (ComboBox, CheckBox, ...)
        { nameof(Text.Menu_SinglePage), "Single page" },
        { nameof(Text.Menu_OneColumn), "One column" },
        { nameof(Text.Menu_TwoPageLeft), "Two page (left)" },
        { nameof(Text.Menu_TwoPageRight), "Two page (right)" },
        { nameof(Text.Menu_TwoColumnLeft), "Two column (left)" },
        { nameof(Text.Menu_TwoColumnRight), "Two column (right)" },

        // Menus for Security tab (ComboBox, CheckBox, ...)
        { nameof(Text.Menu_EnableSecurity), "Encrypt the PDF with password" },
        { nameof(Text.Menu_OpenWithPassword), "Open with password" },
        { nameof(Text.Menu_SharePassword), "Use owner password" },
        { nameof(Text.Menu_AllowPrint), "Allow printing" },
        { nameof(Text.Menu_AllowCopy), "Allow copying text and images" },
        { nameof(Text.Menu_AllowModify), "Allow inserting and removing pages" },
        { nameof(Text.Menu_AllowAccessibility), "Allow using contents for accessibility" },
        { nameof(Text.Menu_AllowForm), "Allow filling in forms" },
        { nameof(Text.Menu_AllowAnnotation), "Allow creating and editing annotations" },

        // Menus for Others tab (ComboBox, CheckBox, ...)
        { nameof(Text.Menu_CheckUpdate), "Check for updates on startup" },

        // Titles for dialogs
        { nameof(Text.Title_Source), "Select source file" },
        { nameof(Text.Title_Destination), "Save as" },
        { nameof(Text.Title_UserProgram), "Select user program" },

        // Error messages
        { nameof(Text.Error_Source), "Input file not specified. Please check if CubePDF was executed through the normal procedure." },
        { nameof(Text.Error_Digest), "Message digest of the source file does not match." },
        { nameof(Text.Error_Ghostscript), "Ghostscript error ({0:D})" },
        { nameof(Text.Error_InvalidChars), "Path cannot contain any of the following characters." },
        { nameof(Text.Error_OwnerPassword), "Owner password is empty or does not match the confirmation. Please check your password and confirmation again." },
        { nameof(Text.Error_UserPassword), "User password is empty or does not match the confirmation. Please check the user password or enable the \"Use owner password\" checkbox." },
        { nameof(Text.Error_MergePassword), "Set the owner password of the PDF file to be merged in the Security tab." },
        { nameof(Text.Error_PostProcess), "Post-process failed, although the conversion was completed. Check the file association settings or the user program is correct." },

        // Warning/Confirm messages
        { nameof(Text.Warn_Exist), "{0} already exists." },
        { nameof(Text.Warn_Overwrite), "Do you want to overwrite the file?" },
        { nameof(Text.Warn_MergeHead), "Do you want to merge at the beginning of the existing file?" },
        { nameof(Text.Warn_MergeTail), "Do you want to merge at the end of the existing file?" },
        { nameof(Text.Warn_Metadata), "Some value is entered in the Title, Author, Subject, or Keywords field. Do you want to save the settings?" },

        // File filters
        { nameof(Text.Filter_All), "All files" },
        { nameof(Text.Filter_Pdf), "PDF files" },
        { nameof(Text.Filter_Ps), "PS files" },
        { nameof(Text.Filter_Eps), "EPS files" },
        { nameof(Text.Filter_Bmp), "BMP files" },
        { nameof(Text.Filter_Png), "PNG files" },
        { nameof(Text.Filter_Jpg), "JPEG files" },
        { nameof(Text.Filter_Tiff), "TIFF files" },
        { nameof(Text.Filter_Exe), "Executable files" },
    };
}
