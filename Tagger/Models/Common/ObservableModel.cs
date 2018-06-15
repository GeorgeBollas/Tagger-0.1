using GalaSoft.MvvmLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tagger.Models
{
    //todo should this be named ObservableModel
    public abstract class ObservableModel:ObservableObject, INotifyDataErrorInfo
    {
        public bool IsEmpty { get; set; }

        public abstract void Merge(object item);

        //todo do we need this if we use ObservabeObject?? as it does on each
        public abstract void RaisePropertiesChanged();

        #region Error handling

        public void Validate(object value, [CallerMemberName] string propertyName = "")
        {
            // step 1 : common

            if (Errors.ContainsKey(propertyName))
            {
                Errors.Remove(propertyName);
                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }

            var results = new ObservableCollection<ValidationResult>();
            var context = new ValidationContext(this, null, null) { MemberName = propertyName };
            Validator.TryValidateProperty(value, context, results);

            if (results.Count > 0)
            {
                if (!Errors.ContainsKey(propertyName))
                {
                    Errors.Add(propertyName, new ObservableCollection<ValidationResult>());
                }
                foreach (var result in results)
                {
                    Errors[propertyName].Add(new ValidationResult(result.ErrorMessage));
                }

                ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            }

        }

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        protected readonly Dictionary<string, ObservableCollection<ValidationResult>> Errors = new Dictionary<string, ObservableCollection<ValidationResult>>();

        public bool HasErrors => Errors.Count > 0;

        public IEnumerable GetErrors([CallerMemberName] string propertyName = null)
        {
            return propertyName != null && Errors.ContainsKey(propertyName)
                ? Errors[propertyName]
                : new ObservableCollection<ValidationResult>();
        }

        #endregion
    }
}
