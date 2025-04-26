using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //PLAYER MOVEMENT
    private Rigidbody rb;
    private Vector3 input;

    public float speed;
   
    public InputActionReference moveAction;
    public InputActionReference interactAction;

    //INTERACTING
    [SerializeField] private bool canInteract;

    public static UnityAction enterCombat;

#region EVENTS
    private void OnEnable() {
        Interactable.interactRange += interactRange;
        interactAction.action.started += interact;
    }
    private void OnDisable() {
        Interactable.interactRange -= interactRange;
        interactAction.action.started -= interact;
    }
#endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = GameManager.instance.playerSpawnLocation;
    }


    void Update()
    {
        input = getInput(); //gather player input
        
        lookDirection(); //changes rotation
    }

    void FixedUpdate() {
        move(); //moves the player
    }

#region MOVEMENT
    Vector3 getInput(){//gathers input from playerInput actions
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        return new Vector3(input.x, 0, input.y);
    }

    void lookDirection(){//change the rotation of where you are facing
        if (input == Vector3.zero) return;

        var rot = Quaternion.LookRotation(input, Vector3.up);
        transform.rotation = rot;
    }

    void move(){
        rb.MovePosition(transform.position + transform.forward * input.normalized.magnitude * speed * Time.deltaTime);
    }
#endregion

    void interactRange(){
        canInteract=!canInteract;
    }

    void interact(InputAction.CallbackContext obj){
        //Debug.Log("interact pressed");

        if (canInteract) {// change to start an event
            GameManager.instance.playerSpawnLocation = transform.position;
            enterCombat();
            // SceneChanger.instance.changeScene("CombatScene");
        }
        else if (!canInteract) Debug.Log("get in range to interact!");
    }
}

public static class Helpers //(do the isometric things? idk rly lol)
{
    private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler(0, 45, 0));
    public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
