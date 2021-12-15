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
    public List<List<GameObject>> buttons = new List<List<GameObject>>();

    public InputField floorCountInput;
    public InputField entranceCountInput;

    public static float WIDTH_FLOOR = 116;
    public static float HEIGHT_FLOOR = 50;
    public static float START_POSITION_Y = -200;

    public void OnClick() {
        try
        {
            StateOfHouse.countOfEntrance = Convert.ToInt32(this.entranceCountInput.text);
            StateOfHouse.countOfFloor = Convert.ToInt32(this.floorCountInput.text);
            if (StateOfHouse.countOfEntrance < 1) StateOfHouse.countOfEntrance = 1;
            if (StateOfHouse.countOfFloor < 1) StateOfHouse.countOfFloor = 1;
            for(int i = 0; i < this.floors.Count; i++) {
                Destroy(StateOfHouse.elevators[i]);
                for(int j = 0; j < this.floors[i].Count; j++) {
                    Destroy(this.floors[i][j]);
                    Destroy(this.buttons[i][j]);
                }
            }
            for(int i = 0; i < this.floors.Count; i++) {
                this.floors[i].Clear();
                this.buttons[i].Clear();
            }
            this.floors.Clear();
            StateOfHouse.elevators.Clear();
            this.buttons.Clear();
            float avgX = (float) (StateOfHouse.countOfEntrance - 1.0f) / 2.0f;
            for(int i = 0; i < StateOfHouse.countOfEntrance; i++) {
                this.floors.Add(new List<GameObject>());
                this.buttons.Add(new List<GameObject>());
                
                Vector3 elevatorPosition = floor.transform.position;
                elevatorPosition.x += WIDTH_FLOOR * (i - avgX);
                elevatorPosition.y = START_POSITION_Y;
                
                StateOfHouse.elevators.Add(Instantiate(elevator, elevatorPosition, Quaternion.identity));

                for(int j = 0; j < StateOfHouse.countOfFloor; j++) {
                    Vector3 floorPosition = floor.transform.position;
                    floorPosition.x += WIDTH_FLOOR * (i - avgX);
                    floorPosition.y += START_POSITION_Y + HEIGHT_FLOOR * j;
                    
                    this.floors[i].Add(Instantiate(floor, floorPosition, Quaternion.identity));

                    Vector3 floorButtonPosition = button.transform.position;
                    floorButtonPosition.x = WIDTH_FLOOR * (i - avgX) + 20;
                    floorButtonPosition.y = START_POSITION_Y + HEIGHT_FLOOR * j;
                    
                    this.buttons[i].Add(Instantiate(button, floorButtonPosition, Quaternion.identity));
                    this.buttons[i][j].GetComponent<FloorButton>().floorNumber = j;
                    this.buttons[i][j].GetComponent<FloorButton>().entranceNumber = i;
                }
            }
        }
        catch (FormatException)
        {
            Debug.Log("Введены неверные данные");
        }   
    }
}
