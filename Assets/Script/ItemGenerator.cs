using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //コース;
    public GameObject stageGameObj;
    //Course
    public GameObject courseObj;
    //ゴールのオブジェクト
    public GameObject goalObj;

    //スタート地点
    private int startPos = -500;
    //ゴール地点
    private int goalPos = 120;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //親のゲームオブジェクトを格納用
    GameObject obj;
    // Use this for initialization
    void Start()
    {
        GameObject filedobj;
        //コースを生成
        for ( int i =0; i < 10 + Field.retryCnt; i ++)
        {
            filedobj = Instantiate(stageGameObj) as GameObject;
            filedobj.transform.position = new Vector3(-50, -0.5f, -400 + i * 100 );

            filedobj = Instantiate(courseObj) as GameObject;
            filedobj.transform.position = new Vector3(0, 0, -350 + i * 100);

        }
        filedobj = Instantiate(goalObj) as GameObject;
        filedobj.transform.position = new Vector3(0, 2.5f, 2 + Field.retryCnt * 100);
        for( int i = 0; i < 4 + Field.retryCnt; i ++)
        {
            createItem(-400 + i * 100);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GameObjDestory()
    {
        Destroy(obj);
    }
    
    public void createItem(int z)
    {
        int startPos = z;

        goalPos = startPos + 50;
        obj = new GameObject();
        //一定の距離ごとにアイテムを生成
        for (int i = startPos; i < goalPos; i += 10)
        {
            //どのアイテムを出すのかをランダムに設定
            int num = Random.Range(0, 10);
            if (num <= 1)
            {
                if (Field.gameDif == 1) continue;
                //コーンをx軸方向に一直線に生成
                for (float j = -1; j <= 1; j += 0.2f)
                {
                     GameObject cone = Instantiate(conePrefab) as GameObject;
                     cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                    cone.transform.parent = obj.transform;
                }
                
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j < 2; j++)
                {
                    //アイテムの種類を決める
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置:30%車配置:10%何もなし
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        GameObject coin = Instantiate(coinPrefab) as GameObject;
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                        coin.transform.parent = obj.transform;
                    }
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab) as GameObject;
                        if (Field.gameDif != 2)
                        {
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                        }
                        else
                        {
                            car.transform.position = new Vector3(posRange * j - 50, car.transform.position.y, i + offsetZ);
                            car.transform.Rotate(new Vector3(0.0f, 90.0f, 0.0f));
                        }
                        car.transform.parent = obj.transform;
                    }
//else
//{
//    
//    
//    //GameObject GameBomb = Instantiate(Bomb) as GameObject;
//    //GameBomb.transform.position = new Vector3(posRange * j, GameBomb.transform.position.y, i + offsetZ);
//    //GameBomb.transform.parent = obj.transform;
//}
                }
            }
        }
    }
}