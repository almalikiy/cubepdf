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
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Media.Imaging;
using Cube.FileSystem.DataContract;
using Cube.Logging;
using Cube.Mixin.Collections;
using Cube.Mixin.Commands;
using Cube.Mixin.String;
using Cube.Tests;
using NUnit.Framework;

namespace Cube.Pdf.Editor.Tests
{
    /* --------------------------------------------------------------------- */
    ///
    /// ViewModelFixture
    ///
    /// <summary>
    /// Provides functionality to test ViewModel classes.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public abstract class ViewModelFixture : FileFixture
    {
        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Source
        ///
        /// <summary>
        /// Gets or sets a loading path.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected string Source { get; set; }

        /* ----------------------------------------------------------------- */
        ///
        /// Destination
        ///
        /// <summary>
        /// Gets or sets a saving path.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected string Destination { get; set; }

        /* ----------------------------------------------------------------- */
        ///
        /// Password
        ///
        /// <summary>
        /// Gets or sets a password.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected string Password { get; set; }

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Setup
        ///
        /// <summary>
        /// Executes before each test.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [SetUp]
        protected virtual void Setup()
        {
            Source      = string.Empty;
            Destination = string.Empty;
            Password    = string.Empty;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Make
        ///
        /// <summary>
        /// Creates a new instance of the MainViewModel class, initializes
        /// some properties, and execute the specified action.
        /// </summary>
        ///
        /// <param name="callback">User action.</param>
        ///
        /* ----------------------------------------------------------------- */
        protected void Make(Action<MainViewModel> callback)
        {
            using (var src = Create())
            using (Subscribe(src))
            {
                callback(src);
            }
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Open
        ///
        /// <summary>
        /// Creates a new instance of the MainViewModel class, executes
        /// the Open command, and runs the specified action.
        /// </summary>
        ///
        /// <param name="filename">Filename of the source.</param>
        /// <param name="password">Password of the source.</param>
        /// <param name="next">User action.</param>
        ///
        /* ----------------------------------------------------------------- */
        protected void Open(string filename, string password, Action<MainViewModel> next) => Make(vm =>
        {
            Source   = GetSource(filename);
            Password = password;
            vm.Test(vm.Ribbon.Open);
            next(vm);
        });

        /* ----------------------------------------------------------------- */
        ///
        /// Get
        ///
        /// <summary>
        /// Gets a path with the specified arguments and the Results
        /// directory.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected string Get(IEnumerable<object> parts, [CallerMemberName] string name = null) =>
           Get($"{name}_{parts.Join("_", e => e.ToString())}.pdf");

        /* ----------------------------------------------------------------- */
        ///
        /// Args
        ///
        /// <summary>
        /// Creates a collection with the specified arguments.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected IEnumerable<object> Args(params object[] src) => src;

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// Create
        ///
        /// <summary>
        /// Creates a new instance of the MainViewModel class.
        /// </summary>
        ///
        /// <returns>MainViewModel object.</returns>
        ///
        /* ----------------------------------------------------------------- */
        private MainViewModel Create()
        {
            var src = new SettingFolder(
                Assembly.GetExecutingAssembly(),
                Format.Registry,
                @"CubeSoft\Cube.Pdf.Editor.Tests"
            ) { AutoSave = false };

            var dest  = new MainViewModel(src, new SynchronizationContext());
            var dummy = new BitmapImage(new Uri(GetSource("Loading.png")));

            dest.Value.Images.Preferences.Dummy = dummy;
            dest.Value.Images.Preferences.VisibleFirst = 0;
            dest.Value.Images.Preferences.VisibleLast = 10;

            Assert.That(dest.Value.Message, Is.Empty);
            return dest;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Subscribe
        ///
        /// <summary>
        /// Sets some dummy callbacks to the specified Messenger.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private DisposableContainer Subscribe(IBindable src) => new(
            src.Subscribe<DialogMessage    >(e => Select(e)),
            src.Subscribe<OpenFileMessage  >(e => e.Value = new[] { Source }),
            src.Subscribe<SaveFileMessage  >(e => e.Value = Destination),
            src.Subscribe<PasswordViewModel>(e =>
            {
                Assert.That(e.Title,          Is.Not.Null.And.Not.Empty);
                Assert.That(e.Password.Text,  Is.Not.Null.And.Not.Empty);
                Assert.That(e.Password.Value, Is.Null);
                e.Password.Value = Password;
                var dest = Password.HasValue() ? e.OK : e.Cancel;
                Assert.That(dest.Command.CanExecute(), Is.True, dest.Text);
                dest.Command.Execute();
            })
        );

        /* ----------------------------------------------------------------- */
        ///
        /// Select
        ///
        /// <summary>
        /// Selects a button.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Select(DialogMessage src)
        {
            var found = new Dictionary<DialogButtons, DialogStatus>
            {
                { DialogButtons.Ok,          DialogStatus.Ok  },
                { DialogButtons.OkCancel,    DialogStatus.Ok  },
                { DialogButtons.YesNo,       DialogStatus.Yes },
                { DialogButtons.YesNoCancel, DialogStatus.Yes },
            }.TryGetValue(src.Buttons, out var dest);

            GetType().LogDebug($"{src.Text.Quote()} ({found})");
            Assert.That(found, Is.True, $"{src.Buttons}");
            src.Value = dest;
        }

        #endregion
    }
}
