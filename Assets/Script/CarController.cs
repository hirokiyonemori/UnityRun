using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    // Use this for initialization
    //Rigidbody myRigidbody;
    void Start () {
       // myRigidbody = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        //myRigidbody.velocity = new Vector3(myRigidbody.velocity.x, myRigidbody.velocity.y, -10);
        if (Field.gameDif == 1)
            transform.position += new Vector3(0f, 0f, -10f * Time.deltaTime);
        else if( Field.gameDif == 2 )
            transform.position += new Vector3(10f * Time.deltaTime, 0f, 0f );

        if (transform.position.z < Field.plyPos.z)
        {
            Destroy(this.gameObject);
        }
        if (transform.position.z > 100 )
        {
            Destroy(this.gameObject);
        }
        //this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -1 ) ; 
    }
}
