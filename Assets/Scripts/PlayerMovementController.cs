using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovementController : MonoBehaviour
{

    [SerializeField, Range(0.1f, 1.0f)] private float rotationSpeeed = 0.1f;
    [SerializeField] private float moveSpeed = 10.0f;

    private GameObject catModel;

    private void Awake()
    {
        catModel = GameObject.Find("CatModel");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, -verticalInput);

        if(moveDirection != Vector3.zero)
        {
            Rotate(catModel, moveDirection, rotationSpeeed);
            Move();

        }

    }


    private void Move()
    {
        transform.position += catModel.transform.forward * Time.deltaTime * moveSpeed;
    }

    public static void Rotate(GameObject catModel, Vector3 targetPosition, float rotationSpeeed)
    {
        Quaternion rotationFrom = catModel.transform.rotation;
        Quaternion rotationTo = Quaternion.LookRotation(targetPosition.normalized, Vector3.up);


        catModel.transform.rotation = Quaternion.Slerp(rotationFrom, rotationTo, rotationSpeeed);
    }




}
