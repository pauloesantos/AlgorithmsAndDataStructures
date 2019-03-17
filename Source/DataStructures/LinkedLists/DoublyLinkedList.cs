﻿/* 
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

using System;
using CSFundamentals.Styling;

//TODO: Should I have a build method as well?
// TODO: Could also call Append, with a node, after all this class does not have an insert method anyways, ...
// TODO Insert can make sense for sorted list, because it is then similar to binary search tree, there is only one suitable location to insert, ...
// But with a normal linked list there can be as many locations for inserts, ...
//TODO I could have an Insert method that calls Append inside, or prepend, prepend will be O(1), and so will be Append: O(1).  just for the sake of Interface. //

namespace CSFundamentals.DataStructures.LinkedLists
{
    /// <summary>
    /// Implements a bi-directional/doubly linked list (aka. DLL). 
    /// </summary>
    /// <typeparam name="T">Is the type of the keys in the list. </typeparam>
    public class DoublyLinkedList<T> where T : IComparable<T>
    {
        public DoublyLinkedListNode<T> Head = null;
        public DoublyLinkedListNode<T> Tail = null;

        public DoublyLinkedList()
        {

        }

        public DoublyLinkedList(DoublyLinkedListNode<T> head)
        {
            Head = head;
            Tail = head;
        }

        /// <summary>
        /// Computes the length of the linked list. Length is the number of the nodes in the list.
        /// </summary>
        /// <returns>Number of nodes in the list. </returns>
        [TimeComplexity(Case.Best, "O(n)")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public int Count()
        {
            int length = 0;
            var current = Head;
            while (current != null)
            {
                length++;
                current = current.Next;
            }
            return length;
        }

        /// <summary>
        /// Inserts a new node with <paramref name="newValue"/> as its value in the list after the node containing <paramref name="Value"/> as its value. If a node with <paramref name="Value"/> does not exist, fails the insert and returns false. 
        /// </summary>
        /// <param name="value">The value of the node, that <paramref name="newValue"/> will be inserted after.</param>
        /// <param name="newValue">The value of the new node that is meant to be inserted in the list. </param>
        /// <returns>True in case the operation is successful, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "Inserting after the first node in the list.")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public bool InsertAfter(T value, T newValue)
        {
            var node = Search(value);
            if (node == null)
            {
                return false;
            }

            return InsertAfter(node, newValue);
        }

        /// <summary>
        /// Inserts a new node with <paramref name="newValue"/> as its value in the list after the given node <paramref name="node"/>.
        /// </summary>
        /// <param name="node">The node that a new node with value <paramref name="newValue"/> will be inserted after.</param>
        /// <param name="newValue">The value of the new node that is meant to be inserted in the list. </param>
        /// <returns>True in case the operation is successful</returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(1)")]
        [TimeComplexity(Case.Average, "O(1)")]
        public bool InsertAfter(DoublyLinkedListNode<T> node, T newValue)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(newValue);
            newNode.Previous = node;
            newNode.Next = node?.Next;
            node.Next = newNode;

            if (newNode.Next == null)
            {
                Tail = newNode;
            }
            else
            {
                newNode.Next.Previous = newNode;
            }

            if (newNode.Previous == null)
            {
                Head = newNode;
            }
            return true;
        }

        /// <summary>
        /// Inserts a new node with <paramref name="newValue"/> as its value in the list before the node containing <paramref name="Value"/> as its value. If a node with <paramref name="Value"/> does not exist, fails the insert and returns false. 
        /// </summary>
        /// <param name="value">The value of the node, that <paramref name="newValue"/> will be inserted before.</param>
        /// <param name="newValue">The value of the new node that is meant to be inserted in the list. </param>
        /// <returns>True in case the operation is successful, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "Inserting before the first node in the list.")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public bool InsertBefore(T value, T newValue)
        {
            var node = Search(value);
            if (node == null)
            {
                return false;
            }
            return InsertBefore(node, newValue);
        }

        /// <summary>
        /// Inserts a new node with <paramref name="newValue"/> as its value in the list before the given node.
        /// </summary>
        /// <param name="node">The node that a new node with value <paramref name="newValue"/> will be inserted before.</param>
        /// <param name="newValue">The value of the new node that is meant to be inserted in the list. </param>
        /// <returns>True in case the operation is successful. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(1)")]
        [TimeComplexity(Case.Average, "O(1)")]
        public bool InsertBefore(DoublyLinkedListNode<T> node, T newValue)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(newValue);
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous = newNode;
            if (newNode.Previous == null)
            {
                Head = newNode;
            }
            else
            {
                newNode.Previous.Next = newNode;
            }
            if (newNode.Next == null)
            {
                Tail = newNode;
            }
            return true;
        }

        /// <summary>
        /// Adds a new node to the end of the list. Changing the Tail node.
        /// </summary>
        /// <param name="newValue">The value of the new node that is meant to be appended in the list. </param>
        /// <returns>True in case the operation is successful, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(1)")]
        [TimeComplexity(Case.Average, "O(1)")]
        public bool Append(T newValue)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(newValue);
            if (Tail != null)
            {
                Tail.Next = newNode;
            }

            newNode.Previous = Tail;
            Tail = newNode;

            if (Head == null)
            {
                Head = newNode;
            }
            return true;
        }

        /// <summary>
        /// Ands a new node to the beginning of the list. Changing the Head node. 
        /// </summary>
        /// <param name="newValue">The value of the new node that is meant to be prepended to the list. </param>
        /// <returns>True in case operation is successful, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)")]
        [TimeComplexity(Case.Worst, "O(1)")]
        [TimeComplexity(Case.Average, "O(1)")]
        public bool PrePend(T newValue)
        {
            DoublyLinkedListNode<T> newNode = new DoublyLinkedListNode<T>(newValue);
            if (Head != null)
            {
                Head.Previous = newNode;
            }

            newNode.Next = Head;
            Head = newNode;
            if (Tail == null)
            {
                Tail = newNode;
            }
            return true;
        }

        /// <summary>
        /// Searches for the specified <paramref name="Value"/>. Since there is no assumption about the order of the values in the list, starts from the Head node and performs a linear search.
        /// </summary>
        /// <param name="value">Is the value of the node that is being searched for.</param>
        /// <returns>The node containing <paramref name="value"/>, and if no node is found throws an exception. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "The first node (Head) contains the value.")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public DoublyLinkedListNode<T> Search(T value)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0)
                {
                    return currentNode;
                }
                else
                {
                    currentNode = currentNode.Next;
                }
            }
            throw new NotFoundException($"Value {value.ToString()} does not exist in the list.");
        }

        /// <summary>
        /// Deletes a node from the list with the given value. If no node with the <paramref name="value"/> is found fails the operation and returns false.
        /// </summary>
        /// <param name="value">Is the value of the node to be deleted. </param>
        /// <returns>True in case the operation is successful, and false otherwise. </returns>
        [TimeComplexity(Case.Best, "O(1)", When = "The first node (Head) contains the value.")]
        [TimeComplexity(Case.Worst, "O(n)")]
        [TimeComplexity(Case.Average, "O(n)")]
        public bool Delete(T value)
        {
            var currentNode = Head;
            while (currentNode != null)
            {
                if (currentNode.Value.CompareTo(value) == 0) /* If the key is found. */
                {
                    if (currentNode.Previous == null && currentNode.Next == null) /* This means the list has only one node.*/
                    {
                        Head = null;
                        Tail = null;
                        return true;
                    }
                    else if (currentNode.Previous == null) /* This means we are deleting the head. */
                    {
                        Head = Head.Next;
                        Head.Previous = null;
                        return true;
                    }
                    else if (currentNode.Next == null) /*This means we are deleting the tail.*/
                    {
                        Tail = Tail.Previous;
                        Tail.Next = null;
                        return true;
                    }
                    else /* Node is in the middle and has not-null next and previous nodes. */
                    {
                        currentNode.Previous.Next = currentNode.Next;
                        currentNode.Next.Previous = currentNode.Previous;
                        return true;
                    }
                }
                else /* Keep moving forward in the list. */
                {
                    currentNode = currentNode.Next;
                }
            }
            return false;
        }
    }
}
