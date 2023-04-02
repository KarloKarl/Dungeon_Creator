using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{

    public enum directions{
        Top,Left,Right,Down
    }
    public static Camera mainCamera;
    public GameObject  player;
    public float leftCameraEdgeX ;
    public float bottomCameraEdgeY;
    public float topCameraEdgeY;
    public float rightCameraEdgeX;

    public Vector2 speed=new Vector2(1,1);

    public Vector3 playerPosition;
    Vector3 cameraPosition;
    // Start is called before the first frame update
       void Awake()
    {  
        mainCamera = Camera.main;
        player = GameObject.Find("playerMain");
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
        if(playerPosition.x<(leftCameraEdgeX)){
            moveCamera(directions.Left,speed);
        }
        if(playerPosition.x>(rightCameraEdgeX)){
            moveCamera(directions.Right,speed);
        }
         if(playerPosition.y<(topCameraEdgeY)){
            moveCamera(directions.Top,speed);
        }
         if(playerPosition.y>(bottomCameraEdgeY)){
            moveCamera(directions.Down,speed);
        }
    }

    void moveCamera(directions direction,Vector2 speed){
        switch (direction){
            case directions.Left:
                mainCamera.transform.position= new Vector3(cameraPosition.x - speed.x, cameraPosition.y, cameraPosition.z);
                break;
            case directions.Right:
                mainCamera.transform.position= new Vector3(cameraPosition.x + speed.x, cameraPosition.y, cameraPosition.z);
                break;
            case directions.Top:
                mainCamera.transform.position= new Vector3(cameraPosition.x, cameraPosition.y-speed.y, cameraPosition.z);
                break;
            case directions.Down:
                mainCamera.transform.position= new Vector3(cameraPosition.x, cameraPosition.y+speed.y, cameraPosition.z);
                break;
        }
        updateInfo();
        
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
   float GetPercentWidth(float percent)
{
    percent /= 100f;
    float screenWidth = Screen.width;
    float worldWidth = bottomCameraEdgeY * mainCamera.orthographicSize * 2f * mainCamera.aspect;
    float widthInGrid = worldWidth * percent / bottomCameraEdgeY;
    return widthInGrid;
}

float getPercentHeight(float percent)
{
    percent /= 100f;
    float screenHeight = Screen.height;
    float worldHeight = 2 * rightCameraEdgeX * mainCamera.orthographicSize * 2f;
    float heightInGrid = 2 *  worldHeight * percent / rightCameraEdgeX;
    return heightInGrid;
}
}
