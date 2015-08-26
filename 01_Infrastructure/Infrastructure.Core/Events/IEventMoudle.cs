using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core.Events
{
    // 摘要:
    //     事件处理程序模块接口
    public interface IEventMoudle
    {
        // 摘要:
        //     注册事件处理程序
        void RegisterEventHandler();
    }
}
