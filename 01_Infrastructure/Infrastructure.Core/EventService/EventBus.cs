using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Infrastructure.Core.EventService
{
    /// <summary>
    /// 事件总线
    /// http://www.cnblogs.com/lori/p/3476703.html
    /// </summary>
    public class EventBus
    {
        private EventBus() {
            InitFromXml();
        }

        private static EventBus _eventBus = null;
        private readonly static object lockObj = new object();

        private Dictionary<Type, List<Type>> eventMapping = new Dictionary<Type, List<Type>>();

        public static EventBus Instance {
            get {
                if (_eventBus == null) {
                    lock (lockObj) {
                        if (_eventBus == null)
                            _eventBus = new EventBus();
                    }
                }

                return _eventBus;
            }
        }

        private void InitFromXml() {

            XElement root = XElement.Load(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EventBus.xml"));
            foreach (var evt in root.Elements("Event")){
                
                Type publishEventType = Type.GetType(evt.Element("PublishEvent").Value);
                List<Type> handlers = new List<Type>();
                foreach (var subscribeEvt in evt.Elements("SubscribedEvent")) {
                    Type subscribeEventType = Type.GetType(subscribeEvt.Value);
                    handlers.Add(subscribeEventType);
                }
                eventMapping.Add(publishEventType, handlers);
            }

        }

        /// <summary>
        /// 订阅事件
        /// </summary>
        public void Subscribe<T>(IEventHandler<T> eventHandler)
            where T : class,IEvent
        {
            lock (lockObj)
            {
                Type eventType = typeof(T);
                Type handlerType = eventHandler.GetType();
                if (eventMapping.ContainsKey(eventType))
                {
                    var handlers = eventMapping[eventType];
                    if (handlers != null)
                    {
                        //加一层判断，判断是否已经存在该handler了
                        if (!handlers.Exists(t => typeEquals(t, handlerType)))
                            handlers.Add(handlerType);
                    }
                    else
                    {
                        handlers = new List<Type>();
                        handlers.Add(handlerType);
                    }
                    eventMapping[eventType] = handlers;
                }
                else
                {
                    eventMapping.Add(eventType, new List<Type>() { handlerType });
                }
            }
        }

        /// <summary>
        /// 取消订阅
        /// </summary>
        public void Unsubscribe<T>(IEventHandler<T> eventHandler)
            where T : class,IEvent
        {

            lock (lockObj)
            {
                Type eventType = typeof(T);
                Type handlerType = eventHandler.GetType();
                if (eventMapping.ContainsKey(eventType))
                {
                    var handlers = eventMapping[eventType];
                    if (handlers != null)
                    {
                        //移除，移除之前先进行一个比较
                        if (handlers.Exists(t => typeEquals(t, handlerType)))
                            handlers.Remove(handlerType);
                    }
                }
            }

        }

        /// <summary>
        /// 发布事件
        /// </summary>
        public void Publish<T>(T evt)
            where T : class,IEvent
        {
            if (evt == null)
                throw new Exception("异常");

            var eventType = typeof(T);
            if (eventMapping.ContainsKey(eventType))
            {
                var handlers = eventMapping[eventType];
                if (handlers != null) {
                    foreach (var handler in handlers) {
                        var eventHandler = handler as IEventHandler<T>;
                        eventHandler.Handler(evt);
                    }
                }
            }
        }

        /// <summary>
        /// 类型比较
        /// </summary>
        private Func<Type, Type, Boolean> typeEquals = (obj1, obj2) =>
        {
            var obj1Type = obj1.GetType();
            var obj2Type = obj2.GetType();

            return obj1Type == obj2Type;
        };

    }
}
