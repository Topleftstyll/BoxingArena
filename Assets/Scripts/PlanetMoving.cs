using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetMoving : MonoBehaviour {
	public BackgroundManager m_bckgrdMgr;
	private Vector3 newx;
	private float m_screenEdge = 16;
	// Update is called once per frame
	void Update () {
		newx = new Vector3(transform.position.x + 0.01f,transform.position.y,transform.position.z);
		gameObject.transform.position = newx;
		if(transform.position.x > m_screenEdge){
			m_bckgrdMgr.CreateNewPlanet();
			Destroy(gameObject);
		}
		
	}

}
