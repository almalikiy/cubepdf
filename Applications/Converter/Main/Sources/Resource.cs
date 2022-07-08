﻿/* ------------------------------------------------------------------------- */
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
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using Cube.Forms;
using Cube.Mixin.Uri;
using Cube.Pdf.Ghostscript;

namespace Cube.Pdf.Converter
{
    /* --------------------------------------------------------------------- */
    ///
    /// Resource
    ///
    /// <summary>
    /// Provides resources for display.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public static class Resource
    {
        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// ProductUri
        ///
        /// <summary>
        /// Gets the URL of the product Web page.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static Uri ProductUri => GetUri("https://www.cube-soft.jp/cubepdf/");

        /* ----------------------------------------------------------------- */
        ///
        /// DocumentUri
        ///
        /// <summary>
        /// Gets the URL of the document Web page.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static Uri DocumentUri => GetUri("https://docs.cube-soft.jp/entry/cubepdf");

        /* ----------------------------------------------------------------- */
        ///
        /// Formats
        ///
        /// <summary>
        /// Gets a collection in which each item consists of a display
        /// string and a Format pair.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static ComboListSource<Format> Formats { get; } = new()
        {
            { "PDF",  Format.Pdf },
            { "PS",   Format.Ps },
            { "EPS",  Format.Eps },
            { "PNG",  Format.Png },
            { "JPEG", Format.Jpeg },
            { "BMP",  Format.Bmp },
            { "TIFF", Format.Tiff },
        };

        /* ----------------------------------------------------------------- */
        ///
        /// Extensions
        ///
        /// <summary>
        /// Gets a collection in which each item consists of an extension
        /// and a Format pair.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static ComboListSource<Format> Extensions { get; } = new()
        {
            { ".pdf",  Format.Pdf  },
            { ".ps",   Format.Ps   },
            { ".eps",  Format.Eps  },
            { ".png",  Format.Png  },
            { ".jpg",  Format.Jpeg },
            { ".jpeg", Format.Jpeg },
            { ".bmp",  Format.Bmp  },
            { ".tiff", Format.Tiff },
            { ".tif",  Format.Tiff },
        };

        /* ----------------------------------------------------------------- */
        ///
        /// PdfVersions
        ///
        /// <summary>
        /// Gets a collection in which each item consists of a display
        /// string and a minor number of PDF version.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static ComboListSource<int> PdfVersions { get; } = new()
        {
            { "PDF 1.7", 7 },
            { "PDF 1.6", 6 },
            { "PDF 1.5", 5 },
            { "PDF 1.4", 4 },
            { "PDF 1.3", 3 },
            { "PDF 1.2", 2 },
        };

        /* ----------------------------------------------------------------- */
        ///
        /// SaveOptions
        ///
        /// <summary>
        /// Gets a collection in which each item consists of a display
        /// string and a SaveOption pair.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static ComboListSource<SaveOption> SaveOptions => new()
        {
            { Properties.Resources.MenuOverwrite, SaveOption.Overwrite },
            { Properties.Resources.MenuMergeHead, SaveOption.MergeHead },
            { Properties.Resources.MenuMergeTail, SaveOption.MergeTail },
            { Properties.Resources.MenuRename,    SaveOption.Rename },
        };

        /* ----------------------------------------------------------------- */
        ///
        /// ViewerOptions
        ///
        /// <summary>
        /// Gets a collection in which each item consists of a display
        /// string and a ViewerOptions pair.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static ComboListSource<ViewerOption> ViewerOptions => new()
        {
            { Properties.Resources.MenuSinglePage,     ViewerOption.SinglePage },
            { Properties.Resources.MenuOneColumn,      ViewerOption.OneColumn },
            { Properties.Resources.MenuTwoPageLeft,    ViewerOption.TwoPageLeft },
            { Properties.Resources.MenuTwoPageRight,   ViewerOption.TwoPageRight },
            { Properties.Resources.MenuTwoColumnLeft,  ViewerOption.TwoColumnLeft },
            { Properties.Resources.MenuTwoColumnRight, ViewerOption.TwoColumnRight },
        };

        /* ----------------------------------------------------------------- */
        ///
        /// PostProcesses
        ///
        /// <summary>
        /// Gets a collection in which each item consists of a display
        /// string and a PostProcess pair.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static ComboListSource<PostProcess> PostProcesses => new()
        {
            { Properties.Resources.MenuOpen,          PostProcess.Open },
            { Properties.Resources.MenuOpenDirectory, PostProcess.OpenDirectory },
            { Properties.Resources.MenuNone,          PostProcess.None },
            { Properties.Resources.MenuOthers,        PostProcess.Others },
        };

        /* ----------------------------------------------------------------- */
        ///
        /// Orientations
        ///
        /// <summary>
        /// Gets a collection in which each item consists of a display
        /// string and a Orientation pair.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static ComboListSource<Orientation> Orientations => new()
        {
            { Properties.Resources.MenuPortrait,  Orientation.Portrait },
            { Properties.Resources.MenuLandscape, Orientation.Landscape },
            { Properties.Resources.MenuAuto,      Orientation.Auto },
        };

        /* ----------------------------------------------------------------- */
        ///
        /// Languages
        ///
        /// <summary>
        /// Gets a collection in which each item consists of a display
        /// string and a Language pair.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static ComboListSource<Language> Languages => new()
        {
            { Properties.Resources.GlobalMenuAuto,     Language.Auto },
            { Properties.Resources.GlobalMenuEnglish,  Language.English },
            { Properties.Resources.GlobalMenuJapanese, Language.Japanese },
        };

        /* ----------------------------------------------------------------- */
        ///
        /// SourceFilters
        ///
        /// <summary>
        /// Gets a collection of OpenFileDialog filters.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static IList<FileDialogFilter> SourceFilters => new FileDialogFilter[]
        {
            new(Properties.Resources.FilterPs,  ".ps"),
            new(Properties.Resources.FilterEps, ".eps"),
            new(Properties.Resources.FilterPdf, ".pdf"),
            new(Properties.Resources.FilterAll, ".*"),
        };

        /* ----------------------------------------------------------------- */
        ///
        /// DestinationFilters
        ///
        /// <summary>
        /// Gets a collection of SaveFileDialog filters.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static IList<FileDialogFilter> DestinationFilters => new FileDialogFilter[]
        {
            new(Properties.Resources.FilterPdf,  ".pdf"),
            new(Properties.Resources.FilterPs,   ".ps"),
            new(Properties.Resources.FilterEps,  ".eps"),
            new(Properties.Resources.FilterPng,  ".png"),
            new(Properties.Resources.FilterJpeg, ".jpg", ".jpeg"),
            new(Properties.Resources.FilterBmp,  ".bmp"),
            new(Properties.Resources.FilterTiff, ".tiff", ".tif"),
        };

        /* ----------------------------------------------------------------- */
        ///
        /// UserProgramFilters
        ///
        /// <summary>
        /// Gets a collection of OpenFileDialog filters.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static IList<FileDialogFilter> UserProgramFilters => new FileDialogFilter[]
        {
            new(Properties.Resources.FilterExecutable, ".exe", ".bat"),
            new(Properties.Resources.FilterAll, ".*"),
        };

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// UpdateCulture
        ///
        /// <summary>
        /// Updates the culture information of resource objects.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static void UpdateCulture(Language src) => Properties.Resources.Culture = src.ToCultureInfo();

        /* ----------------------------------------------------------------- */
        ///
        /// WordWrap
        ///
        /// <summary>
        /// Inserts a new line and splits words.
        /// </summary>
        ///
        /// <param name="src">Source string.</param>
        /// <param name="n">Number of characters to split words.</param>
        ///
        /// <returns>Converted string.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public static string WordWrap(this string src, int n) =>
            Regex.Replace(src, $@"(?<=\G.{{{n}}})(?!$)", Environment.NewLine);

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// GetUri
        ///
        /// <summary>
        /// Gets the Uri object from the specified URL string.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private static Uri GetUri(string url) =>
            new Uri(url).With("lang", CultureInfo.CurrentCulture.Name.ToLowerInvariant());

        #endregion
    }
}
