using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public GameObject CharacterToFollow;
    public Camera MainCamera;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = CharacterToFollow.transform.position -MainCamera. transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        SetPosition();
    }

    public void SetPosition()
    {
       MainCamera.transform.position = CharacterToFollow.transform.position - offset;
    }

    public void FollowMouse()
    {
        //transform.LookAt(Camera.main.ScreenToWorldPoint(GameController.Instance.m_Crosshair.transform.position));
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        if(Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            mouseX = touch.deltaPosition.x;
            mouseY = touch.deltaPosition.y;
        }

        var targetAngles = MainCamera.transform.localEulerAngles + new Vector3(-mouseY, mouseX, 0);
        var adjustedAngles = Vector3.zero;

        if (targetAngles.x > 180f)
        {
            targetAngles.x -= 360f;
        }
        adjustedAngles.x = Mathf.Clamp(targetAngles.x, -20f, 10f);

        if (targetAngles.y > 180f)
        {
            targetAngles.y -= 360f;
        }
        adjustedAngles.y = Mathf.Clamp(targetAngles.y, -30f, 30f);
        //adjustedAngles.y = targetAngles.y;
        MainCamera.transform.localEulerAngles = adjustedAngles;
    }

    public void Reset()
    {

    }
}
