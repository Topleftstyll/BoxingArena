using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float m_speed = 5.0f;

	private Rigidbody m_rb;
	private float m_velocitySlowAmount = 0.8f;

	void Start() {
		m_rb = GetComponent<Rigidbody>();
	}

	 void Update() {
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
		transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
    }
	
	void FixedUpdate() {
		// mouse location is always forward
		if(Input.GetKey(KeyCode.W)) {
	 		m_rb.velocity = transform.forward * m_speed; 
		}
		if(Input.GetKey(KeyCode.S)) {
			m_rb.velocity = -transform.forward * m_speed; 
		}
		if(Input.GetKey(KeyCode.A)) {
			m_rb.velocity = -transform.right * m_speed; 
		}
		if(Input.GetKey(KeyCode.D)) {
			m_rb.velocity = transform.right * m_speed; 
		}

		// slows the velocity over time if nothing else is preesed
		m_rb.velocity = m_rb.velocity * m_velocitySlowAmount;

		// top if the screen is always forward rotation
		// m_rb.velocity = new Vector3(Mathf.Lerp(0, Input.GetAxis("Vertical") * m_speed, 0.8f), 0, Mathf.Lerp(0, Input.GetAxis("Horizontal") * m_speed, 0.8f));
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
