using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorsTask{
    public int task;
    public List<int> listFloors  = new List<int>();
    public int endFloor;

    public ElevatorsTask(){
        this.task = 0;
        this.listFloors = new List<int>();
        this.endFloor = -1;
    }
}
public class configOfElevator : MonoBehaviour
{
    public InputField speedInput;
    public InputField timeInput;

    static public float SPEED_ELEVATOR;
    static public int TIME_STAY;

    static public List<ElevatorsTask> elevatorsTasks = new List<ElevatorsTask>();
 
    // Start is called before the first frame update
    void Start()
    {
        SPEED_ELEVATOR = 0.01f;
        TIME_STAY = 3;
        speedInput.GetComponent<InputField>().text = SPEED_ELEVATOR.ToString();
        timeInput.GetComponent<InputField>().text = TIME_STAY.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        for(int i=0; i<StateOfHouse.countOfEntrance; i++){
            switch(elevatorsTasks[i].task){
                default:    //ожидание
                    break;
                case(1):    //двигаться на заданый этаж

                    this.mooveElevator(i);
                    break;
                case(2):    //открываем двери
                    break;
                case(3):    //ожидание
                    break;
                case(4):    //закрыть двери
                    break;
            }
        }
    }

    public void OnClick() {
        SPEED_ELEVATOR = (float) Convert.ToDouble(speedInput.GetComponent<InputField>().text);
        TIME_STAY = Convert.ToInt32(timeInput.GetComponent<InputField>().text);
    }

    void mooveElevator(int entrance){
            Vector3 newPosition = StateOfHouse.elevators[entrance].transform.position;
            float startPosition = newPosition.y;
            int floor = elevatorsTasks[entrance].endFloor;
            float endPosition = StateOfHouse.START_POSITION_Y + StateOfHouse.HEIGHT_FLOOR * floor;
            float speed = SPEED_ELEVATOR;
            if(startPosition < endPosition){
                newPosition.y += speed;
                StateOfHouse.elevators[entrance].transform.SetPositionAndRotation(newPosition, Quaternion.identity);
            }
            else{
                if(startPosition > endPosition){
                    newPosition.y += speed;
                    StateOfHouse.elevators[entrance].transform.SetPositionAndRotation(newPosition, Quaternion.identity);
                }
                else {
                    newPosition.y = endPosition;
                    StateOfHouse.elevators[entrance].transform.SetPositionAndRotation(newPosition, Quaternion.identity);
                    elevatorsTasks[entrance].task = 2;
                }
            }
    }
    
}
