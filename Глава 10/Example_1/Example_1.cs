using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Example_1
{
    public class BetterEllipse : FrameworkElement
    {
        //определяем зависимые свойства
        public static readonly DependencyProperty FillProperty;
        public static readonly DependencyProperty StrokeProperty;
        //и определяем доступ к ним
        public Brush Fill
        {
            set { SetValue(FillProperty, value); }
            get { return (Brush)GetValue(FillProperty); }
        }

        public Pen Stroke
        {
            set { SetValue(StrokeProperty, value); }
            get { return (Pen)GetValue(StrokeProperty); }
        }
        //определяем статический конструктор
        static BetterEllipse()
        {
            //регистрируем свойство зависимостей с указанным именем свойства, 
            //типом свойства, типом владельца и метаданными свойства.
            FillProperty = DependencyProperty.Register("Fill", typeof(Brush), typeof(BetterEllipse),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender));
            StrokeProperty = DependencyProperty.Register("Stroke", typeof(Pen), typeof(BetterEllipse),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsMeasure));
        }
        //переопределяем естественные размеры элемента с учетом толщины Stroke
        protected override Size MeasureOverride(Size availableSize)
        {
            Size sizeDesired = base.MeasureOverride(availableSize);
            if (Stroke != null)
            {
                sizeDesired = new Size(Stroke.Thickness, Stroke.Thickness);
            }
            return sizeDesired;
        }

        //переопределяем метод отрисовки с учетом толщины Stroke
        protected override void OnRender(DrawingContext dc)
        {
            Size size = RenderSize;

            if (Stroke != null)
            {
                size.Width = Math.Max(0, size.Width - Stroke.Thickness);
                size.Height = Math.Max(0, size.Height - Stroke.Thickness);
            }

            dc.DrawEllipse(Fill, Stroke, new Point(RenderSize.Width / 2, RenderSize.Height / 2),
                size.Width / 2, size.Height / 2);
        }
    }
}