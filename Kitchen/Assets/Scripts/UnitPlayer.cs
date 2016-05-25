using UnityEngine;
using System.Collections;

public class UnitPlayer : Unit {

    float cameraRotX = 0f;
    public float cameraPitchMax = 45f;

	// Use this for initialization
	public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {

        // character rotation
        transform.Rotate(0f, Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime, 0f);

        // camera rotation
        cameraRotX -= Input.GetAxis("Mouse Y");
        cameraRotX = Mathf.Clamp(cameraRotX, -cameraPitchMax, cameraPitchMax); // limit the angle of camera rotation
        Camera.main.transform.forward = transform.forward; // reset the camera view
        Camera.main.transform.Rotate(cameraRotX, 0f, 0f);

        // movement
        move = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        move.Normalize();
        // transform the movement to the character's local orientation
        move = transform.TransformDirection(move);

        base.Update();
	}
}
