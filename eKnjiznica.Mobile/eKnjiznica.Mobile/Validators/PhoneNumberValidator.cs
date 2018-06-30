using CommonServiceLocator;
using eKnjiznica.Commons.Util;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace eKnjiznica.Mobile.Validators
{
    public class PhoneNumberValidator : Behavior<Entry>
    {
        private MyRegex myRegex;
        public PhoneNumberValidator():base()
        {
            myRegex = ServiceLocator.Current.GetInstance<MyRegex>();
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            var textValue = args.NewTextValue;
            bool isValid = myRegex.IsValidPhone(textValue);
            ((Entry)sender).TextColor = isValid ? Color.Default : Color.Red;
        }
    }
}
