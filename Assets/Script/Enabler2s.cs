using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Core;
using UnityEngine.UI;
public class Enabler2s : InstanceTracker<Location>
{
	 public GameObject obj;
	
        void OnTriggerEnter2D(Collider2D other)
        {
		obj.SetActive(false);

        }

        void OnTriggerExit2D(Collider2D other)
        {
		obj.SetActive(true);

        }
	
}

