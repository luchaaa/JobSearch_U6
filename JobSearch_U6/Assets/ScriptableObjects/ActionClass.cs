using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/ActionItem", order = 1)]
public class ActionClass : ScriptableObject
{
    public string actionName;
    public string dialogueText;
}