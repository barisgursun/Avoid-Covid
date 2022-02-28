using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyringaController : MonoBehaviour
{
    public LayerMask ObstacleLayer;
    RaycastHit hit;
    public Vector3 Offset;
    public GameObject Bullet;
    public Transform FirePoint;
    public AudioClip GunShoot;

    public GameObject Hand;

    private float coolDown;

    private void Update()
    {

        //look
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, ObstacleLayer))
        {
            // hit.point -->  ray point vec3 coordinates
            // hit.transform.position // references the center of the object we hit 
            // transform.LookAt() this function , When you enter any location, it allows that object to look at the location we have given.

           Hand. transform.LookAt(hit.point);

           Hand. transform.rotation *= Quaternion.Euler(Offset);
        }
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        //fire
        if (Input.GetMouseButtonDown(0) && coolDown <= 0)
        {
            
            Instantiate(Bullet, transform.position, transform.rotation); // create bullet gameobject

            //reset cooldown
            coolDown = 0.25f;

            //sound
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(GunShoot,0.5f);


            //animation
            GetComponent<Animator>().SetTrigger("Shot");
        }

    }
}
