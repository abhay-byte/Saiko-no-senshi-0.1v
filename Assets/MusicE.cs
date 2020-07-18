using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicE : MonoBehaviour
{
	public GameObject Disable; 
	
	 public void Enable1(bool val1)
		{
					Disable.SetActive(val1);
		}
	
}