using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform player;
    private Transform cam;

    // Start is called before the first frame update
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        cam = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.position = new Vector3(player.transform.position.x, player.transform.position.y, cam.position.z);
        cam.rotation = Quaternion.Euler(0, 0, 0);
    }
}
