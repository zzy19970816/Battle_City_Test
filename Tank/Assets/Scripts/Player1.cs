using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour {
    // property
    public float movespeed = 3;
    private Vector3 bulletEulerAngles;
    private float timeVal = 0;
    private bool isProtected = true;
    private float protectTimeVal = 3;
    // reference
    private SpriteRenderer sr;
    public Sprite[] tankSprite; // up right down left;
    public GameObject bullet;
    public GameObject explosionPrefab;
    public GameObject protectedPrefab;
    public void Awake () {
        sr = GetComponent<SpriteRenderer> ();
    }

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {

        if (isProtected == true){
            protectedPrefab.SetActive(true);
            protectTimeVal -= Time.deltaTime;
            if (protectTimeVal <= 0){
                isProtected = false;
                protectedPrefab.SetActive(false);
            }
        }

        if (timeVal >= 0.4f){
            Attack ();
        }else {
            timeVal += Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        Move ();
    }

    private void Attack () {
        if (Input.GetKeyDown (KeyCode.Space)) {
            Instantiate (bullet, transform.position, Quaternion.Euler (transform.eulerAngles + bulletEulerAngles));
            timeVal = 0;
        }
    }

    private void Move () {

        float h = Input.GetAxisRaw ("Horizontal");
        transform.Translate (Vector3.right * h * movespeed * Time.deltaTime, Space.World);
        if (h > 0) {
            sr.sprite = tankSprite[1];
            bulletEulerAngles = new Vector3(0, 0, -90);
        } else if (h < 0) {
            sr.sprite = tankSprite[3];
            bulletEulerAngles = new Vector3(0, 0, 90);
        }

        if (h != 0) {
            return;
        }

        float v = Input.GetAxisRaw ("Vertical");
        transform.Translate (Vector3.up * v * movespeed * Time.deltaTime, Space.World);
        if (v > 0) {
            sr.sprite = tankSprite[0];
            bulletEulerAngles = new Vector3(0, 0, 0);
        } else if (v < 0) {
            sr.sprite = tankSprite[2];
            bulletEulerAngles = new Vector3(0, 0, 180);
        }

    }

    private void Die(){
        if (isProtected){
            return;
        }

        PlayerManager.Instance.isdead = true;
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}