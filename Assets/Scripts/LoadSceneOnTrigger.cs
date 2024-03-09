using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnTrigger : MonoBehaviour
{
    [SerializeField] private string SceneName;
    [SerializeField] private string TagToReact = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == TagToReact)
            SceneManager.LoadScene(SceneName);
    }
}
