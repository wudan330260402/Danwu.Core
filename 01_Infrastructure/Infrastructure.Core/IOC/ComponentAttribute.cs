using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Core.IOC
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ComponentAttribute : System.Attribute
    {
        public LifeStyle LifeStyle { get; private set; }

        public ComponentAttribute()
            : this(LifeStyle.Singleton)
        { 
            
        }

        public ComponentAttribute(LifeStyle lifeStyle) {
            this.LifeStyle = lifeStyle;
        }
    }

    public enum LifeStyle
    {
        Transient,
        Singleton
    }
}
