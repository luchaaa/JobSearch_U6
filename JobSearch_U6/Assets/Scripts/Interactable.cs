using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour
{
    public LayerMask interactionLayer;

    public bool canInteract;

    public static UnityAction interactRange;
    //public static UnityAction interactExit;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && canInteract){
            interactRange();
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") && canInteract){
            interactRange();
        }
    }
}
