using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCameraController : MonoBehaviour {

    //Unityちゃんのオブジェクト
    private GameObject unitychan;
    //Unityちゃんとカメラの距離
    private float difference;
    //カメラの番号
    public int no = 0;

    // Use this for initialization
    void Start()
    {
        Camera camera = this.GetComponent<Camera>();
        //Debug.Log(" Field.plyNum =" + Field.plyNum);
        camera.rect = new Rect(0, 0, 1, 1);
//if (Field.plyNum == 1)
//{
//    camera.rect = new Rect(0, 0, 1, 1);
//    if( no == 1 )camera.enabled = false;
//}
//else
//{
//    float x = 0.0f;//カメラのｘ座標
//    if( no == 1)
//    {
//        x = 0.5f;
//    }
//    camera.rect = new Rect(x, 0, 0.5f, 1);
//}
        
//  if( no == 0)
//  {
//      //Unityちゃんのオブジェクトを取得
//      this.unitychan = GameObject.Find("Misaki_sum_humanoid");
//      //Unityちゃんとカメラの位置（z座標）の差を求める
//      this.difference = unitychan.transform.position.z - this.transform.position.z;
//  }else if( no == 1)
//  {
//      //Unityちゃんのオブジェクトを取得
//      this.unitychan = GameObject.Find("Yuko_sum_humanoid");
//      //Unityちゃんとカメラの位置（z座標）の差を求める
//      this.difference = unitychan.transform.position.z - this.transform.position.z;
//  }
        

    }

//public void set(GameObject obj)
//{
//    this.unitychan = obj;
//}
    // Update is called once per frame
    void Update()
    {
        //Unityちゃんの位置に合わせてカメラの位置を移動
       //this.transform.position = new Vector3(0, this.transform.position.y, this.unitychan.transform.position.z - difference);
    }
}
