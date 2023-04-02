using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{

    public enum directions{
        Top,Left,Right,Down
    }
    private  Camera mainCamera;
    private  GameObject player;
    public float leftCameraEdgeX ;
    public float bottomCameraEdgeY;
    public float topCameraEdgeY;
    public float rightCameraEdgeX;

    public Vector2 speed=new Vector2(20,20);

    public Vector3 playerPosition;
     Vector3 cameraPosition;
    // Start is called before the first frame update
    void Start()
    {  
        player = GameObject.Find("playerMain");
        mainCamera = Camera.main;
        playerPosition = player.transform.position;
        cameraPosition = mainCamera.transform.position;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        leftCameraEdgeX = mainCamera.transform.position.x - cameraWidth / 2f;
        bottomCameraEdgeY = mainCamera.transform.position.y - mainCamera.orthographicSize;
        topCameraEdgeY = mainCamera.transform.position.y + mainCamera.orthographicSize;
        rightCameraEdgeX = mainCamera.transform.position.x + cameraWidth / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        cameraPosition = Camera.main.transform.position;
        if(playerPosition.x<(leftCameraEdgeX+getPercentWidth(0.2f))){
            mainCamera.transform.position= new Vector3(cameraPosition.x - speed.x, cameraPosition.y, cameraPosition.z);
        }
        if(playerPosition.x>(rightCameraEdgeX-getPercentWidth(0.2f))){
            mainCamera.transform.position= new Vector3(cameraPosition.x + speed.x, cameraPosition.y, cameraPosition.z);
        }
         if(playerPosition.y>(topCameraEdgeY-getPercentWidth(0.2f))){
            mainCamera.transform.position= new Vector3(cameraPosition.x + speed.x, cameraPosition.y, cameraPosition.z);
        }
         if(playerPosition.x>(bottomCameraEdgeY-getPercentWidth(0.2f))){
            mainCamera.transform.position= new Vector3(cameraPosition.x + speed.x, cameraPosition.y, cameraPosition.z);
        }
    }

    void moveCamera(directions direction,Vector2 speed){
        switch (direction){
            case directions.Left:
                mainCamera.transform.position= new Vector3(cameraPosition.x - speed.x, cameraPosition.y, cameraPosition.z);
              
                break;
        }
        
    }

    void updateInfo(){
        cameraPosition = mainCamera.transform.position;
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;
        leftCameraEdgeX = mainCamera.transform.position.x - cameraWidth / 2f;
        bottomCameraEdgeY = mainCamera.transform.position.y - mainCamera.orthographicSize;
        topCameraEdgeY = mainCamera.transform.position.y + mainCamera.orthographicSize;
        rightCameraEdgeX = mainCamera.transform.position.x + cameraWidth / 2f;
    }
    
    // 0.0<per<=1.0 z.B. 0.3f=30% 
    float getPercentWidth(float per){
        float screenWidth = Screen.width;
        float widthInPixels = per * screenWidth;
        return widthInPixels;
    }

    float getPercentHeight(float per){
    float screenHeight = Screen.height;
    float heightInPixels = per * screenHeight;
    return heightInPixels;
}
}
