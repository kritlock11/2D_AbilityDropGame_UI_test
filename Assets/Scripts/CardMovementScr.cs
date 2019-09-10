using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardMovementScr : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Camera MainCamera;
    Vector3 offset;
    public Transform DefaultParent, DefaultTempCardParent;
    public GameObject tempCardGO;
    public GameObject tempSettingsCard;
    public bool SettingsCardON;
    public CardChainController CardChainController;
    public bool isDraggable;

    private void Awake()
    {
        MainCamera = Camera.allCameras[0];
        tempCardGO = GameObject.Find("tempCardGO");
        //tempSettingsCard = GameObject.Find("tempSettingsCard");

    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        offset = transform.position - MainCamera.ScreenToWorldPoint(eventData.position);
        DefaultParent = DefaultTempCardParent = transform.parent;

        isDraggable = DefaultParent.GetComponent<DropPlaceScr>().fieldType == FieldType.PLAYER_FIELD;
        if (!isDraggable)
        {
            return;
        }
        tempCardGO.transform.SetParent(DefaultParent);
        tempCardGO.transform.SetSiblingIndex(transform.GetSiblingIndex());
        transform.SetParent(DefaultParent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDraggable)
        {
            return;
        }
        Vector3 newPos = MainCamera.ScreenToWorldPoint(eventData.position);

        transform.position = newPos + offset;
        if (tempCardGO.transform.parent != DefaultTempCardParent)
        {
            tempCardGO.transform.SetParent(DefaultTempCardParent);
        }
        CheckPosition();
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isDraggable)
        {
            return;
        }
        transform.SetParent(DefaultParent);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
        transform.SetSiblingIndex(tempCardGO.transform.GetSiblingIndex());
        tempCardGO.transform.SetParent(GameObject.Find("Canvas").transform);
        tempCardGO.transform.localPosition = new Vector3(3000, 0);
    }
    private void CheckPosition()
    {
        int newIndex = DefaultTempCardParent.childCount;

        for (int i = 0; i < DefaultTempCardParent.childCount; i++)
        {
            if (transform.position.x < DefaultTempCardParent.GetChild(i).position.x)
            {
                newIndex = i;

                if (tempCardGO.transform.GetSiblingIndex() < newIndex)
                {
                    newIndex--;
                }
                break;
            }
        }
        tempCardGO.transform.SetSiblingIndex(newIndex);
    }

    private void Update()
    {
        //if (SettingsCardON)
        //{
        //    tempSettingsCard.SetActive(true);

        //    //tempSettingsCard.transform.position = transform.position + Vector3.up * 0.4f;

        //}
        //if (Input.GetKeyDown(KeyCode.Mouse0))
        //{
        //    tempSettingsCard.transform.position = new Vector3(3000, 0);

        //}
    }
    public void qweq()
    {
        SettingsCardON = !SettingsCardON;
        if (SettingsCardON)
            tempSettingsCard.SetActive(true);
        else
            tempSettingsCard.SetActive(false);


        //if (SettingsCardON)
        //    {
        //    tempSettingsCard.SetActive(true);
        //}
        //if (!SettingsCardON)
        //{
        //    tempSettingsCard.SetActive(false);
        //}
        //Debug.Log($"wewew");
    }
}
