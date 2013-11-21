using System.Collections.Generic;
using System.Linq;
using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using SSCS_LIVE.Domain.Entities;
using SSCS_LIVE.Domain.DataInterface;
using SSCS_LIVE.Domain.Context;

/** Code from Adam Freeman 
 * Book: Pro APP.NET MVC4**/

namespace SSCS_LIVE_MVC.Controller_Factory
{

    public class ContFactoryNinject: DefaultControllerFactory
    {
        private IKernel ninjectKernel;
          
        public ContFactoryNinject()
          {
              ninjectKernel = new StandardKernel();
              AddBindings();
          }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }
          
        private void AddBindings() 
          {
             
              ninjectKernel.Bind<UserInterface>().To<StoreDataAccess>();
              ninjectKernel.Bind<BookInterface>().To<StoreDataAccess>();
              ninjectKernel.Bind<CartInterface>().To<StoreDataAccess>();

          } 
    }

}
