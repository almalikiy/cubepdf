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
using Cube.FileSystem.DataContract;
using Cube.Mixin.Assembly;

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
        ///
        /* ----------------------------------------------------------------- */
        public SettingFolder(Assembly assembly) :
            this(assembly, Format.Registry, @"CubeSoft\CubePDF Page") { }

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
        ///
        /* ----------------------------------------------------------------- */
        public SettingFolder(Assembly assembly, Format format, string location) :
            base(format, location, assembly.GetSoftwareVersion())
        {
            AutoSave = false;
            Startup  = new("cubepdf-page-checker")
            {
                Source = Io.Combine(GetType().Assembly.GetDirectoryName(), "CubeChecker.exe"),
            };

            Startup.Arguments.Add("cubepdfpage");
            Startup.Arguments.Add("/subkey");
            Startup.Arguments.Add("CubePDF Page");
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Startup
        ///
        /// <summary>
        /// Get the startup registration object.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public Startup Startup { get; }

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// OnSave
        ///
        /// <summary>
        /// Saves the user settings.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnSave()
        {
            base.OnSave();
            Startup.Save(true);
        }

        #endregion
    }
}
