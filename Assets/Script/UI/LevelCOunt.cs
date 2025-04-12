using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelCOunt : MonoBehaviour
{

    [Header("UI Components")]
    public Slider expSlider;
    public TextMeshProUGUI levelText;

    [Header("Level Info")]
    private int level = 0;
    public int currentExp = 0;
    public int expToLevelUp = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        expSlider.maxValue = expToLevelUp;
        expSlider.value = currentExp;
        UpdateLevelText();
    }

    void UpdateLevelText()
    {
        levelText.text = "Lv." + level;
    }

    public void AddExp(int amount)
{
        currentExp += amount;
        while (currentExp >= expToLevelUp)
        {
            currentExp -= expToLevelUp;
            LevelUp();
        }

    expSlider.value = currentExp;
}

    void LevelUp()
    {
        level++;
        expToLevelUp += 50; // 레벨업마다 필요 경험치 증가 (조절 가능)
        expSlider.maxValue = expToLevelUp;
        expSlider.value = currentExp;

        UpdateLevelText();
    }
}
