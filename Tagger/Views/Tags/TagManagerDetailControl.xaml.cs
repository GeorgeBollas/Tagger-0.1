using System;
using Tagger.Entities.Tags;
using Tagger.Models;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Tagger.Views
{
    public sealed partial class TagManagerDetailControl : UserControl
    {
        public TagType MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as TagType; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static readonly DependencyProperty MasterMenuItemProperty = DependencyProperty.Register("MasterMenuItem", typeof(SampleOrder), typeof(TagManagerDetailControl), new PropertyMetadata(null, OnMasterMenuItemPropertyChanged));

        public TagManagerDetailControl()
        {
            InitializeComponent();
        }

        private static void OnMasterMenuItemPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as TagManagerDetailControl;
            control.ForegroundElement.ChangeView(0, 0, 1);
        }
    }
}
