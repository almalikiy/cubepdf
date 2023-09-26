/* ------------------------------------------------------------------------- */
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
namespace Cube.Pdf.Converter.Sources;

using Cube.Globalization;

/* ------------------------------------------------------------------------- */
///
/// TextFactory
///
/// <summary>
/// Provides the functionality to create a text group corresponding to the
/// specified language.
/// </summary>
///
/* ------------------------------------------------------------------------- */
internal static class TextFactory
{
    /* --------------------------------------------------------------------- */
    ///
    /// Get
    ///
    /// <summary>
    /// Gets the text group corresponding to the specified language.
    /// </summary>
    ///
    /// <param name="e">Required language.</param>
    ///
    /// <returns>Text group.</returns>
    ///
    /* --------------------------------------------------------------------- */
    public static TextGroup Get(Language e) => e switch
    {
        Language.English => EnglishText.Get(),
        _ => default,
    };
}
