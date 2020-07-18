using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross : MonoBehaviour
{
	public GameObject Disable1;
	public GameObject Disable2;
	public GameObject Disable3;
	public GameObject Enable1;
	public GameObject Enable7;
	public GameObject Enable8;
	public GameObject Enable9;
	public Animator transi;
    float time = 0.5f;	

	public GameObject Cross;
	
	public void LoadLevel(){
		
		StartCoroutine(RunRate());
		
	}
	
	IEnumerator RunRate ()
	{	


		Disable3.SetActive(false);

		Enable9.SetActive(true);


		yield return new WaitForSeconds(1.9f);
		Enable1.SetActive(true);
		Enable7.SetActive(true);
		Enable8.SetActive(true);

		Disable1.SetActive(false);
		Disable2.SetActive(false);
		Cross.SetActive(false);		
	}
}
