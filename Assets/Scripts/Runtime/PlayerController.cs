using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
	
	public void HandleMove(Vector2 inputs) {
		Debug.Log("Move");
	}

	public void HandleDash() => Debug.Log("Dash");
	public void HandleInteract() => Debug.Log("Interact");

}
