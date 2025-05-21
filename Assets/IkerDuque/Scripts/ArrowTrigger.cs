using UnityEngine;

public class ArrowTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            FindObjectOfType<ArrowPlacer>().ActivateNextArrow();
            Destroy(gameObject); // Opcional, eliminar flechas recolectadas
        }
    }
}
