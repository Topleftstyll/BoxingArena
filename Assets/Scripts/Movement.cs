using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	public float m_speed = 5.0f;
	public float m_dashCooldown = 5.0f;
	public float m_dashSpeed = 15.0f;
	public float m_timePunchIsBig = .2f;
	public float m_punchCoolDown = .2f;
	public float m_punchSpeed = 1000f;
	public GameObject m_rightFist;
	public GameObject m_leftFist;
	public GameObject m_rightSpring;
	public GameObject m_leftSpring;
	public GameObject m_glove;
	public Transform m_LeftArmLocation;
	public Transform m_RightArmLocation;
	public bool m_canRightPunch = true;
	public bool m_canLeftPunch = true;

	private Rigidbody m_rb;
	private float m_velocitySlowAmount = 0.8f;
	private bool m_canDash = true;
	private Vector2 mouseOnScreen; 
	void Start() {
		m_rb = GetComponent<Rigidbody>();
	}

	 void Update() {
		// rotate the player so it faces the mouse
		Vector2 positionOnScreen = Camera.main.WorldToViewportPoint(transform.position);
		 mouseOnScreen = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);
		float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);
		transform.rotation = Quaternion.Euler(new Vector3(0, -angle, 0));

		if(Input.GetMouseButtonDown(1) && m_canRightPunch) {
			m_canRightPunch = false;
			m_rightFist.SetActive(false);
			StartCoroutine(SetPunch(m_timePunchIsBig, m_rightFist, false));
		}

		if(Input.GetMouseButtonDown(0) && m_canLeftPunch) {
			m_canLeftPunch = false;
			m_leftFist.SetActive(false);
			StartCoroutine(SetPunch(m_timePunchIsBig, m_leftFist, true));
		} 
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

	private IEnumerator SetPunch(float waitTime, GameObject spring, bool isLeftPunch) {
		if(isLeftPunch){
			var punch = Instantiate(m_glove, m_LeftArmLocation.position, Quaternion.identity);
			punch.tag = "LeftFist";
			punch.GetComponent<PunchCollider>().m_player = this;
			punch.transform.forward = m_LeftArmLocation.forward;
			punch.GetComponent<Rigidbody>().AddForce(punch.transform.forward * m_punchSpeed);
			Destroy(punch, waitTime);
		} else {
			var punch = Instantiate(m_glove, m_RightArmLocation.position, Quaternion.identity);
			punch.tag = "RightFist";
			punch.GetComponent<PunchCollider>().m_player = this;
			punch.transform.forward = m_RightArmLocation.forward;
			punch.GetComponent<Rigidbody>().AddForce(punch.transform.forward * m_punchSpeed);
			Destroy(punch, waitTime);
		}
        yield return new WaitForSeconds(waitTime);
		spring.SetActive(true);
		if(isLeftPunch) {
			StartCoroutine(WaitBetweenPunches(m_punchCoolDown, true));
		} else {
			StartCoroutine(WaitBetweenPunches(m_punchCoolDown, false));
		}
    }

	private IEnumerator WaitBetweenPunches(float waitTime, bool isLeftPunch) {
		yield return new WaitForSeconds(waitTime);
		if(isLeftPunch) {
			m_canLeftPunch = true;
		} else {
			m_canRightPunch = true;
		}
	}
}
