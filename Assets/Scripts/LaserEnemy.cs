using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask Obstacle, PlayerLayer;
    public float LaserMultipler = 1f;
    private bool laser_hit;
    public float range = 100f;
    // Start is called before the first frame update
    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, Obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;
            laser_hit = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            GetComponent<LineRenderer>().startWidth = 0.025f * LaserMultipler + Mathf.Sin(Time.time) / 80;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
            laser_hit = false;
        }

        //kill player
        if (Physics.Raycast(transform.position, transform.forward, out hit, range, PlayerLayer))
        {

            if (laser_hit)
            {
                if(hit.transform.CompareTag("Player"))
                {
                    hit.transform.gameObject.GetComponent<PlayerManager>().Death();

                }

            }
        }
    }

}

// Update is called once per frame

