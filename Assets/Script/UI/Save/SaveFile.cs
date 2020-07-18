using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveFile : MonoBehaviour
{
	public GameObject Enable;
	public GameObject Disable1;
	public GameObject Disable2;
	public GameObject Disable3;
	public GameObject Disable4;
	public GameObject Disable5;
	
	public void OnMouseClick(){
		Enable.SetActive(true);
		Disable1.SetActive(false);
		Disable2.SetActive(false);
		Disable3.SetActive(false);
		Disable4.SetActive(false);
		Disable5.SetActive(false);
	}
}
