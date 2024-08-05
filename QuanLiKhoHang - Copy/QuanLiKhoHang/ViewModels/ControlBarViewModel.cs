using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace QuanLiKhoHang.ViewModels
{
    public class ControlBarViewModel:BaseViewModel
    {
        public ICommand CloseWindow {  get; set; }
        public ICommand MaximizeWindow { get; set; }
        public ICommand MinimizeWindow { get; set; }
        public ICommand MouseMoveWindowCommand { get; set; }
        public ControlBarViewModel()
        {
            CloseWindow = new RelayCommand<UserControl>(p => p==null? false : true, p => {
                Window window = Window.GetWindow(p);
                if (window != null)
                {
                    window.Close();
                }
            });
            MaximizeWindow = new RelayCommand<UserControl>(p => p == null ? false : true, p => {
                Window window = Window.GetWindow(p);
                if (window != null)
                {
                    if(window.WindowState != WindowState.Maximized)
                    {
                        window.WindowState = WindowState.Maximized;
                    }
                    else
                    {
                        window.WindowState = WindowState.Normal;
                    }
                }
            });
            MinimizeWindow = new RelayCommand<UserControl>(p => p == null ? false : true, p => {
                Window window = Window.GetWindow(p);
                if (window != null)
                {
                    if (window.WindowState != WindowState.Minimized)
                    {
                        window.WindowState = WindowState.Minimized;
                    }
                    else
                    {
                        return;
                    }
                }
            });
            MouseMoveWindowCommand = new RelayCommand<UserControl>(p => p == null ? false : true, p => {
                Window window = Window.GetWindow(p);
                window?.DragMove();
                
            });
        }
        void GetWindowParentCachKho(UserControl uc)
        {
            Window window = Window.GetWindow(uc);
            if (window!=null)
            {
                window.Close();
            }
        }
    }
}
