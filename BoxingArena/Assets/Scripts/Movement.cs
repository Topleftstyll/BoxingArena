using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float m_speed = 5.0f;
	public float m_dashCooldown = 5.0f;
	public float m_dashSpeed = 15.0f;

	private Rigidbody m_rb;
	private float m_velocitySlowAmount = 0.8f;
	private bool m_canDash = true;

	void Start() {
		m_rb = GetComponent<Rigidbody>();
	}

	 void Update() {
		// rotate the player so it faces the mouse
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
		Vector2 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
		transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));
    }
	
	void FixedUpdate() {
		// top if the screen is always forward rotation
		m_rb.velocity = new Vector3(Mathf.Lerp(0, Input.GetAxis("Horizontal") * m_speed, 0.8f), 0, Mathf.Lerp(0, Input.GetAxis("Vertical") * m_speed, 0.8f));

		if(Input.GetKey(KeyCode.Space) && m_canDash) {
			Dash(m_rb.velocity);
		}

		// slows the velocity over time if nothing else is preesed
		m_rb.velocity = m_rb.velocity * m_velocitySlowAmount;
	}

	void Dash(Vector3 direction) {
		m_canDash = false;
		m_rb.velocity = direction * m_dashSpeed;
		StartCoroutine(DashCooldown(m_dashCooldown));
	}

	float AngleBetweenTwoPoints(Vector3 a, Vector3 b) {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }

	private IEnumerator DashCooldown(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        m_canDash = true;
    }
}
