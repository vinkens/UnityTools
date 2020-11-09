using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Physic2DEventSender : MonoBehaviour
{

    private ICollisionEnter2DEventReceiver collisionEnterEventReceiver;
    private ICollisionStay2DEeventReceiver collisionStayEeventReceiver;
    private ICollisionExit2DEventReceiver collisionExitEventReceiver;

    private ITriggerEnter2DEventReceiver triggerEnter2DEventReceiver;
    private ITriggerStay2DEeventReceiver triggerStay2DEeventReceiver;
    private ITriggerExit2DEventReceiver triggerExit2DEventReceiver;

    private void Awake()
    {
        collisionEnterEventReceiver = GetComponentInParent<ICollisionEnter2DEventReceiver>();
        collisionStayEeventReceiver = GetComponentInParent<ICollisionStay2DEeventReceiver>();
        collisionExitEventReceiver = GetComponentInParent<ICollisionExit2DEventReceiver>();

        triggerEnter2DEventReceiver = GetComponentInParent<ITriggerEnter2DEventReceiver>();
        triggerStay2DEeventReceiver = GetComponentInParent<ITriggerStay2DEeventReceiver>();
        triggerExit2DEventReceiver = GetComponentInParent<ITriggerExit2DEventReceiver>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collisionEnterEventReceiver != null)
        {
            collisionEnterEventReceiver.OnReceiveCollisionEnter(collision);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collisionStayEeventReceiver != null)
        {
            collisionStayEeventReceiver.OnReceiveCollisionStay(collision);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collisionExitEventReceiver != null)
        {
            collisionExitEventReceiver.OnReceiveCollisionExit(collision);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerEnter2DEventReceiver != null)
        {
            triggerEnter2DEventReceiver.OnReceiveTriggerEnter(collision);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (triggerStay2DEeventReceiver != null)
        {
            triggerStay2DEeventReceiver.OnReceiveTriggerStay(collision);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggerExit2DEventReceiver != null)
        {
            triggerExit2DEventReceiver.OnReceiveTriggerExit(collision);
        }
    }
}

interface ICollisionEnter2DEventReceiver
{
    void OnReceiveCollisionEnter(Collision2D collision);
}

interface ICollisionStay2DEeventReceiver
{
    void OnReceiveCollisionStay(Collision2D collision);
}

interface ICollisionExit2DEventReceiver
{
    void OnReceiveCollisionExit(Collision2D collision);
}

interface ITriggerEnter2DEventReceiver
{
    void OnReceiveTriggerEnter(Collider2D collision);
}

interface ITriggerStay2DEeventReceiver
{
    void OnReceiveTriggerStay(Collider2D collision);
}

interface ITriggerExit2DEventReceiver
{
    void OnReceiveTriggerExit(Collider2D collision);
}

