using UnityEngine;

public class GateColliderPlate : MonoBehaviour
{
    public bool isTriggered = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            isTriggered = true;
        }
    }
}
