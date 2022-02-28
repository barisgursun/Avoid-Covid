using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private float rotationSpeed = 10f;
    private float verticalSpeed = 1f;

    private float amplitude = 0.5f;

    private float prevLocalYPos;
    // Start is called before the first frame update
    void Start()
    {
        prevLocalYPos = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        RotateObject();
        HoverObject();
    }

    private void RotateObject()
    {
        Vector3 temp = transform.localEulerAngles;
        temp += Vector3.up * rotationSpeed * Time.deltaTime;
        transform.localEulerAngles = temp;
    }

    private void HoverObject()
    {
        float sineConst = Mathf.Sin(Time.time * verticalSpeed) * amplitude;
        //Debug.Log(sineConst);
        transform.localPosition = new Vector3(transform.localPosition.x, prevLocalYPos + sineConst + 0.5f, transform.localPosition.z);
        //Debug.Log(transform.localPosition.y + sineConst);
    }
}
