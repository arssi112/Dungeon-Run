using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionSystem : MonoBehaviour
{

    [Header("Detection Fields")]
    //detection Point
    public Transform detectionPoint;
    //detection Radius
    private const float detectionRadius = 0.2f;
    //detection Layer
    public LayerMask detectionLayer;
    //Trigger Object
    public GameObject detectedObject;

    [Header("Examine Fields")]
    public GameObject examineWindow;
    public Image examineImage;
    public Text examineText;
    public bool isExamining;

    [Header("Others")]
    //List of picked Items
    public List<GameObject> pickedItems = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        if (DetectObject())
        {
            if (InteractInput())
            {
                detectedObject.GetComponent<Item>().Interact();
            }
        }
    }

    bool InteractInput()
    {
        return Input.GetKeyDown(KeyCode.E);
    }

    bool DetectObject()
    {

        Collider2D obj =  Physics2D.OverlapCircle(detectionPoint.position, detectionRadius, detectionLayer);
        if (obj == null)
        {
            detectedObject = null;
            return false;
        }
        else 
        {
            detectedObject = obj.gameObject;

            return true;
        }
    }

    public void PickUpItem(GameObject item)
    {
        pickedItems.Add(item);
    }



    public void ExamineItem(Item item)
    {
        if (isExamining)
        {
            examineWindow.SetActive(false);
            isExamining = false;
        }
        else 
        {
            examineImage.sprite = item.GetComponent<SpriteRenderer>().sprite;
            examineText.text = item.descriptionText;
            examineWindow.SetActive(true);
            //enable boolean
            isExamining = true;
        }

    }
}
