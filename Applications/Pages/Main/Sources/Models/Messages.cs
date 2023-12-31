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
using System.Collections.Generic;

namespace Cube.Pdf.Pages
{
    /* --------------------------------------------------------------------- */
    ///
    /// UpdateListMessage
    ///
    /// <summary>
    /// Represents the message that the collection is changed.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public sealed class UpdateListMessage { }

    /* --------------------------------------------------------------------- */
    ///
    /// SelectMessage
    ///
    /// <summary>
    /// Represents the message to select PDF files.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public sealed class SelectMessage : Message<IEnumerable<int>> { }

    /* --------------------------------------------------------------------- */
    ///
    /// CollectionMessage
    ///
    /// <summary>
    /// Represents the message to preview the provided PDF file.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public sealed class PreviewMessage : Message<string> { }
}
