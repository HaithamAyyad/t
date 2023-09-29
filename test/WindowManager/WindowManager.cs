using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using test.Interface;

namespace test.WindowManager
{
    public class WindowsManager
    {
        public static Window CreateWindow(IViewModel viewModel)
        {
            var windowName = viewModel.GetType().ToString().Replace("Model", "");
            windowName = windowName.Replace("DocumentView", "DocumentWindow");

            var windowType = Type.GetType(windowName);

            if (windowType != null && typeof(Window).IsAssignableFrom(windowType))
            {
                var window = (Window)Activator.CreateInstance(windowType);

                window.DataContext = viewModel;

                return window;
            }

            return null;
        }


    }
}
