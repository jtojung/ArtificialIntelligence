using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithinBounds1 : MonoBehaviour {

    public float moveSpeed = 15f;
    public float zoomSpeed = 20f;
    public CameraBounds comBounds;

	
	
	// Update is called once per frame
	void LateUpdate () {
        // Move the camera left + right
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        Vector3 inputDir = new Vector3(inputH, 0, inputV);
        // position += (direction x speed) x deltaTime
        //                      |
        //                      V
        //                    Velocity     x deltaTime
        transform.position += inputDir * moveSpeed * Time.deltaTime;
        // Zoom the camera in + out
        // inputScroll gives you back either -1,1 or 0
        float inputScroll = Input.GetAxis("Mouse ScrollWheel");
        // +=- appending position
        transform.position += transform.forward * inputScroll * zoomSpeed * Time.deltaTime;
        // Cap the position to stay within camera bounds
        transform.position = comBounds.GetAdjustedPositon(transform.position);

	}
}
