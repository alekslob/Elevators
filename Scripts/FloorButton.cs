using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    public int floorNumber;
    public int entranceNumber;

    void OnMouseDown() {
        StateOfHouse.buttons[entranceNumber][floorNumber].GetComponent<SpriteRenderer>().color = Color.red;
        StateOfHouse.elevators[entranceNumber].GetComponent<Elevator>().queue.Add(floorNumber);
    }
}