using ReactNative.Bridge;
using ReactNative.Modules.Core;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ReactNative.Modules.DeviceInfo
{
    /// <summary>
    /// Native module that manages window dimension updates to JavaScript.
    /// </summary>
    public class DeviceInfoModule : ReactContextNativeModuleBase, ILifecycleEventListener
    {
        private readonly UserControl _window;
        private readonly IReadOnlyDictionary<string, object> _constants;

        /// <summary>
        /// Instantiates the <see cref="DeviceInfoModule"/>. 
        /// </summary>
        /// <param name="reactContext">The React context.</param>
        public DeviceInfoModule(ReactContext reactContext)
            : base(reactContext)
        {
            _window = (UserControl)Application.Current.Properties["RNSPIKE"];
            _constants = new Dictionary<string, object>
            {
                { "Dimensions", GetDimensions() },
            };
        }

        /// <summary>
        /// The name of the native module.
        /// </summary>
        public override string Name
        {
            get
            {
                return "DeviceInfo";
            }    
        }

        /// <summary>
        /// Native module constants.
        /// </summary>
        public override IReadOnlyDictionary<string, object> Constants
        {
            get
            {
                return _constants;
            }
        }

        /// <summary>
        /// Called after the creation of a <see cref="IReactInstance"/>,
        /// </summary>
        public override void Initialize()
        {
            Context.AddLifecycleEventListener(this);
        }

        /// <summary>
        /// Called when the application is suspended.
        /// </summary>
        public void OnSuspend()
        {
            _window.SizeChanged -= OnBoundsChanged;
        }

        /// <summary>
        /// Called when the application is resumed.
        /// </summary>
        public void OnResume()
        {
            _window.SizeChanged += OnBoundsChanged;
        }

        /// <summary>
        /// Called when the application is terminated.
        /// </summary>
        public void OnDestroy()
        {
            _window.SizeChanged -= OnBoundsChanged;
        }

        private void OnBoundsChanged(object sender, SizeChangedEventArgs args)
        {
            Context.GetJavaScriptModule<RCTDeviceEventEmitter>()
                .emit("didUpdateDimensions", GetDimensions());
        }

        private IDictionary<string, object> GetDimensions()
        {
            var content = (FrameworkElement)_window.Content;
            double scale = 1.0;

            return new Dictionary<string, object>
            {
                {
                    "window",
                    new Dictionary<string, object>
                    {
                        { "width", content?.ActualWidth ?? 0.0 },
                        { "height", content?.ActualHeight ?? 0.0 },
                        { "scale", scale },
                        /* TODO: density and DPI needed? */
                    }
                },
            };
        }
    }
}
