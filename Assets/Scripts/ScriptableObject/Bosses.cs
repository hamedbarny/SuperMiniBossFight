using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BossData", menuName = "Boss")]
public class Bosses : ScriptableObject
{
    public int health;
    public int fireBallDamage;
    public int spawnCount;
    public int kickDamage;

}

