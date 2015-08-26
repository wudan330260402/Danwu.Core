using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.DomainModel
{
    /// <summary>
    /// 服务层类的基类
    /// 作用：对象释放
    /// </summary>
    public abstract class ServiceBase : IDisposable
    {
        public IList<IDisposable> disposableObjects { get; private set; }

        public ServiceBase() {
            disposableObjects = new List<IDisposable>();
        }

        /// <summary>
        /// 将对象添加到待释放队列
        /// </summary>
        /// <param name="obj"></param>
        protected void AddDisposableObject(Object obj) {
            IDisposable disposable = obj as IDisposable;
            if (disposable != null)
                disposableObjects.Add(disposable);
        }

        /// <summary>
        /// 释放对象
        /// </summary>
        public void Dispose()
        {
            foreach (IDisposable obj in disposableObjects) {
                obj.Dispose();
            }
        }
    }
}
