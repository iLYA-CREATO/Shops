using System;
using System.Collections.Generic;
using System.Threading;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    // Скрипт выполняет функцию переноса предметов
    #region  --- Переменные ---
    private Transform canvasGame;
    private Transform contentPlayer;
    private Transform contentBoxing;
    #region -- Просто куча слотов
    private Transform contentLavkaOne;
    private Transform contentLavkaTwo;
    private Transform contentLavkaThree;
    private Transform contentLavkaFour;
    private Transform contentLavkaFive;
    private Transform contentLavkaSix;
    private Transform contentLavkaSeven;
    private Transform contentLavkaEight;
    private Transform contentLavkaNine;
    private Transform contentLavkaTen;
    private Transform contentLavkaEleven;
    private Transform contentLavkaTwelve;
    #endregion
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

    public void Init(AudioSource soundAudio, AudioClip soundClip, Transform canvas, Transform contentPlayer,
        Transform contentBoxing, AddItemInventory addItemInventory,
        Transform contentLavkaOne, Transform contentLavkaTwo,Transform contentLavkaThree, Transform contentLavkaFour, 
        Transform contentLavkaFive, Transform contentLavkaSix, Transform contentLavkaSeven, Transform contentLavkaEight,
        Transform contentLavkaNine, Transform contentLavkaTen, Transform contentLavkaEleven, Transform contentLavkaTwelve)
    {
        // При создании клетки сразу будем вызывать метод чтобы получить данные
        this.canvasGame = canvas;
        this.contentPlayer = contentPlayer;
        this.contentBoxing = contentBoxing;
        this.soundAudio = soundAudio;
        this.soundClip = soundClip;
        this.addItemInventory = addItemInventory;
        this.contentLavkaOne = contentLavkaOne;
        this.contentLavkaTwo = contentLavkaTwo;
        this.contentLavkaThree = contentLavkaThree;
        this.contentLavkaFour = contentLavkaFour;
        this.contentLavkaFive = contentLavkaFive;
        this.contentLavkaSix = contentLavkaSix;
        this.contentLavkaSeven = contentLavkaSeven;
        this.contentLavkaEight = contentLavkaEight;
        this.contentLavkaNine = contentLavkaNine;
        this.contentLavkaTen = contentLavkaTen;
        this.contentLavkaEleven = contentLavkaEleven;
        this.contentLavkaTwelve = contentLavkaTwelve; 
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
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaOne as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
            transform.SetParent(contentBoxing);
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaTwo as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
            transform.SetParent(contentBoxing);
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaThree as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
            transform.SetParent(contentBoxing);
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaFour as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
            transform.SetParent(contentBoxing);
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaFive as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
            transform.SetParent(contentBoxing);
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaSix as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
            transform.SetParent(contentBoxing);
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaSeven as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
            transform.SetParent(contentBoxing);
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaEight as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
            transform.SetParent(contentBoxing);
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaNine as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
            transform.SetParent(contentBoxing);
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaTen as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
            transform.SetParent(contentBoxing);
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaEleven as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
            transform.SetParent(contentBoxing);
        }
        else if (RectTransformUtility.RectangleContainsScreenPoint(contentLavkaTwelve as RectTransform, eventData.position))
        {
            // Если в зоне ящика
            MoveToSlot();
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
    public void MoveToSlot()
    {
        for (int i = 0; i < addItemInventory.SlotInventoryPlayer.Count; i++)
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
