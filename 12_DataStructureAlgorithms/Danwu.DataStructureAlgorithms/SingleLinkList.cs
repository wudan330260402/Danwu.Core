using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.DataStructureAlgorithms
{
    /// <summary>
    /// 单链表
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingleLinkList<T>:ILinearList<T>
    {
        private Node<T> _head;

        public SingleLinkList() {
            _head = null;
        }

        #region ILinearList Members

        public virtual int GetLength()
        {
            if (_head == null) return 0;

            Node<T> node = _head;
            Int32 len = 0;
            while (node.Next != null) {
                len++;
                node = node.Next;
            }
            return len;
        }
        public virtual bool IsEmpty()
        {
            return _head == null;
        }
        public virtual bool IsFull()
        {
            return false;
        }

        public virtual void Append(T data)
        {
            Node<T> item = new Node<T>(data);
            if (_head == null) {
                _head = item;
                return;
            }

            Node<T> node = _head;
            while (item.Next != null) {
                node = item.Next;
            }
            node.Next = item;
        }
        public virtual void Insert(T data, int index)
        {
            if (index < 0 || (IsEmpty() && index > 0)) throw new Exception("索引越界");

            Node<T> item = new Node<T>(data);
            if (index == 0) { 
                item.Next = _head;
                _head = item;
            }

            Node<T> node = _head;
            Int32 len = 0;
            while (node.Next != null && len < index) {
                node = node.Next;
                len++;
            }
            if (len != index) throw new Exception("索引越界");
            item.Next = node.Next;
            node.Next = item;
        }
        public virtual void Remove(T data)
        {
            Node<T> item = new Node<T>(data);
            if (_head == null) throw new Exception("列表不包含任何数据");
            var index = Location(data);

            if (index == -1) throw new Exception("没有找到对应数据");
            RemoveAt(index);
        }
        public virtual T RemoveAt(int index)
        {
            var t = default(T);
            if (_head == null) throw new Exception("列表为空");
            if (index < 0) throw new Exception("索引越界");

            if (index == 0) {
                t = _head.Data;
                _head = _head.Next;
                return t;
            }

            var node = _head;
            var prevNode = new Node<T>();
            var i = 0;
            while (node.Next != null && i < index) {
                prevNode = node;
                node = node.Next;
                i++;
            }
            if (i == index) {
                prevNode.Next = node.Next;
                t = node.Data;
            }

            return t;
        }

        public virtual T GetElem(int index)
        {
            var t = default(T);
            if (_head == null) throw new Exception("列表为空");
            if (index < 0) throw new Exception("索引越界");

            if (index == 0) return _head.Data;

            var node = _head;
            var i=0;
            while (node.Next != null && i < index) {
                node = node.Next;
                i++;
            }
            if (i == index) return node.Data;
            return t;
        }
        public virtual int Location(T data)
        {
            if (_head == null) throw new Exception("列表不包含任何数据");
            if (_head.Data.Equals(data)) return 0;

            Node<T> node = _head;
            var index = 1;
            while (node.Next != null)
            {
                var nextNode = node.Next;
                if (nextNode.Data.Equals(data))
                {
                    node.Next = nextNode.Next;
                    return index;
                }
                index++;
            }
            return -1;
        }

        public virtual void Clear()
        {
            _head = null;
        }

        #endregion
    }
}
