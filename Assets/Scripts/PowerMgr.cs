using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMgr : MonoBehaviour {
	public float m_powerupSpawn = 30f;
	public float m_PowerDuration = 5f;

	public void SpawnCorutine(GameObject Powerup){
		StartCoroutine(SpawnPowerups(Powerup));
	}
	public void PowerCorutine(GameObject player, string powertype){
		StartCoroutine(PowerDuration(player, powertype));
	}
	IEnumerator SpawnPowerups(GameObject Powerup){
		 yield return new WaitForSeconds(m_powerupSpawn);
		 Powerup.SetActive(true);
	}
	IEnumerator PowerDuration(GameObject player, string powertype){
		yield return new WaitForSeconds(m_PowerDuration);

		if(powertype == "Shield"){
			player.GetComponent<Movement>().m_invul = false;
			player.GetComponent<Movement>().m_shieldIndicator.SetActive(false);
		}
		if(powertype == "Doubledmg"){
			player.GetComponent<Movement>().m_punchForce /=2;
			player.GetComponent<Movement>().m_doubledmgIndicator.SetActive(false);
		}

	}
}
