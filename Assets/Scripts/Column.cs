using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{

    public Transform Checker;
    public LayerMask Player_Layer;

    public Vector3 Velocity;
    private bool broke = false;

    private void Update()
    {
        if (Physics.CheckBox(Checker.position, new Vector3(3f, 2f, 3f), Quaternion.identity,Player_Layer))
        {
            broke = true;
        }
        if(broke)
        {
            Velocity.y -= Time.deltaTime/500;
            transform.Translate(Velocity);
        }
    }
}
