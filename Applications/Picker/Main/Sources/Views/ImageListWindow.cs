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
using System.Windows.Forms;
using Cube.Forms;

namespace Cube.Pdf.Picker
{
    /* --------------------------------------------------------------------- */
    ///
    /// ImageListWindow
    ///
    /// <summary>
    /// Represents the window to display the image list.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public partial class ImageListWindow : Window
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// ImageListWindow
        ///
        /// <summary>
        /// Initializes a new instance of the ImageListWindow class.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public ImageListWindow()
        {
            InitializeComponent();

            new ToolTip
            {
                InitialDelay = 200,
                AutoPopDelay = 5000,
                ReshowDelay  = 1000,
            }.SetToolTip(TitleButton, Properties.Resources.About);
        }

        #endregion
    }
}
