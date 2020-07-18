using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enabler : MonoBehaviour
{
	public int i;
	public GameObject Button;
	public GameObject UIElements0;
	public GameObject UIElements1;
	public GameObject UIElements2;
	public GameObject UIElements3;
	public GameObject UIElements4;
	public GameObject UIElements5;
	public GameObject UIElements6;

	
	void Update(){
		NonUP Data = UIElements6.GetComponent<NonUP>();
		i = Data.ULevel;		
	}
	
	public void OnMouseClick(){

		if (i >= 1){ 
		Button.SetActive(true);
		UIElements0.SetActive(false);
		UIElements1.SetActive(false);
		UIElements2.SetActive(false);
		UIElements3.SetActive(false);
		UIElements4.SetActive(false);
		UIElements5.SetActive(false);

		}
	}
}
