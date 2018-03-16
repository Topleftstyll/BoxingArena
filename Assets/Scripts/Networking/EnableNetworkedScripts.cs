using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EnableNetworkedScripts : NetworkBehaviour {

	void Start() {
		if(isLocalPlayer) {
			GetComponent<Movement>().enabled = true;
		}
		GameManager.Instance.AddPlayer(gameObject);
	}

	public override void OnStartLocalPlayer() {
        GetComponent<MeshRenderer>().material.color = Color.blue;
		this.tag = "Player";
    }
}
