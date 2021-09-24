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
using System.Linq;
using System.Security.Cryptography;
using Cube.Collections;
using Cube.FileSystem;
using Cube.Mixin.Assembly;
using Cube.Pdf.Ghostscript;
using Cube.Tests;
using NUnit.Framework;

namespace Cube.Pdf.Converter.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// FacadeTest
    ///
    /// <summary>
    /// Tests the Facade class.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class FacadeTest : FileFixture
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// Convert
        ///
        /// <summary>
        /// Tests the Convert method.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase(Format.Pdf,                "Sdk.pdf")]
        [TestCase(Format.Ps,                 "Sdk.ps")]
        [TestCase(Format.Png,                "Sdk.png")]
        [TestCase(Format.Png32bppArgb,       "Sdk-Alpha.png")]
        [TestCase(Format.Png8bppIndexed,     "Sdk-Index.png")]
        [TestCase(Format.Png8bppGrayscale,   "Sdk-Gray.png")]
        [TestCase(Format.Png1bppMonochrome,  "Sdk-Mono.png")]
        [TestCase(Format.Jpeg,               "Sdk.jpg")]
        [TestCase(Format.Jpeg8bppGrayscale,  "Sdk-Gray.jpg")]
        [TestCase(Format.Tiff,               "Sdk.tiff")]
        [TestCase(Format.Tiff12bppRgb,       "Sdk-12bpp.tiff")]
        [TestCase(Format.Tiff8bppGrayscale,  "Sdk-Gray.tiff")]
        [TestCase(Format.Tiff1bppMonochrome, "Sdk-Mono.tiff")]
        public void Convert(Format format, string file)
        {
            using var src = new Facade();
            src.Settings.Value.Source      = GetSource("SampleMix.ps");
            src.Settings.Value.Destination = Get(file);
            src.Settings.Value.Format      = format;
            src.Settings.Value.PostProcess = PostProcess.None;
            src.Settings.Value.Resolution  = 96;
            src.Invoke();

            var n = ImageConverter.SupportedFormats.Contains(format) ? 3 : 1;
            Assert.That(src.Busy, Is.False);
            Assert.That(src.Results.Count(), Is.EqualTo(n));
            foreach (var f in src.Results) Assert.That(Io.Exists(f), f);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Convert_SaveOption
        ///
        /// <summary>
        /// Tests the Convert method.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [TestCase(SaveOption.Overwrite)]
        [TestCase(SaveOption.MergeHead)]
        [TestCase(SaveOption.MergeTail)]
        [TestCase(SaveOption.Rename)]
        public void Convert_SaveOption(SaveOption so)
        {
            var dest = Get($"So-{so}.pdf");
            Io.Copy(GetSource("Sample.pdf"), dest, true);

            using var src = new Facade();
            src.Settings.Value.Source = GetSource("Sample.ps");
            src.Settings.Value.Destination = dest;
            src.Settings.Value.SaveOption = so;
            src.Settings.Value.PostProcess = PostProcess.None;
            src.Invoke();

            Assert.That(src.Busy, Is.False);
            Assert.That(src.Results.Count(), Is.EqualTo(1));
            Assert.That(Io.Exists(dest), Is.True);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Convert_CryptographicException
        ///
        /// <summary>
        /// Tests the Convert method with the invalid digest.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Convert_CryptographicException()
        {
            var dest = Get("digest.pdf");
            var args = new ArgumentCollection(new[] { "-Digest", "dummy" });
            var settings = new SettingFolder();

            settings.Value.Source = GetSource("Sample.ps");
            settings.Value.Destination = dest;
            settings.Value.PostProcess = PostProcess.None;
            settings.Set(args);

            using var src = new Facade(settings);
            Assert.That(() => src.Invoke(), Throws.TypeOf<CryptographicException>());
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Version
        ///
        /// <summary>
        /// Tests the version to be set to the Facade object.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Version()
        {
            using var src = new Facade();
            var dest = src.Settings.Version.ToString();
            var cmp  = GetType().Assembly.GetSoftwareVersion().ToString();
            Assert.That(dest, Is.EqualTo(cmp));
        }

        #endregion
    }
}
