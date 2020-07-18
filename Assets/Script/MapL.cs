using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MapL : MonoBehaviour
{
	public GameObject Player;
	public Text Lol;
	public string l;
	public Vector3 l1;
	
	public void OnClick()
	{
		Lol.text = l;
        FastTravel Data = Player.GetComponent<FastTravel>();
		Data.Lo(l1);
	}
}
