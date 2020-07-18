using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatPoint : MonoBehaviour
{
    // Start is called before the first frame update
	public double points ;
	public Text selectedName1;

    void Start()
    {
		NonUP Data = GetComponent<NonUP>();
		points = (Data.ULevel)*5;
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
		NonUP A = GetComponent<NonUP>();
		A.Point1(points);
	}

}