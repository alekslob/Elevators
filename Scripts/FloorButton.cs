using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FloorButton : MonoBehaviour
{
    public int floorNumber;
    public int entranceNumber;

    float endFloor;
    float speed;
    void Start(){
        speed = 0;
        endFloor = StateOfHouse.START_POSITION_Y;
    }
    void OnMouseDown() {
            if(speed == 0){
                this.endFloor = StateOfHouse.START_POSITION_Y + StateOfHouse.HEIGHT_FLOOR * floorNumber;
                Vector3 newPosition = StateOfHouse.elevators[entranceNumber].transform.position;
                float startFloor = newPosition.y;
                if(startFloor < endFloor) speed = configOfElevator.SPEED_ELEVATOR;
                else{
                    if(startFloor > endFloor) speed = -configOfElevator.SPEED_ELEVATOR;
                }
            }
        }

    void Update(){
        // for(int i = 0; i<StateOfHouse.countOfEntrance; i++){
        if(speed != 0){
            Vector3 newPosition = StateOfHouse.elevators[entranceNumber].transform.position;
            float startFloor = newPosition.y;

            if(speed > 0 && startFloor < this.endFloor){
                newPosition.y += this.speed;
                StateOfHouse.elevators[entranceNumber].transform.SetPositionAndRotation(newPosition, Quaternion.identity);
            }
            else{
                if(speed < 0 && startFloor > this.endFloor){
                    newPosition.y += this.speed;
                    StateOfHouse.elevators[entranceNumber].transform.SetPositionAndRotation(newPosition, Quaternion.identity);
                }
                else speed = 0;
            }
        }
        // }
    }
}
