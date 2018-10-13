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
using Cube.FileSystem.TestService;
using Cube.Xui.Mixin;
using NUnit.Framework;
using System.Linq;

namespace Cube.Pdf.Tests.Editor.ViewModels
{
    /* --------------------------------------------------------------------- */
    ///
    /// RemoveTest
    ///
    /// <summary>
    /// Tests for Remove commands and the InsertViewModel class.
    /// </summary>
    ///
    /* --------------------------------------------------------------------- */
    [TestFixture]
    class InsertTest : ViewModelFixture
    {
        #region Tests

        /* ----------------------------------------------------------------- */
        ///
        /// Insert
        ///
        /// <summary>
        /// Executes the test for inserting a new PDF document behind the
        /// selected index.
        /// </summary>
        ///
        /* ----------------------------------------------------------------- */
        [Test]
        public void Insert() => Create("SampleRotation.pdf", "", 9, vm =>
        {
            vm.Data.Images.Skip(2).First().IsSelected = true;
            Source = GetExamplesWith("Sample.pdf");
            Assert.That(vm.Ribbon.Insert.Command.CanExecute(), Is.True);
            vm.Ribbon.Insert.Command.Execute();
            Assert.That(Wait.For(() => vm.Data.Count.Value == 11), "Timeout (Insert)");

            var dest = vm.Data.Images.ToList();

            Assert.That(dest[ 0].RawObject.Number, Is.EqualTo(1));
            Assert.That(dest[ 1].RawObject.Number, Is.EqualTo(2));
            Assert.That(dest[ 2].RawObject.Number, Is.EqualTo(3));
            Assert.That(dest[ 3].RawObject.Number, Is.EqualTo(1));
            Assert.That(dest[ 4].RawObject.Number, Is.EqualTo(2));
            Assert.That(dest[ 5].RawObject.Number, Is.EqualTo(4));
            Assert.That(dest[ 6].RawObject.Number, Is.EqualTo(5));
            Assert.That(dest[ 7].RawObject.Number, Is.EqualTo(6));
            Assert.That(dest[ 8].RawObject.Number, Is.EqualTo(7));
            Assert.That(dest[ 9].RawObject.Number, Is.EqualTo(8));
            Assert.That(dest[10].RawObject.Number, Is.EqualTo(9));

            for (var i = 0; i < dest.Count; ++i) Assert.That(dest[i].Index, Is.EqualTo(i));
        });

        #endregion
    }
}