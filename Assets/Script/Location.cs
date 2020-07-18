using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Core;
using UnityEngine.UI;
public class Location : InstanceTracker<Location>
{
	public Text location;
	public string name = "";
	
        void OnTriggerEnter2D(Collider2D other)
        {
            location.text = name;
        }

        void OnTriggerExit2D(Collider2D other)
        {
            location.text = "Xirsia Isle";
        }
	
}
