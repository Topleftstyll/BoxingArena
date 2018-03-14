using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchCollider : MonoBehaviour {
	public Movement m_player;
	public void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Enemy"){
			other.gameObject.GetComponent<Rigidbody>().AddForce(other.gameObject.transform.forward * -500);
			
		}
		Destroy(this);
			if(this.transform.parent.gameObject.tag == "LeftFist"){
				m_player.m_leftFist.SetActive(true);
				m_player.m_canLeftPunch = true;
			}
			else if(this.transform.parent.gameObject.tag == "RightFist"){
				m_player.m_rightFist.SetActive(true);
				m_player.m_canRightPunch = true;
			}
	}
}
