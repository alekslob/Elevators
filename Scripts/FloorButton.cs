using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FloorButton : MonoBehaviour
{
    public int floorNumber;
    public int entranceNumber;

    
    static public float endFloor =-1;
    // float speed;
    void Start(){
        // endFloor = StateOfHouse.START_POSITION_Y;
    }
    void OnMouseDown() {
            //добавление список вызываемых этажей
            configOfElevator.elevatorsTasks[entranceNumber].listFloors.Add(floorNumber);
            ElevatorsTask task = configOfElevator.elevatorsTasks[entranceNumber];
            if(task.endFloor != -1){   //Если еще не выбран приоритетный этаж и нет этажей в задаче
                //прилритетный этаж
                configOfElevator.elevatorsTasks[entranceNumber].endFloor = floorNumber;
                configOfElevator.elevatorsTasks[entranceNumber].task = 1;
            }
            //смена цвета
            //


            // if(speed == 0){
            //     this.
            //     Vector3 newPosition = StateOfHouse.elevators[entranceNumber].transform.position;
            //     float startFloor = newPosition.y;
            //     if(startFloor < endFloor) speed = configOfElevator.SPEED_ELEVATOR;
            //     else{
            //         if(startFloor > endFloor) speed = -configOfElevator.SPEED_ELEVATOR;
            //     }
            // }
        }

    void Update(){
        // for(int i = 0; i<StateOfHouse.countOfEntrance; i++){
        // if(speed != 0){
        //     Vector3 newPosition = StateOfHouse.elevators[entranceNumber].transform.position;
        //     float startFloor = newPosition.y;

        //     if(speed > 0 && startFloor < this.endFloor){
        //         newPosition.y += this.speed;
        //         StateOfHouse.elevators[entranceNumber].transform.SetPositionAndRotation(newPosition, Quaternion.identity);
        //     }
        //     else{
        //         if(speed < 0 && startFloor > this.endFloor){
        //             newPosition.y += this.speed;
        //             StateOfHouse.elevators[entranceNumber].transform.SetPositionAndRotation(newPosition, Quaternion.identity);
        //         }
        //         else {
        //             newPosition.y = endFloor;
        //             StateOfHouse.elevators[entranceNumber].transform.SetPositionAndRotation(newPosition, Quaternion.identity);
        //             speed = 0;
        //         }
        //     }
        // }
        // }
    }
}
