using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
    public class BSTSet<T> : ISet<T> where T : IComparable
    {
        private BinarySearchTree<T> bst;

        public void Add(T e)
        {
            bst.Add(e);
        }

        public bool Contains(T e)
        {
            return bst.Contains(e);
        }

        public int GetSize()
        {
            return bst.GetSize();
        }

        public bool IsEmpty()
        {
            return bst.IsEmpty();
        }

        public void Remove(T e)
        {
            bst.Remove(e);
        }
    }
}
