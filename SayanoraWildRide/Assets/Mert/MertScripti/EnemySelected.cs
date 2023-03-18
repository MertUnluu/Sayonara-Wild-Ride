using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySelected : MonoBehaviour
{
    public GameObject Select = null;

    private void OnMouseDown()
    {
        Select.SetActive(true);
        Debug.Log("Hmm");
    }

}
