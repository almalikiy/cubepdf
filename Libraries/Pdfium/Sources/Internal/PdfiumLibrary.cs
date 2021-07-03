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
using System;

namespace Cube.Pdf.Pdfium
{
    /* --------------------------------------------------------------------- */
    ///
    /// PdfiumLibrary
    ///
    /// <summary>
    /// Represents the base class to access the PDFium API.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    internal abstract class PdfiumLibrary : DisposableBase
    {
        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// GetLastError
        ///
        /// <summary>
        /// Gets a LoadException object with the last error value.
        /// </summary>
        ///
        /// <returns>LoadException object.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public PdfiumException GetLastError()
        {
            var src = Invoke(NativeMethods.FPDF_GetLastError);
            return new PdfiumException(src);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Invoke
        ///
        /// <summary>
        /// Invokes the specified action with the global lock.
        /// </summary>
        ///
        /// <param name="action">User action.</param>
        ///
        /* ----------------------------------------------------------------- */
        public void Invoke(Action action)
        {
            if (Disposed) throw new ObjectDisposedException(GetType().Name);
            Lock(action);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Invoke
        ///
        /// <summary>
        /// Invokes the specified function with the global lock.
        /// </summary>
        ///
        /// <param name="func">User function.</param>
        ///
        /// <returns>Returned value of the specified function.</returns>
        ///
        /* ----------------------------------------------------------------- */
        public T Invoke<T>(Func<T> func)
        {
            if (Disposed) throw new ObjectDisposedException(GetType().Name);
            lock (_core) return func();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// Lock
        ///
        /// <summary>
        /// Invokes the specified action with the global lock.
        /// </summary>
        ///
        /// <param name="action">User action.</param>
        ///
        /* ----------------------------------------------------------------- */
        protected void Lock(Action action) { lock (_core) action(); }

        #endregion

        #region Fields
        private class UnmanagedResource
        {
            public UnmanagedResource() { NativeMethods.FPDF_InitLibrary(); }
            ~UnmanagedResource() { NativeMethods.FPDF_DestroyLibrary(); }
        }
        private static readonly UnmanagedResource _core = new();
        #endregion
    }
}
