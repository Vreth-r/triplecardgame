using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DraggableCard : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Plane dragPlane;
    private Vector3 offset;
    private Camera cam;
    private Transform originalParent;
    private bool dragging;

    private float fixedY; // store the card’s Y height at drag start

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    [Header("Snapback Settings")]
    public float snapDuration = 0.25f;

    public void OnBeginDrag(PointerEventData eventData)
    {
        cam = eventData.pressEventCamera != null ? eventData.pressEventCamera : Camera.main;
        if (cam == null) return;

        // Save Y position
        fixedY = transform.position.y;
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        originalParent = transform.parent;

        // Create a horizontal drag plane at this Y height
        dragPlane = new Plane(Vector3.up, new Vector3(0, fixedY, 0));

        Ray ray = cam.ScreenPointToRay(eventData.position);
        if (dragPlane.Raycast(ray, out float enter))
        {
            offset = transform.position - ray.GetPoint(enter);
        }

        dragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!dragging || cam == null) return;

        Ray ray = cam.ScreenPointToRay(eventData.position);
        if (dragPlane.Raycast(ray, out float enter))
        {
            Vector3 targetPos = ray.GetPoint(enter) + offset;

            // Lock Y so card stays on the table
            targetPos.y = fixedY;

            transform.position = targetPos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;

        // If not dropped on a zone → snap back
        if (!IsPointerOverDropZone(eventData))
        {
            StartCoroutine(SnapBack());
        }
    }

    private IEnumerator SnapBack()
    {
        Vector3 startPos = transform.position;
        Quaternion startRot = transform.rotation;

        float elapsed = 0f;
        while (elapsed < snapDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / snapDuration;

            transform.position = Vector3.Lerp(startPos, originalPosition, t);
            transform.rotation = Quaternion.Slerp(startRot, originalRotation, t);

            yield return null;
        }

        transform.position = originalPosition;
        transform.rotation = originalRotation;
        transform.SetParent(originalParent);
    }

    private bool IsPointerOverDropZone(PointerEventData eventData)
    {
        if (eventData.pointerEnter == null) return false;
        return eventData.pointerEnter.GetComponentInParent<DropZone>() != null;
    }
}
