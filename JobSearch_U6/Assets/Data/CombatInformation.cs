using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Combat Info")]
public class CombatInformation : ScriptableObject
{
    public string charName;

    public float maxHP;
    public float currentHP;
}
