using UnityEngine;

public class EnemyRangedAttacks : MonoBehaviour
{
    float enemyAttack = 8f;
    Vector3 playerPosition;
    GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Main Camera");
        
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
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
