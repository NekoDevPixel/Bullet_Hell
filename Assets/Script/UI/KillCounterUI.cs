using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KillCounterUI : MonoBehaviour
{
    public TextMeshProUGUI killText;

    void Update()
    {
        killText.text = "" + GameManager.Instance.GetKillCount();
    }
}
