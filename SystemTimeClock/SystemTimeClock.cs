using ColossalFramework;
using ICities;
using UnityEngine;
using ColossalFramework.UI;

namespace SystemTimeClock
{
    public class SystemTimeClock : IUserMod
    {
        public string Name
        {
            get { return "System Time Clock"; }
        }

        public string Description
        {
            get { return "Displays the current system time."; }
        }
    }

    public class LoadingExtension : LoadingExtensionBase
    {
        UITextField time;
        System.Timers.Timer t;
        public override void OnLevelLoaded(LoadMode mode)
        {
            // Get the UIView object. This seems to be the top-level object for most
            // of the UI.
            var uiView = GameObject.FindObjectOfType<UIView>();
            if (uiView == null) return;

            
            var textObject = new GameObject("MyButton", typeof(UITextField));

            
            textObject.transform.parent = uiView.transform;

            
            time = textObject.GetComponent<UITextField>();

            
            time.text = System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;

            // Set the button dimensions.
            time.width = 100;
            time.height = 30;


            // Place the button.
            time.transformPosition = new Vector3(-1.65f, 0.97f);

            t = new System.Timers.Timer();
            t.AutoReset = false;
            t.Elapsed += new System.Timers.ElapsedEventHandler(setText);
            t.Interval = 1000;
            t.Start();
        }

        private void setText(object sender, System.Timers.ElapsedEventArgs e)
        {
            time.text = System.DateTime.Now.Hour + ":" + System.DateTime.Now.Minute + ":" + System.DateTime.Now.Second;
            DebugOutputPanel.AddMessage(ColossalFramework.Plugins.PluginManager.MessageType.Message, "Time interval reached.");
            t.Start();
        }
    }
}