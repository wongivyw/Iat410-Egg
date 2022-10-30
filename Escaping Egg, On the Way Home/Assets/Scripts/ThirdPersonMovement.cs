using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{

    public Animator animator;

    [SerializeField] public float jumpForce = 12f;
    public bool isOnGround = true;
    //starting level for player size 
    public int level;
    //max level for player size (when food is consumed, level up by one)
    public int MAXlevel;
    //object pickup UI
    public GetUI getui;
    //source of camera and player movement: https://www.youtube.com/watch?v=4HpC--2iowE
    public CharacterController controller;
    public Transform cam; //reference to our camera
    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    float horizontal = 0f;
    float vertical = 0f;
    float y = 0f;

    private Rigidbody rigidbodyComponent;
    public SpriteRenderer foodUI;
    private GameObject currTriggerObj = null;
    private GameObject currTriggerFood = null;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        // player movement
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 to 1
        vertical = Input.GetAxisRaw("Vertical"); // -1 to 1
        y = rigidbodyComponent.velocity.y;
        if (currTriggerObj != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                getui.Get(currTriggerObj);
            }
        }
        //destroy food thats been eaten
        if (currTriggerFood != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Destroy(currTriggerFood);
                jumpForce += 5;
                transform.localScale = transform.localScale * 1.2f;
                level++;
                foodUI.enabled = false;
            }
        }

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //0f because we don't want our player to move upwards

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isMoving", true);
            // makes player turn in the direction that it is moving in
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; // get in radians degrees, also adds rotation of camera on y axis
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            // allows the user to move the player using wasd and arrow keys
            // calculates direction we want to move in taking into account the direction of the camera.
            // i.e. wherever your camera is facing, player will move in that direction as going "forward".
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //controller.Move(moveDirection.normalized * speed * Time.deltaTime);
            transform.Rotate(0, Input.GetAxis("Horizontal") * turnSmoothTime * Time.deltaTime, 0);
            moveDirection.y = 0;
            //Vector3 vel = transform.forward * Input.GetAxis("Vertical") * speed;
            // controller.SimpleMove(moveDirection.normalized * speed);
            transform.Translate(moveDirection.normalized * speed * Time.deltaTime, Space.World);

        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        //jump action
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        
        if (other.gameObject.CompareTag("Get"))
        {

        }
        //check if an object can be eaten
        if (other.gameObject.CompareTag("Food"))
        {
            if (level >= MAXlevel) return;

            currTriggerFood = other.gameObject;
            foodUI.enabled = true;
        }
    }

    void OnTriggerStay(Collider other)
    {
        //check if an object can be picked up
        if (other.gameObject.CompareTag("Get"))
        {
            if (getui.isOpen)
            {
                currTriggerObj = other.gameObject;
            }
            else
            {
                if (GetUI.IsGet)
                {
                    getui.OpenGet();
                }
            }
        }
        if (other.gameObject.CompareTag("Food"))
        {
            if (level >= MAXlevel) return;

            currTriggerFood = other.gameObject;
            foodUI.enabled = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.CompareTag("Get"))
        {
            if (getui.isOpen)
            {
                if (currTriggerObj == other.gameObject)
                {
                    currTriggerObj = null;
                }
                getui.CloseGet();
            }
        }
        
        else if (other.gameObject.CompareTag("Food"))
        {
            currTriggerFood = null;
            foodUI.enabled = false;
        }
    }
    private void FixedUpdate()
    {
        //y = rigidbodyComponent.velocity.y;
        // rigidbodyComponent.velocity = new Vector3(horizontal, y, 0);

    }
}
