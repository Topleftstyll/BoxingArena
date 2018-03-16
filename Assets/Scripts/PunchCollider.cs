using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchCollider : MonoBehaviour {
	public Movement m_player;
	public float m_punchForce;
	public void OnCollisionEnter(Collision other){
		
		if(other.gameObject.tag == "Enemy"){
			other.gameObject.GetComponent<Rigidbody>().AddForce(other.gameObject.transform.forward * -m_punchForce);
			
		}
		Destroy(this.gameObject);
		
			if(gameObject.tag == "LeftFist"){
				Debug.Log("Left");
				m_player.m_leftFist.SetActive(true);
				m_player.m_canLeftPunch = true;
			}
			else if(gameObject.tag == "RightFist"){
				Debug.Log("Right");
				m_player.m_rightFist.SetActive(true);
				m_player.m_canRightPunch = true;
			}
	}
}
