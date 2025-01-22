using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public HealthBar healthBar;
    public MagicBar magicBar;
    public GameObject deathScreen;
    public float health = 100.0f;
    public float magic = 100.0f;
    private float maxMagic = 100.0f;
    public float attackCost = 5.0f;
    public float attack = 5.0f;
    void Start()
    {
        healthBar.SetMaxHealth(health);
        magicBar.setMaxMagic(magic);

    }

    // Update is called once per frame
    void Update()
    {
        magic += Time.deltaTime;
        if (magic > maxMagic){
            magic = maxMagic;
        }
        healthBar.SetHealth(health);
        magicBar.setMagic(magic);
        if (health <= 0)
        {
            deathScreen.SetActive(true);
        }
    }
    void OnTriggerEnter(Collider other){
        // if (other.gameObject.tag == "Enemy"){
        //     Debug.Log("Triggered in if statement");
        //     healthBar.SetHealth(health);

        // } else {
        //     Debug.Log("triggered outside of ifStatement");
        // }
    }

    //takes damage
    public void takeDamage(float enemyAttack)
    {
        health -= enemyAttack;
    }

    //consumesMagic
    public void consumesMagic()
    {
        magic -= attackCost;
    }

    //increases attack
    public void increaseAttack(float percentage)
    {
        float additionalAmount = attack * percentage;
        attack += additionalAmount;
    }
}
