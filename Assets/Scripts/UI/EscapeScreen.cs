using UnityEngine;
using UnityEngine.SceneManagement;

public class EscapeScreen : MonoBehaviour
{
    private float time;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > 6)
        {
            //loads title screen
            SceneManager.LoadScene(0);
        }
    }
}
