using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ArrowPlacer : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab de la flecha
    public Vector3[] arrowPositions; // Posiciones relativas al patrón
    private GameObject[] arrows; // Instancias de flechas
    private int currentArrowIndex = 0;

    public void PlaceArrows(Transform trackedImage)
    {
        arrows = new GameObject[arrowPositions.Length];
        for (int i = 0; i < arrowPositions.Length; i++)
        {
            Vector3 worldPosition = trackedImage.TransformPoint(arrowPositions[i]);
            arrows[i] = Instantiate(arrowPrefab, worldPosition, trackedImage.rotation);
            arrows[i].SetActive(i == 0); // Solo activa la primera flecha inicialmente
        }
    }

    public void ActivateNextArrow()
    {
        if (currentArrowIndex < arrows.Length - 1)
        {
            arrows[currentArrowIndex].SetActive(false);
            currentArrowIndex++;
            arrows[currentArrowIndex].SetActive(true);
        }
    }
}
