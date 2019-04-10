﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemiesBaseStats : ScriptableObject
{
    public float enemyHealthPoints;

    public float enemyDamages;
    public float enemyAttackRange;

    public RuntimeAnimatorController enemyAnimator;

}