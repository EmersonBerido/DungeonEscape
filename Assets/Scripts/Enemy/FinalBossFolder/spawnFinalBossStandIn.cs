using UnityEngine;

public class spawnFinalBossStandIn : MonoBehaviour
{
    public GameObject standIn;
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
        if (other.gameObject.tag == "MainCamera")
        {
            standIn.SetActive(true);
        }
        
    }
}
