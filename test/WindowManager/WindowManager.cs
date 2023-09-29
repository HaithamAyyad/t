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
    internal class WindowManager
    {
        private Window CreateWindow(IDocumentViewModel viewModel)
        {
            /*
            var modelType = viewModel.GetType();
            var windowTypeName = modelType.Name.Replace("ViewModel", "Window");
            var windowTypes = from t in GetTypes().Assembly
                              where t.IsClass
                              && t.Name == windowTypeName
                              select t;
            return (Window)Activator.CreateInstance(windowTypes.Single());
            */
            return null;
        }


    }
}
