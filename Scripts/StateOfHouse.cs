using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class StateOfHouse : MonoBehaviour
{
    public static int countOfFloor;
    public static int countOfEntrance;

    // Prefabs
    public GameObject elevator;
    public GameObject floor;
    public GameObject button;

    public List<List<GameObject>> floors = new List<List<GameObject>>();
    public static List<GameObject> elevators = new List<GameObject>();
    public static List<List<GameObject>> buttons = new List<List<GameObject>>();

    public InputField floorCountInput;
    public InputField entranceCountInput;

    public static float WIDTH_FLOOR = 116;
    public static float HEIGHT_FLOOR = 50;
    public static float START_POSITION_Y = -200;

    private void CreateElevator(int numberOfEntrance) {
        float avgX = (float) (StateOfHouse.countOfEntrance - 1.0f) / 2.0f;
        Vector3 elevatorPosition = floor.transform.position;
        elevatorPosition.x += WIDTH_FLOOR * (numberOfEntrance - avgX);
        elevatorPosition.y = START_POSITION_Y;
        StateOfHouse.elevators.Add(Instantiate(elevator, elevatorPosition, Quaternion.identity));
        StateOfHouse.elevators[numberOfEntrance].GetComponent<Elevator>().numberOfEntrance = numberOfEntrance;
        StateOfHouse.elevators[numberOfEntrance].GetComponent<Elevator>().numberOfCurrentFloor = 0;
    }

    private void CreateFloor(int numberOfEntrance, int numberOfFloor) {
        float avgX = (float) (StateOfHouse.countOfEntrance - 1.0f) / 2.0f;
        Vector3 floorPosition = floor.transform.position;
        floorPosition.x += WIDTH_FLOOR * (numberOfEntrance - avgX);
        floorPosition.y += START_POSITION_Y + HEIGHT_FLOOR * numberOfFloor;
        this.floors[numberOfEntrance].Add(Instantiate(floor, floorPosition, Quaternion.identity));
    }

    private void CreateElevatorButton(int numberOfEntrance, int numberOfFloor) {
        float avgX = (float) (StateOfHouse.countOfEntrance - 1.0f) / 2.0f;
        Vector3 floorButtonPosition = button.transform.position;
        floorButtonPosition.x = WIDTH_FLOOR * (numberOfEntrance - avgX) + 20;
        floorButtonPosition.y = START_POSITION_Y + HEIGHT_FLOOR * numberOfFloor;
        StateOfHouse.buttons[numberOfEntrance].Add(Instantiate(button, floorButtonPosition, Quaternion.identity));
        StateOfHouse.buttons[numberOfEntrance][numberOfFloor].GetComponent<FloorButton>().floorNumber = numberOfFloor;
        StateOfHouse.buttons[numberOfEntrance][numberOfFloor].GetComponent<FloorButton>().entranceNumber = numberOfEntrance;
    }

    private void DestroyHouse() {
        for(int i = 0; i < this.floors.Count; i++) {
            Destroy(StateOfHouse.elevators[i]);
            for(int j = 0; j < this.floors[i].Count; j++) {
                Destroy(this.floors[i][j]);
                Destroy(StateOfHouse.buttons[i][j]);
            }
        }
        for(int i = 0; i < this.floors.Count; i++) {
            this.floors[i].Clear();
            StateOfHouse.buttons[i].Clear();
        }
        this.floors.Clear();
        StateOfHouse.elevators.Clear();
        StateOfHouse.buttons.Clear();
    }

    private void GetInput() {
        StateOfHouse.countOfEntrance = Convert.ToInt32(this.entranceCountInput.text);
        StateOfHouse.countOfFloor = Convert.ToInt32(this.floorCountInput.text);
        if (StateOfHouse.countOfEntrance < 1) StateOfHouse.countOfEntrance = 1;
        if (StateOfHouse.countOfFloor < 1) StateOfHouse.countOfFloor = 1;
    }

    public void OnClick() {
        try {
            this.GetInput();
            this.DestroyHouse();
            for(int i = 0; i < StateOfHouse.countOfEntrance; i++) {
                this.floors.Add(new List<GameObject>());
                StateOfHouse.buttons.Add(new List<GameObject>());
                this.CreateElevator(i);
                for(int j = 0; j < StateOfHouse.countOfFloor; j++) {
                    this.CreateFloor(i,j);
                    this.CreateElevatorButton(i,j);
                }
            
                
            }
            CameraController.maxX = this.floors[countOfEntrance-1][0].transform.position.x;
            CameraController.minX = this.floors[0][0].transform.position.x;
            CameraController.maxY = this.floors[0][countOfFloor-1].transform.position.y;
            CameraController.minY = this.floors[0][0].transform.position.y;
            Debug.Log(this.floors[countOfEntrance-1][0].transform.position.x);
            Debug.Log(this.floors[0][countOfFloor-1].transform.position.y);
        }
        catch (FormatException)
        {
            Debug.Log("Введены неверные данные");
        }   
    }

    public static int ChangeElevatorPosition(int numberOfEntrance, bool isUp) {
        Vector3 elevatorPosition = StateOfHouse.elevators[numberOfEntrance].transform.position;
        if (isUp) {
            elevatorPosition.y += ConfigOfElevator.speed;
        } else {
            elevatorPosition.y -= ConfigOfElevator.speed;
        }
        StateOfHouse.elevators[numberOfEntrance].transform.SetPositionAndRotation(elevatorPosition, Quaternion.identity);
        float numberOfFloor = (elevatorPosition.y - StateOfHouse.START_POSITION_Y) / StateOfHouse.HEIGHT_FLOOR;
        if (isUp) {
            if (numberOfFloor > StateOfHouse.countOfFloor * StateOfHouse.HEIGHT_FLOOR) return StateOfHouse.countOfFloor;
            return (int) numberOfFloor;
        } else {
            if (numberOfFloor < 0) return 0;
            return (int) numberOfFloor + 1;
        }
    }
}
