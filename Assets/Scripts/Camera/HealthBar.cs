using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //healthbar starts at 0 and ends at 140
    //treat 40 as a 0
    public Slider slider;

    public void SetHealth(float health)
    {
        Debug.Log("setHealth method accessed");
        Debug.Log("health passed in"+health);
        slider.value = health + 40;
    }

    public void SetMaxHealth(float health)
    {
        
        slider.maxValue = health + 40;
        slider.value = health + 40;
    }
}
