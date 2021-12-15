using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update( )
    {
        Vector3 newPosition = camera.transform.position;
        if (Input.GetKey(KeyCode.UpArrow)) {
            newPosition.y += 1;
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            newPosition.y -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            newPosition.x += 1;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            newPosition.x -= 1;
        }
        camera.transform.SetPositionAndRotation(newPosition,Quaternion.identity);
    }
}
