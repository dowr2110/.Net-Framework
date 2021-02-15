using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace lab_7_8_new
{
    public class DatePickerEx : DatePicker
    {
        static DatePickerEx()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(DatePickerEx),
                new FrameworkPropertyMetadata(typeof(DatePickerEx)));
        }
        public object AdditionalPopupContent
        {
            get { return (object)GetValue(AdditionalPopupContentProperty); }
            set { SetValue(AdditionalPopupContentProperty, value); }
        }

        public static readonly DependencyProperty AdditionalPopupContentProperty =
            DependencyProperty.Register("AdditionalPopupContent", typeof(object),
                                        typeof(DatePickerEx));
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            var popup = GetTemplateChild("PART_Popup") as Popup;
            if (popup != null)
                ApplyCustomStyle(popup);
        }
        void ApplyCustomStyle(Popup popup)
        {
            var calendar = popup.Child as Calendar;
            if (calendar == null)
                return;
            calendar.SetResourceReference(Calendar.StyleProperty, "DatePickerEx_CustomPopup");
        }
    }



}

