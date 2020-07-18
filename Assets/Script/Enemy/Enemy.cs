using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 3.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D;
    float timer;
    int direction = 1;
    


	void Start()
{
     rigidbody2D = GetComponent<Rigidbody2D>();
     timer = changeTime;
}

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
        
        
        Vector2 position = rigidbody2D.position;

 
        rigidbody2D.MovePosition(position);
    }
    
    void OnCollisionEnter2D(Collision2D other)
    {
        Player_Action_Anim player = other.gameObject.GetComponent<Player_Action_Anim>();

        if (player != null)
        {
            Debug.Log("Hit");

        }
    }
	
    public void DisplayDialog()
    {
        Debug.Log("avc");
    }
}