using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flash_controls : MonoBehaviour
{
    GameObject playerMain;
    public Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        playerMain=GameObject.Find("playerMain");
    }
    

    //set position of flashlight to playerMain
    void FixedUpdate()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        direction = new Vector3(inputX,inputY,0);
        
        transform.rotation = directionToRotation(direction);
        transform.position = playerMain.transform.position;
    }

    //function that transforms direction(Vector 3 from Input (values can only be 0 or 1)) to rotation (Quaternion)
    Quaternion directionToRotation(Vector3 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }
   
}
