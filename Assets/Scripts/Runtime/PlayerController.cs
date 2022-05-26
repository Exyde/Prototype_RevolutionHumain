using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{
	
	
	#region Fields
	[Header ("Player Datas")]
	[SerializeField] [Range (0, 100)] float _moveSpeed;


	private Rigidbody _rb;
	#endregion 

	#region Unity Callbacks
	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		_rb.MovePosition (transform.position + transform.forward * _moveSpeed * Time.deltaTime);
	}
	#endregion 


	#region Inputs Callbacks
	public void HandleMove(Vector2 inputs) {
		Debug.Log("Move");
	}

	public void HandleDash() => Debug.Log("Dash");
	public void HandleInteract() => Debug.Log("Interact");
	#endregion 

}
