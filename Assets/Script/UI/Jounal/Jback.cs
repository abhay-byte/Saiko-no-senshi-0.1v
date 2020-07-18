using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jback : MonoBehaviour
{

	public GameObject Disable1;
	
	public void OnMouseClick(){
		Disable1.SetActive(false);
	}
}