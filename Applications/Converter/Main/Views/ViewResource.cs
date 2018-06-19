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
using Cube.Pdf.Ghostscript;
using System.Collections.Generic;

namespace Cube.Pdf.App.Converter
{
    /* --------------------------------------------------------------------- */
    ///
    /// ViewResource
    ///
    /// <summary>
    /// 表示時に使用するリソースを定義したクラスです。
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public static class ViewResource
    {
        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Formats
        ///
        /// <summary>
        /// 表示文字列と Format の対応関係を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static IList<KeyValuePair<string, Format>> Formats => _formats ?? (
            _formats = new List<KeyValuePair<string, Format>>
            {
                Pair("PDF",  Format.Pdf),
                Pair("PS",   Format.Ps),
                Pair("EPS",  Format.Eps),
                Pair("PNG",  Format.Png),
                Pair("JPEG", Format.Jpeg),
                Pair("BMP",  Format.Bmp),
                Pair("TIFF", Format.Tiff),
            }
        );

        /* ----------------------------------------------------------------- */
        ///
        /// FormatOptions
        ///
        /// <summary>
        /// 表示文字列と FormatOption の対応関係を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static IList<KeyValuePair<string, FormatOption>> FormatOptions => _formatOptions ?? (
            _formatOptions = new List<KeyValuePair<string, FormatOption>>
            {
                Pair("PDF 1.7", FormatOption.Pdf17),
                Pair("PDF 1.6", FormatOption.Pdf16),
                Pair("PDF 1.5", FormatOption.Pdf15),
                Pair("PDF 1.4", FormatOption.Pdf14),
                Pair("PDF 1.3", FormatOption.Pdf13),
                Pair("PDF 1.2", FormatOption.Pdf12),
            }
        );

        /* ----------------------------------------------------------------- */
        ///
        /// SaveOptions
        ///
        /// <summary>
        /// 表示文字列と SaveOption の対応関係を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static IList<KeyValuePair<string, SaveOption>> SaveOptions =>
            new List<KeyValuePair<string, SaveOption>>
            {
                Pair(Properties.Resources.MenuOverwrite, SaveOption.Overwrite),
                Pair(Properties.Resources.MenuMergeHead, SaveOption.MergeHead),
                Pair(Properties.Resources.MenuMergeTail, SaveOption.MergeTail),
                Pair(Properties.Resources.MenuRename,    SaveOption.Rename),
            };

        /* ----------------------------------------------------------------- */
        ///
        /// ViewOptions
        ///
        /// <summary>
        /// 表示文字列と ViewOption の対応関係を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static IList<KeyValuePair<string, ViewOption>> ViewOptions =>
            new List<KeyValuePair<string, ViewOption>>
            {
                Pair(Properties.Resources.MenuSinglePage,     ViewOption.SinglePage),
                Pair(Properties.Resources.MenuOneColumn,      ViewOption.OneColumn),
                Pair(Properties.Resources.MenuTwoPageLeft,    ViewOption.TwoPageLeft),
                Pair(Properties.Resources.MenuTwoPageRight,   ViewOption.TwoPageRight),
                Pair(Properties.Resources.MenuTwoColumnLeft,  ViewOption.TwoColumnLeft),
                Pair(Properties.Resources.MenuTwoColumnRight, ViewOption.TwoColumnRight),
            };

        /* ----------------------------------------------------------------- */
        ///
        /// PostProcesses
        ///
        /// <summary>
        /// 表示文字列と PostProcess の対応関係を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static IList<KeyValuePair<string, PostProcess>> PostProcesses =>
            new List<KeyValuePair<string, PostProcess>>
            {
                Pair(Properties.Resources.MenuOpen,       PostProcess.Open),
                Pair(Properties.Resources.MenuOpenFolder, PostProcess.OpenDirectory),
                Pair(Properties.Resources.MenuNone,       PostProcess.None),
                Pair(Properties.Resources.MenuOthers,     PostProcess.Others),
            };

        /* ----------------------------------------------------------------- */
        ///
        /// Orientations
        ///
        /// <summary>
        /// 表示文字列と Orientation の対応関係を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static IList<KeyValuePair<string, Orientation>> Orientations =>
            new List<KeyValuePair<string, Orientation>>
            {
                Pair(Properties.Resources.MenuAuto,      Orientation.Auto),
                Pair(Properties.Resources.MenuPortrait,  Orientation.Portrait),
                Pair(Properties.Resources.MenuLandscape, Orientation.Landscape),
            };

        /* ----------------------------------------------------------------- */
        ///
        /// Languages
        ///
        /// <summary>
        /// 表示文字列と Language の対応関係を取得します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static IList<KeyValuePair<string, Language>> Languages =>
            new List<KeyValuePair<string, Language>>
            {
                Pair(Properties.Resources.MenuAuto,     Language.Auto),
                Pair(Properties.Resources.MenuEnglish,  Language.English),
                Pair(Properties.Resources.MenuJapanese, Language.Japanese),
            };

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// Pair(T, U)
        ///
        /// <summary>
        /// KeyValuePair(T, U) を生成します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private static KeyValuePair<K, V> Pair<K, V>(K key, V value) =>
            new KeyValuePair<K, V>(key, value);

        #endregion

        #region Fields
        private static IList<KeyValuePair<string, Format>> _formats;
        private static IList<KeyValuePair<string, FormatOption>> _formatOptions;
        #endregion
    }
}
