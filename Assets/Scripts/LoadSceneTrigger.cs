using UnityEngine;

public class ActivationCollider : MonoBehaviour
{
    public GameObject vetoObject; // Référence à l'objet avec le tag "Veto"
    public BoxCollider targetCollider; // BoxCollider à activer

    private void Start()
    {
        // BoxCollider désactivée au démarrage
        if (targetCollider != null)
        {
            targetCollider.enabled = false;
        }
    }

    private void Update()
    {
        // Si l'objet "Veto" est détruit
        if (vetoObject == null && targetCollider != null && !targetCollider.enabled)
        {
            // La BoxCollider s'active
            targetCollider.enabled = true;
        }
    }
}