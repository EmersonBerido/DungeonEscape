using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    public GameObject player;
    private Vector3 playerPosition;
    public GameObject leftGate;
    public GameObject rightGate;
    public GameObject fireball;
    public GameObject rewardScreen;
    public float health;
    public bool isRanged;
    private float speed = 1.5f;
    private float swayAmount = 15;
    private float internalTimer;
    private Vector3 defaultPosition;
    private bool moveBack = false;
    public float enemyAttack;
    public bool isPlayerRewarded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        defaultPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        internalTimer += Time.deltaTime;

        playerPosition = player.transform.position;
        transform.rotation = Quaternion.LookRotation(playerPosition - transform.position, Vector3.up);
        
        if (isRanged && internalTimer >  2.0f){ //if projectile based

            
            float varyingDistance = Random.Range (-3, 3.1f);
            Instantiate(fireball, new Vector3(transform.position.x + varyingDistance, transform.position.y, transform.position.z), Quaternion.identity); 
            internalTimer = 0;
        }
        if(isRanged == false && moveBack == false) 
        { //if melee based
            transform.position = Vector3.MoveTowards(transform.position, playerPosition, 4f * Time.deltaTime);
        } else if (isRanged == false && moveBack == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, defaultPosition, 9 * Time.deltaTime);
            if (transform.position == defaultPosition)
            {
                moveBack = false;
            }
        }


        if(health <= 0){
            leftGate.GetComponent<CloseGate>().isEventFinished = true;
            rightGate.GetComponent<CloseGate>().isEventFinished = true;
            if (isPlayerRewarded)
            {
                rewardScreen.SetActive(true);
            }
            Destroy(gameObject);
        }
        
    }

//work on this later so that when boss collides with player he moves backwards and attacks again
    void OnTriggerEnter(Collider other){
        Debug.Log("on trigger enter is triggered");
        if (other.gameObject.tag == "MainCamera"){
            moveBack = true;
            player.GetComponent<PlayerStats>().takeDamage(enemyAttack);
        }
    }

    private float SinAmount(){
        return Mathf.Sin(Time.time * speed) * swayAmount;
    }

    void OnMouseDown(){
        if (player.GetComponent<PlayerStats>().magic > player.GetComponent<PlayerStats>().attackCost)
        {
            health -= player.GetComponent<PlayerStats>().attack;
            player.GetComponent<PlayerStats>().consumesMagic();
        }
    }
    
}
