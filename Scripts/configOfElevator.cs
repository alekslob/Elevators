using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class configOfElevator : MonoBehaviour
{
    public InputField speedInput;
    public InputField timeInput;

    // Start is called before the first frame update
    void Start()
    {
        speedInput.GetComponent<InputField>().text = 4;
        timeInput..GetComponent<InputField>().text = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick() {
        
    }
}
