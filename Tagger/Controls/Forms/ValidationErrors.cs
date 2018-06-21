using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tagger.Models;
using Tagger.ViewModels;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Tagger.Controls
{
    public class ValidationErrors : ContentControl
    {
        public ValidationErrors()
        {
            DefaultStyleKey = typeof(ValidationErrors);

            SetAttributeName();
        }

        private void SetAttributeName()
        {
            //todo figure out how to subscribe to the changes in the Errors collection to update each
            //todo add dp and if set just use it

            // 1. find child control
            // 2. get name of control and use as name of property
            var prop = "";
            // 3. get view model (DataContext)

            var errors = typeof(GenericDetailsViewModel<>).GetProperty("Errors").GetValue(this) as IEnumerable<InputValidationError>;

            // 4. get the Errors for that attribute
            var propErrors = errors.Where(p => p.PropertyName == prop);

            throw new NotImplementedException();
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
