using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ObjectBuilder2;

namespace Infrastructure.Core.Unity
{
    /// <summary>
    /// Unity的ContrllerFactory，在Gloab.asax文件中注册
    /// </summary>
    public class UnityControllerFacatory : DefaultControllerFactory
    {
        
        private IUnityContainer container;
        public UnityControllerFacatory(IUnityContainer _container)
        {
            this.container = _container;
        }

        protected override IController GetControllerInstance(System.Web.Routing.RequestContext requestContext, Type controllerType)
        {
            //IController controller = container.Resolve(controllerType) as IController;
            //return controller;
            return base.GetControllerInstance(requestContext, controllerType);
        }

    }
}
