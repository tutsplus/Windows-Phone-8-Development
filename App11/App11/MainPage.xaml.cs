using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace App11
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private TranslateTransform _moveTransform = new TranslateTransform();
        private ScaleTransform _scaleTransform = new ScaleTransform();
        private TransformGroup _transformGroup = new TransformGroup();

        private Brush _stationaryBrush;
        private Brush _movingBrush = new SolidColorBrush(Colors.Yellow);

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            MyRectangle.ManipulationStarted += ( sender, args ) => {
                _stationaryBrush = MyRectangle.Fill;
                MyRectangle.Fill = _movingBrush;
            };

            MyRectangle.ManipulationDelta += ( sender, args ) => {
                _moveTransform.X += args.Delta.Translation.X;
                _moveTransform.Y += args.Delta.Translation.Y;
            };

            MyRectangle.ManipulationCompleted += ( sender, args ) => {
                MyRectangle.Fill = _stationaryBrush;
            };

            MyRectangle.Tapped += ( sender, args ) => {
                _scaleTransform.ScaleX += .25;
                _scaleTransform.ScaleY += .25;
            };

            _transformGroup.Children.Add(_moveTransform);
            _transformGroup.Children.Add(_scaleTransform);

            MyRectangle.RenderTransform = _transformGroup;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
    }
}
