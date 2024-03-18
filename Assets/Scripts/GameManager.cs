using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    
    public GameObject boundsLeft;
    public GameObject boundsRight;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ToggleCanvas(GameObject gameObject)
    {
        Transform canvas = gameObject.transform.Find("Canvas");

        if (canvas)
        {
            canvas.gameObject.SetActive(!canvas.gameObject.activeInHierarchy);
        }
    }

}
