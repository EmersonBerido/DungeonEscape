using UnityEngine;

public class Ladder : MonoBehaviour
{
    public GameObject escapeScreen;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            escapeScreen.SetActive(true);
        }
    }
}
