using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public int floorNumber;
    public int entranceNumber;

    void OnMouseDown() {
        Vector3 newPosition = StateOfHouse.elevators[entranceNumber].transform.position;
        newPosition.y = StateOfHouse.START_POSITION_Y + StateOfHouse.HEIGHT_FLOOR * floorNumber;
        StateOfHouse.elevators[entranceNumber].transform.SetPositionAndRotation(newPosition, Quaternion.identity);
    }

    void Update(){
        
    }
}
