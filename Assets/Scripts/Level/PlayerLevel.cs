using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private float xpNeededPerLevel;
    [SerializeField] private float xpRequirementIncreasePerLevel;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private Slider xpBar;
    [SerializeField] private float xpGivenPerDeath;

    private float currentXP;
    private int currentLevel;

    public static Action OnPlayerLeveledUp;

    private void Start()
    {
        Enemy.OnEnemyDeath += Handle_EnemyDeath;
        currentXP = 0;
        currentLevel = 1;
        UpdateUI();
    }

    private void Handle_EnemyDeath(Enemy e)
    {
        currentXP += xpGivenPerDeath;
        if (currentXP >= xpNeededPerLevel)
        {
            LevelUp();
        }
        UpdateUI();
    }

    private void LevelUp()
    {
        currentLevel++;
        xpNeededPerLevel += xpRequirementIncreasePerLevel;
        currentXP = 0;
        OnPlayerLeveledUp?.Invoke();
    }

    private void UpdateUI()
    {
        levelText.text = currentLevel.ToString();
        var ratio = currentXP / xpNeededPerLevel;
        xpBar.value = ratio;
    }
}
