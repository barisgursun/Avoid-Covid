using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public bool Player_Enter, Player_Exit;
    private bool Spawnded = false;
    public Transform[] Virus_Spawner;
    public GameObject VirusCovid;
    public GameObject Level;
    public GameObject Destroy_Level;
    //  public Transform LevelLocation;
    private void Awake()
    {
        Player_Enter = false;
        Spawnded = false;
    }
    private void Update()
    {

        if (!Spawnded)
        {
            if (Player_Enter)
            {
                //virus spawn
                for (int i = 0; i < Virus_Spawner.Length; i++)
                {
                    Instantiate(VirusCovid, Virus_Spawner[i].transform.position, Quaternion.identity);

                }

                //level spawn
                SpawnLevel();

                //set bool
                Spawnded = true;
            }
        
        }
        if (Player_Exit)
        {
            if(Destroy_Level != null)
            {
                Destroy(Destroy_Level);

            }

        }
    }
    private void SpawnLevel()
    {
        Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 70f);
        GameObject obj = Instantiate(Level, pos, Quaternion.identity);
        obj.GetComponent<LevelManager>().Destroy_Level = this.gameObject;
    }
    private void DestroyLevel()
    {
    }

}
