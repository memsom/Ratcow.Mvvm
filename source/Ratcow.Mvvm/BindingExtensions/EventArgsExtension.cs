// Updated Ultimate WPF Event Method Binding implementation by Mike Marynowski
// View the article here: http://www.singulink.com/CodeIndex/post/updated-ultimate-wpf-event-method-binding

// Licensed under the Code Project Open License: http://www.codeproject.com/info/cpol10.aspx

using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Ratcow.Mvvm.BindingExtensions
{
    public class EventArgsExtension : MarkupExtension
    {
        public PropertyPath Path { get; set; }

        public IValueConverter Converter { get; set; }
        public object ConverterParameter { get; set; }
        public Type ConverterTargetType { get; set; }

        [TypeConverter(typeof(CultureInfoIetfLanguageTagConverter))]
        public CultureInfo ConverterCulture { get; set; }

        public EventArgsExtension()
        {
        }

        public EventArgsExtension(string path)
        {
            Path = new PropertyPath(path);
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        internal object GetArgumentValue(EventArgs eventArgs, XmlLanguage language)
        {
            if (Path == null)
            {
                return eventArgs;
            }

            object value = PropertyPathHelpers.Evaluate(Path, eventArgs);

            if (Converter != null)
            {
                value = Converter.Convert(value, ConverterTargetType ?? typeof(object), ConverterParameter, ConverterCulture ?? language.GetSpecificCulture());
            }

            return value;
        }
    }
}