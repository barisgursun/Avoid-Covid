using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public LevelManager LM;
    public bool Enter;
    private void OnTriggerEnter(Collider other)
    {
        if(Enter)
        {
            LM.Player_Enter = true;

        }
        else
        {
            LM.Player_Exit = true;
        }
    }
}
