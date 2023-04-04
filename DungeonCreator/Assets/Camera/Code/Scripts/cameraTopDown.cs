using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraTopDown : MonoBehaviour
{
  public Transform target;

    void Start()
    {
        // Finde das Objekt mit dem Namen "playerMain" und weise es der Variable target zu
        target = GameObject.Find("playerMain").transform;
    }

   //der Spieler zieht die Kamera hinter sich her wenn er sich in die nähe des Kamerarands bewegt
   void LateUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }

}
