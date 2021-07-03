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
using System.Windows;
using System.Windows.Controls;
using Cube.Xui;
using Cube.Xui.Behaviors;

namespace Cube.Pdf.Editor
{
    /* --------------------------------------------------------------------- */
    ///
    /// SelectionBehavior
    ///
    /// <summary>
    /// Represents the behavior when a ListBoxItem is selected.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    public class SelectionBehavior : CommandBehavior<ListBox>
    {
        #region Properties

        /* ----------------------------------------------------------------- */
        ///
        /// Popup
        ///
        /// <summary>
        /// Gets or sets a value indicating whether the AssociatedObject
        /// may be popped up.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public bool Popup
        {
            get => (bool)GetValue(PopupProperty);
            set => SetValue(PopupProperty, value);
        }

        /* ----------------------------------------------------------------- */
        ///
        /// PopupProperty
        ///
        /// <summary>
        /// Gets the DependencyProperty object for the Popup property.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        public static readonly DependencyProperty PopupProperty =
            DependencyFactory.Create<SelectionBehavior, bool>(nameof(Popup), (s, e) => s.Popup = e);

        #endregion

        #region Implementations

        /* ----------------------------------------------------------------- */
        ///
        /// OnAttached
        ///
        /// <summary>
        /// Called after the action is attached to an AssociatedObject.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += WhenChanged;
        }

        /* ----------------------------------------------------------------- */
        ///
        /// OnDetaching
        ///
        /// <summary>
        /// Called when the action is being detached from its
        /// AssociatedObject, but before it has actually occurred.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        protected override void OnDetaching()
        {
            AssociatedObject.SelectionChanged -= WhenChanged;
            base.OnDetaching();
        }

        /* ----------------------------------------------------------------- */
        ///
        /// WhenChanged
        ///
        /// <summary>
        /// Called when the selection of the ListBox is changed.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        private void WhenChanged(object s, SelectionChangedEventArgs e)
        {
            try
            {
                var ok = (e.AddedItems.Count > 0) &&
                         (Command?.CanExecute(e.AddedItems[0]) ?? false);
                if (ok) Command.Execute(e.AddedItems[0]);
            }
            finally
            {
                AssociatedObject.UnselectAll();
                //if (Popup) PopupService.RaiseDismissPopupEventAsync(AssociatedObject, DismissPopupMode.Always);
            }
        }

        #endregion
    }
}
