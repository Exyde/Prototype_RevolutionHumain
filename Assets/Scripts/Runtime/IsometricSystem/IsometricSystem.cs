using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IsometricSystem{
    //Ref GDD : https://malouctor.notion.site/GameConcept-Demon-Int-rieur-51170de9b4f146a0a681956457590503

    public static Quaternion WorldRotation = Quaternion.Euler (0, 45, 0);
    //Create a 45° offseted Matrix for all the ingame.
	private static Matrix4x4 _isoMatrix = Matrix4x4.Rotate(WorldRotation);

    //Vector3 Extension Methods
	public static Vector3 ToIso(this Vector3 input) => _isoMatrix.MultiplyPoint3x4(input);

}
