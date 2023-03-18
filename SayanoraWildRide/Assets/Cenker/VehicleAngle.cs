using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleAngle : MonoBehaviour
{
    public Transform vehicle;
    public float angleMultiplier = 1;

    float horizontalValue;
    float horizontalSpeed=90;
    public float slowingValue=20f;
    public float angleLimit = 20f;

    public bool isCar = false;

    // Update is called once per frame
    void Update()
    {
        if (vehicle)
        {
            if (Input.GetButton("Right"))
            {
                horizontalValue -= horizontalSpeed * angleMultiplier * Time.deltaTime;
            }

            else if (Input.GetButton("Left"))
            {
                horizontalValue += horizontalSpeed * angleMultiplier * Time.deltaTime;
            }
            horizontalValue= Mathf.Clamp(horizontalValue, -angleLimit, angleLimit);

            // horizontalValue = (horizontalValue / slowingValue) * Time.deltaTime;


            if (isCar)
            {
                vehicle.localRotation = Quaternion.Euler(0, -horizontalValue, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, horizontalValue);
            }


             



            horizontalValue = horizontalValue >= 0 ? horizontalValue - (slowingValue * Time.deltaTime) : horizontalValue + (slowingValue * Time.deltaTime);
            


            Debug.Log(horizontalValue);
        }

    }
}
