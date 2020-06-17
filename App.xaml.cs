using Autofac;
using Autoface;
using Autoface.Common;
using Autoface.ModDialog.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WPFCore.ViewCenter;

namespace WPFCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            ConfigureServices();
            var view = AutofacProvider.Get<IModuleDialog>("LoginCenter");
            view.ShowDialog();
        }

        protected void ConfigureServices()
        {
            AutofacLocator locator = new AutofacLocator();
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType(typeof(LoginCenter)).Named("LoginCenter", typeof(IModuleDialog));


            locator.Register(builder);
            AutofacProvider.RegisterServiceLocator(locator);
        }
    }
}
