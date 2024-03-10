using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_AttackTrigger : MonoBehaviour
{
    public int[] croquetteAmount;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ennemi")
        {
            print("Aie");
            StartCoroutine(Death(other.gameObject));
        }
    }

    IEnumerator Death(GameObject ennemi)
    {
        print("Death");
        S_Player.croquetteAmount += Random.Range(croquetteAmount[0], croquetteAmount[1]);
        S_Player.noiseValue += 1;
        S_Player.instance.CheckNoises();
        //Instantie FX poof : >>>>>>>>>>>
        //Instantie cadavre : >>>>>>>>>>>
        Destroy(ennemi);
        yield return null;
    }
}
