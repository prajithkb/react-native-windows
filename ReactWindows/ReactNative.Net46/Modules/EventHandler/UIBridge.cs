using Newtonsoft.Json.Linq;
using ReactNative.Bridge;
using ReactNative.Modules.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactNative.Modules.UIBridge
{
    public class UIBridge : ReactContextNativeModuleBase
    {

        // Use this for registering for callbacks from JS
        public event EventHandler<JObject> SendEvent;

        #region Constructor(s)
        public UIBridge(ReactContext reactContext)
            : base(reactContext)
        {
        }

        public UIBridge(ReactContext reactContext,EventHandler<UIBridge> callback)
            : base(reactContext)
        {
            callback.Invoke(this, this);
        }

        #endregion

        #region NativeModuleBase Overrides

        public override string Name
        {
            get
            {
                return "UIBridge";
            }
        }

        #endregion

        #region Public Methods

        [ReactMethod]
        public void sendEvent(JObject o)
        {
            Console.WriteLine("PKB Sending Event :"+ o);
            SendEvent?.Invoke(this, o);
        }

        public void acceptDirective(JObject o)
        {
            Console.WriteLine("PKB Accepting directive :"+  o);
            SendToJS("Directive", o);
        }
        #endregion


        #region Private Methods
        private void SendToJS(string eventName, JObject parameters)
        {
            Context.GetJavaScriptModule<RCTDeviceEventEmitter>()
                .emit(eventName, parameters);
        }
        #endregion
    }
}
