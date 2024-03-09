using UnityEngine;

public class ActivationCollider : MonoBehaviour
{
    public GameObject vetoObject; // R�f�rence � l'objet avec le tag "Veto"
    public BoxCollider targetCollider; // BoxCollider � activer

    private void Start()
    {
        // BoxCollider d�sactiv�e au d�marrage
        if (targetCollider != null)
        {
            targetCollider.enabled = false;
        }
    }

    private void Update()
    {
        // Si l'objet "Veto" est d�truit
        if (vetoObject == null && targetCollider != null && !targetCollider.enabled)
        {
            // La BoxCollider s'active
            targetCollider.enabled = true;
        }
    }
}