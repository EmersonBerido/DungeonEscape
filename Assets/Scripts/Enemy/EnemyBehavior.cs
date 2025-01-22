using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    //---Variables---

    //-> Enemy Stats 
    public float enemyHealth;
    public float enemyAttack;

    //-> Enemy Movement
    public float swayDistance; 
    //only enemies w ranged attacks will sway
    public bool isSwaying;
    public float swaySpeed;
    private float internalTimer;
    public GameObject fireball;

    //-> Enemy Attacks
    public float movementSpeed;
    private Vector3 defaultPosition;

    //-> Player
    public GameObject player;
    private Vector3 playerPosition;
    public float enemyDamage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Main Camera");
        defaultPosition = transform.position;
        enemyDamage = player.GetComponent<PlayerStats>().attack;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = player.transform.position;
        if (isSwaying){
            //sways left and right
            transform.position = new Vector3(transform.position.x, transform.position.y, SinAmount());
        } else{
            //moves towards player
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, movementSpeed * Time.deltaTime);
        }

        //rotates towards player
        transform.rotation = Quaternion.LookRotation(playerPosition - transform.position, Vector3.up);

        //Unique to EyeEnemy
        internalTimer += Time.deltaTime;
        if (isSwaying && internalTimer > 5.0f)
        {
            Instantiate(fireball, transform.position, Quaternion.identity);
            internalTimer = 0;

        }
    
    }
    void OnMouseDown()
    {
        Debug.Log("triggered");
        //if player has enough magic to attack
        if (player.GetComponent<PlayerStats>().magic > player.GetComponent<PlayerStats>().attackCost)
        {
            //enemy loses health
            enemyHealth -= enemyDamage;

            player.GetComponent<PlayerStats>().consumesMagic();
        }

        //if enemy health is 0, destroy enemy
        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    public float SinAmount(){
        return Mathf.Sin(Time.time * swaySpeed) * swayDistance;
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
