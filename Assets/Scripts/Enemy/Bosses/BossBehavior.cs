using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    //player variables
    public GameObject player;
    private Vector3 playerPosition;

    //win variables
    public GameObject leftGate;
    public GameObject rightGate;
    public GameObject fireball;
    public GameObject rewardScreen;

    //Boss stats
    public float health;
    public bool isRanged;
    private float speed = 1.5f;
    private float swayAmount = 15;

    //Miscellaneous
    private float internalTimer;
    private Vector3 defaultPosition;
    private bool moveBack = false;
    public float enemyAttack;
    public bool isPlayerRewarded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //initializes defaultPosition
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        internalTimer += Time.deltaTime;

        //initializes playerPosition & rotates towards player
        playerPosition = player.transform.position;
        transform.rotation = Quaternion.LookRotation(playerPosition - transform.position, Vector3.up);
        
        //if Boss is ranged, shoot fireballs
        if (isRanged && internalTimer >  2.0f){ 

            //Randomizes where fireballs are instantiated
            float varyingDistance = Random.Range (-3, 3.1f);
            Instantiate(fireball, new Vector3(transform.position.x + varyingDistance, transform.position.y, transform.position.z), Quaternion.identity); 

            //Resets internalTimer
            internalTimer = 0;

        }

        //if Boss is melee based & not moving towards defaultPosition
        if(isRanged == false && moveBack == false) 
        { 
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, 4f * Time.deltaTime);
        } else if (isRanged == false && moveBack == true)
        {

            //Moves object towards defaultPosition
            transform.position = Vector3.MoveTowards(transform.position, defaultPosition, 9 * Time.deltaTime);
            if (transform.position == defaultPosition)
            {
                moveBack = false;
            }

        }

        //If game object's health reaches 0
        if(health <= 0){

            //Opens gates
            leftGate.GetComponent<CloseGate>().isEventFinished = true;
            rightGate.GetComponent<CloseGate>().isEventFinished = true;

            //If game object rewards player
            if (isPlayerRewarded)
            {
                //Activates reward screen
                rewardScreen.SetActive(true);
            }

            //Destroys game object
            Destroy(gameObject);
        }
        
    }

    //If game object collides
    void OnTriggerEnter(Collider other){
        
        //If game object collides with player
        if (other.gameObject.tag == "MainCamera"){

            moveBack = true;

            //Player takes damage
            player.GetComponent<PlayerStats>().takeDamage(enemyAttack);
        }
    }

    //returns float depending on sin wave
    private float SinAmount(){
        return Mathf.Sin(Time.time * speed) * swayAmount;
    }

    //If game object is clicked
    void OnMouseDown(){
        //if player has enough magic to attack
        if (player.GetComponent<PlayerStats>().magic > player.GetComponent<PlayerStats>().attackCost)
        {
            //game object takes damage
            health -= player.GetComponent<PlayerStats>().attack;

            //player consumes magic
            player.GetComponent<PlayerStats>().consumesMagic();
        }
    }
    
}
