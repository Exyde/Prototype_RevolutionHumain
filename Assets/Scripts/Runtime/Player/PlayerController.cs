using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//Reference video : https://www.youtube.com/watch?v=8ZxVBCvJDWk

public class PlayerController : Entity{

	[SerializeField] PlayerDatas _playerDatas;

	#region Private Fields
	private Vector3 _inputs;
	private Rigidbody _rb;
	#endregion 

	#region Unity Callbacks
	private void Awake()
	{
		_rb = GetComponent<Rigidbody>();
		_playerDatas.ResetDashData();
	}

	private void Update()
	{
		if (_playerDatas._isDashing && _playerDatas._dashDisableMovement) return;
	}
	private void FixedUpdate()
	{
		if (_playerDatas._isDashing && _playerDatas._dashDisableMovement) return;
		Move();
	}
	#endregion 

	#region Methods
	private void Move(){
		_rb.MovePosition (transform.position + (_inputs.ToIso() * _inputs.magnitude) *_playerDatas. _moveSpeed * Time.deltaTime);
	}

	IEnumerator Dash(){
		Debug.Log("Started Dash");
		_playerDatas._canDash = false;
		_playerDatas._isDashing = true;
		_rb.useGravity = false;
		Vector3 vel = (_inputs.ToIso() * _playerDatas._dashSpeed);
		_rb.velocity = vel;

		GameManager._instance.AdjustSanity(-_playerDatas._dashMentalStabilityDecayPercentage);
		//Fx ---
		yield return new WaitForSeconds(_playerDatas._dashDuration);
		_rb.useGravity = true;
		_playerDatas._isDashing = false;
		if (_playerDatas._dashEndResetVelocity) _rb.velocity = Vector3.zero;
		Debug.Log("Ended Dash");

		yield return new WaitForSeconds(_playerDatas._dashCooldown);
		_playerDatas._canDash = true;
		Debug.Log("Dash is ready !");

	}
	#endregion

	#region Inputs Callbacks
	public void HandleMove(Vector2 inputs) {
		_inputs = new Vector3(inputs.x, 0, inputs.y);
	}

	public void HandleDash(){
		Debug.Log("Dash button pressed");
		if (_playerDatas._canDash && _inputs != Vector3.zero) StartCoroutine(Dash());
	}
	public void HandleInteract() => Debug.Log("Interact");
	#endregion 

	//Deprecatted
	// private void Look(){
	// 	if (_inputs == Vector3.zero) return;

	// 	// Matrix4x4 matrix = Matrix4x4.Rotate(Quaternion.Euler (0, 45, 0));
	// 	// //Just like BOTW skew ! :D
	// 	// var skewedInput = matrix.MultiplyPoint3x4(_inputs);

	// 	var relative = (transform.position + _inputs.ToIso()) - transform.position;
	// 	var rot = Quaternion.LookRotation (relative, Vector3.up);
	// 	transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, _playerDatas._turnSpeed * Time.deltaTime);
	// }
}
