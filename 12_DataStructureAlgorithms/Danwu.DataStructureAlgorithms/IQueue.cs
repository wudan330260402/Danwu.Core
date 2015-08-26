using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.DataStructureAlgorithms
{
    /// <summary>
    /// 队列接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IQueue<T>
    {
        Int32 GetLength();
        Boolean IsEmpty();

        void Enqueue(T item);
        T Dequeue();
        //Queue<T>
        //void 
    }
}
