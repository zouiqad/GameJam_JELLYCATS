using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Bush : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<S_Player>() != null)
        {
            other.GetComponent<S_Player>().isHided = true;
        }


    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<S_Player>() != null)
        {
            other.GetComponent<S_Player>().isHided = false;
        }
    }

}
