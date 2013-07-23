using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Autofac.Configuration;

namespace Autofac.WebApplication
{
    public class Global : System.Web.HttpApplication
    {

        public static IContainer Container { get; set; }

        void Application_Start(object sender, EventArgs e)
        {
            // Create your builder.
            var builder = new ContainerBuilder();

            //// Usually you're only interested in exposing the type
            //// via its interface:
            //builder.RegisterType<SomeType>().As<IService>();

            //// However, if you want BOTH services (not as common)
            //// you can say so:
            //builder.RegisterType<SomeType>().AsSelf().As<IService>();


            //builder.RegisterType<ConsoleOutput>().As<IOutput>();
            //builder.RegisterType<WebOutput>().As<IOutput>();
            //builder.RegisterType<TodayWriter>().As<IDateWriter>();
            
            // register components using XML config
            builder.RegisterModule(new ConfigurationSettingsReader("autofac"));
            Container = builder.Build(); 
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
