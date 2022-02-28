using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool playerAlive= true;
    public GameObject DeathEffect;

    public GameObject Hand;
    public GameObject Cross;
    private float PlayerHealth=500f;
    public PauseMenu pm;

    public GameObject GameOverUI;
    public void Death()
    {
        Debug.Log(PlayerHealth);
        PlayerHealth = PlayerHealth - 10f;

        if (playerAlive && PlayerHealth<0)
        {
            playerAlive = false;


            pm.isGameOver = true;

            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            Debug.Log("Game Over");

            // disable player movement
            GetComponent<PlayerMovement>().enabled = false;
            Hand.SetActive(false);
            Cross.SetActive(false);


            // cursor active
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;



            //enable gamoeovermenu
            GameOverUI.SetActive(true);
        }
    }
}
