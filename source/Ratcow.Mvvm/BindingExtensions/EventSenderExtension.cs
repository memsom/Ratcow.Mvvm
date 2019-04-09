// Updated Ultimate WPF Event Method Binding implementation by Mike Marynowski
// View the article here: http://www.singulink.com/CodeIndex/post/updated-ultimate-wpf-event-method-binding

// Licensed under the Code Project Open License: http://www.codeproject.com/info/cpol10.aspx

using System;
using System.Windows.Markup;

namespace Ratcow.Mvvm.BindingExtensions
{
    public class EventSenderExtension : MarkupExtension
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }
    }
}