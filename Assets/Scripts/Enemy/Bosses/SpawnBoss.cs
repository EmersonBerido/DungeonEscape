using Unity.VisualScripting;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject finalBoss;
    public GameObject finalBossStandIn;
    private bool isActivatedOnce = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MainCamera" && isActivatedOnce == false)
        {
            isActivatedOnce = true;
            //spawn boss
            finalBossStandIn.SetActive(false);
            
            finalBoss.SetActive(true);
        }
    }
}
