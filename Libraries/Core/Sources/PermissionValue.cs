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

/* ------------------------------------------------------------------------- */
///
/// PermissionValue
///
/// <summary>
/// Specifies the permission method for operations.
/// </summary>
///
/* ------------------------------------------------------------------------- */
[Serializable]
public enum PermissionValue
{
    /// <summary>Operation is denied.</summary>
    Deny,
    /// <summary>Part of the operation is allowed.</summary>
    Restrict,
    /// <summary>Operation is allowed.</summary>
    Allow,
}

/* ------------------------------------------------------------------------- */
///
/// PermissionValueExtension
///
/// <summary>
/// Provides extended methods of the PermissionValue enum.
/// </summary>
///
/* ------------------------------------------------------------------------- */
public static class PermissionValueExtension
{
    /* --------------------------------------------------------------------- */
    ///
    /// IsAllowed
    ///
    /// <summary>
    /// Determines whether the specified operation is allowed.
    /// </summary>
    ///
    /// <param name="src">PermissionMethod object.</param>
    ///
    /// <returns>true for allowed.</returns>
    ///
    /* --------------------------------------------------------------------- */
    public static bool IsAllowed(this PermissionValue src) => src == PermissionValue.Allow;

    /* --------------------------------------------------------------------- */
    ///
    /// IsDenid
    ///
    /// <summary>
    /// Determines whether the specified operation is denied.
    /// </summary>
    ///
    /// <param name="src">PermissionMethod object.</param>
    ///
    /// <returns>true for denied.</returns>
    ///
    /* --------------------------------------------------------------------- */
    public static bool IsDenid(this PermissionValue src) => src == PermissionValue.Deny;
}
