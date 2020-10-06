﻿/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2013 CubeSoft, Inc.
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
using System.Reflection;
using Cube.FileSystem;
using Cube.Mixin.Assembly;
using Cube.Mixin.IO;
using Cube.Mixin.String;

namespace Cube.Pdf.Pages
{
    /* --------------------------------------------------------------------- */
    ///
    /// SettingFolder
    ///
    /// <summary>
    /// Represents the application and/or user settings.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public sealed class SettingFolder : SettingFolder<SettingValue>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// SettingFolder
        ///
        /// <summary>
        /// Initializes a new instance of the SettingFolder with the
        /// specified parameters.
        /// </summary>
        ///
        /// <param name="assembly">Assembly information.</param>
        /// <param name="io">I/O handler</param>
        ///
        /* ----------------------------------------------------------------- */
        public SettingFolder(Assembly assembly, IO io) :
            this(assembly, Cube.DataContract.Format.Registry, @"CubeSoft\CubePDF Page", io)
        { }

        /* ----------------------------------------------------------------- */
        ///
        /// SettingFolder
        ///
        /// <summary>
        /// Initializes a new instance of the SettingFolder with the
        /// specified parameters.
        /// </summary>
        ///
        /// <param name="assembly">Assembly information.</param>
        /// <param name="format">Serialized format.</param>
        /// <param name="location">Location for the settings.</param>
        /// <param name="io">I/O handler</param>
        ///
        /* ----------------------------------------------------------------- */
        public SettingFolder(Assembly assembly, Cube.DataContract.Format format, string location, IO io) :
            base(assembly, format, location, io)
        {
            AutoSave = false;
            Version.Digit = 3;
        }

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// OnSaved
        ///
        /// <summary>
        /// Occurs when the Saved event is fired.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnSaved(KeyValueEventArgs<Cube.DataContract.Format, string> e)
        {
            try
            {
                if (Value == null) return;

                var name = "cubepdf-page-checker";
                var exe  = IO.Combine(Assembly.GetDirectoryName(), "CubeChecker.exe");
                var sk   = "CubePDF Page";
                var args = $"{Assembly.GetNameString().Quote()} /subkey {sk.Quote()}";

                new Startup(name)
                {
                    Command = $"{exe.Quote()} {args}",
                    Enabled = Value.CheckUpdate && IO.Exists(exe),
                }.Save();
            }
            finally { base.OnSaved(e); }
        }

        #endregion
    }
}
