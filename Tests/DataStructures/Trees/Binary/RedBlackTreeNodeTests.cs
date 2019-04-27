﻿#region copyright
/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of CSFundamentalAlgorithms project.
 *
 * CSFundamentalAlgorithms is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * CSFundamentalAlgorithms is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with CSFundamentals.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using CSFundamentals.DataStructures.Trees.Binary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSFundamentalsTests.DataStructures.Trees.Binary
{
    [TestClass]
    public class RedBlackTreeNodeTests
    {
        [TestMethod]
        public void FlipColor()
        {
            var A = new RedBlackTreeNode<int, string>(2, "A", RedBlackTreeNodeColor.Red);
            Assert.AreEqual(RedBlackTreeNodeColor.Red, A.Color);

            var tree = new RedBlackTree<int, string>();

            A.FlipColor();
            Assert.AreEqual(RedBlackTreeNodeColor.Black, A.Color);
            A.FlipColor();
            Assert.AreEqual(RedBlackTreeNodeColor.Red, A.Color);
        }
    }
}
