using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TouchPad : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{
    public float smoothing;


    private Vector2 orign;
    private Vector2 direction;
    private Vector2 smoothDirect;

    public void OnPointerDown(PointerEventData eventData)
    {
        orign = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        direction = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 directionRaw = eventData.position - orign;
        direction = directionRaw.normalized;
    }

    public Vector2 GetDirection()
    {
       // Debug.Log(smoothDirect);
        smoothDirect = Vector2.MoveTowards(smoothDirect, direction, smoothing);
        return smoothDirect;
    }
}
