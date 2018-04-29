using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xaml.Interactivity;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace WSL_Guideline_UWP.Behaviors
{
    public sealed class DragImageBehavior : DependencyObject,IBehavior
    {
        private FrameworkElement _element;
        private TranslateTransform _dragTransition;

        public DependencyObject AssociatedObject { get; }

        public void Attach(DependencyObject associatedObject)
        {
            _element = associatedObject as FrameworkElement;

            _element.ManipulationDelta += _element_ManipulationDelta;
        }

        private void _element_ManipulationDelta(object sender, Windows.UI.Xaml.Input.ManipulationDeltaRoutedEventArgs e)
        {
            if (_element == null)
            {
                return;
            }

            if (_dragTransition == null)
            {
                _dragTransition = new TranslateTransform();
            }

            _element.RenderTransform = _dragTransition;
            _dragTransition.X += e.Delta.Translation.X;
            _dragTransition.Y += e.Delta.Translation.Y;
        }

        public void Detach()
        {
            if (_element != null)
            {
                _element.ManipulationDelta -= _element_ManipulationDelta;
            }
        }
    }
}
