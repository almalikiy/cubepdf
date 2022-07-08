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
using System.Linq;
using Cube.Pdf.Ghostscript;
using NUnit.Framework;

namespace Cube.Pdf.Converter.Tests.Views
{
    /* --------------------------------------------------------------------- */
    ///
    /// ViewResourceTest
    ///
    /// <summary>
    /// Tests the Resource class.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class ViewResourceTest : ViewModelFixture
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// Formats
        ///
        /// <summary>
        /// Tests the display string for Formats.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Formats() => Create(vm =>
        {
            var v = Resource.Formats.ToArray();
            Assert.That(v.Count,    Is.EqualTo(7));
            Assert.That(v[0].Value, Is.EqualTo(Format.Pdf));
            Assert.That(v[1].Value, Is.EqualTo(Format.Ps));
            Assert.That(v[2].Value, Is.EqualTo(Format.Eps));
            Assert.That(v[3].Value, Is.EqualTo(Format.Png));
            Assert.That(v[4].Value, Is.EqualTo(Format.Jpeg));
            Assert.That(v[5].Value, Is.EqualTo(Format.Bmp));
            Assert.That(v[6].Value, Is.EqualTo(Format.Tiff));

            vm.Settings.Language = Language.English;
            var en = Resource.Formats.ToArray();
            Assert.That(en[0].Key, Is.EqualTo("PDF"));
            Assert.That(en[1].Key, Is.EqualTo("PS"));
            Assert.That(en[2].Key, Is.EqualTo("EPS"));
            Assert.That(en[3].Key, Is.EqualTo("PNG"));
            Assert.That(en[4].Key, Is.EqualTo("JPEG"));
            Assert.That(en[5].Key, Is.EqualTo("BMP"));
            Assert.That(en[6].Key, Is.EqualTo("TIFF"));

            vm.Settings.Language = Language.Japanese;
            var ja = Resource.Formats.ToArray();
            Assert.That(ja[0].Key, Is.EqualTo("PDF"));
            Assert.That(ja[1].Key, Is.EqualTo("PS"));
            Assert.That(ja[2].Key, Is.EqualTo("EPS"));
            Assert.That(ja[3].Key, Is.EqualTo("PNG"));
            Assert.That(ja[4].Key, Is.EqualTo("JPEG"));
            Assert.That(ja[5].Key, Is.EqualTo("BMP"));
            Assert.That(ja[6].Key, Is.EqualTo("TIFF"));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// PdfVersions
        ///
        /// <summary>
        /// Tests the display string for PdfVersions.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void PdfVersions() => Create(vm =>
        {
            var v = Resource.PdfVersions.ToArray();
            Assert.That(v.Count,    Is.EqualTo(6));
            Assert.That(v[0].Value, Is.EqualTo(7));
            Assert.That(v[1].Value, Is.EqualTo(6));
            Assert.That(v[2].Value, Is.EqualTo(5));
            Assert.That(v[3].Value, Is.EqualTo(4));
            Assert.That(v[4].Value, Is.EqualTo(3));
            Assert.That(v[5].Value, Is.EqualTo(2));

            vm.Settings.Language = Language.English;
            var en = Resource.PdfVersions.ToArray();
            Assert.That(en[0].Key, Is.EqualTo("PDF 1.7"));
            Assert.That(en[1].Key, Is.EqualTo("PDF 1.6"));
            Assert.That(en[2].Key, Is.EqualTo("PDF 1.5"));
            Assert.That(en[3].Key, Is.EqualTo("PDF 1.4"));
            Assert.That(en[4].Key, Is.EqualTo("PDF 1.3"));
            Assert.That(en[5].Key, Is.EqualTo("PDF 1.2"));

            vm.Settings.Language = Language.Japanese;
            var ja = Resource.PdfVersions.ToArray();
            Assert.That(ja[0].Key, Is.EqualTo("PDF 1.7"));
            Assert.That(ja[1].Key, Is.EqualTo("PDF 1.6"));
            Assert.That(ja[2].Key, Is.EqualTo("PDF 1.5"));
            Assert.That(ja[3].Key, Is.EqualTo("PDF 1.4"));
            Assert.That(ja[4].Key, Is.EqualTo("PDF 1.3"));
            Assert.That(ja[5].Key, Is.EqualTo("PDF 1.2"));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// SaveOptions
        ///
        /// <summary>
        /// Tests the display string for SaveOptions.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void SaveOptions() => Create(vm =>
        {
            var v = Resource.SaveOptions.ToArray();
            Assert.That(v.Count,    Is.EqualTo(4));
            Assert.That(v[0].Value, Is.EqualTo(SaveOption.Overwrite));
            Assert.That(v[1].Value, Is.EqualTo(SaveOption.MergeHead));
            Assert.That(v[2].Value, Is.EqualTo(SaveOption.MergeTail));
            Assert.That(v[3].Value, Is.EqualTo(SaveOption.Rename));

            vm.Settings.Language = Language.English;
            var en = Resource.SaveOptions.ToArray();
            Assert.That(en[0].Key, Is.EqualTo("Overwrite"));
            Assert.That(en[1].Key, Is.EqualTo("Merge head"));
            Assert.That(en[2].Key, Is.EqualTo("Merge tail"));
            Assert.That(en[3].Key, Is.EqualTo("Rename"));

            vm.Settings.Language = Language.Japanese;
            var ja = Resource.SaveOptions.ToArray();
            Assert.That(ja[0].Key, Is.EqualTo("上書き"));
            Assert.That(ja[1].Key, Is.EqualTo("先頭に結合"));
            Assert.That(ja[2].Key, Is.EqualTo("末尾に結合"));
            Assert.That(ja[3].Key, Is.EqualTo("リネーム"));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Orientations
        ///
        /// <summary>
        /// Tests the display string for Orientations.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Orientations() => Create(vm =>
        {
            var v = Resource.Orientations.ToArray();
            Assert.That(v.Count,    Is.EqualTo(3));
            Assert.That(v[0].Value, Is.EqualTo(Orientation.Portrait));
            Assert.That(v[1].Value, Is.EqualTo(Orientation.Landscape));
            Assert.That(v[2].Value, Is.EqualTo(Orientation.Auto));

            vm.Settings.Language = Language.English;
            var en = Resource.Orientations.ToArray();
            Assert.That(en[0].Key, Is.EqualTo("Portrait"));
            Assert.That(en[1].Key, Is.EqualTo("Landscape"));
            Assert.That(en[2].Key, Is.EqualTo("Auto"));

            vm.Settings.Language = Language.Japanese;
            var ja = Resource.Orientations.ToArray();
            Assert.That(ja[0].Key, Is.EqualTo("縦"));
            Assert.That(ja[1].Key, Is.EqualTo("横"));
            Assert.That(ja[2].Key, Is.EqualTo("自動"));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// PostProcesses
        ///
        /// <summary>
        /// Tests the display string for PostProcesses.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void PostProcesses() => Create(vm =>
        {
            var v = Resource.PostProcesses.ToArray();
            Assert.That(v.Count,    Is.EqualTo(4));
            Assert.That(v[0].Value, Is.EqualTo(PostProcess.Open));
            Assert.That(v[1].Value, Is.EqualTo(PostProcess.OpenDirectory));
            Assert.That(v[2].Value, Is.EqualTo(PostProcess.None));
            Assert.That(v[3].Value, Is.EqualTo(PostProcess.Others));

            vm.Settings.Language = Language.English;
            var en = Resource.PostProcesses.ToArray();
            Assert.That(en[0].Key, Is.EqualTo("Open"));
            Assert.That(en[1].Key, Is.EqualTo("Open directory"));
            Assert.That(en[2].Key, Is.EqualTo("None"));
            Assert.That(en[3].Key, Is.EqualTo("Others"));

            vm.Settings.Language = Language.Japanese;
            var ja = Resource.PostProcesses.ToArray();
            Assert.That(ja[0].Key, Is.EqualTo("開く"));
            Assert.That(ja[1].Key, Is.EqualTo("フォルダを開く"));
            Assert.That(ja[2].Key, Is.EqualTo("何もしない"));
            Assert.That(ja[3].Key, Is.EqualTo("その他"));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// ViewerOptions
        ///
        /// <summary>
        /// Tests the display string for ViewerOptions.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void ViewerOptions() => Create(vm =>
        {
            var v = Resource.ViewerOptions.ToArray();
            Assert.That(v.Count, Is.EqualTo(6));
            Assert.That(v[0].Value, Is.EqualTo(ViewerOption.SinglePage));
            Assert.That(v[1].Value, Is.EqualTo(ViewerOption.OneColumn));
            Assert.That(v[2].Value, Is.EqualTo(ViewerOption.TwoPageLeft));
            Assert.That(v[3].Value, Is.EqualTo(ViewerOption.TwoPageRight));
            Assert.That(v[4].Value, Is.EqualTo(ViewerOption.TwoColumnLeft));
            Assert.That(v[5].Value, Is.EqualTo(ViewerOption.TwoColumnRight));

            vm.Settings.Language = Language.English;
            var en = Resource.ViewerOptions.ToArray();
            Assert.That(en[0].Key, Is.EqualTo("Single page"));
            Assert.That(en[1].Key, Is.EqualTo("One column"));
            Assert.That(en[2].Key, Is.EqualTo("Two page (left)"));
            Assert.That(en[3].Key, Is.EqualTo("Two page (right)"));
            Assert.That(en[4].Key, Is.EqualTo("Two column (left)"));
            Assert.That(en[5].Key, Is.EqualTo("Two column (right)"));

            vm.Settings.Language = Language.Japanese;
            var ja = Resource.ViewerOptions.ToArray();
            Assert.That(ja[0].Key, Is.EqualTo("単一ページ"));
            Assert.That(ja[1].Key, Is.EqualTo("連続ページ"));
            Assert.That(ja[2].Key, Is.EqualTo("見開きページ（左綴じ）"));
            Assert.That(ja[3].Key, Is.EqualTo("見開きページ（右綴じ）"));
            Assert.That(ja[4].Key, Is.EqualTo("連続見開きページ（左綴じ）"));
            Assert.That(ja[5].Key, Is.EqualTo("連続見開きページ（右綴じ）"));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Languages
        ///
        /// <summary>
        /// Tests the display string for Language.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Languages() => Create(vm =>
        {
            var v = Resource.Languages.ToArray();
            Assert.That(v.Count,    Is.EqualTo(3));
            Assert.That(v[0].Value, Is.EqualTo(Language.Auto));
            Assert.That(v[1].Value, Is.EqualTo(Language.English));
            Assert.That(v[2].Value, Is.EqualTo(Language.Japanese));

            vm.Settings.Language = Language.English;
            var en = Resource.Languages.ToArray();
            Assert.That(en[0].Key, Is.EqualTo("Auto"));
            Assert.That(en[1].Key, Is.EqualTo("English"));
            Assert.That(en[2].Key, Is.EqualTo("Japanese"));

            vm.Settings.Language = Language.Japanese;
            var ja = Resource.Languages.ToArray();
            Assert.That(ja[0].Key, Is.EqualTo("Auto"));
            Assert.That(ja[1].Key, Is.EqualTo("English"));
            Assert.That(ja[2].Key, Is.EqualTo("Japanese"));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// SourceFilters
        ///
        /// <summary>
        /// Tests the display string regarding filters on the selecting
        /// source dialog.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void SourceFilters() => Create(vm =>
        {
            var v = Resource.SourceFilters;
            Assert.That(v.Count, Is.EqualTo(4));

            vm.Settings.Language = Language.English;
            var en = Resource.SourceFilters;
            Assert.That(en[0].ToString(), Does.StartWith("PS files"));
            Assert.That(en[1].ToString(), Does.StartWith("EPS files"));
            Assert.That(en[2].ToString(), Does.StartWith("PDF files"));
            Assert.That(en[3].ToString(), Does.StartWith("All files"));

            vm.Settings.Language = Language.Japanese;
            var ja = Resource.SourceFilters;
            Assert.That(ja[0].ToString(), Does.StartWith("PS ファイル"));
            Assert.That(ja[1].ToString(), Does.StartWith("EPS ファイル"));
            Assert.That(ja[2].ToString(), Does.StartWith("PDF ファイル"));
            Assert.That(ja[3].ToString(), Does.StartWith("すべてのファイル"));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// DestinationFilters
        ///
        /// <summary>
        /// Tests the display string regarding filters on the SaveAs dialog.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void DestinationFilters() => Create(vm =>
        {
            var v = Resource.DestinationFilters;
            Assert.That(v.Count, Is.EqualTo(7));

            vm.Settings.Language = Language.English;
            var en = Resource.DestinationFilters;
            Assert.That(en[0].ToString(), Does.StartWith("PDF files"));
            Assert.That(en[1].ToString(), Does.StartWith("PS files"));
            Assert.That(en[2].ToString(), Does.StartWith("EPS files"));
            Assert.That(en[3].ToString(), Does.StartWith("PNG files"));
            Assert.That(en[4].ToString(), Does.StartWith("JPEG files"));
            Assert.That(en[5].ToString(), Does.StartWith("BMP files"));
            Assert.That(en[6].ToString(), Does.StartWith("TIFF files"));

            vm.Settings.Language = Language.Japanese;
            var ja = Resource.DestinationFilters;
            Assert.That(ja[0].ToString(), Does.StartWith("PDF ファイル"));
            Assert.That(ja[1].ToString(), Does.StartWith("PS ファイル"));
            Assert.That(ja[2].ToString(), Does.StartWith("EPS ファイル"));
            Assert.That(ja[3].ToString(), Does.StartWith("PNG ファイル"));
            Assert.That(ja[4].ToString(), Does.StartWith("JPEG ファイル"));
            Assert.That(ja[5].ToString(), Does.StartWith("BMP ファイル"));
            Assert.That(ja[6].ToString(), Does.StartWith("TIFF ファイル"));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// UserProgramFilters
        ///
        /// <summary>
        /// Tests the display string regarding filters on the selecting
        /// UserProgram dialog.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void UserProgramFilters() => Create(vm =>
        {
            var v = Resource.UserProgramFilters;
            Assert.That(v.Count, Is.EqualTo(2));

            vm.Settings.Language = Language.English;
            var en = Resource.UserProgramFilters;
            Assert.That(en[0].ToString(), Does.StartWith("Executable files"));
            Assert.That(en[1].ToString(), Does.StartWith("All files"));

            vm.Settings.Language = Language.Japanese;
            var ja = Resource.UserProgramFilters;
            Assert.That(ja[0].ToString(), Does.StartWith("実行可能なファイル"));
            Assert.That(ja[1].ToString(), Does.StartWith("すべてのファイル"));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// WordWrap
        ///
        /// <summary>
        /// Tests the WordWrap extended method.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase("a",       5, ExpectedResult = 1)]
        [TestCase("abcde",   5, ExpectedResult = 1)]
        [TestCase("abcdefg", 5, ExpectedResult = 2)]
        [TestCase("",        5, ExpectedResult = 1)]
        public int WordWrap(string src, int n) =>
            src.WordWrap(n)
               .Split(new[] { Environment.NewLine }, StringSplitOptions.None)
               .Length;

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// Creates a new ViewModel object for testing.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Create(Action<MainViewModel> action)
        {
            var src = Create(Combine(GetArgs(nameof(ViewResourceTest)), "Sample.ps"));

            using (Locale.Subscribe(SetUiCulture))
            using (var vm = new MainViewModel(src))
            {
                vm.Settings.Language = Language.Auto;
                action(vm);
            }
        }

        #endregion
    }
}
