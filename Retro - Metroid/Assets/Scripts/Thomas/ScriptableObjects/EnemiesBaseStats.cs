using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "EnemiesBaseStats", menuName = "Stats")]
public class EnemiesBaseStats : ScriptableObject
{
    public float enemyHealthPoints;

    public float enemyDamages;
    public float enemyAttackRange;

    public bool touched;

}
