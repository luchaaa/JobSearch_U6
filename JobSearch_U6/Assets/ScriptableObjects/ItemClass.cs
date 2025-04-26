using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemClass : ScriptableObject
{
    public string itemName;
    public string dialogueText;
}