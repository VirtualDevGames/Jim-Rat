using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private TextMeshProUGUI CoinCounterText;
    private int coinCounter = 0;

    public Image[] hearts;
    private int heartCounter = 2; // this is technically 3, full HP
    [SerializeField] private Sprite fullHeart, emptyHeart;
    

    void Start() {
        CoinCounterText = gameObject.transform.Find("Coin Counter").GetComponent<TextMeshProUGUI>();
        hearts = gameObject.transform.Find("Hearts").GetComponentsInChildren<Image>();
    }
    private void OnEnable() {
        // Coins
        Coin.OnCoinCollected += OnCoinCollected;
        // Health Bar
        Enemy.OnDamagePlayer += OnDamagePlayer;
        Enemy.OnDamageEnemy += OnDamageEnemy;
    }

    private void OnDisable() {
        // Coins
        Coin.OnCoinCollected -= OnCoinCollected;
        // Health Bar
        Enemy.OnDamagePlayer -= OnDamagePlayer;
        Enemy.OnDamageEnemy -= OnDamageEnemy;
    }

    // Coins
    private void OnCoinCollected() {
        coinCounter++;
        CoinCounterText.text = coinCounter.ToString();
    }

    // Player Health
    private void OnDamagePlayer(EnemyData enemyData) {

        // DEBUG ONLY - CHANGE WHEN DEATH IMPLEMENTED
        if (heartCounter < 0)
            return;


        hearts[heartCounter].sprite = emptyHeart;
        heartCounter -= enemyData.Damage;
        if (heartCounter < 0) {
            //PlayerDeath();
        }
    }
    private void OnDamageEnemy() {
        hearts[heartCounter].sprite = fullHeart;
        heartCounter++;
    }

    private void Heal() {
        hearts[heartCounter].sprite = fullHeart;
        heartCounter++;
    }

    
}
