using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubCat : MonoBehaviour
{
	public GameObject Enable1;
	public GameObject Enable2;
	public GameObject Enable3;
	public GameObject Enable4;
	public GameObject Disable1;
	public GameObject Disable2;
	public GameObject Disable3;
	public GameObject Disable4;
	public GameObject Disable5;
	public GameObject Disable6;
	
	public void Click()
	{
		Enable1.SetActive(true);
		Enable2.SetActive(true);
		Enable3.SetActive(true);
		Enable4.SetActive(true);
		Disable1.SetActive(false);
		Disable2.SetActive(false);
		Disable3.SetActive(false);
		Disable4.SetActive(false);
		Disable5.SetActive(false);
		Disable6.SetActive(false);
		
	}
}