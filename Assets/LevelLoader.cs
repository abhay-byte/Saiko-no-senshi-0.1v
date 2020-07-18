using System.Collections;
using System.Collections.Generic;
using System;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
	public GameObject LoadingScene;
	public Slider slider;
	public Animator transi;
	public Text Percent;
	
	public void LoadLevel(int sceneIndex){
		
		StartCoroutine(LoadAsynchronously(sceneIndex));
		
	}
	
	IEnumerator LoadAsynchronously (int sceneIndex)
	{	
		transi.SetTrigger("Start");
		yield return new WaitForSeconds(1);

		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
		LoadingScene.SetActive(true);		

		
		while (!operation.isDone)
		{
			float progress = Mathf.Clamp01(operation.progress / .9f);
			slider.value = progress;
			int val = Convert.ToInt32(progress*100);
			Percent.text = val+"%";
			
			yield return null;
		}
	}
}