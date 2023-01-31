using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "Player")]
public class Players : ScriptableObject
{
    public int health;
    public int fireBallDamage;
    public int fireOrbDamage;
    public int hellFireDamage;
    public bool canCast ;


}

