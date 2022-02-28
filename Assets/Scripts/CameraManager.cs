using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    private bool cameraFlag = false;
    [SerializeField] private GameObject player;
    private Vector3 camResetPos;
    private Vector3 camResetRot;
    //private Vector3 offset = new Vector3(0.015f, 1.751f, -0.27f);

    // Start is called before the first frame update
    void Start()
    {
        camResetPos = Camera.main.transform.position; //new Vector3(0f, 8.8f, -8.9f);//(0f, 3.12f, -3.77f); //new Vector3(0, 2.31f, -2.64f);//new Vector3(0, 2.67f, -3.56f);
        camResetRot = Camera.main.transform.localEulerAngles; //new Vector3(6.702f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (cameraFlag)
        {
            cameraFlag = false;
            player = GameObject.FindGameObjectWithTag("Player");
            Debug.Log("Player found in update method");

            transform.parent = player.transform;
            //transform.localPosition = offset;

            //Debug.Log("transform.pos after parenting is  " + transform.position);
            Debug.Log("Player is parent now");

            //transform.localPosition = new Vector3(0, 2, 0);
            //Debug.Log("local pos is ready");
            //transform.localPosition = new Vector3(0, 2, 0);
        }
        else if (player == null)
        {
            cameraFlag = true;
            Debug.Log("Player must be found");
            transform.position = camResetPos;
            transform.eulerAngles = camResetRot;
        }
        //else
        //{
        //    transform.position = new Vector3(transform.position.x, player.transform.position.y + 3f, transform.position.z);
        //}
    }
}
