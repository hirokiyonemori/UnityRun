using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnityChanModel : UnityChanController
{

    //スコアを表示するテキストプレイヤー２用（追加）
    private GameObject scoreText2;
    private GameObject scoreText;
    private GameObject stateText;

    // Use this for initialization
    void Start () {

        //シーン中のstateTextオブジェクトを取得
     //   this.stateText = GameObject.Find("GameResultText");
   //     mainCamera = GameObject.Find("Camera");
 //       mainCamera2 = GameObject.Find("Camera2");
        // myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        if( Field.isEnd)
        {
           
        }
      
        
         

    }
}
