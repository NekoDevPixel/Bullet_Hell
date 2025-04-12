using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int killCount = 0;

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

}
