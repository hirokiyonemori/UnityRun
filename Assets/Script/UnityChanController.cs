﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using GamepadInput;
using UnityEngine.UI;

public class UnityChanController : MonoBehaviour
{

    float speed = 0f;
    float movePower = 0.2f;
    bool jumppingFlug = true;
    Rigidbody myRigidbody;
    private Animator myAnimator;                      // myAnimatoratorへの参照
    private int life = 0;
    //ゲーム終了時に表示するテキスト（追加）
    //private GameObject stateText;

    //スコアを表示するテキスト（追加）
   // private GameObject scoreText;

    //スコアを表示するテキストプレイヤー２用（追加）
   // private GameObject scoreText2;

    //得点（追加）
    private int score = 0;
    //private int score2 = 0;
    //アニメーションするためのコンポーネントを入れる
    //private mymyAnimatoratorator mymymyAnimatoratorator;

    //Unityちゃんを移動させるコンポーネントを入れる
    //private Rigidbody myRigidbody;
    //前進するための力
    private float forwardForce = 800.0f;
    //左右に移動するための力
    private float turnForce = 500.0f;
    //ジャンプするための力
    private float upForce = 500.0f;
    //左右の移動できる範囲
    private float movableRange = 3.4f;
    //動きを減速させる係数（追加）
    private float coefficient = 0.95f;
    private float addSpeed = 10.0f;
    protected bool winflag = false;
    //protected bool winflag2 = false;
    //ゲーム終了の判定（追加）
    //private bool isEnd = false;
    private int time = 0;
    public int no = 0;
    public bool m_playerDeadFlag = false;
    //protected GameObject mainCamera;

    //protected GameObject mainCamera2;

    private GameObject scoreText2;
    private GameObject scoreText;
    private GameObject stateText;

    private bool OnCollisionflag = false;
    private bool cpnflg = false;
    void Start()
    {
       // Debug.Log(" Field.plyNum " + Field.plyNum + " no " + no);
        if( Field.plyNum == 1 && no == 1)
        {
            cpnflg = true;
        }
        myRigidbody = GetComponent<Rigidbody>();
        // 各参照の初期化
        this.myAnimator = GetComponent<Animator>();
        //シーン中のscoreTextオブジェクトを取得（追加）
        this.scoreText = GameObject.Find("ScoreText");
        this.scoreText2 = GameObject.Find("ScoreText2");
        this.stateText = GameObject.Find("GameResultText");

        life = 1;
        //mainCamera = GameObject.Find("Camera");
        //mainCamera2 = GameObject.Find("Camera2");
        //winflag = false;
        //winflag = false;
        //StartCountDown();
        StartCoroutine("StartCountDown");
        Debug.Log(" no " + no + " Field.plyNum  " + Field.plyNum );
        if ( no == 0 )
        {
            MainCamara = GameObject.Find("MainCamera");
            MainCamara.transform.parent = this.transform;
        }else if( no == 1 && Field.plyNum == 2)
        {
            MainCamara = GameObject.Find("MainCamera2");
            MainCamara.transform.parent = this.transform;
        }

        this.scoreText.GetComponent<Text>().text = "score " + GetScore();
        this.scoreText2.GetComponent<Text>().text = "score " + GetScore() ;
        Field.startFlg = false;
    }
    private GameObject MainCamara;

    //Speedにより速度制限
    //speedMax値

    private int wait = 0;
    private int spType = 2;
    private int []waitTime = { 200, 100, 50, 20, 10 };

    void FixedUpdate()
    {
        
        

        if (!Field.startFlg) return;

        //体力システムを追加用
        //      if( ++wait > waitTime[ spType ])
        //      {
        //          wait = 0;
        //          this.score--;
        //          if( no == 0)
        //          {
        //              this.scoreText.GetComponent<Text>().text = "HP " + GetScore();
        //          }else if( no == 1 )
        //          {
        //              this.scoreText2.GetComponent<Text>().text = "HP " + GetScore();
        //          }
        //      }

        if (no == 0)
        {
            this.scoreText.GetComponent<Text>().text = "score " + GetScore();
        }
        else if (no == 1)
        {
            this.scoreText2.GetComponent<Text>().text = "score " + GetScore();
        }
        
        if (Field.isEnd)
        {
            Debug.Log(" winflag = " + winflag + " no " + no);
            if ( winflag )
            {

                if(!myAnimator.GetBool("Win"))
                {
                    if (no == 0)
                    {
                        myAnimator.SetBool("Win", true);
                        MainCamara.transform.position = new Vector3(MainCamara.transform.position.x, MainCamara.transform.position.y -2, MainCamara.transform.position.z + 7);
                        MainCamara.transform.RotateAround(MainCamara.transform.position, Vector3.up, 180.0f);

                    }
                    else if (no == 1 && Field.plyNum == 2)
                    {
                        myAnimator.SetBool("Win", true);
                        MainCamara.transform.position = new Vector3(MainCamara.transform.position.x, MainCamara.transform.position.y-2, MainCamara.transform.position.z  + 7);
                        MainCamara.transform.RotateAround(MainCamara.transform.position, Vector3.up, 180.0f);
                    }
                } 
            }else
            {

                if (!myAnimator.GetBool("Lose"))
                {
                    if (no == 0)
                    {
                        myAnimator.SetBool("Lose", true);
                        MainCamara.transform.position = new Vector3(MainCamara.transform.position.x, MainCamara.transform.position.y -2 , MainCamara.transform.position.z + 7);
                        MainCamara.transform.RotateAround(MainCamara.transform.position, Vector3.up, 180.0f);

                    }
                    else if (no == 1 && Field.plyNum == 2)
                    {
                        myAnimator.SetBool("Lose", true);
                        MainCamara.transform.position = new Vector3(MainCamara.transform.position.x, MainCamara.transform.position.y -2 , MainCamara.transform.position.z + 7);
                        MainCamara.transform.RotateAround(MainCamara.transform.position, Vector3.up, 180.0f);
                    }

                    //myAnimator.SetBool("Down", true);
                }
            }
            
        }
        if (myAnimator.GetBool("Damage") || myAnimator.GetBool("Down"))
        {
            //Debug.Log(" time " + time);
            //speed = -0.02f;
            //time++;
            myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, myRigidbody.velocity.z - 2);
            //if (myAnimator.("Damage"))
            //if( this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Damage"))  
            //Debug.Log(" time  " + this.myAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime ); 
            if( (this.myAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1 && myAnimator.GetBool("Damage") )||
                (this.myAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && myAnimator.GetBool("Down") ))
            //if (time > 120 )
            {
                //addSpeed = 0.01f;
                
                speed = 0;
                time = 0;
                myAnimator.SetBool("Damage", false);
                myAnimator.SetBool("Down", false);
                myAnimator.SetBool("Run", true);
            }
            return;
        }
        //ゲーム終了ならUnityちゃんの動きを減衰する（追加）
        if (Field.isEnd)
        {
            //this.forwardForce *= this.coefficient;
            //this.turnForce *= this.coefficient;
            //this.upForce *= this.coefficient;
            //this.myAnimator.speed = this.coefficient;
            //勝利したときのアクション

            //if (!myAnimator.GetBool("Win") && !m_playerDeadFlag )
            
            return;


        }

  
       
       // if (Input.GetKey("up"))
        {
            if (!myAnimator.GetBool("Damage")) {
                Accel(); //アクセル
            }

        }
        // Debug.Log(" score " + this.score );
        // Debug.Log(" " + GetScore());
        //Debug.Log(" Horizontal" + Input.GetAxis("Horizontal"));
        //Debug.Log(" Horizontal" + Input.GetAxis("Horizontal2"));
        if (Input.GetKey("up") )
        {
            spType++;
            if (spType >= 4) {
                spType = 4;
            }
        }
        if (Input.GetKey("down"))
        {
            spType--;
            if( spType <= 0)
            {
                spType = 0;
            }
        }
        Debug.Log("spType = " + spType);

        if (Input.GetKey("right") || Input.GetAxis("Horizontal") > 0.1 )
        {
            if (!cpnflg)
                Right(); //右移動
        }
        if (Input.GetKey("left") || Input.GetAxis("Horizontal") < -0.1 )
        {
            if (!cpnflg) 
                Left(); //左移動
        }

        //if (Input.GetKeyDown("space") || Input.GetButtonDown("Jump")  && this.transform.position.y <= 1)
        //Debug.Log(" Random " + Random.Range(0, 10));
        //Debug.Log(" jumppingFlug " + jumppingFlug);
        //Debug.Log("Input.GetButtonDown(Jump)" + Input.GetButtonDown("Jump") );
        if ( (Input.GetButtonDown("Jump")  && jumppingFlug  ) 
            || (jampFlag && jumppingFlug  ) )
        {
            //Debug.Log("Jump");
            //if (jumppingFlug == true)
            //{jampFlag
            jampFlag = false;
            //if(!cpnflg)
                Jump();
            //}
        }
//    if(this.transform.position.y > 1)
//    {
//        jumppingFlug = false;
//        //myAnimator.SetBool("Run", false);
//
//    }


        //Jumpステートの場合はJumpにfalseをセットする（追加）
// if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
// {
//     this.myAnimator.SetBool("Jump", false);
// }

        addSpeed = addSpeed + 0.01f;
        //speed -= 1f;    //減速
        if (speed < 0)
        {
            speed = 0f; //最低速度
        }
        if (speed >= 0.1f)
        {
        
            if (!myAnimator.GetBool("Run") && !myAnimator.GetBool("Damage"))
            {
                myAnimator.SetBool("Run", true);
            }
        }else
        {
            if (myAnimator.GetBool("Run"))
            {
                myAnimator.SetBool("Run", false);
            }
        }
       

        //  var playerNo = GamePad.Index.Any;
        //  var keyState = GamePad.GetState(playerNo, false);
        //  if (keyState.A)
        //      Debug.Log("push A button");


    }


    void Accel()
    {

        speed += addSpeed;
        
        if (speed >= 10.0f  + 5 * spType)
        {
            //Debug.Log("sppedMax = " + 5 * spType);
            speed = 10.0f + 5 * spType;
        } 
        myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, speed);
    }

    void Right()
    {
        if (transform.position.x <= 4f)
        {
            Vector3 temp = new Vector3(transform.position.x + movePower, transform.position.y, transform.position.z);
            transform.position = temp;
        }
    }

    void Left()
    {
        if (transform.position.x >= -4f)
        {
            Vector3 temp = new Vector3(transform.position.x - movePower, transform.position.y, transform.position.z);
            transform.position = temp;
        }
    }

    void Jump()
    {
       // Debug.Log("JUMP");
        jumppingFlug = false;
        myRigidbody.AddForce(Vector3.up * 500);
        //myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y + 3, myRigidbody.velocity.z);
        //myAnimator.SetBool("Jump", true);
        
        myAnimator.SetBool("Jump", true);
        //myAnimator.SetFloat("Jump", 20);
    }
    void OnCollisionExit(Collision col)
    {
        //OnCollisionflag = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (!cpnflg) return;
        if (other.gameObject.tag == "CarTag")
        {
            if (transform.position.x <= 2f)
                Right();
            else
                Left();
        }
    }
    private bool jampFlag = false;
    //トリガーモードで他のオブジェクトと接触した場合の処理（追加）
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if( other.gameObject.transform.position.y < this.transform.position.y)
            {
                Debug.Log(" player Jump");
                Jump();
            }
        }

        //障害物に衝突した場合
        if (other.gameObject.tag == "Bomb" )
        {
            myAnimator.SetBool("Down", true);
            Destroy(other.gameObject);
        }
            //障害物に衝突した場合
        if (other.gameObject.tag == "CarTag" || other.gameObject.tag == "TrafficConeTag")
        //if ( other.gameObject.tag == "TrafficConeTag")
        {
            
            if ( !jampFlag && cpnflg && other.gameObject.tag == "TrafficConeTag" )
            {
                jampFlag = true;
                return;

            }
            if (cpnflg) return;
                Debug.Log(" CarTag tach" );
            Debug.Log(" " + jampFlag);
            //lifeを減らす
            //myAnimator.SetBool("Down", true);
            //if (this.transform.position.y > 1)
            if (myAnimator.GetBool("Jump"))
            {
                myAnimator.SetBool("Jump", false);
                myAnimator.SetBool("Down", true);
                
                //myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y + 10, myRigidbody.velocity.z);
                myRigidbody.AddForce(Vector3.up * 500);
            }
            else {
                myAnimator.SetBool("Damage", true);
            }
            
            //パーティクルを再生（追加）
            GetComponent<ParticleSystem>().Play();
            //接触したコインのオブジェクトを破棄（追加）
            Destroy(other.gameObject);


            //life--;
            //if (life <= 0)
            //{
            //    Field.isEnd = true;
            //    m_playerDeadFlag = true;
            //    //stateTextにGAME OVERを表示（追加）
            //    this.stateText.GetComponent<Text>().text = "GAME OVER";
            //}

        }
        //ゴール地点に到達した場合
        if (other.gameObject.tag == "GoalTag")
        {
            Destroy(other.gameObject);
            Field.isEnd = true;
            //stateTextにGAME CLEARを表示（追加）
            //this.stateText.GetComponent<Text>().text = "CLEAR!!";
            winflag = true;
           
           Debug.Log(" no " + no);
           this.stateText.GetComponent<Text>().text = "Player" + (no + 1) + "Win";
            //if( no == 0) {
            //    winflag = true;
            //} else {
            //    winflag2 = true;
            //}

        }
        
        //コインに衝突した場合（追加）
        if (other.gameObject.tag == "CoinTag")
        {
            //if (no == 0)
           // {
                // スコアを加算(追加)
            this.score += 1;
            //Debug.Log(" score " + this.score);
            //ScoreText獲得した点数を表示(追加)
            //this.scoreText.GetComponent<Text>().text = "Score " + this.score + "pt";
            if (no == 0)
            {
                this.scoreText.GetComponent<Text>().text = "Score " + GetScore() + "pt";
            }
            else if (no == 1)
            {
                this.scoreText2.GetComponent<Text>().text = "Score " + GetScore() +"pt"; ;
            }
            //パーティクルを再生（追加）
            GetComponent<ParticleSystem>().Play();
                //接触したコインのオブジェクトを破棄（追加）
                Destroy(other.gameObject);
// }else
// {
//     // スコアを加算(追加)
//     this.score2 += 10;
//
//     //ScoreText獲得した点数を表示(追加)
//     //this.scoreText2.GetComponent<Text>().text = "Score " + this.score2 + "pt";
//     //パーティクルを再生（追加）
//     GetComponent<ParticleSystem>().Play();
//     //接触したコインのオブジェクトを破棄（追加）
//     Destroy(other.gameObject);
// }

        }
        //Debug.Log("コースに触れている");
        //コースに触れている。
        if (other.gameObject.tag == "Course")
        {
            Debug.Log("コースに触れている");
            this.myAnimator.SetBool("Jump", false);
            //Jumpステートの場合はJumpにfalseをセットする
            //if (this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
            //{
            jumppingFlug = true;
            //this.myAnimator.SetBool("Jump", false);
            //this.myAnimator.SetBool("Run", true);
            //}
        }
    }
    IEnumerator StartCountDown()
    {
        //GUIの表示を3にする
        this.stateText.GetComponent<Text>().text = "3";
        Debug.Log("3");
        //1秒待つ
        yield return new WaitForSeconds(1.0f);
        //GUIの表示を3にする
        this.stateText.GetComponent<Text>().text = "2";
        Debug.Log("2");
        //1秒待つ
        yield return new WaitForSeconds(1.0f);
        //GUIの表示を3にする
        this.stateText.GetComponent<Text>().text = "1";
        Debug.Log("1");
        //1秒待つ
        yield return new WaitForSeconds(1.0f);
        //GUIに何も表示しない
        this.stateText.GetComponent<Text>().text = "";
        //ゲームの状態をゲーム中にする
        Field.startFlg = true;
        //state = STATE.MOVE;
    }

    public int GetScore()
    {
        //Debug.Log(" GetScore " + this.score );
        return this.score;
    }
}