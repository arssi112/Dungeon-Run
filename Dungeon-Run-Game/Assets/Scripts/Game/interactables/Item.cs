using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType{ NONE, PickUp, Examine }
    public enum ItemType { staic, consumables}
    [Header("Attributes")]
    public InteractionType interactType;
    public ItemType type;
    [Header("Examine")]
    public string descriptionText;
    [Header("Custom Events")]
    public UnityEvent customEvent;
    public UnityEvent consumeEvent;

    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 9;
    }

    public void Interact()
    {
        switch (interactType)
        {
            //Add object to the PickedUpItems List
            case InteractionType.PickUp:
                FindObjectOfType<InteractionSystem>().PickUpItem(gameObject);
                Debug.Log("PICKUP");
                //Disable PickedUp Item
                gameObject.SetActive(false);
                break;

            case InteractionType.Examine:
                //Examine Items
                FindObjectOfType<InteractionSystem>().ExamineItem(this);
                Debug.Log("EXAMINE");
                break;

            default:
                Debug.Log("NULL ITEM");
                break;
        }

        //Invoke the custom Events
        customEvent.Invoke();
    }

}
