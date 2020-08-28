﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float moveSpeed = 10;
    public bool isPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.up * moveSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        switch(collision.tag){
            case"Tank":
                if (!isPlayer){
                    collision.SendMessage("Die");

                    Destroy(gameObject);
                }
                break;
            case"home":
                collision.SendMessage("Die");
                Destroy(gameObject);
                break;
            case"Enemy":
                if (isPlayer){
                    collision.SendMessage("Die");
                    Destroy(gameObject);
                }
                break;
            case"Wall":
                Destroy(collision.gameObject);
                Destroy(gameObject);
                break;
            case"Barriar":
                Destroy(gameObject);
                break;
            default:
                break;
        }
    }
}
