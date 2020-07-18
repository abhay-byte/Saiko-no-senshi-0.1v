using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToCharacter : MonoBehaviour
{
	public GameObject Enable;
	public GameObject Disable;
	
public void OnMouseClick()
	{ 
		Enable.SetActive(true);
		Disable.SetActive(false);
	}
}