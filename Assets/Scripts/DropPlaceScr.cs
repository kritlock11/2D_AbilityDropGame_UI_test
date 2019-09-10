using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum FieldType
{
    PLAYER_FIELD,
    ENEMY_FIELD
}
public class DropPlaceScr : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    public FieldType fieldType;
    public float cardChainController;
    private void Update()
    {
        cardChainController = gameObject.GetComponent<CardChainController>().CardChain.Count;

    }
    public void OnDrop(PointerEventData eventData)
    {
        if (fieldType != FieldType.PLAYER_FIELD) 
        {
            return;
        }
        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();
        if (card&& cardChainController < 3)
        {
            card.DefaultParent = transform;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null || fieldType == FieldType.ENEMY_FIELD || cardChainController >= 3)
        { 
            return;
        }
        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();
        if (card)
        {
            card.DefaultTempCardParent = transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
            return;
        CardMovementScr card = eventData.pointerDrag.GetComponent<CardMovementScr>();
        if (card && card.DefaultTempCardParent == transform)
        {
            card.DefaultTempCardParent = card.DefaultParent;
        }
    }
}
