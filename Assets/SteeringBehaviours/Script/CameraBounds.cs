using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBounds : MonoBehaviour
{
    public Vector3 size = new Vector3(50f, 0f, 20f);

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, size);
    }

    // <summary>
    // This function returns an adjusted vector3
    // </summary>
    /// <param name="incomingPos">The position coming in</param>
    /// <returns></returns>
    public Vector3 GetAdjustedPositon(Vector3 incomingPos)
    {
        // Get bounds position
        Vector3 pos = transform.position;
        Vector3 halfSize = size * 0.5f;
        // if the incomingPos is outside the bounds on x
        if (incomingPos.x > pos.x + halfSize.x)
        {
            // cap it
            incomingPos.x = pos.x + halfSize.x;
        }

        // if the incomingPos is outside the bounds on x
        if (incomingPos.x < pos.x - halfSize.x)
        {
            // cap it
            incomingPos.x = pos.x - halfSize.x;
        }

        // if the incomingPos is outside the bounds on z
        if (incomingPos.z > pos.z + halfSize.z)
        {
            // cap it
            incomingPos.z = pos.z + halfSize.z;
        }

        if (incomingPos.z < pos.z - halfSize.z)
        {
            // cap it
            incomingPos.z = pos.z - halfSize.z;
        }

        return incomingPos;
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
