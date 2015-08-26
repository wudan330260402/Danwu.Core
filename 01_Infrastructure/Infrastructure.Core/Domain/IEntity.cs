using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core
{

    /// <summary>
    /// 表示继承该接口的类型都是领域实体
    /// </summary>
    public interface IEntity<T>
    {
        #region Properties

        /// <summary>
        /// 获取当前实体的全局唯一标识
        /// </summary>
        T ID { get; }

        #endregion
    }
    /// <summary>
    /// 表示实体接口
    /// </summary>
    public interface IEntity : IEntity<Guid>
    {

    }

    
}
