using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour, IEnemy {

    public static event HandleDamagePlayer OnDamagePlayer;
    public delegate void HandleDamagePlayer(EnemyData enemyData);

    public static event Action OnDamageEnemy;

    public EnemyData enemyData;

    public void DamagePlayer() {
        OnDamagePlayer?.Invoke(enemyData);
    }
    public void DamageEnemy() {
        // TODO
    }

    
}
