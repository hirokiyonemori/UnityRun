using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    // Use this for initialization
    //Rigidbody myRigidbody;
    void Start () {
        // myRigidbody = GetComponent<Rigidbody>();
        transform.position += new Vector3(0f, 0f, 0f);

    }
	
	// Update is called once per frame
	void Update () {
        //myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, -10);
        
        if (Field.gameDif == 1)
        {
            if (Field.plyPos.z > transform.position.z - 100)
            {
                transform.position += new Vector3(0f, 0f, -10f * Time.deltaTime);
            }
            //普通難易度でプレイヤーを通り過ぎた場合
            if (transform.position.z < Field.plyPos.z)
            {
                Destroy(this.gameObject);
            }
        }
        else if( Field.gameDif == 2)
        {
            if(  Field.plyPos.z > transform.position.z -65)
            {
                transform.position += new Vector3(10f * Time.deltaTime, 0f, 0f);
            }
            //プレイヤーの難易度がハードの場合は
            if (transform.position.z > 100)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
