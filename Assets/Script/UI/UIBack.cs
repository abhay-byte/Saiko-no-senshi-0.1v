using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBack : MonoBehaviour
{
	public GameObject Disable;

	
	public void OnMouseClick(){
		Disable.SetActive(false);

	}
}
