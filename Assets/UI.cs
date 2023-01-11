using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{

    private TextMeshProUGUI CoinCounterText;
    private Transform gm;
    private int coinCounter = 0;
    private Array v;

    // Start is called before the first frame update
    void Start() {
        CoinCounterText = gameObject.transform.Find("Coin Counter").GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable() {
        Coin.OnCoinCollected += OnCoinCollected;
    }

    private void OnDisable() {
        Coin.OnCoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected() {
        coinCounter++;
        CoinCounterText.text = coinCounter.ToString();
    }
}
