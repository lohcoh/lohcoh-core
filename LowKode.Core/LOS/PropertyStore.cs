using System;
using System.Collections.Generic;
using System.Linq;

namespace LowKode.Core.LOS
{
    /**
     * Maintains a tree of value revisions
     */
    public class PropertyStore
    {
        ValueTreeNode root = new ValueTreeNode();        

        internal ValueTreeNode GetNode(RevisionTag revision)
        {
            var node = root;

            foreach (int branch in revision)
            {
                if (node.Children.Count <= branch)
                    return null;
                var values = node.Children[branch];
                if (values == null)
                    return null;
                node = node.Children[branch];
            }

            return node;
        }

        public void AddValue(RevisionTag revision, object value)
        {
            var node = root;
            foreach (int branch in revision)
            {
                if (node.Children.Count <= branch)
                {
                    var newNode = new ValueTreeNode();
                    node.Children.Insert(branch, newNode);
                    node = newNode;
                }
                else
                {
                    var childNode = node.Children[branch];
                    if (childNode == null)
                    { 
                        childNode = new ValueTreeNode();
                        node.Children.Insert(branch, childNode);
                    }
                    node = childNode;
                }
            }

            if (node.Value != null)
                throw new Exception("Property already Added");

            node.Value = value;
        }
        public void UpdateValue(RevisionTag revision, object value)
        {
            var node = root;
            foreach (int branch in revision)
            {
                if (node.Children.Count <= branch)
                {
                    var newNode = new ValueTreeNode();
                    node.Children.Insert(branch, newNode);
                    node = newNode;
                }
                else
                {
                    var childNode = node.Children[branch];
                    if (childNode == null)
                    {
                        childNode = new ValueTreeNode();
                        node.Children.Insert(branch, childNode);
                    }
                    node = childNode;
                }
            }

            node.Value = value;
        }

        public object GetValue(RevisionTag revision)
        {
            var node = root;
            object value = root.Value;

            foreach (int branch in revision)
            {
                if (node.Children.Count <= branch)
                    return value;
                var values = node.Children[branch];
                if (values == null)
                    return value;
                node = node.Children[branch];
                value = node.Value;
            }

            return value;
        }

        public void RemoveValue(RevisionTag revision)
        {
            var node = root;
            int branch2delete= -1;
            var parent = root;
            foreach (int branch in revision)
            {
                branch2delete = branch;
                if (node.Children.Count <= branch)
                    return;

                var childNode = node.Children[branch];
                if (childNode == null)
                    return;

                node = childNode;
            }

            parent.Children.RemoveAt(branch2delete);            
        }
    }

    public class PropertyStore<TValue> : PropertyStore
    {
        public void AddValue(RevisionTag revision, TValue value) => base.AddValue(revision, value);

        public void UpdateValue(RevisionTag revision, TValue value) => base.AddValue(revision, value);

        public new TValue GetValue(RevisionTag revision) => (TValue)base.GetValue(revision);

        public new void RemoveValue(RevisionTag revision) => base.RemoveValue(revision);
        
    }

    internal class ValueTreeNode
    {
        public object Value;
        public List<ValueTreeNode> Children;
    }

}
