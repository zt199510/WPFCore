using Autoface.ModDialog.Interfaces;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPFCore.ViewCenter
{
    public class BaseDialogCenter<TView, TViewModel> : IModuleDialog
        where TView: Window,new()
        where TViewModel: ViewModelBase, new()
    {
        public TView View = new TView();
        public TViewModel ViewModel = new TViewModel();
        /// <summary>
        /// 绑定默认ViewModel
        /// </summary>
        public virtual void BindDefaultViewModel()
        {
            ViewModel = new TViewModel();
            View.DataContext = ViewModel;
        }
        /// <summary>
        /// 注册默认事件
        /// </summary>
        public void BindViewModel<TViewModel1>(TViewModel1 viewModel)
        {
          
        }

        public virtual void Close()
        {
      
        }

        public void Register()
        {
          
        }

        public void RegisterDefaultEvent()
        {
            View.MouseDown += (sender, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    View.DragMove();
            };
        }

        public virtual void RegisterMessenger()
        {
           
        }

        public virtual Task<bool> ShowDialog()
        {
            if (View.DataContext == null)
            {
                this.RegisterMessenger();
                this.RegisterDefaultEvent();
                this.BindDefaultViewModel();
            }
            var result = View.ShowDialog();
            return Task.FromResult(true);
        }
    }
}
