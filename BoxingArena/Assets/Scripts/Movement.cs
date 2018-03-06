using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float m_speed = 5.0f;

	private Vector3 m_movementX;
	private Vector3 m_movementZ;
	private Rigidbody m_rb;
	void Start () {
		m_rb = GetComponent<Rigidbody>();
	}
	
	void FixedUpdate() {
		if(Input.GetKey(KeyCode.W)) {
	 		m_movementZ = Vector3.forward * m_speed; 
		}
		if(Input.GetKey(KeyCode.S)) {
			m_movementZ = Vector3.back * m_speed; 
		}
		if(Input.GetKey(KeyCode.A)) {
			m_movementX = Vector3.left * m_speed; 
		}
		if(Input.GetKey(KeyCode.D)) {
			m_movementX = Vector3.right * m_speed; 
		}

		m_rb.velocity = new Vector3(m_movementX.x, 0, m_movementZ.z);
	}
}
