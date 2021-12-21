using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConfigOfElevator : MonoBehaviour
{
    public InputField speedInput;
    public InputField timeInput;

    public static float speed;
    public static float time;

    void Start() {
        this.speedInput.text = "0,3";
        this.timeInput.text = "2";
        ConfigOfElevator.speed = 0.3f;
        ConfigOfElevator.time = 2;
    }

    public void OnClick() {
        ConfigOfElevator.speed = float.Parse(this.speedInput.text);
        ConfigOfElevator.time = float.Parse(this.timeInput.text);
        if (ConfigOfElevator.speed < 0.1f) ConfigOfElevator.speed = 0.1f;
        if (ConfigOfElevator.time < 0) ConfigOfElevator.time = 0;
    }
}
