using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    //References
    public HealthBar healthBar;
    public MagicBar magicBar;
    public GameObject deathScreen;
    
    //Stats
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
    
    //takes damage method
    public void takeDamage(float enemyAttack)
    {
        health -= enemyAttack;
    }

    //consumes Magic method
    public void consumesMagic()
    {
        magic -= attackCost;
    }

    //increases attack method
    public void increaseAttack(float percentage)
    {
        float additionalAmount = attack * percentage;
        attack += additionalAmount;
    }
}
