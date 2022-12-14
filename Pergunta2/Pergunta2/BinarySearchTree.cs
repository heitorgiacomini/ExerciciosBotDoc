namespace Pergunta2
{

    public class BinarySearchTree
    {
        public class Node
        {
            public int value { set; get; }
            public string text { set; get; }
            public Node leftChild { set; get; }
            public Node rightChild { set; get; }

            public Node(int value, string text)
            {
                this.value = value;
                this.text = text;
            }

            //to debug easy and see the values:
            public override string ToString()
            {
                return "Node = " + value;
            }
        }

        public Node Root { get; set; }

        public void Insert(int value, string text)
        {
            var node = new Node(value, text);

            //two cases: if the tree is empty or is not
            if (Root == null)
            {
                Root = node;
                return;
            }

            var current = Root;
            while (true)
            {
                if (value < current.value)    //we should go to the left subtree
                {
                    if (current.leftChild == null)
                    {
                        current.leftChild = node;
                        break;
                    }
                    current = current.leftChild;
                }
                else
                {
                    if (current.rightChild == null)
                    {
                        current.rightChild = node;
                        break;
                    }
                    current = current.rightChild;
                }
            }
        }

        public bool Find(int value)
        {
            var current = Root;

            while (current != null)
            {
                if (value < current.value)
                    current = current.leftChild;
                else if (value > current.value)
                    current = current.rightChild;
                else
                    return true;
            }

            return false;
        }

        public bool FindAndPrint(int value)
        {
            var current = Root;

            while (current != null)
            {
                Console.Write(" -> " + current.text);
                if (value < current.value)
                    current = current.leftChild;
                else if (value > current.value)
                    current = current.rightChild;
                else
                    return true;
            }

            return false;
        }

        #region TraversePreOrder
        //Root-Left-Right
        public void TraversePreOrder()
        {
            TraversePreOrder(Root);
        }

        private void TraversePreOrder(Node root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.value);
            TraversePreOrder(root.leftChild);
            TraversePreOrder(root.rightChild);
        }
        #endregion

        #region TraverseInOrder
        //Left-Root-Right
        public void TraverseInOrder()
        {
            TraverseInOrder(Root);
        }

        private void TraverseInOrder(Node root)
        {
            if (root == null)
                return;

            TraverseInOrder(root.leftChild);
            Console.WriteLine(root.value);
            TraverseInOrder(root.rightChild);
        }
        #endregion

        #region TraversePostOrder
        //Left-Right-Root
        public void TraversePostOrder()
        {
            TraversePostOrder(Root);
        }

        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;

            TraversePostOrder(root.leftChild);
            TraversePostOrder(root.rightChild);
            Console.WriteLine(root.value);
        }
        #endregion

        #region EqualityChecking
        public bool Equals(BinarySearchTree other)
        {
            if (other == null)
                return false;

            return Equals(Root, other.Root);
        }

        private bool Equals(Node first, Node second)
        {
            if (first == null && second == null)
                return true;

            if (first != null && second != null)
                return first.value == second.value
                    && Equals(first.leftChild, second.leftChild)
                    && Equals(first.rightChild, second.rightChild);

            return false;
        }
        #endregion

        #region Height 
        public int Height()
        {
            return Height(Root);
        }

        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (root.leftChild == null && root.rightChild == null) //base condition -> bottom of the recursion ->leaf
                return 0;

            return 1 + Math.Max(   //the biggest between the height of the left subtree or the right subtree + 1 (for the current node)
                Height(root.leftChild),
                Height(root.rightChild));
        }
        #endregion

        #region DepthToNode -> Get Nodes At Distance

        public List<int> GetNodesAtDistance(int distance)
        {
            var list = new List<int>();
            GetNodesAtDistance(Root, distance, list);
            return list;
        }

        private void GetNodesAtDistance(Node root, int distance, List<int> list)
        {
            if (root == null)
                return;

            if (distance == 0)
            {
                list.Add(root.value);
                return;
            }

            GetNodesAtDistance(root.leftChild, distance - 1, list);
            GetNodesAtDistance(root.rightChild, distance - 1, list);
        }

        #endregion

        #region LevelOrderTraversal       

        public void TraverseLevelOrder()
        {
            for (int i = 0; i < Height(); i++)
            {
                var list = GetNodesAtDistance(i);
                foreach (var item in GetNodesAtDistance(i))
                {
                    Console.WriteLine(item);
                }
            }
        }

        #endregion


        #region SizeOfTheTree

        public int Size()
        {
            return Size(Root);
        }

        private int Size(Node root)
        {
            if (root == null)
                return 0;

            if (IsLeaf(root))
                return 1;

            return 1 + Size(root.leftChild) + Size(root.rightChild);
        }

        private bool IsLeaf(Node node)
        {
            return node.leftChild == null && node.rightChild == null;
        }

        #endregion

        #region CountOfTheLeaves
        public int CountLeaves()
        {
            return CountLeaves(Root);
        }

        private int CountLeaves(Node root)
        {
            if (root == null)
                return 0;

            if (IsLeaf(root))
                return 1;

            return CountLeaves(root.leftChild) + CountLeaves(root.rightChild);
        }

        #endregion

        #region IsBalanced

        public bool IsBalanced()
        {
            return IsBalanced(Root);
        }

        private bool IsBalanced(Node root)
        {
            if (root == null)
                return true;

            var coef = Height(root.leftChild) - Height(root.rightChild);

            return Math.Abs(coef) <= 1 &&
                    IsBalanced(root.leftChild) &&
                    IsBalanced(root.rightChild);
        }

        #endregion



        #region ValidatingBST
        // we should check it a bynatry tree is a bynary Serac tree
        // 1st  way - using recursion - for every node we visit it's subtrees -> if all the values are in the correct intervals, we are going to the next subtree
        // 1st way is slow, because we are visiting every node multiply times

        //2nd way - to traverse the tree and for every node we checks if the value of this node is in the correct interval

        public bool IsBinarySearchTree()
        {
            return IsBinarySearchTree(Root, Int32.MinValue, Int32.MaxValue);
        }

        private bool IsBinarySearchTree(Node root, int min, int max)
        {
            if (root == null)
                return true;

            if (root.value < min || root.value > max)
                return false;

            return
                IsBinarySearchTree(Root.leftChild, min, Root.value - 1)
                && IsBinarySearchTree(Root.rightChild, Root.value + 1, max);
        }

        #endregion
    }
}
