using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CombatDisplay : MonoBehaviour
{
    //references to displays
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI healthText;

    //data
    public CombatInformation data;

    #region events
    private void OnEnable() {
        PlayerCombatManager.playerAttack+=updateHealth;
    }
    private void OnDisable() {
        PlayerCombatManager.playerAttack-=updateHealth;
    }
    #endregion

    //functions
    public void setupDisplay(){
        nameText.text = data.charName;
        healthText.text = "Health: "+ data.currentHP + "/" + data.maxHP;
    }

    public void updateHealth(){
        healthText.text = "Health: "+ data.currentHP + "/" + data.maxHP;
    }
}
