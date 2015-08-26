using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
{
    /// <summary>
    /// 表示聚合根接口
    /// </summary>
    public interface IAggregateRoot : IAggregateRoot<Guid>
    {

    }

    /// <summary>
    /// 表示继承该接口的类型都是聚合根类型
    /// </summary>
    public interface IAggregateRoot<T> : IEntity<T>
    {
        T ID { get; }
        Int32 Version { get; }
    }
}
