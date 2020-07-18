using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler_S : MonoBehaviour
{
    // Start is called before the first frame update
	public GameObject Disable;
	public GameObject UIElements0;
	public GameObject UIElements1;
	public GameObject UIElements2;
	public GameObject UIElements3;
	public GameObject UIElements4;
	public GameObject UIElements5;


	
	public void OnMouseClick(){
		Disable.SetActive(false);
		UIElements0.SetActive(true);
		UIElements1.SetActive(true);
		UIElements2.SetActive(true);
		UIElements3.SetActive(true);
		UIElements4.SetActive(true);
		UIElements5.SetActive(true);



	}
}
