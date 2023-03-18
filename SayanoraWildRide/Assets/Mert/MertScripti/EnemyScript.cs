using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform EnemyPos = null;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, EnemyPos.transform.position, 10);
        //transform.rotation = EnemyPos.transform.rotation;
    }
}
