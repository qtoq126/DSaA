using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
    /// <summary>
    /// 二分搜索树BST
    /// 不包含重复元素的二分搜索树
    /// </summary>
    public class BinarySearchTree
    {
        private class Node
        {
            public int e;
            public Node left;
            public Node right;

            public Node(int e)
            {
                this.e = e;
                left = null;
                right = null;
            }
        }

        private Node root;
        private int size;

        public BinarySearchTree()
        {
            root = null;
            size = 0;
        }

        public int Size() => size;

        public bool IsEmpty() => size == 0;

        int i = 0;


        /// <summary>
        /// 添加元素
        /// </summary>
        public void Add(int e)
        {
            root = Add(root, e);
        }

        /// <summary>
        /// 返回插入新节点后树的根
        /// </summary>
        private Node Add(Node node, int e)
        {
            if (node == null)
            {
                size++;
                return new Node(e);
            }

            if (e.CompareTo(node.e) < 0)
            {
                node.left = Add(node.left, e);
            }
            else if (e.CompareTo(node.e) > 0)
            {
                node.right = Add(node.right, e);
            }

            return node;
        }

        public void Add1(int e)
        {
            if (root == null)
            {
                root = new Node(e);
                size++;
            }
            else
            {
                Add1(root, e);
            }
        }

        /// <summary>
        /// 以node为根的二分搜索树中插入元素e，递归算法
        /// 初级写法
        /// </summary>
        private void Add1(Node node, int e)
        {
            if (e.Equals(node.e))
            {
                return;
            }
            else if (e.CompareTo(node.e) < 0 && node.left == null)
            {
                node.left = new Node(e);
                size++;
                return;
            }
            else if (e.CompareTo(node.e) > 0 && node.right == null)
            {
                node.right = new Node(e);
                size++;
                return;
            }
            if (e.CompareTo(node.e) < 0)
            {
                Add1(node.left, e);
            }
            else
            {
                Add1(node.right, e);
            }
        }

        /// <summary>
        /// 非递归写法
        /// </summary>
        public void Add2(int e)
        {
            if (root == null)
            {
                root = new Node(e);
                size++;
            }
            var node = root;
            while (node != null)
            {
                if (e.CompareTo(node.e) < 0)
                {
                    if (node.left == null)
                    {
                        node.left = new Node(e);
                        size++;
                        return;
                    }
                    else
                    {
                        node = node.left;
                    }
                }
                else if (e.CompareTo(node.e) > 0)
                {
                    if (node.right == null)
                    {
                        node.right = new Node(e);
                        size++;
                        return;
                    }
                    else
                    {
                        node = node.right;
                    }
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 查找
        /// </summary>
        public bool Contains(int e)
        {
            return Contains(root, e);
        }

        private bool Contains(Node node, int e)
        {
            if (node == null)
            {
                return false;
            }

            if (e.Equals(node.e))
            {
                return true;
            }
            else if (e.CompareTo(node.e) < 0)
            {
                return Contains(node.left, e);
            }
            else
            {
                return Contains(node.right, e);
            }
        }

        /// <summary>
        /// 前序遍历
        /// 先访问该节点，再访问该节点的左子树，左子树遍历完了后再遍历右子树
        /// 深度优先遍历：一扎到底
        /// </summary>
        public void PreOrder()
        {
            PreOrder(root);
        }

        private void PreOrder(Node node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.e);
            PreOrder(node.left);
            PreOrder(node.right);
        }

        /// <summary>
        /// 前序遍历：非递归写法
        /// 栈的另一个应用
        /// </summary>
        public void PreOrderByStack()
        {
            Stack<Node> ts = new Stack<Node>();
            Node node = root;
            ts.Push(node);
            while (ts.Count != 0)
            {
                node = ts.Pop();
                Console.WriteLine(node.e);

                // 先压右孩子再压左孩子，保证左孩子先被遍历到
                if (node.right != null)
                {
                    ts.Push(node.right);
                }
                if (node.left != null)
                {
                    ts.Push(node.left);
                }
            }
        }

        /// <summary>
        /// 中序遍历 -> 排序后的结果
        /// 先访问该节点的左子树，再访问节点，最后访问节点的右子树
        /// 深度优先遍历
        /// </summary>
        public void InOrder()
        {
            InOrder(root);
        }

        private void InOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            InOrder(node.left);
            i++;
            Console.WriteLine(node.e + " " + i);
            InOrder(node.right);
        }

        /// <summary>
        /// 后续遍历（内存释放）
        /// 先访问该节点的左子树，再访问该节点的右子树，最后访问该节点
        /// 深度优先遍历
        /// </summary>
        public void PostOrder()
        {
            PostOrder(root);
        }

        private void PostOrder(Node node)
        {
            if (node == null)
            {
                return;
            }
            PostOrder(node.left);
            PostOrder(node.right);
            Console.WriteLine(node.e);
        }

        /// <summary>
        /// 广度优先遍历
        /// 队列的另一个应用
        /// 可以方便用于搜索
        /// </summary>
        public void LevelOrder()
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count != 0)
            {
                var cur = queue.Dequeue();
                Console.WriteLine(cur.e);

                // 先入队左孩子再入队右孩子，保证左孩子先被遍历到（先进先出）
                if (cur.left != null)
                {
                    queue.Enqueue(cur.left);
                }
                if (cur.right != null)
                {
                    queue.Enqueue(cur.right);
                }
            }
        }

        /// <summary>
        /// 找到最小元素
        /// </summary>
        public int GetMin()
        {
            if (size == 0)
            {
                throw new ArgumentException("BST is empty!");
            }
            return GetMin(root).e;
        }

        private Node GetMin(Node node)
        {
            if (node.left == null)
            {
                return node;
            }
            return GetMin(node.left);
        }

        /// <summary>
        /// 找到最大元素
        /// </summary>
        public int GetMax()
        {
            if (size == 0)
            {
                throw new ArgumentException("BST is empty!");
            }
            return GetMax(root).e;
        }

        private Node GetMax(Node node)
        {
            if (node.right == null)
            {
                return node;
            }
            return GetMax(node.right);
        }

        /// <summary>
        /// 删除最小元素
        /// </summary>
        public int RemoveMin()
        {
            var m = GetMin(); // 先找到最小值
            root = RemoveMin(root);
            return m;
        }

        /// <summary>
        /// 返回删除节点后新的二分搜索树的根
        /// </summary>
        private Node RemoveMin(Node node)
        {
            if (node.left == null)
            {
                var rightNode = node.right;
                node.right = null;
                size--;
                return rightNode;
            }
            node.left = RemoveMin(node.left);
            return node;
        }

        /// <summary>
        /// 删除元素为e的节点
        /// </summary>
        public void Remove(int e)
        {
            root = Remove(root, e);
        }

        private Node Remove(Node node, int e)
        {
            if (node == null)
            {
                return null;
            }

            if (e.CompareTo(node.e) < 0)
            {
                node.left = Remove(node.left, e);
                return node;
            }
            else if(e.CompareTo(node.e) > 0)
            {
                node.right = Remove(node.right, e);
                return node;
            }
            else // e == node.e
            {
                if (node.left == null)
                {
                    var rightNode = node.right;
                    node.right = null;
                    size--;
                    return rightNode;
                }
                else if (node.right == null)
                {
                    var leftNode = node.left;
                    node.left = null;
                    size--;
                    return leftNode;
                }
                else // 待删除节点左右子树均不为空
                {
                    var successor = GetMin(node.right); // 找到比待删除节点大的最小节点，即待删除节点右子树的最小节点（后继，也可以找前驱）
                    successor.right = RemoveMin(node.right); // 返回的是删除了最小节点的根节点
                    successor.left = node.left;  // 将该节点替换掉删除的节点
                    node.left = node.right = null;
                    return successor;
                }
            }
        }

        /// <summary>
        /// 比e大的最小值
        /// </summary>
        public int Ceil(int e)
        {
            var ceilNode = Ceil(root, e);
            return ceilNode.e;
        }

        private Node Ceil(Node node, int e)
        {
            if (node == null)
            {
                return null;
            }
            if (e == node.e)
            {
                return GetMin(node.right); // 找到以比e大的根节点的树的最小值
            }
            else if (node.e < e)
            {
                return Ceil(node.right, e);
            }

            var tempNode = Ceil(node.left, e);
            if (tempNode != null)
            {
                return tempNode;
            }
            return node;
        }

        //public int Rank(int target)
        //{
        //    return Rank(root, target);
        //}

        //private int Rank(Node node, int target)
        //{
            
        //}

        /// <summary>
        /// 最小元素
        /// 非递归
        /// </summary>
        public int Minimum1()
        {
            if (size == 0)
            {
                throw new ArgumentException("BST is empty!");
            }
            Node cur = root;
            while (cur.left != null)
            {
                cur = cur.left;
            }
            return cur.e;
        }

        /// <summary>
        /// 重载ToString()
        /// </summary>
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            GenerateBSTString(root, 0, res);
            return res.ToString();
        }

        private void GenerateBSTString(Node node, int depth, StringBuilder res)
        {
            if (node == null)
            {
                res.Append(DepthString(depth) + "null\n");
                return;
            }
            res.Append(DepthString(depth) + node.e + "\n");
            GenerateBSTString(node.left, depth + 1, res);
            GenerateBSTString(node.right, depth + 1, res);
        }

        private string DepthString(int depth)
        {
            var res = new StringBuilder();
            for (int i = 0; i < depth; i++)
            {
                res.Append("--");
            }
            return res.ToString();
        }
    }
}
