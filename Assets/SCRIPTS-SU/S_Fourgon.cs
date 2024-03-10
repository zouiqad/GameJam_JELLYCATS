using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class S_Fourgon : MonoBehaviour
{
    public float speed;

    private void Start()
    {
        transform.parent = null;
        StartCoroutine(speedup());
    }

    private void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, S_Player.instance.fourgonSpawn.position) > 50)
        {
            S_Player.noiseValue = 0;

            Destroy(gameObject);
        }
    }

    public IEnumerator speedup()
    {
        speed -= 1;
        yield return new WaitForSeconds(0.75f);
        StartCoroutine(speedup());
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<S_Player>() != null)
        {
            if(!S_Player.instance.isHided)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
