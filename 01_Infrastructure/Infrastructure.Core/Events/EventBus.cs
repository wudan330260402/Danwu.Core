using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Infrastructure.Core.Events
{
    public class EventBus<S, T> : IEventBus<S, T> where T : CommonEventArgs
    {
        private static EventBus<S, T> _instance = null;
        private static Object obj = new Object();
        //事件列表
        private static EventHandlerList eventList = new EventHandlerList();

        private Object bfObj = new Object();
        private Object afObj = new Object();
        private Object bt_bfObj = new Object();
        private Object bt_afObj = new Object();

        public event CommonEventHandler<S, T> Before {
            add {
                EventBus<S, T>.eventList.AddHandler(bfObj, value);
            }
            remove {
                EventBus<S, T>.eventList.RemoveHandler(bfObj, value);
            }
        }        
        public event CommonEventHandler<S, T> After {
            add {
                EventBus<S, T>.eventList.AddHandler(afObj, value);
            }
            remove {
                EventBus<S, T>.eventList.AddHandler(afObj, value);
            }
        }
        public event BatchEventHandler<S, T> BatchBefore{
            add {
                EventBus<S, T>.eventList.AddHandler(bt_bfObj, value);
            }
            remove {
                EventBus<S, T>.eventList.RemoveHandler(bt_bfObj, value);
            }
        }
        public event BatchEventHandler<S, T> BatchAfter {
            add {
                EventBus<S, T>.eventList.AddHandler(bt_afObj, value);
            }
            remove {
                EventBus<S, T>.eventList.RemoveHandler(bt_afObj, value);
            }
        }

        protected EventBus() { }
        public static EventBus<S, T> Instance() {
            if (EventBus<S, T>._instance == null) {
                lock (obj) {
                    if (EventBus<S, T>._instance == null) {
                        EventBus<S, T>._instance = new EventBus<S, T>();
                    }
                }
            }
            return EventBus<S, T>._instance;
        }

        public void OnBefore(S sender, T eventArgs)
        {
            CommonEventHandler<S, T> beforeHandler = EventBus<S, T>.eventList[bfObj] as CommonEventHandler<S, T>;
            if (beforeHandler != null)
                beforeHandler.BeginInvoke(sender, eventArgs, null, null);
        }
        public void OnAfter(S sender, T eventArgs)
        {
            CommonEventHandler<S, T> afterHandler = EventBus<S, T>.eventList[afObj] as CommonEventHandler<S, T>;
            if (afterHandler != null)
                afterHandler.BeginInvoke(sender, eventArgs, null, null);
        }      
        public void OnBatchBefore(IEnumerable<S> senders, T eventArgs)
        {
            throw new NotImplementedException();
        }
        public void OnBatchAfter(IEnumerable<S> senders, T eventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
