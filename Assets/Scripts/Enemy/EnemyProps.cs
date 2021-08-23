using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(order = 1,fileName = "New Enemy",menuName = "Enemies/Enemy")]
public class EnemyProps : ScriptableObject 
{

    public int HP;

    public int damage = 10;

}
