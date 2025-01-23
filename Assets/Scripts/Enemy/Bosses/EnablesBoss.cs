using UnityEngine;

public class EnablesBoss : MonoBehaviour
{
    public GameObject boss;

    //If player hits collider
    void OnTriggerEnter(Collider other){
        
        //Enables boss
        boss.GetComponent<Animator>().enabled = true;
        boss.GetComponent<BossBehavior>().enabled = true;

    }
}
