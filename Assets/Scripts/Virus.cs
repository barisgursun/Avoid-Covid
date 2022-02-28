using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    private float prevLocalYPos;
    private float verticalSpeed = 5f;
    private float amplitude = 2f;
    void Start()
    {
        prevLocalYPos = transform.localPosition.y;

    }
    void Update()
    {
        MovementVirus();
    }
    public void MovementVirus()
    {
        // go up and down for virus
        float sineConst = Mathf.Sin(Time.time * verticalSpeed) * amplitude;

        transform.localPosition = new Vector3(transform.localPosition.x, prevLocalYPos + sineConst + 0.5f, transform.localPosition.z);

    }
    /*
    private void OnTriggerEnter(Collider other) 
    {
        // if the bullet hits the virus we destroy the virus
        if (other.gameObject.layer == LayerMask.NameToLayer("Bullet"))
        {
            Destroy(gameObject);
        }
    }
    */
}
