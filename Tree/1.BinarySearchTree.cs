using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructure.Tree
{
    /// <summary>
    /// 二分搜索树BST
    /// 不包含重复元素的二分搜索树
    /// 可以用于集合Set：SortSet(可去重)
    /// O(h)：为树的高度 -> O(logn)
    /// 最差为O(n)，跟链表相同，可用平衡二叉树解决该问题
    /// </summary>
    public class BinarySearchTree<T> where T : IComparable
    {
        public class Node
        {
            public T e;
            public Node left;
            public Node right;

            /// <summary>
            /// 返回以node为根节点的树一共有多少个元素
            /// </summary>
            private int _nodeSize;
            public int NodeSize
            {
                get
                {
                    _nodeSize = 0;
                    return GetNodeSize(this);
                }
            }

            private int GetNodeSize(Node node)
            {
                if (node == null)
                {
                    return 0;
                }
                else
                {
                    _nodeSize++;
                }
                GetNodeSize(node.left);
                GetNodeSize(node.right);
                return _nodeSize;
            }

            /// <summary>
            /// 节点的深度
            /// </summary>
            public int Depth
            {
                get; set;
            }

            public Node(T e)
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

        public int GetSize() => size;

        public bool IsEmpty() => size == 0;

        /// <summary>
        /// 添加元素
        /// </summary>
        public void Add(T e)
        {
            root = Add(root, e);
        }

        /// <summary>
        /// 返回插入新节点后树的根
        /// </summary>
        private Node Add(Node node, T e)
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

        public void Add1(T e)
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
        private void Add1(Node node, T e)
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
        public void Add2(T e)
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
        public bool Contains(T e)
        {
            return Contains(root, e);
        }

        private bool Contains(Node node, T e)
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
        /// 深度优先遍历
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
        /// 深度优先遍历
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
            Console.WriteLine(node.e);
            InOrder(node.right);
        }

        /// <summary>
        /// 深度优先遍历
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
        public T GetMin()
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
        public T GetMax()
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
        public T RemoveMin()
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
        public void Remove(T e)
        {
            root = Remove(root, e);
        }

        private Node Remove(Node node, T e)
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
        public T Ceil(T e)
        {
            var ceilNode = Ceil(root, e);
            return ceilNode.e;
        }

        private Node Ceil(Node node, T e)
        {
            if (node == null)
            {
                return null;
            }
            if (e.Equals(node.e))
            {
                return GetMin(node.right); // 找到以比e大的根节点的树的最小值
            }
            else if (node.e.CompareTo(e) < 0)
            {
                return Ceil(node.right, e);
            }
            else
            {
                return Ceil(node.left, e);
            }
        }

        /// <summary>
        /// 获取某个数的排位
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public int Rank(T key)
        {
            return Rank(root, key);
        }

        private int Rank(Node node, T key)
        {
            if (node == null)
            {
                return 0;
            }

            if (key.CompareTo(node.e) < 0)
            {
                return Rank(node.left, key);
            }
            else
            {
                if (node.left == null)
                {
                    return Rank(node.right, key) + 1;
                }
                return Rank(node.right, key) + node.left.NodeSize + 1;
            }
        }

        /// <summary>
        /// 获取排位为rank位的数
        /// </summary>
        public T Select(int rank)
        {
           return Select1(root, rank);
        }

        private T Select(Node node, int rank)
        {
            T e = default;
            while (node != null)
            {
                int rootRank = Rank(node.e);
                if (rank < rootRank)
                {
                    node = node.left;
                }
                else if (rank > rootRank)
                {
                    node = node.right;
                }
                else
                {
                    e = node.e;
                    break;
                }
                
            }
            return e;
        }

        private T Select1(Node node, int rank)
        {
            if (node == null)
            {
                return default;
            }
            int curRank = Rank(node.e);
            if (rank < curRank)
            {
                return Select1(node.left, rank);
            }
            else if (rank > curRank)
            {
                return Select1(node.right, rank);
            }
            else
            {
                return node.e;
            }
        }

        /// <summary>
        /// 返回节点的深度
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public void Depth()
        {
            Depth(root, 0);
        }

        private void Depth(Node node, int d)
        {
            if (node == null)
            {
                return;
            }
            node.Depth = d;
            Depth(node.left, d + 1);
            Depth(node.right, d + 1);
        }

        /// <summary>
        /// 最小元素
        /// 非递归
        /// </summary>
        public T Minimum1()
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
