using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createScript : MonoBehaviour
{
    public GameObject enemy1;
    int enemyBorder = 80;
    // Use this for initialization
    void Start()
    {
        CreateEnemy();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void CreateEnemy()
    {
        //if (Random.Range(0, 3) == 0)
        //{
            Instantiate(enemy1, new Vector3(1.0f, 3.0f, 1), enemy1.transform.rotation);
        //}
    }
}
