using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public int numberOfEntrance;
    public int numberOfCurrentFloor;
    public List<int> queue = new List<int>();

    private float time = 0;
    
    // Start is called before the first frame update
    void Start() {}

    // Update is called once per frame
    void Update() {
        if (this.time > 0) {
            this.time -=Time.deltaTime;
            
        } else {
            if (StateOfHouse.buttons[this.numberOfEntrance][this.numberOfCurrentFloor].GetComponent<SpriteRenderer>().color == Color.white) {
                StateOfHouse.buttons[this.numberOfEntrance][this.numberOfCurrentFloor].GetComponent<SpriteRenderer>().color = Color.green;
            }
            if (this.queue.Count > 0) {
                if (this.queue[0] > this.numberOfCurrentFloor) {
                    this.numberOfCurrentFloor = StateOfHouse.ChangeElevatorPosition(this.numberOfEntrance, true);
                } else if (this.queue[0] < this.numberOfCurrentFloor) {
                    this.numberOfCurrentFloor = StateOfHouse.ChangeElevatorPosition(this.numberOfEntrance, false);
                } 
                // else {
                if (this.queue.Contains(this.numberOfCurrentFloor)){
                    this.time = ConfigOfElevator.time;
                    StateOfHouse.buttons[this.numberOfEntrance][this.numberOfCurrentFloor].GetComponent<SpriteRenderer>().color = Color.white;
                    // this.queue.Dequeue();
                    this.queue.Remove(this.numberOfCurrentFloor);
                }
            }
        }  
    }
}
