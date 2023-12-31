﻿// realvirtual (R) Framework for Automation Concept Design, Virtual Commissioning and 3D-HMI
// (c) 2019 realvirtual GmbH - Usage of this source code only allowed based on License conditions see https://realvirtual.io/en/company/license

using System;
using System.Linq;
using UnityEngine;


namespace realvirtual
{
    //! Adds this Gameobject to a defined group. Is used for filtering the View or for defining a new kinematic structure with Kinematic script.
    [HelpURL("https://doc.realvirtual.io/components-and-scripts/motion/group")]
    public class Group : realvirtualBehavior
    {
        // Start is called before the first frame update
        public string GroupName; //!< The Group name
        public GameObject GroupNamePrefix; //!< A prefix for the Groupname (used for using Groups in reusable Prefabs)

        // Gets the Groupname
        public string GetGroupName()
        {
            if (GroupNamePrefix!=null)
                return (GroupNamePrefix.name + GroupName);
            else
                return GroupName;
        }
        
        // Gets the text for the hierarchy view
        public string GetVisuText()
        {
            string text = "";
            // Collect all groups
            var groups = GetComponents<Group>().ToArray();

            for (int i = 0; i < groups.Length; i++)
            {
                if (i != 0)
                    text = text + "/";
                text = text + groups[i].GroupName;
            }

            return text;
        }

        
        private new void Awake()
        {
            
        }


        public void ChangeConnectionMode()
        {
            
        }
        
    }
}