using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapS : MonoBehaviour
{
	public GameObject Enable;
	public GameObject Enable1;
	public GameObject Enable3;
	
	public GameObject Cross;

	public GameObject Cam1;	
	public GameObject Cam2;
	public GameObject Cam3;

	public GameObject Disable1;

	public GameObject Disable7;
	public GameObject Disable8;
	public GameObject Disable9;
	public Animator transi;
	float time = 0.5f;

	public void LoadLevel(){
		
		StartCoroutine(RunRate());
		
	}
	
	IEnumerator RunRate ()
	{
		Cam1.SetActive(true);
		Disable9.SetActive(false);
		yield return new WaitForSeconds(1f);
		Cross.SetActive(true);
		Cam3.SetActive(false);
		Enable3.SetActive(true);		
		Enable.SetActive(true);
		Enable1.SetActive(true);
		Disable1.SetActive(false);
		Disable7.SetActive(false);
		Disable8.SetActive(false);	
		
	
	}
}
