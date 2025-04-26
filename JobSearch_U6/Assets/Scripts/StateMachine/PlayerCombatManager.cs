using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerCombatManager : MonoBehaviour
{
    [SerializeField] float playerCooldown;

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
    //public static UnityAction enemyDead;
    
    public PlayerCombatBaseState currentState;
    public PlayerCombatReadyState readyState = new PlayerCombatReadyState();
    public PlayerCombatCooldownState cooldownState = new PlayerCombatCooldownState();

    void OnEnable()
    {
        //CombatManager.playerAttack+=playerAttack;
        PlayerCombatCooldownState.cooldownOver+=leaveCooldown;
    }
    void OnDisable()
    {
        //CombatManager.playerAttack-=playerAttack;
        PlayerCombatCooldownState.cooldownOver+=leaveCooldown;
    }

    // Start is called before the first frame update
    void Start()
    {
        currentState = readyState;
        currentState.EnterState(this);

        //playerCombatManager = GetComponent<PlayerCombatManager>();
        setHealthMax();

        var ps = playerDisplay.GetComponent<CombatDisplay>();
        var es = enemyDisplay.GetComponent<CombatDisplay>();

        ps.data = playerData;
        es.data = enemyData;

        ps.setupDisplay();
        es.setupDisplay();

        attackButton.onClick.AddListener(attack); 
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnUpdate(this);
    }

    public void SwitchState(PlayerCombatBaseState state)
    {
        currentState.ExitState(this);
        currentState = state;
        state.EnterState(this);
    }

    void setHealthMax(){
        playerData.currentHP = playerData.maxHP;
        enemyData.currentHP = enemyData.maxHP;  
    }

    // void playerAttack(){
    //     cooldownState.totalCooldown = playerCooldown;
    //     SwitchState(cooldownState);
    // }
    public void attack(){
        if (currentState != readyState){
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
        cooldownState.totalCooldown = playerCooldown;
        SwitchState(cooldownState);
    }

    void leaveCooldown(){
        SwitchState(readyState);

        attackButton.interactable=true;
    }

    void backToGame(){
        SceneChanger.instance.changeScene("SampleScene");
    }
}
