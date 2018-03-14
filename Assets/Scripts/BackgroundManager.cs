using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour {

	public GameObject[] planets;
	private int m_randPlanet;
	private float m_planetHeight;
	private int m_edgeofcam = -16;
	private float m_screenTop = 2.5f;
	private float m_screenBot = -7f;
	public void Start(){
		StartCoroutine(SpawnStartPlanets());

	}
	public void CreateNewPlanet(){
		m_randPlanet = Random.Range(1,9);
		m_planetHeight = Random.Range(m_screenBot, m_screenTop);
		var planet =Instantiate(planets[m_randPlanet],new Vector3(m_edgeofcam, 1, m_planetHeight),Quaternion.identity);
		planet.transform.parent = gameObject.transform;
		planet.GetComponent<PlanetMoving>().m_bckgrdMgr = this;
		planet.transform.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
	}

	private IEnumerator SpawnStartPlanets() {
		CreateNewPlanet();
        yield return new WaitForSeconds(6.0f);
		CreateNewPlanet();
        yield return new WaitForSeconds(6.0f);
		CreateNewPlanet();
		 yield return new WaitForSeconds(6.0f);
		CreateNewPlanet();
        
    }
}
