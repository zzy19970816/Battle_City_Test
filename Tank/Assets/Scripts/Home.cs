using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    private SpriteRenderer sr;
    public GameObject explosionPrefab;
    public Sprite Broken;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }


    public void Die(){
        sr.sprite = Broken;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        PlayerManager.Instance.isdefeat = true;
    }
}
