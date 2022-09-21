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
using System.Threading.Tasks;
using Cube.FileSystem;
using Cube.Tasks.Extensions;
using Cube.Xui.Drawing.Extensions;

namespace Cube.Pdf.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// PreviewFacade
    ///
    /// <summary>
    /// Provides functionality to show the preview window.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public sealed class PreviewFacade
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// PreviewFacade
        ///
        /// <summary>
        /// Initializes a new instance of the PreviewFacade class
        /// with the specified arguments.
        /// </summary>
        ///
        /// <param name="src">Source images.</param>
        /// <param name="file">Target file information.</param>
        /// <param name="dispatcher">Dispatcher object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public PreviewFacade(ImageCollection src, Entity file, Dispatcher dispatcher)
        {
            Value = new(src, file, dispatcher);
            Task.Run(() => Setup(src.Selection.First)).Forget();
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Value
        ///
        /// <summary>
        /// Gets the bindable object.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public PreviewBindableValue Value { get; }

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// Setup
        ///
        /// <summary>
        /// Initializes some fields and properties.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void Setup(int index)
        {
            try
            {
                Value.Busy  = true;
                Value.Image = Value.Source.GetImage(index, 2.0).ToBitmapImage(true);
            }
            finally { Value.Busy = false; }
        }

        #endregion
    }
}
