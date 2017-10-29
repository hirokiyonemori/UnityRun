using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Field : MonoBehaviour {
    private GameObject m_player1Object;                   //プレーヤー1のプレハブ
    //private GameObject m_player2Object;                 //プレーヤー2のプレハブ
    //ゲーム終了の判定（追加）
    public static bool isEnd = false;
    public Vector3 position;           //ブロックの生成位置// Use this for initialization
    //public Vector3 position2;           //ブロックの生成位置
    private GameObject instancePlayerObject;      //ブロックをとりあえず入れておく変数
    //private GameObject instancePlayerObject2;      //ブロックをとりあえず入れておく変数
    //private GameObject RankText;
    //private GameObject RankText2;
    public static int gameDif = 2;
    public static int plyNum = 0;
    public static bool startFlg = false;
    //private float lead = 0;
    //private ItemGenerator i;
    //左ボタン押下の判定（追加）
    public static bool isLButtonDown = false;
    //右ボタン押下の判定（追加）
    public static bool isRButtonDown = false;
    //ジャンプをおしたフラグ
    public static bool isUpButtonDown = false;
    public static int retryCnt;
    void Start () {

        //ブロックを作る
        //GameObject originalObject;      //生成するブロックの元となるオブジェクト

        m_player1Object = (GameObject)Resources.Load("Prefabs/Misaki_sum_humanoid");
  //      if( Field.plyNum == 1)
//        {
            //m_player2Object = (GameObject)Resources.Load("Prefabs/Utc_sum_humanoid");
    //    }
        //else
       // {
          //  m_player2Object = (GameObject)Resources.Load("Prefabs/Yuko_sum_humanoid");
        //}


        //左ボタン押下の判定（追加）
        isLButtonDown = false;
        //右ボタン押下の判定（追加）
        isRButtonDown = false;
        //ジャンプをおしたフラグ
        isUpButtonDown = false;

        //ブロック生成							複製する対象		生成位置		回転
        instancePlayerObject = Instantiate(m_player1Object, position, m_player1Object.transform.rotation) as GameObject;
        // instancePlayerObject2 = Instantiate(m_player2Object, position2, m_player2Object.transform.rotation) as GameObject;
        Field.isEnd = false;
        //RankText = GameObject.Find("Rack");
        //RankText2 = GameObject.Find("Rack2");
        //i = GameObject.Find("ItemGenerator").GetComponent<ItemGenerator>();
        //i.createItem(this.transform.position.z + createRead);
        //lead = instancePlayerObject.transform.position.z;
        con = GameObject.Find("Continue");
        fin = GameObject.Find("Fin");
        con.SetActive(false);
        fin.SetActive(false);

    }
    private GameObject con;
    private GameObject fin;
    public int createRead = 50;

    public static Vector3 plyPos;
    // Update is called once per frame
    void Update () {
        // Debug.Log(" m_player1Object.transform.position.z " + instancePlayerObject.transform.position.z + " m_player2Object.transform.position.z " + instancePlayerObject2.transform.position.z);

        //  if (instancePlayerObject.transform.position.z >= instancePlayerObject2.transform.position.z)
        //  {
        //      RankText.GetComponent<Text>().text = "1位";
        //      RankText2.GetComponent<Text>().text = "2位";
        //      plyPos = instancePlayerObject2.transform.position;
        //  }
        //  else
        //  {
        //      RankText.GetComponent<Text>().text = "2位";
        //      RankText2.GetComponent<Text>().text = "1位";
        //      plyPos = instancePlayerObject.transform.position;
        //  }
        plyPos = instancePlayerObject.transform.position;
 //if (instancePlayerObject.transform.position.z - lead >= createRead * 2)
 //{
 //    //Debug.Log(" 生成する = " + this.transform.position.z);
 //
 //    i.GameObjDestory();
 //    i.createItem(instancePlayerObject.transform.position.z + createRead);
 //    lead = instancePlayerObject.transform.position.z;
 //}
        //m_player1Object = GameObject.Find("Misaki_sum_humanoid").GetComponent<transform>;

        if ( Field.isEnd)
        {
            
            con.SetActive(true);
            fin.SetActive(true);
            //もし、Jumpボタンが押されたら
            //if (Input.GetButtonDown("Jump") || isUpButtonDown )
           // {
            //    SceneManager.LoadScene("Title");
            //}
        } 
    }

    

    //左ボタンを押し続けた場合の処理（追加）
    public void GetMyLeftButtonDown()
    {
        //Debug.Log("左ボタンを押下");
        Field.isLButtonDown = true;
    }
    //左ボタンを離した場合の処理（追加）
    public void GetMyLeftButtonUp()
    {
       // Debug.Log("左ボタンを話した");
        Field.isLButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理（追加）
    public void GetMyRightButtonDown()
    {
        Field.isRButtonDown = true;
    }
    //右ボタンを離した場合の処理（追加）
    public void GetMyRightButtonUp()
    {
        Field.isRButtonDown = false;
    }

    //右ボタンを押し続けた場合の処理（追加）
    public void GetMyUpButtonDown()
    {
        Field.isUpButtonDown = true;
    }
    //右ボタンを離した場合の処理（追加）
    public void GetMyUpButtonUp()
    {
        Field.isUpButtonDown = false;
    }

    public void RetryPlayChange()
    {
        
        Application.LoadLevel("1PStage");
        
    }

    public void TitleSceneChange()
    {
        retryCnt = 0;
        SceneManager.LoadScene("Title");
    }
    
}
