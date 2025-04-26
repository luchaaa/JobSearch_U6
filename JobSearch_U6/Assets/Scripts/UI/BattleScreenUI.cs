using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;
using TMPro;


public class BattleScreenUI : MonoBehaviour
{
    [Header("--Folders--")]
    public GameObject folderBG;
    public GameObject folderImages;
    public GameObject actionFolder;
    public GameObject itemFolder;
    [SerializeField] private Transform contentPanel;
    public Sprite actionFolderTab;
    public Sprite itemFolderTab;

    [Header("--Lists--")]
    public List<ItemClass> items;
    public List<ActionClass> actions;

    [Header("--Prefabs--")]
    private Button itemAdd;
    public Button actionPrefab;
    public Button itemPrefab;

    [Header("--Audio--")]
    public AudioSource paper;
    public AudioSource click;




    // Start is called before the first frame update
    void Start()
    {
        folderBG.SetActive(false);
        openActions();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region buttonFunctions
    public void openActions()
    {
        paper.Play();
        populateFolderwithActions(actions);
        folderImages.transform.DOLocalMoveY(-800, .2f, false);
    }
    public void openItems()
    {
        paper.Play();
        populateFolderwithItems(items);
        folderImages.transform.DOLocalMoveY(-800, .2f, false);
    }
    IEnumerator closeFolders()
    {
        click.Play();
        folderImages.transform.DOLocalMoveY(-1031, .2f, false);
        folderBG.GetComponent<Image>().DOFade((float)0, .2f);
        yield return new WaitForSeconds(.2f);
        folderBG.SetActive(false);



    }
    #endregion

    public void populateFolderwithActions(List<ActionClass> items)
    {
        folderImages.GetComponent<Image>().sprite = actionFolderTab;
        folderBG.SetActive(true);
        folderBG.GetComponent<Image>().DOFade((float)0.7, .2f);
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }
        foreach (ActionClass item in items)
        {
            itemAdd = Instantiate(actionPrefab);
            itemAdd.transform.SetParent(contentPanel);
            itemAdd.GetComponent<ActionButton>().actionName.text = item.name;
            itemAdd.GetComponent<ActionButton>().dialogueText = item.dialogueText;

        }
    }
    public void populateFolderwithItems(List<ItemClass> items)
    {
        folderImages.GetComponent<Image>().sprite = itemFolderTab;
        folderBG.SetActive(true);
        folderBG.GetComponent<Image>().DOFade((float)0.7, .2f);
        foreach (Transform child in contentPanel)
        {
            Destroy(child.gameObject);
        }
        foreach (ItemClass item in items)
        {
            itemAdd = Instantiate(itemPrefab);
            itemAdd.transform.SetParent(contentPanel);
            itemAdd.GetComponent<ItemButton>().itemName.text = item.name;
            itemAdd.GetComponent<ItemButton>().dialogueText = item.dialogueText;

        }
    }
    public void OnPointerClick(PointerEventData pointerEventData)
    {
        
        if(name == "FolderBG")
        {
            print("working");
        }
    }

    public void closeFolder()
    {
        StartCoroutine(closeFolders());
    }

}
