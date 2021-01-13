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
using Cube.Mixin.String;
using Cube.Pdf.Ghostscript;
using Cube.Tests;
using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Cube.Pdf.Converter.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// OtherViewModelTest
    ///
    /// <summary>
    /// Tests properties and methods of ViewModel classes.
    /// </summary>
    ///
    /// <remarks>
    /// 変換処理を含むテストは ConverterTest で実行しています。
    /// </remarks>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class OtherViewModelTest : ViewModelFixture
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// MainViewModel
        ///
        /// <summary>
        /// Confirms the properties of the MainViewModel class.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void MainViewModel() => Invoke(vm =>
        {
            Assert.That(vm.Title,   Does.StartWith(nameof(MainViewModel)));
            Assert.That(vm.Title,   Does.Contain("CubePDF 1.2.1"));
            Assert.That(vm.Version, Does.StartWith("1.2.1 (").And.EndsWith(")"));
            Assert.That(vm.Uri,     Is.EqualTo(new Uri("https://www.cube-soft.jp/cubepdf/")));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// SettingViewModel
        ///
        /// <summary>
        /// Confirms the properties of the SettingViewModel class.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void SettingViewModel() => Invoke(vm =>
        {
            var vms = vm.General;
            Assert.That(vms.Resolution,         Is.EqualTo(600));
            Assert.That(vms.Language,           Is.EqualTo(Language.Auto));
            Assert.That(vms.IsAutoOrientation,  Is.True,  nameof(vms.IsAutoOrientation));
            Assert.That(vms.IsPortrait,         Is.False, nameof(vms.IsPortrait));
            Assert.That(vms.IsLandscape,        Is.False, nameof(vms.IsLandscape));
            Assert.That(vms.Grayscale,          Is.False, nameof(vms.Grayscale));
            Assert.That(vms.ImageFilter,        Is.True,  nameof(vms.ImageFilter));
            Assert.That(vms.Linearization,      Is.False, nameof(vms.Linearization));
            Assert.That(vms.CheckUpdate,        Is.True,  nameof(vms.CheckUpdate));
            Assert.That(vms.IsPdf,              Is.True,  nameof(vms.IsPdf));
            Assert.That(vms.EnableUserProgram,  Is.False, nameof(vms.EnableUserProgram));
            Assert.That(vms.SourceEditable,     Is.False, nameof(vms.SourceEditable));
            Assert.That(vms.SourceVisible,      Is.False, nameof(vms.SourceVisible));

            vms.Format = Format.Png;
            Assert.That(vms.IsPdf, Is.False, nameof(vms.IsPdf));

            vms.PostProcess = PostProcess.Others;
            Assert.That(vms.EnableUserProgram,  Is.True,  nameof(vms.EnableUserProgram));

            vms.IsPortrait = true;
            Assert.That(vms.IsAutoOrientation,  Is.False, nameof(vms.IsAutoOrientation));
            Assert.That(vms.IsPortrait,         Is.True,  nameof(vms.IsPortrait));
            Assert.That(vms.IsLandscape,        Is.False, nameof(vms.IsLandscape));

            vms.IsLandscape = true;
            Assert.That(vms.IsAutoOrientation,  Is.False, nameof(vms.IsAutoOrientation));
            Assert.That(vms.IsPortrait,         Is.False, nameof(vms.IsPortrait));
            Assert.That(vms.IsLandscape,        Is.True,  nameof(vms.IsLandscape));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// MetadataViewModel
        ///
        /// <summary>
        /// MetadataViewModel の各種プロパティを確認します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void MetadataViewModel() => Invoke(vm =>
        {
            var vmm = vm.Metadata;
            Assert.That(vmm.Title,    Is.Empty, nameof(vmm.Title));
            Assert.That(vmm.Author,   Is.Empty, nameof(vmm.Author));
            Assert.That(vmm.Subject,  Is.Empty, nameof(vmm.Subject));
            Assert.That(vmm.Keywords, Is.Empty, nameof(vmm.Keywords));
            Assert.That(vmm.Creator,  Is.EqualTo("CubePDF"));
            Assert.That(vmm.Options,  Is.EqualTo(ViewerOption.OneColumn));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// EncryptionViewModel
        ///
        /// <summary>
        /// EncryptionViewModel の各種プロパティを確認します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void EncryptionViewModel() => Invoke(vm =>
        {
            var vme = vm.Encryption;
            Assert.That(vme.Enabled,            Is.False, nameof(vme.Enabled));
            Assert.That(vme.OwnerPassword,      Is.Empty, nameof(vme.OwnerPassword));
            Assert.That(vme.OwnerConfirm,       Is.Empty, nameof(vme.OwnerConfirm));
            Assert.That(vme.OpenWithPassword,   Is.False, nameof(vme.OpenWithPassword));
            Assert.That(vme.UseOwnerPassword,   Is.False, nameof(vme.UseOwnerPassword));
            Assert.That(vme.EnableUserPassword, Is.False, nameof(vme.EnableUserPassword));
            Assert.That(vme.UserPassword,       Is.Empty, nameof(vme.UserPassword));
            Assert.That(vme.UserConfirm,        Is.Empty, nameof(vme.UserConfirm));
            Assert.That(vme.AllowCopy,          Is.False, nameof(vme.AllowCopy));
            Assert.That(vme.AllowInputForm,     Is.False, nameof(vme.AllowInputForm));
            Assert.That(vme.AllowModify,        Is.False, nameof(vme.AllowModify));
            Assert.That(vme.AllowPrint,         Is.False, nameof(vme.AllowPrint));
            Assert.That(vme.EnablePermission,   Is.True,  nameof(vme.EnablePermission));

            vme.Enabled = true;
            vme.OwnerPassword    = "Password";
            vme.OwnerConfirm     = "Password";
            vme.OpenWithPassword = true;

            Assert.That(vme.Enabled,            Is.True,  nameof(vme.Enabled));
            Assert.That(vme.OpenWithPassword,   Is.True,  nameof(vme.OpenWithPassword));
            Assert.That(vme.UseOwnerPassword,   Is.False, nameof(vme.UseOwnerPassword));
            Assert.That(vme.EnableUserPassword, Is.True,  nameof(vme.EnableUserPassword));
            Assert.That(vme.EnablePermission,   Is.True,  nameof(vme.EnablePermission));

            vme.UseOwnerPassword = true;

            Assert.That(vme.UseOwnerPassword,   Is.True,  nameof(vme.UseOwnerPassword));
            Assert.That(vme.EnableUserPassword, Is.False, nameof(vme.EnableUserPassword));
            Assert.That(vme.EnablePermission,   Is.False, nameof(vme.EnablePermission));
        });

        /* ----------------------------------------------------------------- */
        ///
        /// BrowseUserProgram
        ///
        /// <summary>
        /// 保存パスを選択するテストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void BrowseSource() => Invoke(vm =>
        {
            var done = $"{nameof(BrowseSource)}_Done.pdf";

            _ = vm.Subscribe<OpenFileMessage>(e =>
            {
                Assert.That(e.Text,             Is.EqualTo("入力ファイルを選択"));
                Assert.That(e.InitialDirectory, Is.Empty);
                Assert.That(e.Value.Count(),    Is.EqualTo(1));
                Assert.That(e.Filter,           Is.Not.Null.And.Not.Empty);
                Assert.That(e.FilterIndex,      Is.EqualTo(0));
                Assert.That(e.CheckPathExists,  Is.True);

                e.Value  = new[] { done };
                e.Cancel = false;
            });

            vm.General.Language = Language.Japanese;
            vm.SelectSource();
            Assert.That(Wait.For(() => vm.General.Source.FuzzyEquals(done)), "Timeout");
        });

        /* ----------------------------------------------------------------- */
        ///
        /// BrowseDestination
        ///
        /// <summary>
        /// 保存パスを選択するテストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void BrowseDestination() => Invoke(vm =>
        {
            var done = $"{nameof(BrowseDestination)}_Done.pdf";

            _ = vm.Subscribe<SaveFileMessage>(e =>
            {
                Assert.That(e.Text,             Is.EqualTo("名前を付けて保存"));
                Assert.That(e.InitialDirectory, Is.Empty);
                Assert.That(e.Value,            Is.EqualTo(nameof(BrowseDestination)));
                Assert.That(e.Filter,           Is.Not.Null.And.Not.Empty);
                Assert.That(e.FilterIndex,      Is.EqualTo(1));
                Assert.That(e.OverwritePrompt,  Is.False);
                Assert.That(e.CheckPathExists,  Is.False);

                e.Value  = done;
                e.Cancel = false;
            });

            vm.General.Language = Language.Japanese;
            vm.SelectDestination();
            Assert.That(Wait.For(() => vm.General.Destination.FuzzyEquals(done)), "Timeout");
        });

        /* ----------------------------------------------------------------- */
        ///
        /// BrowseUserProgram
        ///
        /// <summary>
        /// ユーザプログラムを選択するテストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void BrowseUserProgram() => Invoke(vm =>
        {
            var done = $"{nameof(BrowseUserProgram)}_Done.pdf";

            _ = vm.Subscribe<OpenFileMessage>(e =>
            {
                Assert.That(e.Text,             Is.EqualTo("変換完了時に実行するプログラムを選択"));
                Assert.That(e.InitialDirectory, Is.Empty);
                Assert.That(e.Value.Count(),    Is.EqualTo(0));
                Assert.That(e.Filter,           Is.Not.Null.And.Not.Empty);
                Assert.That(e.FilterIndex,      Is.EqualTo(0));
                Assert.That(e.CheckPathExists,  Is.True);

                e.Value  = new[] { done };
                e.Cancel = false;
            });

            vm.General.Language = Language.Japanese;
            vm.SelectUserProgram();
            Assert.That(Wait.For(() => vm.General.UserProgram.FuzzyEquals(done)), "Timeout");
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Validate_OwnerPassword
        ///
        /// <summary>
        /// 管理用パスワードの入力チェック処理のテストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Validate_OwnerPassword() => Invoke(vm =>
        {
            vm.General.Language         = Language.English;
            vm.Encryption.Enabled       = true;
            vm.Encryption.OwnerPassword = nameof(Validate_OwnerPassword);

            Assert.That(TestError(vm), Is.True, "Timeout (Empty)");
            vm.Encryption.OwnerConfirm = "Dummy";
            Assert.That(TestError(vm), Is.True, "Timeout (NotMatch)");
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Validate_UserPassword
        ///
        /// <summary>
        /// 管理用パスワードの入力チェック処理のテストを実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Validate_UserPassword() => Invoke(vm =>
        {
            vm.General.Language            = Language.English;
            vm.Encryption.Enabled          = true;
            vm.Encryption.OwnerPassword    = nameof(Validate_OwnerPassword);
            vm.Encryption.OwnerConfirm     = nameof(Validate_OwnerPassword);
            vm.Encryption.OpenWithPassword = true;
            vm.Encryption.UserPassword     = nameof(Validate_UserPassword);

            Assert.That(TestError(vm), Is.True, "Timeout (Empty)");
            vm.Encryption.UserConfirm = "Dummy";
            Assert.That(TestError(vm), Is.True, "Timeout (NotMatch)");
        });

        #endregion

        #region Others

        /* ----------------------------------------------------------------- */
        ///
        /// Invoke
        ///
        /// <summary>
        /// ViewModel オブジェクトを生成し、処理を実行します。
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Invoke(Action<MainViewModel> action, [CallerMemberName] string name = null)
        {
            var args = GetArgs(name);
            var dest = Create(Combine(args, "Sample.ps"));

            using (Locale.Subscribe(SetUiCulture))
            using (var vm = new MainViewModel(dest, new SynchronizationContext()))
            using (vm.Subscribe<DialogMessage>(SetMessage))
            {
                action(vm);
            }
        }

        #endregion
    }
}
