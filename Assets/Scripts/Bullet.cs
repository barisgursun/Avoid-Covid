using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Instantiate  objects destroy after a certain period of time
    public float Speed = 1f;
    public float Lifetime = 5f;
    public GameObject Hit_Effect;
    public AudioClip Hit_Sound;

    private void Update()
    {
        transform.Translate(Vector3.forward * -1f * Time.deltaTime * Speed); // move the forward bullet
        Lifetime = Lifetime - Time.deltaTime;
        if (Lifetime <= 0)
        {
            Destroy(this.gameObject); // after 5 second , Objects that do not hit the virus destroy
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        
        // if hit  enemy
        if(other.CompareTag("Enemy"))
        {
            GameObject ParentCovid = other.transform.parent.gameObject;
            ParentCovid.GetComponent<Covid>().Health -= 25f;
            ParentCovid.GetComponent<AudioSource>().PlayOneShot(Hit_Sound);

        }
        //hit
        Instantiate(Hit_Effect, transform.position, transform.rotation);
        Destroy(this.gameObject);
        
    }

}
