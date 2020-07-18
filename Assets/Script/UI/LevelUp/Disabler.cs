using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disabler : MonoBehaviour
{
	public GameObject Button;
	public GameObject UIElements0;
	public GameObject UIElements1;
	public GameObject UIElements2;
	public GameObject UIElements3;
	public GameObject UIElements4;
	public GameObject UIElements5;
	public GameObject UIElements6;
	public GameObject UIElements7;
	public GameObject UIElements8;
	public GameObject UIElements9;
	public GameObject UIElements10;
	public GameObject UIElements11;
	public GameObject UIElements12;
	public GameObject UIElements13;
	public GameObject UIElements14;
	public GameObject UIElements15;
	
	public void OnMouseClick(){
		Button.SetActive(false);
		UIElements0.SetActive(true);
		UIElements1.SetActive(true);
		UIElements2.SetActive(true);
		UIElements3.SetActive(true);
		UIElements4.SetActive(true);
		UIElements5.SetActive(true);
		UIElements6.SetActive(true);
		UIElements7.SetActive(true);
		UIElements8.SetActive(true);
		UIElements9.SetActive(true);
		UIElements10.SetActive(true);
		UIElements11.SetActive(true);
		UIElements12.SetActive(true);
		UIElements13.SetActive(true);
		UIElements14.SetActive(true);
		UIElements15.SetActive(true);

	}
}
