using ReactNative.Bridge;

namespace ReactNative.Modules.Core
{
    /// <summary>
    /// JavaScript module for emitting device events.
    /// </summary>
    public sealed class RCTDeviceEventEmitter : JavaScriptModuleBase
    {
        /// <summary>
        /// Emits an event to the JavaScript instance.
        /// </summary>
        /// <param name="eventName">The event name.</param>
        /// <param name="data">The event data.</param>
        public void emit(string eventName, object data)
        {
            //System.Console.WriteLine("PKB {0} - {1}", eventName, data != null ? data.ToString() : "");
            Invoke(eventName, data);
        }
    }
}
