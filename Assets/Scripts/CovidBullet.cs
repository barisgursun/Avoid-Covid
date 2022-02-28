using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CovidBullet : MonoBehaviour
{
    // Instantiate  objects destroy after a certain period of time
    public float Speed = 1f;
    public float Lifetime = 5f;
    public bool Enemy_Bullet = false;
    public float Bullet_Radius = 0.5f;
    public LayerMask Playere_Layer;
    private void Update()
    {
        transform.Translate(Vector3.forward * -1f * Time.deltaTime * Speed * 100f); // move the forward bullet
        Lifetime = Lifetime - Time.deltaTime;
        if (Lifetime <= 0)
        {
            Destroy(this.gameObject); // after 5 second , Objects that do not hit the virus destroy
        }
        if (Enemy_Bullet)
        {
            if (Physics.CheckSphere(transform.position, Bullet_Radius, Playere_Layer))
            {
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManager>().Death();

                }

            }
        }
    }
}
