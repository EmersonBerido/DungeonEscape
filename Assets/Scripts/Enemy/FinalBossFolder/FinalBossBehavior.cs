using System.IO;
using UnityEngine;

public class FinalBossBehavior : MonoBehaviour
{
    //Stats
    public float health = 90;



    Vector3 defaultPosition;
    Vector3 standardYPosition;
    public float speed;
    public float swayAmount = 19;
    private float internalTimer;
    private float fireballTimer;
    private float skeletonTimer;
    public GameObject skeletonMinion;
    public GameObject player;
    public GameObject fireball;
    Vector3 playerPosition;
    public GameObject ladder;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultPosition = transform.position;
        standardYPosition = new Vector3(transform.position.x, transform.position.y + 5, transform.position.z);
        player = GameObject.Find("Main Camera");
        
    }

    // Update is called once per frame
    void Update()
    {
        internalTimer += Time.deltaTime;
        fireballTimer += Time.deltaTime;
        skeletonTimer += Time.deltaTime;

        //boss moves upwards
        if (internalTimer > 3.0f)
        {
             transform.position = Vector3.MoveTowards(transform.position, standardYPosition, Time.deltaTime * 3.0f);
 
        }

        //enables hitbox
        if (internalTimer > 6)
        {
            gameObject.GetComponent<BoxCollider>().enabled = true;
            
        }

        //sways
        if (internalTimer > (8 * Mathf.PI / 3))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, SinAmount());
        }

        //rotates towards player
        playerPosition = player.transform.position;
        transform.rotation = Quaternion.LookRotation(playerPosition - transform.position, Vector3.up);
        

        //spawn skeleton minions every 3 seconds
        if (skeletonTimer > 3.0f)
        {
            skeletonTimer = 0.0f;
            //spawns skeletons
            float varyingSpawnDistance = Random.Range(-10, 11f);
            Instantiate(skeletonMinion, new Vector3(defaultPosition.x + varyingSpawnDistance, 4f, defaultPosition.z), Quaternion.identity);
        }

        //shoot fireball every 5 seconds
        if (fireballTimer > 10.0f)
        {
            Debug.Log("Fireball launched");
            //shoot fireball
            fireballTimer = 0.0f;
            float varyingDistance = Random.Range (-2, 2.1f);
            Instantiate(fireball, new Vector3(transform.position.x + varyingDistance, transform.position.y + varyingDistance, transform.position.z), Quaternion.identity); 
        }
        
    }

    private float SinAmount(){
        return Mathf.Sin(Time.time * speed) * swayAmount;
    }

    void OnMouseDown(){
        Debug.Log("triggered");
        //if player has enough magic to attack
        if (player.GetComponent<PlayerStats>().magic > player.GetComponent<PlayerStats>().attackCost)
        {
            //enemy loses health
            health -= player.GetComponent<PlayerStats>().attack;

            player.GetComponent<PlayerStats>().consumesMagic();
        }
        if(health < 0){
            ladder.SetActive(true);
            Destroy(gameObject);
        }

        //if player magic is 0, destroy player
        
    }
}
