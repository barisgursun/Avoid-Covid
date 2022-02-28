using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Startup : MonoBehaviour
{
    public Slider SliderMouse;
    // Start is called before the first frame update
    private void Awake()
    {
        //moseu sens

        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().MouseSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 225);
        SliderMouse.value = PlayerPrefs.GetFloat("MouseSensitivity", 225);

    }
}
