using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int killCount = 0;
    public int exp = 0;
    public int gold = 0;
    public int wallet = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddKill()
    {
        killCount++;
    }

    public int GetKillCount()
    {
        return killCount;
    }

    public void LevelUpExp()
    {
        FindFirstObjectByType<LevelCOunt>().AddExp(exp);
    }

    public void killMoney(){
        wallet += gold;
    }

}
