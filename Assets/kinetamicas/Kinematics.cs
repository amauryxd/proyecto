using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematics 
{
    public static Vector3 MovimientoRectilineoUniforme(float time, Vector3 InitialPosition, Vector3 InitialVecocity)
    {
        return InitialVecocity * time + InitialPosition;
    }


}
