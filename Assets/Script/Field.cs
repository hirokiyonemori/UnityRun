using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Field : MonoBehaviour {
    private GameObject m_player1Object = null;                   //プレーヤー1のプレハブ
    private GameObject m_player2Object = null;                 //プレーヤー2のプレハブ
    public bool[] m_playerInput = new bool[2];
    //ゲーム終了の判定（追加）
    public static bool isEnd = false;
    public Vector3 position;           //ブロックの生成位置// Use this for initialization
    public Vector3 position2;           //ブロックの生成位置
    GameObject instancePlayerObject;      //ブロックをとりあえず入れておく変数
    GameObject instancePlayerObject2;      //ブロックをとりあえず入れておく変数
    private GameObject RankText;
    private GameObject RankText2;
    public static int gameDif = 2;
    public static int plyNum = 0;
    public static bool startFlg = false;
    private float lead = 0;

    private ItemGenerator i;

    void Start () {

        //ブロックを作る
        //GameObject originalObject;      //生成するブロックの元となるオブジェクト

        m_player1Object = (GameObject)Resources.Load("Prefabs/Misaki_sum_humanoid");
        if( Field.plyNum == 1)
        {
            m_player2Object = (GameObject)Resources.Load("Prefabs/Utc_sum_humanoid");
        }
        else
        {
            m_player2Object = (GameObject)Resources.Load("Prefabs/Yuko_sum_humanoid");

        }
        



        //ブロック生成							複製する対象		生成位置		回転
        instancePlayerObject = Instantiate(m_player1Object, position, m_player1Object.transform.rotation) as GameObject;
        instancePlayerObject2 = Instantiate(m_player2Object, position2, m_player2Object.transform.rotation) as GameObject;
        Field.isEnd = false;
        RankText = GameObject.Find("Rack");
        RankText2 = GameObject.Find("Rack2");
        i = GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>();
        i.createItem(this.transform.position.z + 50);
        lead = instancePlayerObject.transform.position.z;

    }


    public static Vector3 plyPos;
    // Update is called once per frame
    void Update () {
        // Debug.Log(" m_player1Object.transform.position.z " + instancePlayerObject.transform.position.z + " m_player2Object.transform.position.z " + instancePlayerObject2.transform.position.z);
        
        if (instancePlayerObject.transform.position.z >= instancePlayerObject2.transform.position.z)
        {
            RankText.GetComponent<Text>().text = "1位";
            RankText2.GetComponent<Text>().text = "2位";
            plyPos = instancePlayerObject2.transform.position;
        }
        else
        {
            RankText.GetComponent<Text>().text = "2位";
            RankText2.GetComponent<Text>().text = "1位";
            plyPos = instancePlayerObject.transform.position;
        }

        if (instancePlayerObject.transform.position.z - lead >= 50 * 2)
        {
            Debug.Log(" 生成する = " + this.transform.position.z);

            i.GameObjDestory();
            i.createItem(instancePlayerObject.transform.position.z + 50);
            lead = instancePlayerObject.transform.position.z;
        }
        //m_player1Object = GameObject.Find("Misaki_sum_humanoid").GetComponent<transform>;

        if ( Field.isEnd)
        {
            //もし、Jumpボタンが押されたら
            if (Input.GetButtonDown("Jump"))
            {
                //今いるシーン
                //int currentScene = Application.loadedLevel;
                //                    Application.LoadLevel("Title");
                SceneManager.LoadScene("Title");// ←new!
            }
        } 
    }
}
