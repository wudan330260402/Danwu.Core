using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.DataStructureAlgorithms
{
    /// <summary>
    /// 顺序栈
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SeqStack<T> : IStack<T>
    {
        private Int32 _maxSize;     //最大容量
        private Int32 _top;         //栈顶位置，最开始为-1
        private T[] _data;          //数据容器

        public SeqStack(Int32 maxSize) {
            this._maxSize = maxSize;
            _data = new T[_maxSize];
            _top = -1;
        }

        #region IStack Members

        /// <summary>
        /// 获取栈的长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return _top + 1;
        }
        /// <summary>
        /// 栈是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return _top == -1;
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            if (!IsFull()) {
                _data[_top++] = item;
            }
        }
        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            var t = default(T);
            if (!IsEmpty()) {
                t = _data[_top];
                _top--;
            }

            return t;
        }
        /// <summary>
        /// 获取栈顶元素
        /// </summary>
        /// <returns></returns>
        public T GetTop()
        {
            var t = default(T);
            if (!IsEmpty()) t = _data[_top];

            return t;
        }
        /// <summary>
        /// 清空栈
        /// </summary>
        public void Clear()
        {
            _data = new T[_maxSize];
            _top = -1;
        }

        #endregion

        /// <summary>
        /// 栈是否满
        /// </summary>
        /// <returns></returns>
        public Boolean IsFull() {
            return _top == _maxSize - 1;
        }
    }
}
