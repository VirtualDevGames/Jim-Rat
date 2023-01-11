using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "EnemyData")]
public class EnemyData : ScriptableObject
{
    [SerializeField] private int hp = default;
    [SerializeField] private int damage = default;
    [SerializeField] private Sprite sprite;

    public int id;

    public int Damage {
        get => damage; set => damage = value;
    }
}
