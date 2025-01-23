using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;

    //player variables
    public GameObject player;
    private Vector3 playerPrevPosition;
    private Vector3 playerCurrentPosition;
    
    //spawn variables
    public GameObject bossRoomTrigger;
    private int amount;
    private int randomEnemyIndex;
    public bool isActivatedOnce = false;
    int chanceToSpawn;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chanceToSpawn = Random.Range(1, 101);
    }

    void OnTriggerExit(Collider other)
    {
        //spawns enemies once with a 75% chance
        if (other.gameObject.tag == "MainCamera" && isActivatedOnce == false && chanceToSpawn < 75)
        {
            //randomizes amount of enemies spawned
            amount = Random.Range(-2, 3);

            //for each enemy
            for (int i = 0; i < amount; i++)
            {
                //randomizes which enemy is spawned & where
                randomEnemyIndex = Random.Range(0, enemies.Length);
                float randomZ = Random.Range(-3,4);

                //spawns enemy
                Instantiate(enemies[randomEnemyIndex], new Vector3(transform.position.x + 20.0f, 4f, (transform.position.z + randomZ)), Quaternion.identity);
            }
            isActivatedOnce = true;
        }
        
    }
    
}
