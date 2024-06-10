using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    public float rotationSpeed = 10f;
    //public float speed = 2f;
    public Transform groundCheckerTransform;
    public LayerMask notPlayerMask;
    public float jumpForce = 2f;
    public float ahill = 10;
    public targetPlayer targetP;
    public ParticleSystem MusicFlash;
    public ParticleSystem MusicFlash2;

    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    // Start is called before the first frame update
    void Start()
    {
        targetP = GetComponent<targetPlayer>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }


        if(Input.GetMouseButtonDown(0)){
            Shoot();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Dance();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            Dance2();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            Hill();
        }

        if (Physics.CheckSphere(groundCheckerTransform.position, 0.2f, notPlayerMask))
        {
            animator.SetBool("isInAir", false);
        }
        else
        {
            animator.SetBool("isInAir", true);
        }

        }

    void Jump()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheckerTransform.position, Vector3.down, 0.2f, notPlayerMask))
        {
            animator.SetTrigger("jump");
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        else
        {
            Debug.Log("Did not find ground layer");
        }
    }

    void Dance()
    {
        MusicFlash.Play();
        animator.SetTrigger("Dance");
    }

    void Dance2()
    {
        MusicFlash2.Play();
        animator.SetTrigger("Dance2");
    }

    void Hill()
    {
        targetP.TakeHill(ahill);
        animator.SetTrigger("Hill");
    }

    void Shoot()
    {
        animator.SetTrigger("Shoot");
        animator.SetTrigger("Idle");
    }
}
