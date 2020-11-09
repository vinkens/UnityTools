using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
public class PointerClickEventSender : MonoBehaviour, IPointerClickHandler
{

    public IPointerClickReceiver receiver;
    private void Awake()
    {
        receiver = GetComponentInParent<IPointerClickReceiver>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        receiver.OnReceivePointerClick(eventData);
    }

}

public interface IPointerClickReceiver
{
    void OnReceivePointerClick(PointerEventData eventData);
}
