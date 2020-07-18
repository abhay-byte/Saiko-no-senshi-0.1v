using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMap : MonoBehaviour
{
	
    Rigidbody2D rigidbody2d;
    
    Vector2 lookDirection = new Vector2(1,0);
    public VariableJoystick variableJoystick;
	public float speed = 3.0f;
	   
    void Start()
    {
         rigidbody2d = GetComponent<Rigidbody2D>();      
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = variableJoystick.Horizontal;
        float vertical = variableJoystick.Vertical;
                
        Vector2 move = new Vector2(horizontal, vertical);
        
        if(!Mathf.Approximately(move.x, 0.0f) || !Mathf.Approximately(move.y, 0.0f))
        {
            lookDirection.Set(move.x, move.y);
            lookDirection.Normalize();
        }
       
        Vector2 position = rigidbody2d.position;
        
        position = position + move * speed * Time.deltaTime;
        
        rigidbody2d.MovePosition(position);        
    }
}
