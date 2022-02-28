using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Covid : MonoBehaviour
{
    private Transform player;
    public float Speed = 1f;

    public Vector3 Offset;

    public float FollowDistance = 10f;

    private float cooldown = 2f;
    public GameObject Mesh;
    public GameObject Bullet;

    public float Health = 100f;

    public GameObject DeathEffect;
    public AudioClip DeathSound;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        FollowPlayer();
        Shot();
        Death();
    }
    private void FollowPlayer()
    {

        //look to player
        transform.LookAt(player.position);
        transform.rotation *= Quaternion.identity;

        //move to player 
        if (Vector3.Distance(transform.position, player.position) >= FollowDistance)
        {
            transform.Translate(transform.forward * Time.deltaTime * Speed * -1);

        }
        else
        {
            transform.RotateAround(player.position, transform.up, Time.deltaTime * Speed * Random.Range(2f, 6f));
        }
    }
    private void Shot()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            cooldown = 2f;
           if(Vector3.Distance(transform.position, player.position) < FollowDistance +20f)
            {
                Mesh.GetComponent<Animator>().SetTrigger("shot");

                Instantiate(Bullet, transform.position, transform.rotation * Quaternion.Euler(new Vector3(180, 0, 0)));
            }
      
        }
    }
    private void Death()
    {
        if (Health <= 0)
        {
            Instantiate(DeathEffect, transform.position, Quaternion.identity);

            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(DeathSound);
            Destroy(this.gameObject);

        }
    }
}
