using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public GameObject player;
    public GameObject bossRoomTrigger;
    //enemies should spawn within a diameter of 9 meters
    private int amount;
    private int randomEnemyIndex;
    
    public bool isActivatedOnce = false;
    private Vector3 playerPrevPosition;
    private Vector3 playerCurrentPosition;
    int chanceToSpawn;

    //there will be multiple triggrs that will activate the spawn manager

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        chanceToSpawn = Random.Range(1, 101);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        Debug.Log("Triggered"+"is Activated Once: "+isActivatedOnce + gameObject.name);
        
        if (other.gameObject.tag == "MainCamera" && isActivatedOnce == false && chanceToSpawn < 75)
        {
            amount = Random.Range(-2, 3);
        for (int i = 0; i < amount; i++)
        {
            randomEnemyIndex = Random.Range(0, enemies.Length);
            float randomZ = Random.Range(-3,4);
            Instantiate(enemies[randomEnemyIndex], new Vector3(transform.position.x + 20.0f, 4f, (transform.position.z + randomZ)), Quaternion.identity);

            // if (enemies[randomEnemyIndex].GetComponent<EnemyBehavior>().isSwaying == true)
            // {
            //     Instantiate(enemies[randomEnemyIndex], new Vector3(transform.position.x + 20.0f, 7.5f, transform.position.z), Quaternion.identity);
            // } else
            // {
            //     Instantiate(enemies[randomEnemyIndex], new Vector3(transform.position.x + 20.0f, 4f, (transform.position.z + randomZ)), Quaternion.identity);
            // }
        }
            isActivatedOnce = true;
        }
        
    }
    
}
