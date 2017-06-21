using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SkeletonMVVMApp.ViewModel
{
    /// <summary>
    /// Collection Of Viewmodels.
    /// </summary>
    public class FacadeViewModel
    {
        /// <summary>
        /// The get instance
        /// </summary>
        public static FacadeViewModel GetInstance;

        public ViewModel.MainViewModel MainViewModel;


        /// <summary>
        /// Initializes a new instance of the <see cref="FacadeViewModel"/> class.
        /// </summary>
        public FacadeViewModel()
        {
            FacadeViewModel.GetInstance = this;
        }

        /// <summary>

    }
}