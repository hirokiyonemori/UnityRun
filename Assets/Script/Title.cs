using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GamepadInput;


public class Title : MonoBehaviour {
    
     Button myButton;
    Button myButton2;
    Button finButton;
    GameObject titleButton;
    public Canvas canvas;
    private bool upKeyFlg = false;
    private bool downKeyFlg = false;


    public void SceneEasy()
    {
        Field.gameDif = 0;
        Field.retryCnt = 0;
        Application.LoadLevel("1PStage");
    }

    public void SceneNormal()
    {
        Field.gameDif = 1;
        Field.retryCnt = 0;
        Application.LoadLevel("1PStage");
    }

    public void SceneHard()
    {
        Field.gameDif = 2;
        Field.retryCnt = 0;
        Application.LoadLevel("1PStage");
    }

    public void EndGame()
    {
        Application.Quit();
    }

    // Use this for initialization
    void Start () {
        titleButton = GameObject.Find("Button");
        Field.plyNum = 0;

        Button target = null;
        foreach (Transform child in canvas.transform)
        {
            //Debug.Log("" + child.name);
            if (child.name == "Button")
            {
                target = child.gameObject.GetComponent<Button>();
                
                ColorBlock newblock = target.colors;
                newblock.normalColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                target.colors = newblock;
                myButton = target;
                //target.interactable = true;       活性
                //target.interactable = true;       非活性
            }
            else if (child.name == "Button2")
            {
                target = child.gameObject.GetComponent<Button>();

                ColorBlock newblock = target.colors;
                newblock.normalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                target.colors = newblock;
                myButton2 = target;
                // target = child.gameObject.GetComponent<Text>();
                //target.text = "BBBBBBB";
            }
            else if (child.name == "Finish")
            {
                target = child.gameObject.GetComponent<Button>();

                ColorBlock newblock = target.colors;
                newblock.normalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                target.colors = newblock;
                finButton = target;
                // target = child.gameObject.GetComponent<Text>();
                //target.text = "BBBBBBB";
            }
        }

        //titleButton.GetComponent<Button>.colors.disabledColor;
        //myButton.GetComponent<Button>().colors.disabledColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
        //  myButton.interactable = false;
    }
    private int select_no = 0;
	// Update is called once per frame
	void Update () {
        ColorBlock newblock;
       // Debug.Log(" Input.GetAxis(Vertical) " + Input.GetAxis("Vertical"));

        if (Input.GetButtonDown("Vertical"))
        {
            Debug.Log(" GetButtonDown " + Input.GetAxis("Vertical") );
            if(Input.GetAxis("Vertical") < -0.01 )
            {
                upKeyFlg = true;
            }
            else
            {
                downKeyFlg = true;
            }

        }
        else
        {

            downKeyFlg = false;
            upKeyFlg = false;
        }
            

        if (Input.GetKeyUp("up") || Input.GetButtonDown("up"))
        {
            
            select_no--;
            //Debug.Log("select_no " + select_no);
            if (select_no <= 0) select_no = 0;
            upKeyFlg = true;



        }
        if (Input.GetKeyUp("down") || Input.GetButtonDown("down") )
        {
            
            select_no++;
            if (select_no >= 2) select_no = 2;

            //Debug.Log("select_no " + select_no);
            downKeyFlg = false;

        }
        if ( Input.GetButtonDown("Jump") )
        {
            if (Field.plyNum == 0)
            {
                //Debug.Log(" select_no " + select_no);
                if( select_no == 0)
                {
                    Field.plyNum = 1;
                }else if( select_no == 1 )
                {
                    Field.plyNum = 2;
                }
                select_no = 1;
                setText("seltxt1", "やさしい");
                setText("seltxt2", "ふつう");
                setText("seltxt3", "マジやば");
            }else 
            {
                Field.gameDif = select_no;
                switch ( select_no)
                {
                    //    case 0:
                    //        Application.LoadLevel("Stage1");
                    //        break;
                    //    case 1:
                    //        Application.LoadLevel("1PStage");
                    //        break;
                    //    case 2:
                    //        Application.LoadLevel("Stage3");
                    //        break;
                            
                }
                Application.LoadLevel("1PStage");
            }
        }
        
        for (int i = 0; i < 3; i++)
        {
            if (i == select_no)
            {
                switch (select_no)
                {
                    case 0:
                        newblock = myButton.colors;
                        newblock.normalColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                        myButton.colors = newblock;
                        break;
                    case 1:
                        newblock = myButton2.colors;
                        newblock.normalColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                        myButton2.colors = newblock;
                        break;
                    case 2:
                        newblock = finButton.colors;
                        newblock.normalColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                        finButton.colors = newblock;
                        break;
                }
            }
            else
            {
                switch (i)
                {
                    case 0:
                        newblock = myButton.colors;
                        newblock.normalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        myButton.colors = newblock;
                        break;
                    case 1:
                        newblock = myButton2.colors;
                        newblock.normalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        myButton2.colors = newblock;
                        break;
                    case 2:
                        newblock = finButton.colors;
                        newblock.normalColor = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                        finButton.colors = newblock;
                        break;

                }
            }
        }

    }
    void setText(string gameObjectName, string setText )
    {
        GameObject game = GameObject.Find(gameObjectName);
        Text text = game.GetComponent<Text>();
        text.text = setText;
    }
}
