using Unity.VisualScripting;
using UnityEngine;

public class SpawnBoss : MonoBehaviour
{
    public GameObject finalBoss;
    public GameObject finalBossStandIn;
    private bool isActivatedOnce = false;
    
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
