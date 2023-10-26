using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public HealthBar ExpBar;
    int currentExp = 0;
    int currentLevel = 1;
    int requireExp = 30;
    public Health playerHealth;

    public GameObject levelUpPanel;

    // Level + exp
    public void UpdateExperience(int addExp)
    {
        currentExp += addExp;
        if (currentExp >= requireExp)
        {
            currentLevel++;
            currentExp = currentExp - requireExp;
            requireExp = (int)(requireExp * 2);
            // Increase maxHealth by 10
            playerHealth.maxHealth += 10;
            // Restore health to the new maxHealth
            playerHealth.currentHealth = playerHealth.maxHealth;
            // Update the health bar
            playerHealth.healthBar.UpdateHealth(playerHealth.currentHealth, playerHealth.maxHealth);
            // OpenLevelUpPanel();
            // Level up panel
        }
        // Update Exp bar
        ExpBar.UpdateBar(currentExp, requireExp, "Level " + currentLevel.ToString());
    }

    public void CloseLevelUpPanel()
    {
        CanvasGroup group = levelUpPanel.GetComponent<CanvasGroup>();
        group.alpha = 0;
        group.blocksRaycasts = false;
        group.interactable = false;
        Time.timeScale = 1;
    }

    public void OpenLevelUpPanel( )
    {
        CanvasGroup group = levelUpPanel.GetComponent<CanvasGroup>();
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
        Time.timeScale = 0;
    }
}
