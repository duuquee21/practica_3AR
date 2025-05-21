using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class TrackedImageHandler : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    public ArrowPlacer arrowPlacer;

    private void OnEnable()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs args)
    {
        foreach (var trackedImage in args.added)
        {
            arrowPlacer.PlaceArrows(trackedImage.transform);
        }
    }
}
