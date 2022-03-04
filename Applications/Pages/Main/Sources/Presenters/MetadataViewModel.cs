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
using System.Threading;

namespace Cube.Pdf.Pages
{
    /* --------------------------------------------------------------------- */
    ///
    /// MetadataViewModel
    ///
    /// <summary>
    /// Represents the ViewModel for the MetadataWindow.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class MetadataViewModel : PresentableBase<Metadata>
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// MetadataViewModel
        ///
        /// <summary>
        /// Initializes a new instance of the MetadataViewModel class
        /// with the specified arguments.
        /// </summary>
        ///
        /// <param name="context">Synchronization context.</param>
        ///
        /* ----------------------------------------------------------------- */
        public MetadataViewModel(SynchronizationContext context) :
            base(new(), new(), context) { }

        #endregion
    }
}