﻿using ICities;
using System;
using UnityEngine;

namespace fys
{
    public class UserMod : IUserMod
    {

        public string Description
        {
            get
            {
                return "Find your Citizens, Cars, Buildings, Seagulls & More";
            }
        }

        public string Name
        {
            get
            {
                return "CTRL+F to find anything";
            }
        }
    }

    public class FindIt : LoadingExtensionBase
    {
        public static GameObject panel;

        public override void OnLevelLoaded(LoadMode mode)
        {
            DebugOutputPanel.AddMessage(ColossalFramework.Plugins.PluginManager.MessageType.Message, "HI");
            panel = new GameObject("FindItSearchPanel", typeof(SearchForSomeoneRandomPanel));
        }

        public override void OnLevelUnloading()
        {
            GameObject.Destroy(panel);
            panel = null;
        }
    }

    public class ChirpEvent : ChirperExtensionBase
    {
        public override void OnUpdate()
        {
            var panel = FindIt.panel.GetComponent<SearchForSomeoneRandomPanel>();
            if (panel == null)
                return;

            if (Input.GetKeyDown(KeyCode.Escape))
                panel.Hide();
            if (Event.current.control && Input.GetKeyDown(KeyCode.F))
                panel.Toggle();
            if(Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
                panel.ContinueSearchMayhaps();
            
            
        }
    }
}