using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Input keys
    [SerializeField] private KeyCode AttackKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode HideKey = KeyCode.Space;

    // Attack
    [SerializeField] private float attackSpeed = 5f;
    [SerializeField] private float attackDamage = 10f;
    private bool canAttack = true;

    // Hide
    public bool isHiding = false;

    [SerializeField] private float hideSpeed = 5f;
    private Vector3 hidePosition = Vector3.zero;
    private bool canHide = false;
    

    // Misc 
    private GameObject catModel;
    private ScratchController scratchController;

    private void Awake()
    {
        catModel = GameObject.Find("CatModel");
        scratchController = GetComponentInChildren<ScratchController>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(AttackKey) && canAttack)
        {
            StartCoroutine(Attack());
        }

        if(Input.GetKeyDown(HideKey))
        {
            if(canHide)
            {
                StartCoroutine(Hide(hidePosition));
            }
        }

        if(Input.GetKeyUp(HideKey))
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator Attack()
    {
        Debug.Log("Attack");

        float timeElapsed = 0.0f;

        canAttack = false;
        StartCoroutine(scratchController.PlayClawScratch());
        while (timeElapsed < attackSpeed)
        {
            timeElapsed += Time.deltaTime;
            Debug.Log("Cooldown " + timeElapsed + " / " + attackSpeed);
            yield return null;
        }

        canAttack = true;
    }

    private IEnumerator Hide(Vector3 targetPosition)
    {
        Debug.Log("Start hiding");
        

        float timeElapsed = 0.0f;

        Vector3 initialPosition = transform.position;

        targetPosition.z = 0.0f;

        float hideDuration = Vector3.Distance(initialPosition, targetPosition) / hideSpeed;

        while(timeElapsed < hideDuration)
        {
            float t = timeElapsed / hideDuration;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

            timeElapsed += Time.deltaTime;
            PlayerMovementController.Rotate(catModel, targetPosition - initialPosition, 0.1f);

            yield return null;
        }

        isHiding = true;
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "hideSpot")
        {
            canHide = true;
            hidePosition = other.gameObject.transform.position;
            Vector3 hideUIPosition = Camera.main.WorldToScreenPoint(hidePosition);
            GameManager.Instance.ToggleCanvas(other.gameObject);
            Debug.Log("Hide Position: " + hideUIPosition);  
            Debug.Log("Can Hide");
        }


        if (other.gameObject.tag == "Bounds")
        {
            Debug.Log("Player has entered the bounds " + other.gameObject.name);

            if (other.gameObject.name == "BoundsLeft")
            {
                Debug.Log("Player entered left bounds");

                Vector3 boundsPosition = GameManager.Instance.boundsRight.transform.position;

                float offSetX = other.gameObject.GetComponent<BoxCollider>().bounds.size.x + 5.0f;
                transform.position = new Vector3(boundsPosition.x + offSetX, 0.0f, transform.position.z);
            }
            else
            {
                Debug.Log("Player entered right bounds");

                Vector3 boundsPosition = GameManager.Instance.boundsLeft.transform.position;

                float offSetX = other.gameObject.GetComponent<BoxCollider>().bounds.size.x + 5.0f;
                transform.position = new Vector3(boundsPosition.x - offSetX, 0.0f, transform.position.z);
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "hideSpot")
        {
            canHide = false;
            Debug.Log("Can't Hide");
            GameManager.Instance.ToggleCanvas(other.gameObject);
        }
    }
    
}
