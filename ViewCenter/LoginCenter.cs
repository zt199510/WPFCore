using Autoface.Common;
using Autoface.ModDialog.Interfaces;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using WPFCore.View;

namespace WPFCore.ViewCenter
{
    /// <summary>
    /// 登录控制类
    /// </summary>
    public class LoginCenter : BaseDialogCenter<LoginView, LoginViewModel>
    {
        public override  Task<bool> ShowDialog()
        {
            if (View.DataContext == null)
            {
                this.RegisterMessenger();
                this.RegisterDefaultEvent();
                this.BindDefaultViewModel();
            }
            var result = View.ShowDialog();
            return Task.FromResult((bool)result);
        }

        public override void RegisterMessenger()
        {
            Messenger.Default.Register<bool>(View, "NavigationHome", arg =>
            {
                View.Close(); //Close LoginView
                var mainView = AutofacProvider.Get<IModuleDialog>("MainCenter"); //Get MainView Examples
                mainView.ShowDialog(); //Show MainView
            });
            Messenger.Default.Register<bool>(View, "Exit", arg =>
            {
                View.Close();
            });
        }
    }
}
