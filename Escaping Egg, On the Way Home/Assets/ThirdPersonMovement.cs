using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour {

    //source of camera and player movement: https://www.youtube.com/watch?v=4HpC--2iowE
    public CharacterController controller;
    public Transform cam; //reference to our camera
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    // Update is called once per frame
    void Update() {

        // player movement
        float horizontal = Input.GetAxisRaw("Horizontal"); // -1 to 1
        float vertical = Input.GetAxisRaw("Vertical"); // -1 to 1
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //0f because we don't want our player to move upwards

        if (direction.magnitude >= 0.1f) {
            // makes player turn in the direction that it is moving in
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // get in radians degrees, also adds rotation of camera on y axis
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            // allows the user to move the player using wasd and arrow keys

            // calculates direction we want to move in taking into account the direction of the camera.
            // i.e. wherever your camera is facing, player will move in that direction as going "forward".
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; 
            controller.Move(moveDirection.normalized * speed * Time.deltaTime);
        }
    }
}
