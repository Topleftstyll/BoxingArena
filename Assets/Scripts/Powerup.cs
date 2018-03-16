using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour {
	public PowerMgr m_Powermgr;
	
	private string powertype; 

	public void Start(){
		powertype = gameObject.name;
	}
	public void OnTriggerEnter(Collider other){
		if(other.gameObject.tag == "Player"){
			if(gameObject.name == "DoublePushpowerup"){
				other.GetComponent<Movement>().m_punchForce *=2;
				other.GetComponent<Movement>().m_doubledmgIndicator.SetActive(true);
				m_Powermgr.PowerCorutine(other.gameObject, "Doubledmg");
			}
			if(gameObject.name == "ShieldPowerup"){
				other.GetComponent<Movement>().m_invul = true;
				other.GetComponent<Movement>().m_shieldIndicator.SetActive(true);
				m_Powermgr.PowerCorutine(other.gameObject, "Shield");
			}
			gameObject.SetActive(false);
			m_Powermgr.SpawnCorutine(gameObject);
			
			
		}
	}


}
