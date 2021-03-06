﻿#region copyright
/* 
 * Copyright (c) 2019 (PiJei) 
 * 
 * This file is part of AlgorithmsAndDataStructures project.
 *
 * AlgorithmsAndDataStructures is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * AlgorithmsAndDataStructures is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with AlgorithmsAndDataStructures.  If not, see <http://www.gnu.org/licenses/>.
 */
#endregion
using System;
using System.Collections.Generic;
using AlgorithmsAndDataStructures.DataStructures.BinaryHeaps;
using AlgorithmsAndDataStructures.DataStructures.BinaryHeaps.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AlgorithmsAndDataStructuresTests.DataStructures.BinaryHeaps
{
    /// <summary>
    /// Tests methods in <see cref="MaxBinaryHeap{TKey, TValue}"/> class. 
    /// </summary>
    [TestClass]
    public class MaxBinaryHeapTests
    {
        private readonly KeyValuePair<int, string> _nodeA = new KeyValuePair<int, string>(1, "A");
        private readonly KeyValuePair<int, string> _nodeB = new KeyValuePair<int, string>(20, "B");
        private readonly KeyValuePair<int, string> _nodeC = new KeyValuePair<int, string>(32, "C");
        private readonly KeyValuePair<int, string> _nodeD = new KeyValuePair<int, string>(56, "D");
        private readonly KeyValuePair<int, string> _nodeE = new KeyValuePair<int, string>(5, "E");
        private readonly KeyValuePair<int, string> _nodeF = new KeyValuePair<int, string>(3, "F");
        private readonly KeyValuePair<int, string> _nodeG = new KeyValuePair<int, string>(10, "G");
        private readonly KeyValuePair<int, string> _nodeH = new KeyValuePair<int, string>(100, "H");
        private readonly KeyValuePair<int, string> _nodeI = new KeyValuePair<int, string>(72, "I");

        private List<KeyValuePair<int, string>> _keyValues;

        /// <summary>
        /// Initializes/Resets variables before executing each unit test in this class. 
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _keyValues = new List<KeyValuePair<int, string>> {
                _nodeA,
                _nodeB,
                _nodeC,
                _nodeD,
                _nodeE,
                _nodeF,
                _nodeG,
                _nodeH,
                _nodeI };
        }

        /// <summary>
        /// Tests the correctness of build operation when implemented recursively. 
        /// To visualize in-place Max Binary Heap building process see: <img src = "../Images/Heaps/MaxBinaryHeap-Build.png"/>.
        /// </summary>
        [TestMethod]
        public void BuildHeap_Recursively()
        {
            var heap = new MaxBinaryHeap<int, string>(_keyValues);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);

            Assert.AreEqual(9, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));
        }

        /// <summary>
        /// Tests the correctness of Build operation when implemented iteratively. 
        /// To visualize in-place Max Binary Heap building process see: <img src = "../Images/Heaps/MaxBinaryHeap-Build.png"/>.
        /// </summary>
        [TestMethod]
        public void BuildHeap_Itratively()
        {
            var heap = new MaxBinaryHeap<int, string>(_keyValues);
            heap.BuildHeap_Iteratively(heap.HeapArray.Count);

            Assert.AreEqual(9, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(_keyValues.Count, heap));
        }

        /// <summary>
        /// Tests the correctness of removing root of the heap. Removes root several times until no member in tree remains.
        /// To visualize the steps in this test method see: <img src = "../Images/Heaps/MaxBinaryHeap-TryRemoveRoot.png"/>.
        /// </summary>
        [TestMethod]
        public void TryRemoveRoot_RemoveRoot_SeveralTimes_ExpectDescendingOrderInResults()
        {
            var heap = new MaxBinaryHeap<int, string>(_keyValues);
            heap.BuildHeap_Recursively(heap.HeapArray.Count);

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue1, heap.HeapArray.Count));
            Assert.AreEqual(100, maxValue1.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(8, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue2, heap.HeapArray.Count));
            Assert.AreEqual(72, maxValue2.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(7, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue3, heap.HeapArray.Count));
            Assert.AreEqual(56, maxValue3.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(6, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue4, heap.HeapArray.Count));
            Assert.AreEqual(32, maxValue4.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(5, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue5, heap.HeapArray.Count));
            Assert.AreEqual(20, maxValue5.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(4, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue6, heap.HeapArray.Count));
            Assert.AreEqual(10, maxValue6.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(3, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue7, heap.HeapArray.Count));
            Assert.AreEqual(5, maxValue7.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(2, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue8, heap.HeapArray.Count));
            Assert.AreEqual(3, maxValue8.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(1, heap));

            Assert.IsTrue(heap.TryRemoveRoot(out KeyValuePair<int, string> maxValue9, heap.HeapArray.Count));
            Assert.AreEqual(1, maxValue9.Key);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(0, heap));
        }

        /// <summary>
        /// Tests the correctness of insert operation. 
        /// To visualize the steps in this test method see: <img src = "../Images/Heaps/MaxBinaryHeap-Insert.png"/>.
        /// </summary>
        [TestMethod]
        public void Insert_SeveralValues_ExpectCorrectMaxBinaryHeapAfterEachInsert()
        {
            var heap = new MaxBinaryHeap<int, string>(new List<KeyValuePair<int, string>> { });

            heap.Insert(_nodeA, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(1, heap));

            heap.Insert(_nodeB, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(2, heap));

            heap.Insert(_nodeC, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(3, heap));

            heap.Insert(_nodeD, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(4, heap));

            heap.Insert(_nodeE, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(5, heap));

            heap.Insert(_nodeF, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(6, heap));

            heap.Insert(_nodeG, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(7, heap));

            heap.Insert(_nodeH, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(8, heap));

            heap.Insert(_nodeI, heap.HeapArray.Count);
            Assert.IsTrue(HasMaxOrderPropertyForHeap(9, heap));
        }

        /// <summary>
        /// Checks whether the element at the given index follows heap properties. 
        /// Checking the MaxHeap ordering (node relations) for the node at the given index, to make sure the correct relations between the node and its parent and children holds. 
        /// </summary>
        /// <typeparam name="TKey">Type of the keys stored in the heap. </typeparam>
        /// <typeparam name="TValue">Type of the values stored in the heap. </typeparam>
        /// <param name="heap">A max binary heap. </param>
        /// <param name="nodeIndex">Index of a heap node in heap array. </param>
        /// <returns></returns>
        public static bool HasMaxOrderPropertyForNode<TKey, TValue>(BinaryHeapBase<TKey, TValue> heap, int nodeIndex) where TKey : IComparable<TKey>
        {
            int leftChildIndex = heap.GetLeftChildIndexInHeapArray(nodeIndex);
            int rightChildIndex = heap.GetRightChildIndexInHeapArray(nodeIndex);
            int parentindex = heap.GetParentIndex(nodeIndex);

            if (leftChildIndex >= 0 && leftChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex].Key.CompareTo(heap.HeapArray[leftChildIndex].Key) >= 0);
            }
            if (rightChildIndex >= 0 && rightChildIndex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex].Key.CompareTo(heap.HeapArray[rightChildIndex].Key) >= 0);
            }
            if (parentindex >= 0 && parentindex < heap.HeapArray.Count)
            {
                Assert.IsTrue(heap.HeapArray[nodeIndex].Key.CompareTo(heap.HeapArray[parentindex].Key) <= 0);
            }
            return true;
        }

        /// <summary>
        /// Checks whether the heap is a proper Max heap. 
        /// </summary>
        /// <typeparam name="TKey">Type of the keys stored in the heap. </typeparam>
        /// <typeparam name="TValue">Type of the values stored in the heap. </typeparam>
        /// <param name="arraySize">Size of the heap array. </param>
        /// <param name="heap">A Max binary heap. </param>
        /// <returns>True if the heap is a proper Max binary heap, and false otherwise. </returns>
        public static bool HasMaxOrderPropertyForHeap<TKey, TValue>(int arraySize, MaxBinaryHeap<TKey, TValue> heap) where TKey : IComparable<TKey>
        {
            for (int i = 0; i < arraySize; i++)
            {
                HasMaxOrderPropertyForNode(heap, i);
            }
            return true;
        }
    }
}
