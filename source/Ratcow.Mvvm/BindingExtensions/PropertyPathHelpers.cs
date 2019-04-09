// Updated Ultimate WPF Event Method Binding implementation by Mike Marynowski
// View the article here: http://www.singulink.com/CodeIndex/post/updated-ultimate-wpf-event-method-binding

// Licensed under the Code Project Open License: http://www.codeproject.com/info/cpol10.aspx

using System.Windows;
using System.Windows.Data;

namespace Ratcow.Mvvm.BindingExtensions
{
    public static class PropertyPathHelpers
    {
        public static object Evaluate(PropertyPath path, object source)
        {
            var target = new DependencyTarget();
            var binding = new Binding() { Path = path, Source = source, Mode = BindingMode.OneTime };
            BindingOperations.SetBinding(target, DependencyTarget.ValueProperty, binding);

            return target.Value;
        }

        private class DependencyTarget : DependencyObject
        {
            public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(object), typeof(DependencyTarget));

            public object Value
            {
                get => GetValue(ValueProperty);
                set => SetValue(ValueProperty, value);
            }
        }
    }
}