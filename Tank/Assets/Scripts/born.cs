﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class born : MonoBehaviour
{
    public GameObject PlayerPrefab;
    public GameObject[] enemylistPrefab;
    public bool createPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("BornTank", 1.6f);
        Destroy(gameObject, 1.6f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void BornTank(){
        if (createPlayer){
            Instantiate(PlayerPrefab, transform.position, transform.rotation);
        }
        else{
            int num = Random.Range(0, 2);
            Instantiate(enemylistPrefab[num], transform.position, transform.rotation);
        }
    }
}
