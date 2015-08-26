using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.DataStructureAlgorithms
{
    /// <summary>
    /// 线性表行为接口
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ILinearList<T>
    {
        Int32 GetLength();
        Boolean IsEmpty();
        Boolean IsFull();
        
        void Append(T data);
        void Insert(T data, Int32 index);
        void Remove(T data);
        T RemoveAt(Int32 index);

        T GetElem(Int32 index);
        Int32 Location(T data);

        void Clear();
    }
}
