using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D collision) {

        if(collision.tag == "Collectable") {
            ICollectable collectable = collision.GetComponent<ICollectable>();
            if (collectable != null) {
                collectable.Collect();
            }
        }
        
        if(collision.tag == "Enemy") {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null) {
                enemy.DamagePlayer();
            }
        }
    }

    
}
