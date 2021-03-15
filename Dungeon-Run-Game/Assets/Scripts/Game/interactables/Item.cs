using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Item : MonoBehaviour
{
    public enum InteractionType{ NONE, PickUp, Examine }
    public InteractionType type;

    [Header("Examine")]
    public string descriptionText;


    private void Reset()
    {
        GetComponent<Collider2D>().isTrigger = true;
        gameObject.layer = 9;
    }

    public void Interact()
    {
        switch (type)
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
    }
}
