using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class option : MonoBehaviour
{
    // Start is called before the first frame update
    private int choice = 1;
    public Transform posone;
    public Transform postwo;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)){
            choice = 1;
            transform.position = posone.position;
        }
        else if (Input.GetKeyDown(KeyCode.S)){
            choice = 1;
            transform.position = postwo.position;
        }
        if (choice == 1 && Input.GetKeyDown(KeyCode.Space)){
            SceneManager.LoadScene(1);
        }
    }
}
