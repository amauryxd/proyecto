using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parabolicshot 
{
    public static Vector3 Position(float time, Vector3 initialPos, Vector3 initialVel)
    {
        Vector3 g = new Vector3(0, -9.81f, 0);
        return 0.5f * g * time * time + initialVel * time + initialPos;
    }
    public static Vector3 Velocity(float time, Vector3 initalPos, Vector3 initialVel)
    {
        Vector3 g = new Vector3(0, -9.81f, 0);
        return g * time + initialVel;
    }
    public static float TiempodeVuelo(Vector3 initialPos, Vector3 initialVel)
    {
        float g = 9.81f;
        //return initialVel.y+Mathf.Sqrt(initialVel.y*initialVel.y+2*g*)
        float v0y = initialVel.y;
        float y0 = initialPos.y;
        float result = (v0y + Mathf.Sqrt(v0y * v0y + 2 * g * y0)) / g;
        return result;
    }
}
