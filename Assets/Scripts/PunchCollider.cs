using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchCollider : MonoBehaviour {

	public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Enemy"){
			other.gameObject.GetComponent<Rigidbody>().AddForce(other.gameObject.transform.forward * -500);
			
		}
	}
}
