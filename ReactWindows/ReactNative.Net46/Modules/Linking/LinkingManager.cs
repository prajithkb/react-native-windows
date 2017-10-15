using ReactNative.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactNative.Modules.Linking
{
    class LinkingManagerModule : ReactContextNativeModuleBase
    {

        private readonly object locker = new object();

        #region Constructor(s)

        public LinkingManagerModule(ReactContext reactContext)
            : base(reactContext)
        {
        }

        #endregion

        #region NativeModuleBase Overrides

        public override string Name
        {
            get
            {
                return "LinkingManager";
            }
        }

        #endregion

        #region Public Methods

        [ReactMethod]
        public void getInitialURL(IPromise promise)
        {
             promise.Reject("PKBERR-1","Un supported operation");
        }

        [ReactMethod]
        public void openURL(String url, IPromise promise)
        {
            promise.Reject("PKBERR-1", "Un supported operation");
        }

        [ReactMethod]
        public void canOpenURL(String url, IPromise promise)
        {
            promise.Reject("PKBERR-1", "Un supported operation");
        }
        #endregion


    }
}
