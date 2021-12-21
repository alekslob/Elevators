using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;
    // Update is called once per frame
    static public float maxX; 
    static public float minX;
    static public float maxY;
    static public float minY;
    void Update( )
    {
        Vector3 newPosition = camera.transform.position;
        if (Input.GetKey(KeyCode.UpArrow)) {
            if(newPosition.y < maxY) newPosition.y += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            if(newPosition.y > minY) newPosition.y -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            if(newPosition.x < maxX) newPosition.x += 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if(newPosition.x > minX)newPosition.x -= 1;
        }
        camera.transform.SetPositionAndRotation(newPosition,Quaternion.identity);
    }
}
