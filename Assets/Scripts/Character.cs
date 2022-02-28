using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : Singleton<Character>
{
    private float horizontalSpeed = 0.8f;
    private float forwardSpeed = 10f;

    //mouse delta things 
    private Vector3 currentPosition = Vector3.zero;
    private Vector3 deltaPosition = Vector3.zero;
    private Vector3 lastPosition = Vector3.zero;

    private bool stopMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = Input.mousePosition;

        if (GameController.Instance.GameStarted)
        {
            MoveForward();

            if (Input.GetMouseButton(0))
            {
                MoveHorizontally();
            }
        }

        deltaPosition = currentPosition - lastPosition;
        lastPosition = currentPosition;
    }

    private void MoveForward()
    {
        if (!stopMovement)
        {
            if (transform.position.z < 236f) // 236f road length
            {
                transform.position += Vector3.forward * forwardSpeed * Time.deltaTime;
            }
        }

    }

    private void MoveHorizontally()
    {
        //forwardSpeed = 12f;
        float touchHorizontal = 0f;
        float horizontalMoveDrag = 0f;

        if (Input.touchCount > 0)
        {
            touchHorizontal = Input.GetTouch(0).deltaPosition.x * Time.deltaTime * horizontalSpeed;
        }
        else
        {
            horizontalMoveDrag = deltaPosition.x * Time.deltaTime * horizontalSpeed;
        }

        if (Input.touchCount > 0)
        {
            transform.position += new Vector3(touchHorizontal, 0, 0);
        }
        else
        {
            transform.position += new Vector3(horizontalMoveDrag, 0, 0);
        }


        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, -2f, 2f);
        transform.position = clampedPos;
        //cam.transform.position += transform.position;
    }

    public void EndGame(bool success)
    {
        if (success) // you are going to cut shit at this point
        {

            GameController.Instance.LevelCompleted();
        }
        else
        {

            GameController.Instance.GameOver();
        }
    }

    private IEnumerator MoveObject(GameObject obj, Vector3 target, float time)
    {
        float t = 0f;
        float waitT = time;
        Vector3 oldPos = obj.transform.position;

        while (t < waitT)
        {
            obj.transform.position = Vector3.Lerp(oldPos, target, (t / waitT));
            t += Time.deltaTime;

            yield return null;
        }

        obj.transform.position = target;
    }

    private IEnumerator MoveObject(GameObject obj, GameObject targetObj, float time)
    {
        float t = 0f;
        float waitT = time;
        Vector3 curPos = obj.transform.position;

        while (t < waitT)
        {
            obj.transform.position = Vector3.Lerp(curPos, targetObj.transform.position, (t / waitT));
            t += Time.deltaTime;

            yield return null;
        }
        obj.transform.position = targetObj.transform.position;
    }

    private IEnumerator RotateObject(GameObject obj, Vector3 target, float time)
    {
        float t = 0f;
        float waitT = time;
        Vector3 curRot = obj.transform.localEulerAngles;

        while (t < waitT)
        {
            obj.transform.localEulerAngles = Vector3.Lerp(curRot, target, (t / waitT));
            t += Time.deltaTime;

            yield return null;
        }
        obj.transform.localEulerAngles = target;
    }
}
