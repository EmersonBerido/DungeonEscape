using UnityEngine;

public class EnemyRangedAttacks : MonoBehaviour
{
    float enemyAttack = 8f;

    //player variables
    Vector3 playerPosition;
    GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initializes player
        player = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        //initializes playerPosition
        playerPosition = player.transform.position;

        //Moves towards player while facing them
        transform.rotation = Quaternion.LookRotation(playerPosition - transform.position, Vector3.up);
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, 8.0f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            player.GetComponent<PlayerStats>().takeDamage(enemyAttack);
            Destroy(gameObject);
        }
    }
}
