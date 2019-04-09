using System;
using System.Windows;
using System.Windows.Controls;

namespace Ratcow.Mvvm.BindingExtensions
{
    /// <summary>
    /// This allows us to set dialog result on the buttons without having to add in 
    /// explicit code.
    /// 
    /// https://stackoverflow.com/a/1759505/2298819
    /// </summary>
    public class ButtonHelper
    {
        // Boilerplate code to register attached property "bool? DialogResult"
        public static bool? GetDialogResult(DependencyObject obj) { return (bool?)obj.GetValue(DialogResultProperty); }
        public static void SetDialogResult(DependencyObject obj, bool? value) { obj.SetValue(DialogResultProperty, value); }
        public static readonly DependencyProperty DialogResultProperty = DependencyProperty.RegisterAttached("DialogResult", typeof(bool?), typeof(ButtonHelper), new UIPropertyMetadata
        {
            PropertyChangedCallback = (obj, e) =>
            {
                // Implementation of DialogResult functionality
                if (!(obj is Button button))
                {
                    throw new InvalidOperationException(
                      "Can only use ButtonHelper.DialogResult on a Button control");
                }

                button.Click += (sender, e2) =>
                {
                    Window.GetWindow(button).DialogResult = GetDialogResult(button);
                };
            }
        });
    }
}