using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTravel : MonoBehaviour
{
	public GameObject Player;
	public Vector3 L;
    public void OnClick()
    {
        HeroT Data = Player.GetComponent<HeroT>();
		Data.Ft(L);
		
    }
	public void Lo(Vector3 val){
		L = val;
		}
}
