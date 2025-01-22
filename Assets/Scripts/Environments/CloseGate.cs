using UnityEngine;

public class CloseGate : MonoBehaviour
{
    //---Variables---
    public GameObject trigger;
    public bool isEventFinished = false;
    public Vector3 defaultPosition;
    private Vector3 openPosition;
    public float speed = 5.0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Makes gate open at first
        defaultPosition = transform.position;
        openPosition = new Vector3(transform.position.x, (transform.position.y + 10), transform.position.z);
        transform.position = openPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (trigger.GetComponent<GateColliderPlate>().isTriggered && isEventFinished == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, defaultPosition, speed * Time.deltaTime);

        }
        if (isEventFinished)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition, speed * Time.deltaTime);
        }
    }
}
