using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player has entered the bounds");

            if (this.gameObject.name == "BoundsLeft")
            {
                Vector3 boundsPosition = GameManager.Instance.boundsRight.transform.position;
                Debug.Log("Player entered left bounds");
                collision.transform.position = new Vector3(boundsPosition.x, 0.0f, collision.transform.position.z);
            }
            else
            {
                Vector3 boundsPosition = GameManager.Instance.boundsLeft.transform.position;
                Debug.Log("Player entered right bounds");
                collision.transform.position = new Vector3(boundsPosition.x, 0.0f, collision.transform.position.z);
            }

        }
    }
}
