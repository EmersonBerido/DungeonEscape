using UnityEngine;
using UnityEngine.UI;

public class MagicBar : MonoBehaviour
{
    //bar starts at 0 and ends at 140
    //treat 40 as a 0
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Slider magicBar;

    public void setMaxMagic(float magic)
    {
        magicBar.maxValue = magic + 40;
        magicBar.value = magicBar.maxValue;
    }

    public void setMagic(float magic)
    {
        magicBar.value = magic + 40;
    }
   
}
