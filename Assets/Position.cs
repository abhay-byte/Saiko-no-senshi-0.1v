using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{

	public GameObject Player;

	void Start()
	{
		
	}
		
    void Update()
    {
        HeroT Data = Player.GetComponent<HeroT>();
		transform.position = Data.Poval;
		
    }
}
