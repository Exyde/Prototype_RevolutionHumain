using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Reference video : https://www.youtube.com/watch?v=8ZxVBCvJDWk

public class PlayerController : MonoBehaviour{
	
	#region Fields
	[Header ("Player Datas")]
	[SerializeField] [Range (0, 100)] float _moveSpeed;
	[SerializeField] [Range (100, 1000)] float _turnSpeed;

	Vector3 _inputs;

	private Rigidbody _rb;
	#endregion 

	#region Unity Callbacks
	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		Look();
	}
	private void FixedUpdate()
	{
		Move();
	}
	#endregion 

	#region Methods
	private void Move(){
		_rb.MovePosition (transform.position + (transform.forward * _inputs.magnitude) * _moveSpeed * Time.deltaTime);
	}

	private void Look(){
		if (_inputs == Vector3.zero) return;

		// Matrix4x4 matrix = Matrix4x4.Rotate(Quaternion.Euler (0, 45, 0));
		// //Just like BOTW skew ! :D
		// var skewedInput = matrix.MultiplyPoint3x4(_inputs);

		var relative = (transform.position + _inputs.ToIso()) - transform.position;
		var rot = Quaternion.LookRotation (relative, Vector3.up);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _turnSpeed * Time.deltaTime);
	}
	#endregion

	#region Inputs Callbacks
	public void HandleMove(Vector2 inputs) {
		_inputs = new Vector3(inputs.x, 0, inputs.y);
	}

	public void HandleDash() => Debug.Log("Dash");
	public void HandleInteract() => Debug.Log("Interact");
	#endregion 

}
