using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danwu.DataStructureAlgorithms
{
    /// <summary>
    /// 顺序表(此处顺序表示的是数组的物理顺序和逻辑顺序是一致)
    /// </summary>
    public class SeqLinearList<T> : ILinearList<T>
    {
        private Int32 _maxSize;     //设置一个最大值
        private T[] _dataList;      //用数组来存储
        private Int32 _lastIndex;   //最后一个数据的索引位置

        public SeqLinearList()
            : this(10000)
        { }
        public SeqLinearList(Int32 maxSize) {
            _maxSize = maxSize;
            _lastIndex = -1;
            _dataList = new T[_maxSize];
        }

        #region ILinearList Members

        public virtual int GetLength()
        {
            if (_dataList != null)
                return _dataList.Length;
            return 0;
        }
        public virtual bool IsEmpty()
        {
            return _lastIndex == -1;
        }
        public virtual bool IsFull()
        {
            return _lastIndex == _maxSize - 1;
        }

        public virtual void Append(T data)
        {
            if (IsFull()) throw new Exception("数组已满，不能再插入数据");

            _lastIndex++;
            _dataList[_lastIndex] = data;
        }
        public virtual void Insert(T data, int index)
        {
            if (index < 0 || index > (_maxSize - 1)) throw new Exception("插入索引位置越界");
            _lastIndex++;
            if (index > _lastIndex) _dataList[_lastIndex] = data;
            else {
                for (var i = _lastIndex; i > index; i--)
                    _dataList[i] = _dataList[i - 1];
                _dataList[index] = data;
            }
        }
        public virtual void Remove(T data)
        {
            Int32 index = Location(data);
            if (index == -1) throw new Exception("数据项不在表中");

            RemoveAt(index);
        }
        public virtual T RemoveAt(int index)
        {
            if (index < 0 || index > _maxSize-1) throw new Exception("索引越界");
            
            var t = _dataList[index];
            for (var i = index; i < _lastIndex; i++) {
                _dataList[i] = _dataList[i + 1];
            }
            _lastIndex--;
            return t;
        }

        public virtual T GetElem(int index)
        {
            if (index < 0 || index > _maxSize - 1) throw new Exception("索引越界");
            return _dataList[index];
        }
        public virtual int Location(T data)
        {
            for (var i = 0; i <=_lastIndex; i++) {
                if (_dataList[i].Equals(data)) return i;
            }
            return -1;
        }

        public virtual void Clear()
        {
            _dataList = new T[_maxSize];
            _lastIndex = -1;
        }

        #endregion

    }
}
