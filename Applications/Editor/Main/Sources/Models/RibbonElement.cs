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
using System;
using System.ComponentModel;
using System.Windows.Input;
using Cube.Xui;
using Cube.Xui.Commands.Extensions;

namespace Cube.Pdf.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// RibbonElement
    ///
    /// <summary>
    /// Represents a ribbon element.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public sealed class RibbonElement : BindableElement
    {
        #region Constructors

        /* ----------------------------------------------------------------- */
        ///
        /// RibbonElement
        ///
        /// <summary>
        /// Initializes a new instance of the RibbonElement class
        /// with the specified arguments.
        /// </summary>
        ///
        /// <param name="name">Name of icons.</param>
        /// <param name="getText">Function to get text.</param>
        /// <param name="dispatcher">Dispatcher object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public RibbonElement(string name,
            Getter<string> getText,
            Dispatcher dispatcher
        ) : this(name, getText, getText, dispatcher) { }

        /* ----------------------------------------------------------------- */
        ///
        /// RibbonElement
        ///
        /// <summary>
        /// Initializes a new instance of the RibbonElement class
        /// with the specified arguments.
        /// </summary>
        ///
        /// <param name="name">Name of icons.</param>
        /// <param name="getText">Function to get text.</param>
        /// <param name="getTooltip">Function to get tooltip.</param>
        /// <param name="dispatcher">Dispatcher object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public RibbonElement(string name,
            Getter<string> getText,
            Getter<string> getTooltip,
            Dispatcher dispatcher
        ) : this(name, getText, getTooltip, null, dispatcher) { }

        /* ----------------------------------------------------------------- */
        ///
        /// RibbonElement
        ///
        /// <summary>
        /// Initializes a new instance of the RibbonElement class
        /// with the specified arguments.
        /// </summary>
        ///
        /// <param name="name">Name of icons.</param>
        /// <param name="getText">Function to get text.</param>
        /// <param name="getTooltip">Function to get tooltip.</param>
        /// <param name="getEnabled">Function to get enabled value.</param>
        /// <param name="dispatcher">Dispatcher object.</param>
        ///
        /* ----------------------------------------------------------------- */
        public RibbonElement(string name,
            Getter<string> getText,
            Getter<string> getTooltip,
            Getter<bool> getEnabled,
            Dispatcher dispatcher
        ) : base(getText, dispatcher)
        {
            Name = name;
            _getTooltip = getTooltip;
            _getEnabled = getEnabled;
        }

        #endregion

        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Tooltip
        ///
        /// <summary>
        /// Gets the tooltip.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string Tooltip => _getTooltip();

        /* ----------------------------------------------------------------- */
        ///
        /// Enabled
        ///
        /// <summary>
        /// Gets the value indicating whether the element is enabled.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public bool Enabled => _getEnabled?.Invoke() ?? Command?.CanExecute() ?? true;

        /* ----------------------------------------------------------------- */
        ///
        /// Name
        ///
        /// <summary>
        /// Gets the name for icons.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string Name { get; }

        /* ----------------------------------------------------------------- */
        ///
        /// LargeIcon
        ///
        /// <summary>
        /// Gets the file path of large size icon with the WPF URI format.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string LargeIcon => $"{Assets}/Large/{IconName}.png";

        /* ----------------------------------------------------------------- */
        ///
        /// SmallIcon
        ///
        /// <summary>
        /// Gets the file path of small size icon with the WPF URI format.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public string SmallIcon => $"{Assets}/Small/{IconName}.png";

        /* ----------------------------------------------------------------- */
        ///
        /// IconName
        ///
        /// <summary>
        /// Gets the name of icons.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private string IconName => Enabled ? Name : $"{Name}Disable";

        /* ----------------------------------------------------------------- */
        ///
        /// Assets
        ///
        /// <summary>
        /// Gets the root path of icon files with the WPF URI format.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private static string Assets { get; } = "pack://application:,,,/Assets";

        #endregion

        #region Methods

        /* ----------------------------------------------------------------- */
        ///
        /// Dispose
        ///
        /// <summary>
        /// Releases the unmanaged resources used by the class and
        /// optionally releases the managed resources.
        /// </summary>
        ///
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources;
        /// false to release only unmanaged resources.
        /// </param>
        ///
        /* ----------------------------------------------------------------- */
        protected override void Dispose(bool disposing)
        {
            if (disposing) _canExecute?.Dispose();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// React
        ///
        /// <summary>
        /// Occurs when any states are changed.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void React()
        {
            base.React();
            Refresh(nameof(Tooltip), nameof(Enabled));
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnPropertyChanged
        ///
        /// <summary>
        /// Occurs when the PropertyChanged event is fired.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName != nameof(Command)) return;
                _canExecute?.Dispose();
                _canExecute = (Command != null) ? Register(Command) : null;
            }
            finally { base.OnPropertyChanged(e); }
        }

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// Register
        ///
        /// <summary>
        /// Attaches the event handler and creates an object to detach.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private IDisposable Register(ICommand src)
        {
            void update(object s, EventArgs e) => Refresh(nameof(Enabled), nameof(SmallIcon), nameof(LargeIcon));
            src.CanExecuteChanged -= update;
            src.CanExecuteChanged += update;
            return Disposable.Create(() => src.CanExecuteChanged -= update);
        }

        #endregion

        #region Fields
        private readonly Getter<string> _getTooltip;
        private readonly Getter<bool> _getEnabled;
        private IDisposable _canExecute;
        #endregion
    }
}
