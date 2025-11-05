using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Melee/Attack")]
public class AttackSO : ScriptableObject
{
    public AnimatorOverrideController animatorOC;
    public int damage;
    public float attackMoveDistance;
}
