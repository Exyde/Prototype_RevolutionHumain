using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "ScriptableObjects/PlayerDatas", order = 1)]
public class PlayerDatas : ScriptableObject
{
#region Serialized Fields
	[Header ("Movement Datas")]
	[SerializeField] [Range (0, 20)] public float _moveSpeed;
	[SerializeField] [Range (100, 1000)] public float _turnSpeed;

	[Header ("Dash Datas")]

	[SerializeField] [Range (0, 1000)] public float _dashSpeed;
	[SerializeField] [Range (0, 5)] public float _dashDuration;
	[SerializeField] [Range (0, 10)] public float _dashCooldown;
	[SerializeField] [Range (0, 100)] public float _dashMentalStabilityDecayPercentage;

	[Header ("Debug")]
	[SerializeField] public bool _canDash = true;
	[SerializeField] public bool _isDashing;
	[SerializeField] public bool _dashDisableMovement;
	[SerializeField] public bool _dashEndResetVelocity;
	#endregion

	public void ResetDashData(){
		_canDash = true;
		_isDashing = false;
	}

}
