using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Tagger.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Tagger.Views.Tags
{
    public sealed partial class TagTypeDetailsControl : UserControl
    {
        public TagTypeDetailsControl()
        {
            this.InitializeComponent();
        }

        #region ViewModel
        public TagTypeDetailsViewModel ViewModel
        {
            get { return (TagTypeDetailsViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register("ViewModel", typeof(TagTypeDetailsViewModel), typeof(TagTypeDetailsControl), new PropertyMetadata(null));
        #endregion

    }
}
