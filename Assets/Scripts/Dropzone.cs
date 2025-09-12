using UnityEngine;
using UnityEngine.EventSystems;

public enum DropzoneType
{
    Battlefield,
    Discard,
    Hand
}

[RequireComponent(typeof(Collider))]
public class Dropzone : MonoBehaviour, IDropHandler
{
    public DropzoneType zoneType;
    public HandManager handManager; // assign reference in Inspector if needed

    public void OnDrop(PointerEventData eventData)
    {
        var draggable = eventData.pointerDrag?.GetComponent<DraggableCard>();
        if (draggable == null) return;

        // Reparent under this zone
        draggable.transform.SetParent(transform);

        // Snap to zone center for now (you can expand with slots/arrangement later)
        draggable.transform.position = transform.position;
        draggable.transform.rotation = Quaternion.identity;

        Debug.Log($"Card dropped into {zoneType}");

        // If dropped on battlefield → remove from hand
        if (zoneType == DropzoneType.Battlefield && handManager != null)
        {
            handManager.RemoveCardFromHand(draggable.gameObject);
        }
    }
}
