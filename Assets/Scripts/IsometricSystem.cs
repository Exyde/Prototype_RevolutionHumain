using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IsometricSystem{

    //Create a 45° offseted Matrix for all the ingame.
	private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(Quaternion.Euler (0, 45, 0));

    //Vector3 Extension Methods
	public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);
}
