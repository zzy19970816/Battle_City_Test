using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour
{
    public int life = 3;
    public int score = 0;
    public bool isdead = false;
    public GameObject Born;
    public Text playerScoreText;
    public Text playerLifeText;
    public bool isdefeat = false;
    public GameObject isdefeatUI;

    private static PlayerManager instance;
    public static PlayerManager Instance{
        get{
            return instance;
        }

        set{
            instance = value;
        }
    }


    private void Awake(){
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private float timecount = 0;
    void Update()
    {
        if (isdefeat){
            isdefeatUI.SetActive(true);
            if (timecount <3.0f){
                timecount += Time.deltaTime;
            }
            if (timecount >= 3)
            {
                SceneManager.LoadScene(0);
            }
            return;
        }
        if (isdead){
            recover();
        }
        playerScoreText.text = score.ToString();
        playerLifeText.text = life.ToString();
    }

    private void recover(){
        if (life <= 0){
            isdefeat = true;
        }
        else{
            life--;
            GameObject go = Instantiate(Born, new Vector3(-2, -8, 0), Quaternion.identity);
            go.GetComponent<born>().createPlayer = true;
            isdead = false;
        }
    }
}
