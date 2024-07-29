using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemySettings", menuName = "Enemy/New Enemy")]
public class EnemyObject : ScriptableObject
{
    public string names;
    public int life;
    public float speed;
    public float attack;

    public RuntimeAnimatorController animController;
}
