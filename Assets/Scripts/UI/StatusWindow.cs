using UnityEngine;
public class StatusWindow : MonoBehaviour
{
    public GameObject player;

    public void giveBuffs()
    {
        player.GetComponent<PlayerStats>().increaseAttack(0.5f);
        //set it off to
        gameObject.SetActive(false);
    }
    
}
