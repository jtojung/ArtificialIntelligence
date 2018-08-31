using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Vector3 size = new Vector3(50f, 0f, 20f);

    public Vector3 GetAdjustedPositon(Vector3 incomingPos)
    {
        // Get bounds position
        Vector3 pos = transform.position;
        Vector3 halfSize = size * 0.5f;

        if(incomingPos.z > pos.z + halfSize.z)
        {
            incomingPos.z = pos.z + halfSize.z;
        }

    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
