using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class ItemButton : MonoBehaviour
{
    public TextMeshProUGUI itemName;
    public string dialogueText;
    public GameObject dialoguePrefab;


    //dialoguePrefab
    private GameObject itemAdd;
    private BattleScreenUI battleUiScript;
    [SerializeField] private Transform CombatCanvas;
    void Start()
    {
        CombatCanvas = GameObject.Find("CombatCanvas").GetComponent<Transform>();
        battleUiScript = GameObject.Find("--BattleUI_Manager--").GetComponent<BattleScreenUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPress()
    {
        /*itemAdd = Instantiate(dialoguePrefab);
        itemAdd.transform.SetParent(CombatCanvas);
        itemAdd.transform.DOLocalMove(new Vector3(0, 0, 0), 0, false);
        itemAdd.transform.DOScale(6, .5f);
        itemAdd.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialogueText;*/
        battleUiScript.closeFolder();
    }
}
