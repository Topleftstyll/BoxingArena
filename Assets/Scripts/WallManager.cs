using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour {
	private float m_lowerLength = -0.40f;
	private float m_raiseLength = 1.5f;
	public void LowerWall(GameObject wall){
		wall.transform.position = new Vector3(wall.transform.position.x, m_lowerLength, wall.transform.position.z);
	}

	public void RaiseWall(GameObject wall){
		wall.transform.position = new Vector3(wall.transform.position.x, m_raiseLength, wall.transform.position.z);
	}
}
