using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_controls : MonoBehaviour
{
    public Vector2 speed = new Vector2(5,5);
    public Vector2 direction = new Vector2(0,1);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(speed.x*inputX, speed.y*inputY,0);
        direction = new Vector2(inputX,inputY);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }

}
