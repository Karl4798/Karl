using System.Collections.Generic;

namespace Dewey_Training.TreeStructure
{

    // TreeNode class used in the tree structure
    public class TreeNode<T>
    {

        public T Value { get; }
        public TreeNode<T> Parent { get; }
        public List<TreeNode<T>> Children { get; }

        public TreeNode(T val, TreeNode<T> parent)
        {
            Value = val;
            Parent = parent;
            Children = new List<TreeNode<T>>();
        }

        public TreeNode<T> Add(T val)
        {
            var node = new TreeNode<T>(val, this);
            Children.Add(node);
            return node;
        }

    }

}
