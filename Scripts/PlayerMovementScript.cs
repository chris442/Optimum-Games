using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {

    public float speed = 2.0F;
    public float sprintSpeed = 2.5f;
    public float jumpSpeed = 4.0F;
    public float gravity = 10.0F;

    bool grounded = false;

    private CharacterController controller = null;
    private Vector3 moveDirection = Vector3.zero;
    public bool walking = false;
    public bool run = false;

    // Use this for initialization
    void Start()
    {
	    controller = GetComponent<CharacterController>();
        if (!controller)
        {
            controller = gameObject.AddComponent<CharacterController>();
        }
    }

    void FixedUpdate()
    {

        if (grounded)
        {
            // We are grounded, so recalculate movedirection directly from axes
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }
      
        // Apply gravity
        moveDirection.y -= gravity * Time.deltaTime;

        // Move the controller
        var flags = controller.Move(moveDirection * Time.deltaTime);
        grounded = (flags & CollisionFlags.CollidedBelow) != 0;
    }

  
    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (run)
            {
                moveDirection *= sprintSpeed;
            }

            if (Input.GetKey("space"))
            {
                moveDirection.y = jumpSpeed;
            }

        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);
        //add this into FixedUpdate()
       
        if ((Mathf.Abs(moveDirection.x) > 0) || (Mathf.Abs(moveDirection.z) > 0))
        {
            //if the player is moving, walking is true
            if (!walking)
            {
                walking = true;
            }
        }
        else if (walking)
        {
            walking = false;
        }
    }
}
