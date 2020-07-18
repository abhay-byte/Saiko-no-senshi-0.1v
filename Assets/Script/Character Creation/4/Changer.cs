using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Changer : MonoBehaviour
{
    // Start is called before the first frame update
	public int points = 60;
	public Text selectedName1;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	public void Changepoint(int amount)
	{
		points = points + amount;
		
		string s1;
		s1 = (points).ToString();
		selectedName1.text = s1;
		Next4 A = GetComponent<Next4>();
		A.Point(points);
	}
}
