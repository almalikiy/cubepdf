﻿/* ------------------------------------------------------------------------- */
//
// Copyright (c) 2010 CubeSoft, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
/* ------------------------------------------------------------------------- */
namespace Cube.Pdf;

using System;
using System.Drawing;

/* ------------------------------------------------------------------------- */
///
/// Page
///
/// <summary>
/// Represents information of a document page.
/// </summary>
///
/* ------------------------------------------------------------------------- */
[Serializable]
public sealed class Page
{
    #region Constructors

    /* --------------------------------------------------------------------- */
    ///
    /// Page
    ///
    /// <summary>
    /// Initializes a new instance of the Page class with the specified
    /// source object.
    /// </summary>
    ///
    /// <param name="src">Page source object.</param>
    ///
    /* --------------------------------------------------------------------- */
    public Page(IPageSource src) => _source = src ?? throw new ArgumentNullException();

    #endregion

    #region Properties

    /* --------------------------------------------------------------------- */
    ///
    /// File
    ///
    /// <summary>
    /// Get the file information that owns this Page.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public File File => _source.File;

    /* --------------------------------------------------------------------- */
    ///
    /// Number
    ///
    /// <summary>
    /// Get the page number.
    /// </summary>
    ///
    /// <remarks>
    /// 1 for first page.
    /// </remarks>
    ///
    /* --------------------------------------------------------------------- */
    public int Number => _source.Number;

    /* --------------------------------------------------------------------- */
    ///
    /// Rotation
    ///
    /// <summary>
    /// Get the rotation of this Page.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public Angle Rotation => _source.Rotation;

    /* --------------------------------------------------------------------- */
    ///
    /// Resolution
    ///
    /// <summary>
    /// Get the horizontal and vertical resolution (dpi) of this Page.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public PointF Resolution => _source.Resolution;

    /* --------------------------------------------------------------------- */
    ///
    /// Size
    ///
    /// <summary>
    /// Get the page size.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public SizeF Size => _source.Size;

    #endregion

    #region Fields
    private IPageSource _source;
    #endregion
}
