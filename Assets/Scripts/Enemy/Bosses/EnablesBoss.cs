using UnityEngine;

public class EnablesBoss : MonoBehaviour
{
    public GameObject boss;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        boss.GetComponent<Animator>().enabled = true;
        boss.GetComponent<BossBehavior>().enabled = true;

    }
}
