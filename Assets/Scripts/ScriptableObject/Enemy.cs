using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData", menuName ="Enemy")]
public class Enemy : ScriptableObject
{
    public float followRange;
    public float attackRange;
    public float speed;
    public int attackDamage;

}

