using TMPro;
using UnityEngine;

public class gameTime : MonoBehaviour
{
    private float sec = 0;
    private int min = 0;
    public TextMeshProUGUI GameTime;

    void Update()
    {
        sec += Time.deltaTime;
        if (sec >= 60f)
        {
            min += 1;
            sec = 0;
        }
 
        GameTime.text = string.Format("{0:D2}:{1:D2}", min, (int)sec);
    }

    
}
