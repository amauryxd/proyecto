using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Torreta : MonoBehaviour
{
    public float rotSpeed;
    public Transform AxisX;
    public Transform AxisY;
    float angleX;

    public Transform shootpoint;
    public GameObject bulletprefab;
    public float bulletspeed;

    void Update()

    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            Vector3 pos =shootpoint.position;
            Quaternion rot = shootpoint.localRotation;
            GameObject bullet = Instantiate(bulletprefab,pos,rot);
            bullet.GetComponent<KinematicBullet>(). P0 = pos;
            bullet.GetComponent<KinematicBullet>().V0 = bulletspeed * shootpoint.forward;
        }

        Horizontalrt();
        Verticalrt();
    }
    void Horizontalrt()
    {
        float dt = Time.deltaTime;
        float hinput = Input.GetAxis("Horizontal");
        float angle = rotSpeed * dt * hinput;

        Vector3 eulerAngles = new Vector3 (0, angle, 0);
         AxisY.Rotate(eulerAngles, Space.Self);
    }
    void Verticalrt()
    {
        float dt = Time.deltaTime;
        float vInput = Input.GetAxis("Vertical");
        angleX -= rotSpeed * dt * vInput;
        angleX = Mathf.Clamp(angleX, -90f, 0f);
        AxisX.localRotation = Quaternion.Euler (angleX, 0, 0);
        
    }

}
