using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.DataStructureAlgorithms
{
    /// <summary>
    /// 链栈结构
    /// </summary>
    public class LinkStack<T> : IStack<T>
    {
        #region IStack Members

        /// <summary>
        /// 获取栈的长度
        /// </summary>
        /// <returns></returns>
        public int GetLength()
        {
            return 0;
        }
        /// <summary>
        /// 栈是否为空
        /// </summary>
        /// <returns></returns>
        public bool IsEmpty()
        {
            return false;
        }
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        public void Push(T item)
        {
            
        }
        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        public T Pop()
        {
            var t = default(T);

            return t;
        }
        /// <summary>
        /// 获取栈顶元素
        /// </summary>
        /// <returns></returns>
        public T GetTop()
        {
            var t = default(T);

            return t;
        }
        /// <summary>
        /// 清空栈
        /// </summary>
        public void Clear()
        {
            
        }

        #endregion
    }
}
