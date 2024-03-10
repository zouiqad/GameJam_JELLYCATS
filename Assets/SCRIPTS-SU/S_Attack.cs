using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class S_Attack : MonoBehaviour
{

    public KeyCode attackinput;
    public GameObject attackBox;

    bool onCD;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(attackinput) && !onCD)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        onCD = true;
        attackBox.SetActive(true);

        // Appliquer l'animation : >>>>>>>>>>> 
        // Instantier un VFX : >>>>>>>>>>>>>>>
        yield return new WaitForSeconds(0.2f);

        attackBox.SetActive(false);

        yield return new WaitForSeconds(1);
        onCD = false;
    }
}
