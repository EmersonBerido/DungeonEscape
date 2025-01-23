using UnityEngine;

public class spawnFinalBossStandIn : MonoBehaviour
{
    public GameObject standIn;
        void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            standIn.SetActive(true);
        }
        
    }
}
