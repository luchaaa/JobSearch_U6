using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;
using UnityEngine.UI;

public class InteractUI : MonoBehaviour
{
    public GameObject interactVisual;
    public Image fade;

    [SerializeField] private bool canInteract;

    private void OnEnable() {
        Interactable.interactRange += toggleInteractVisual;
        PlayerController.enterCombat += fadeOut;
    }
    private void OnDisable() {
        Interactable.interactRange -= toggleInteractVisual;
        PlayerController.enterCombat -= fadeOut;
    }

    private void Start() {
        //basic check to see if thing is active or not
        fadeIn();
    }

    void toggleInteractVisual(){
        if (canInteract) interactVisual.SetActive(false);
        else if (!canInteract) interactVisual.SetActive(true);

        canInteract=!canInteract;
    }

    void fadeOut(){
        fade.DOFade(1, .2f).OnComplete(delegate{SceneChanger.instance.changeScene("CombatScene");});
    }

    void fadeIn(){
        fade.color = Color.black;
        fade.DOFade(0, .2f);
    }
}
