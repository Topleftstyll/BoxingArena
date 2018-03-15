using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour {

	public WallManager m_wallMgr;
	public float m_wallLowerTime;
	public float m_wallDelay;

	private bool m_raised = false;

	void Start(){
		StartCoroutine(m_StartWalls());
	}
	// Update is called once per frame
	void Update () {
		if(m_raised){
			StartCoroutine(LowerWall());
		}
		
	}
	private IEnumerator m_StartWalls(){
		yield return new WaitForSeconds(m_wallDelay);
		m_raised = true;
	}
	private IEnumerator LowerWall(){
		
		m_raised = false;
		m_wallMgr.LowerWall(this.gameObject);
		yield return new WaitForSeconds(m_wallLowerTime);
		m_wallMgr.RaiseWall(this.gameObject);
		yield return new WaitForSeconds(m_wallDelay);
		m_raised = true;

	}
}
