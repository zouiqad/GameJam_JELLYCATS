using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class S_Player : MonoBehaviour
{
    public static S_Player instance;
    Rigidbody rb;

    public Transform t_cameraHolder;

    [Header("Mouvements")]
    public KeyCode jumpInput = KeyCode.Space;
    public float movSpeed = 8;
    public float jumpForce = 35;
    public float gravity = 5000;

    public bool isGrounded = false;
    public float groundDetectionLenght = 0.55f;

    public Transform catModel;

    [Header("Manager")]
    public bool isHided;
    public int maxNoises;
    public bool fourgon;
    public GameObject fourgonP;
    public Transform fourgonSpawn;
    public static int croquetteAmount;
    public static int noiseValue;
    public Slider croquetteSlider;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        if(GetComponent<Rigidbody>() == null)
        {
            gameObject.AddComponent<Rigidbody>();
        }
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //La cam suit le joueur
        t_cameraHolder.position = transform.position;
        float direction = Input.GetAxis("Horizontal");

        Mov(direction);

        if (direction == 0)
        {
            rb.velocity = Vector3.zero; 
        }

        //input de saut
        if (Input.GetKeyDown(jumpInput) && isGrounded)
        {
            Jump();
        }

        //Check si le joueur est au sol
        if (!isGrounded)
        {
            CheckGround();
            GravityFall();
        }

        catModel.forward = Vector3.Lerp(catModel.forward, transform.right * direction, 0.35f);

    }

    void Mov(float direction)
    {
        rb.velocity = transform.right * direction * movSpeed;
    }

    void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;
    }

    //Check si le joueur est au sol
    void CheckGround()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, Vector3.down, out hit, groundDetectionLenght))
        {
            isGrounded = true;
        }
    }

    void GravityFall()
    {
        print("gravity apply");
        rb.AddForce(Vector3.down * gravity * Time.deltaTime, ForceMode.Force);
    }

    public void CheckNoises()
    {
        if(noiseValue >= maxNoises && !fourgon)
        {
            Instantiate(fourgonP, fourgonSpawn);
        }
        //croquetteSlider.value = croquetteAmount / 100;
    }

}
