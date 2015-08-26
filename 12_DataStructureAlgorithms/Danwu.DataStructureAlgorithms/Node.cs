using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.DataStructureAlgorithms
{
    /// <summary>
    /// 节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Node<T>
    {

        private T _data;
        private Node<T> _next;

        public Node()
            : this(default(T))
        { }
        public Node(T data)
            : this(data, null)
        { }
        public Node(T data, Node<T> next)
        {
            this.Data = data;
            this.Next = next;
        }


        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public Node<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }
    }
}
