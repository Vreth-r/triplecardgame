using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Collider))]
public class DropZone : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var draggable = eventData.pointerDrag?.GetComponent<DraggableCard>();
        if (draggable != null)
        {
            // Reparent under this zone
            draggable.transform.SetParent(transform);

            // Optional: snap to zone center
            draggable.transform.position = transform.position;
            Debug.Log($"Card dropped into {gameObject.name}");
        }
    }
}
