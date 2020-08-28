using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map : MonoBehaviour
{
    // home, wall, barriar, born, river, grass, air
    public GameObject[] item;
    private List<Vector3> itemPositionList = new List<Vector3>();
    private void Awake(){
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(0, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        for (int i = -11; i <= 11; i++){
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -8; i <= 8; i++){
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
            CreateItem(item[6], new Vector3(-11, i, 0), Quaternion.identity);
        }
        for (int i = 0; i < 21; i++){
            CreateItem(item[1], createRandomPosition(), Quaternion.identity);
            CreateItem(item[2], createRandomPosition(), Quaternion.identity);
            CreateItem(item[4], createRandomPosition(), Quaternion.identity);
            CreateItem(item[5], createRandomPosition(), Quaternion.identity);
        }

        //player
        GameObject go = Instantiate(item[3], new Vector3(-2, -8, 0), Quaternion.identity);
        go.GetComponent<born>().createPlayer = true;

        //enemy
        CreateItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);
        InvokeRepeating("createEnemy", 4, 5);
    }

    private void CreateItem(GameObject create, Vector3 position, Quaternion def){
        GameObject itemGo = Instantiate(create, position, def);
        itemGo.transform.SetParent(gameObject.transform);
        itemPositionList.Add(position);
    }

    private Vector3 createRandomPosition(){
        while (true){
            Vector3 createPosition = new Vector3(Random.Range(-9, 10), Random.Range(-7, 8), 0);
            if(!HasThePosition(createPosition)){
                return createPosition;
            }
        }
    }

    private bool HasThePosition(Vector3 createPos){
        for (int i = 0; i < itemPositionList.Count; i++){
            if (createPos == itemPositionList[i]){
                return true;
            }
        }
        return false;
    }

    private void createEnemy(){
        int num = Random.Range(0, 3);
        Vector3 enemyPos = new Vector3();
        if (num == 0){
            enemyPos = new Vector3(-10, 8, 0);
        }
        else if (num == 1){
            enemyPos = new Vector3(10, 8, 0);
        }
        else {
            enemyPos = new Vector3(0, 8, 0);
        }
        CreateItem(item[3], enemyPos, Quaternion.identity);
    }
}
