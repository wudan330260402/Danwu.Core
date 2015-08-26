using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.DataStructureAlgorithms
{
    /// <summary>
    /// 栈结构接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IStack<T>
    {
        /// <summary>
        /// 获取栈的长度
        /// </summary>
        /// <returns></returns>
        Int32 GetLength();
        /// <summary>
        /// 栈是否为空
        /// </summary>
        /// <returns></returns>
        Boolean IsEmpty();
        /// <summary>
        /// 入栈
        /// </summary>
        /// <param name="item"></param>
        void Push(T item);
        /// <summary>
        /// 出栈
        /// </summary>
        /// <returns></returns>
        T Pop();
        /// <summary>
        /// 获取栈顶元素
        /// </summary>
        /// <returns></returns>
        T GetTop();
        /// <summary>
        /// 清空栈
        /// </summary>
        void Clear();
    }
}
