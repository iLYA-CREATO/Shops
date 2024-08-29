using System;
using System.Collections.Generic;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Скрипт выполняет функцию переноса предметов
    #region  --- Переменные ---
    private Transform canvasGame;
    private Transform contentPlayer;
    private Transform contentBoxing;
    [SerializeField] private CanvasGroup canvasGroup;

    [Header("Звук")]
    [SerializeField] private AudioSource soundAudio;
    [SerializeField] private AudioClip soundClip;

    public AddItemInventory addItemInventory;

    public int index;

    public Transform startPositionCell;
    public Transform pastPositionCell;
    [Tooltip("Bufer")] public InventorySlot bufer;

    #endregion

    public void Init(AudioSource soundAudio, AudioClip soundClip, Transform canvas, Transform contentPlayer, Transform contentBoxing, AddItemInventory addItemInventory)
    {
        // При создании клетки сразу будем вызывать метод чтобы получить данные
        this.canvasGame = canvas;
        this.contentPlayer = contentPlayer;
        this.contentBoxing = contentBoxing;
        this.soundAudio = soundAudio;
        this.soundClip = soundClip;
        this.addItemInventory = addItemInventory;
        
    }

    #region --- Перемещение объекта между инвенторями ---
    public void OnBeginDrag(PointerEventData eventData)
    {
        startPositionCell = transform.parent;
        transform.SetParent(canvasGame);
        soundAudio.PlayOneShot(soundClip);

        canvasGroup.alpha = 0.6f;
        index = transform.GetComponent<SelectItem>().indexItem;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        int closestIndex = 0;
        canvasGroup.alpha = 1.0f;
        // Проверим, в каком инвентаре мы закончили перетаскивание
        if (RectTransformUtility.RectangleContainsScreenPoint(contentPlayer as RectTransform, eventData.position))
        {
            // Если в зоне игрока
            MoveFromeBoxingToPlayer();
            transform.SetParent(contentPlayer);
            pastPositionCell = transform.parent;
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentBoxing as RectTransform, eventData.position))
        {
            // Если в зоне ящика

            MoveToBoxing();
            transform.SetParent(contentBoxing);
        }
        else
        {
            // Если игрок промазал
            transform.SetParent(contentPlayer);
            pastPositionCell = transform.parent;
        }

        // Инвентарь игрока
        for (int i = 0; i < contentPlayer.transform.childCount; i++)
        {
            if(Vector3.Distance(transform.position, contentPlayer.GetChild(i).position) <
               Vector3.Distance(transform.position, contentPlayer.GetChild(closestIndex).position))
                {
                closestIndex = i;
            }
            transform.SetSiblingIndex(closestIndex);
        }
    }
    #endregion

    #region --- Само перемещение в другие инвентори
    // В ящик
    public void MoveToBoxing()
    {
        
        for(int i = 0; i < addItemInventory.SlotInventoryPlayer.Count; i++)
        {

            if (addItemInventory.SlotInventoryPlayer[i].ID == index)
            {
                bufer = addItemInventory.SlotInventoryPlayer[i];
            }
        }
        bool alreadyExists = addItemInventory.SlotInventoryBoxing.Exists(slot => slot.ID == bufer.ID);
        if (!alreadyExists)
        {
            addItemInventory.SlotInventoryBoxing.Add(bufer);
            addItemInventory.SlotInventoryPlayer.Remove(bufer);
        }
        else
        {
            Debug.Log("Предмет уже находится в инвентаре игрока!");
        }

        // Debug.Log(transform.name);
    }

    /// <summary>
    /// Метод для перетаскивания из Коробок в инвентарь игрока
    /// </summary>
    public void MoveFromeBoxingToPlayer()
    {
        for (int i = 0; i < addItemInventory.SlotInventoryBoxing.Count; i++)
        {
            if (addItemInventory.SlotInventoryBoxing[i].ID == index)
            {
                bufer = addItemInventory.SlotInventoryBoxing[i];
            }
        }

        bool alreadyExists = addItemInventory.SlotInventoryPlayer.Exists(slot => slot.ID == bufer.ID);
        if (!alreadyExists)
        {
            addItemInventory.SlotInventoryPlayer.Add(bufer);
            addItemInventory.SlotInventoryBoxing.Remove(bufer);
        }
        else
        {
            Debug.Log("Предмет уже находится в инвентаре игрока!");
        }

        Debug.Log(transform.name);
    }
    #endregion
}
