using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagger.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Tagger.Controls
{
    public class ValidationErrors : Control
    {
        public ValidationErrors()
        {
            DefaultStyleKey = typeof(ValidationErrors);
        }
        public List<InputValidationError> Errors
        {
            get { return (List<InputValidationError>)GetValue(ErrorsProperty); }
            set { SetValue(ErrorsProperty, value); }
        }

        public static readonly DependencyProperty ErrorsProperty = DependencyProperty.Register(nameof(Errors), typeof(List<InputValidationError>), typeof(ValidationErrors), new PropertyMetadata(new List<ValidationErrors>(), OnErrosChanged));

        private static void OnErrosChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var ve = d as ValidationErrors;

            if (ve != null)
                ve.HasErrors = ve.Errors != null && ve.Errors.Count > 0 ? Visibility.Visible : Visibility.Collapsed;

        }

        public Visibility HasErrors
        {
            get { return (Visibility)GetValue(HasErrorsProperty); }
            set { SetValue(HasErrorsProperty, value); }
        }

        public static readonly DependencyProperty HasErrorsProperty = DependencyProperty.Register(nameof(HasErrors), typeof(Visibility), typeof(ValidationErrors), null);

    }
}
