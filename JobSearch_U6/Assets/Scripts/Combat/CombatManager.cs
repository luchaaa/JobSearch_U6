using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    //****OLD STUFF, MOVED TO PLAYER COMBAT MANAGER TO KEEP TOGETHER*****
    //data references
    [Header("Data")]
    public CombatInformation playerData;
    public CombatInformation enemyData;

    //setup references
    [Space(10)]
    [Header("UI References")]
    [SerializeField] GameObject playerDisplay;
    [SerializeField] GameObject enemyDisplay;
    [SerializeField] Button attackButton;

    //events
    public static UnityAction playerAttack;
    public static UnityAction enemyDead;

    private PlayerCombatManager playerCombatManager;

    void OnEnable()
    {
        PlayerCombatCooldownState.cooldownOver+=enableAttack;
    }
    void OnDisable()
    {
        PlayerCombatCooldownState.cooldownOver-=enableAttack;
    }

    void Start()
    {
        playerCombatManager = GetComponent<PlayerCombatManager>();
        setHealthMax();

        var ps = playerDisplay.GetComponent<CombatDisplay>();
        var es = enemyDisplay.GetComponent<CombatDisplay>();

        ps.data = playerData;
        es.data = enemyData;

        ps.setupDisplay();
        es.setupDisplay();

        attackButton.onClick.AddListener(attack);  
    }
 
    void setHealthMax(){
        playerData.currentHP = playerData.maxHP;
        enemyData.currentHP = enemyData.maxHP;  
    }

    public void attack(){
        if (playerCombatManager.currentState != playerCombatManager.readyState){
            Debug.Log("cannot attack yet!");
            return;
        }
        enemyData.currentHP-=2;

        attackButton.interactable=false;

        if (enemyData.currentHP <= 0){
            attackButton.gameObject.SetActive(false);

            enemyData.currentHP = 0;
            //enemyDead(); //event called when enemy dies
            
            Debug.Log("you defeated the enemy!");
            Invoke("backToGame", 2f);//call this elsewhere i think
        }
        playerAttack();
    }

    void backToGame(){
        SceneChanger.instance.changeScene("SampleScene");
    }

    void enableAttack(){
        attackButton.interactable=true;
    }

}
