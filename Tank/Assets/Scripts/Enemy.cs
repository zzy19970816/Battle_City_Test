using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    // property
    public float movespeed = 3;
    private Vector3 bulletEulerAngles;
    private float v = -1;
    private float h;
    private float timeVal = 0;
    private bool isProtected;
    private float timevalChangeDirection = 4;
    // reference
    private SpriteRenderer sr;
    public Sprite[] tankSprite; // up right down left;
    public GameObject bullet;
    public GameObject explosionPrefab;
    public void Awake () {
        sr = GetComponent<SpriteRenderer> ();
    }

    // Start is called before the first frame update
    void Start () {

    }

    // Update is called once per frame
    void Update () {


        if (timeVal >= 1){
            Attack ();
        }else {
            timeVal += Time.deltaTime;
        }
    }

    private void FixedUpdate() {
        Move ();
    }

    private void Attack () {
        Instantiate (bullet, transform.position, Quaternion.Euler (transform.eulerAngles + bulletEulerAngles));
        timeVal = 0;
    }

    private void Move () {

        if (timevalChangeDirection >= 4){
            int num = Random.Range(0, 8);
            if (num > 5){
                v = -1;
                h = 0;
            }
            else if (num == 0){
                v = 1;
                h = 0;
            }
            else if (num > 0 && num <= 2){
                v = 0;
                h = 1;
            }
            else if (num > 2 && num <= 4){
                v = 0;
                h = -1;
            }
            timevalChangeDirection = 0;
        }
        else {
            timevalChangeDirection += Time.fixedDeltaTime;
        }
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
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
        PlayerManager.Instance.score++;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy"){
            timevalChangeDirection = 4;
        }
    }
}