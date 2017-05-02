using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour
{
    public GameObject Explision;
    public GameObject FireWall;
    //public GameObject Debris;

    const float EXPLOSION_TIME = 10;     // 爆発までの時間
    Vector3 max_scale;
    float timeElapsed;

    // Use this for initialization
    void Start()
    {
        // 爆発タイマ設定
        Invoke("Explosion", EXPLOSION_TIME);
        // 最大の大きさ
        max_scale = transform.localScale;
    }

    void Explosion()
    {
        // 爆発エフェクト作成
        Quaternion quat = Quaternion.Euler(0, 0, 0);
        Vector3 pos = transform.position;               // 爆弾の位置に
        pos.y = -0f;                                    // 地面に置く
        Instantiate(Explision, pos, quat);              // 爆発

        // 四方に伸びる炎
        for (int i = 0; i < 4; i++)
        {
            quat = Quaternion.Euler(0, 90 * i, 0);      // 90度ずつ回転
            Instantiate(FireWall, pos, quat);           // 火
        }
        // 自分は消滅
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        timeElapsed += Time.deltaTime;

        // 赤くしていく
        GetComponent<Renderer>().material.color = new Color(timeElapsed / EXPLOSION_TIME, timeElapsed / (EXPLOSION_TIME * 3), 0);

        // 1/2サイズから徐々に大きくする
        transform.localScale = (max_scale / 2) + (max_scale * (timeElapsed / EXPLOSION_TIME) / 2);

        // 大きくした分、Y座標をずらす (爆弾の下は若干埋める)
        Vector3 pos = transform.position;
        pos.y = (transform.localScale.y / 2) - (transform.localScale.y / 2) / 4;
        transform.position = pos;
    }
}