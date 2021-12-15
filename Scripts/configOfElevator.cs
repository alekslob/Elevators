using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class configOfElevator : MonoBehaviour
{
    public InputField speedInput;
    public InputField timeInput;

    public int SPEED_ELEVATOR;
    public int TIME_STAY;
    // Start is called before the first frame update
    void Start()
    {
        SPEED_ELEVATOR = 2;
        TIME_STAY = 3;
        speedInput.GetComponent<InputField>().text = SPEED_ELEVATOR.ToString();
        timeInput.GetComponent<InputField>().text = TIME_STAY.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        SPEED_ELEVATOR = Convert.ToInt32(speedInput.GetComponent<InputField>().text);
        TIME_STAY = Convert.ToInt32(timeInput.GetComponent<InputField>().text);
    }
}
