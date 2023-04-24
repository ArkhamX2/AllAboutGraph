﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllAboutGraph.MVC.Model
{
    public class TreeAlgorithms<T> where T : IComparable<T>
    {
        MyTree<T> Tree { get; set; }

        MyBinaryTree<T> BinaryTree { get; set; }

        public TreeAlgorithms(MyTree<T> tree, MyBinaryTree<T> binaryTree)
        {
            Tree = tree; 
            BinaryTree = binaryTree;
        }

        public List<Node<T>> PreOrder(Node<T> root)
        {
            List<Node<T>> order = new List<Node<T>>();
            if (root != null) {

                order.Add(root);

                order.AddRange(PreOrder(root.LeftChild));
                order.AddRange(PreOrder(root.RightSibling));
            }
            return order;
        }
        public List<Node<T>> InOrder(Node<T> root)
        {
            List<Node<T>> order = new List<Node<T>>();
            if (root != null)
            {
                if (root.LeftChild == null && root.RightSibling == null)
                {
                    order.Add(root);
                }
                else
                {
                    order.AddRange(InOrder(root.LeftChild));
                    order.Add(root);
                    order.AddRange(InOrder(root.RightSibling));
                }
            }

            return order;
        }
        public List<Node<T>> PostOrder(Node<T> root)
        {
            List<Node<T>> order = new List<Node<T>>();
            if (root != null)
            {
                order.AddRange(PreOrder(root.LeftChild));
                order.AddRange(PreOrder(root.RightSibling));

                order.Add(root);
            }
            return order;
        }

        public List<MyBinaryTree<T>> BinaryPreOrder(MyBinaryTree<T> root)
        {
            List<MyBinaryTree<T>> order = new List<MyBinaryTree<T>>();
            if (root != null)
            {
                order.Add(root);

                if(root.Left != null)
                {
                    order.AddRange(BinaryPreOrder(root.Left));
                }
                
                if(root.Right != null)
                {
                    order.AddRange(BinaryPreOrder(root.Right));
                }
                
            }
            return order;
        }

        public List<MyBinaryTree<T>> BinaryPreOrder_NotRecursive(MyBinaryTree<T> root)
        {
            List<MyBinaryTree<T>> order = new List<MyBinaryTree<T>>();
            
            Stack<MyBinaryTree<T>> stack = new Stack<MyBinaryTree<T>>();

            MyBinaryTree<T> currentNode = root;
            while (true)
            {
                if(currentNode != null)
                {
                    order.Add(currentNode);
                    stack.Push(currentNode);
                    currentNode = currentNode.Left;
                }
                else
                {
                    if(stack.Count == 0)
                    {
                        return order;
                    }
                    stack.Pop();
                    currentNode = currentNode.Right;
                }
            }
        }

    }
}
