using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Reference video : https://www.youtube.com/watch?v=8ZxVBCvJDWk

public class PlayerController : Entity{
	
	#region Serialized Fields
	[Header ("Movement Datas")]
	[SerializeField] [Range (0, 100)] float _moveSpeed;
	[SerializeField] [Range (100, 1000)] float _turnSpeed;

	[Header ("Dash Datas")]
	[SerializeField] bool _canDash = true;
	[SerializeField] bool _isDashing;
	[SerializeField] bool _dashDisableMovement;
	[SerializeField] bool _dashEndResetVelocity;

	[SerializeField] [Range (0, 1000)] float _dashSpeed;
	[SerializeField] [Range (0, 5)] float _dashDuration;
	[SerializeField] [Range (0, 10)] float _dashCooldown;
    [SerializeField] [Range (0, 100)] float _mentalStabilityDecayPercentage;
	#endregion

	#region Private Fields
	private Vector3 _inputs;
	private Rigidbody _rb;
	#endregion 

	#region Unity Callbacks
	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (_isDashing && _dashDisableMovement) return;
		//Look();
	}
	private void FixedUpdate()
	{
		if (_isDashing && _dashDisableMovement) return;
		Move();
	}
	#endregion 

	#region Methods
	private void Move(){
		// _rb.MovePosition (transform.position + (transform.forward * _inputs.magnitude) * _moveSpeed * Time.deltaTime);
		_rb.MovePosition (transform.position + (_inputs.ToIso() * _inputs.magnitude) * _moveSpeed * Time.deltaTime);

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

	IEnumerator Dash(){
		Debug.Log("Started Dash");
		_canDash = false;
		_isDashing = true;
		_rb.useGravity = false;
		Vector3 vel = (transform.forward * _dashSpeed);
		_rb.velocity = vel;

		GameManager._instance.AdjustSanity(-_mentalStabilityDecayPercentage);
		//Fx ---
		yield return new WaitForSeconds(_dashDuration);
		_rb.useGravity = true;
		_isDashing = false;
		if (_dashEndResetVelocity) _rb.velocity = Vector3.zero;
		Debug.Log("Ended Dash");

		yield return new WaitForSeconds(_dashCooldown);
		_canDash = true;
		Debug.Log("Dash is ready !");

	}
	#endregion

	#region Inputs Callbacks
	public void HandleMove(Vector2 inputs) {
		_inputs = new Vector3(inputs.x, 0, inputs.y);
	}

	public void HandleDash(){
		Debug.Log("Dash button pressed");
		if (_canDash) StartCoroutine(Dash());
	}
	public void HandleInteract() => Debug.Log("Interact");
	#endregion 
}
