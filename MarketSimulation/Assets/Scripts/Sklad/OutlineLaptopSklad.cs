using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Этот скрипт для покупки товара на оптовой базе
public class OutlineLaptopSklad : MonoBehaviour
{
    #region  --- Переменные ---
    public static event Action<int> BuyTovarCorzine; // Сообщаю что что-то купили

   

    [SerializeField, Tooltip("Тег объекта на который будем наводится")] private string TagRayCastObject;

    // Для реализации покупки
    [SerializeField] private AddItemSklad addItemSklad;
    [SerializeField] private AddItemInventory addItemInventory;

    [SerializeField, Tooltip("Места хранения данных")] private DataTovar dataTovar;
    public List<ComponentKorzin> componentkorzin;

    // Звук покупки
    [SerializeField] private AudioSource audioSound;
    [SerializeField] private AudioClip soudnClip;

    [SerializeField] private AllRay allRay;

    [SerializeField] private string textAction, textObject;

    [SerializeField] private Wallet wallet;
    #endregion

    public GameObject AppledBuy;
    public GameObject WalletNot;

    private void Update()
    {
        PrcesBuy();
    }
    public void PrcesBuy()
    {
        if (allRay.objectRaycast != null && allRay.objectRaycast.tag == TagRayCastObject)
        {
            allRay.InformationObject(textAction, textObject);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (wallet.MinusValuta(addItemSklad.amount))
                {
                    Debug.Log("Процесс покупки");
                    componentkorzin = addItemSklad.componentkorzin;
                    if (componentkorzin.Count != 0)
                    {
                       BuyTovar();
                       AppledBuy.SetActive(true);
                       StartCoroutine(DeactivateAfterDelay(2.1f, AppledBuy));
                    }
            }
            else
            {
                WalletNot.SetActive(true);
                StartCoroutine(DeactivateAfterDelay(2.1f, WalletNot));
            }

        }
        }
    }
    private void BuyTovar()
    {
        // Звук покупки
        audioSound.PlayOneShot(soudnClip);

        for (int i = 0; i < componentkorzin.Count; i++)
        {
            for(int j = 0; j < dataTovar._item.Length; j++)
            {
                if (componentkorzin[i].typeItemKorzine == dataTovar._item[j]._typeItem)
                {
                    addItemInventory.AddNevItem(dataTovar._item[j], componentkorzin[i].value);
                    break;
                }
            }
        }

        componentkorzin.Clear();
        addItemSklad.componentkorzin.Clear();
        
        for (int i = 0; i < addItemSklad.korzina.Count; i++)
        {
            Destroy(addItemSklad.korzina[i]);
        }
        addItemSklad.korzina.Clear();
        
        Debug.Log("Всё купленно");

        addItemSklad.amount = 0;
        BuyTovarCorzine?.Invoke(addItemSklad.amount);
    }

    private IEnumerator DeactivateAfterDelay(float delay, GameObject Activate)
    {
        yield return new WaitForSeconds(delay);

        Activate.SetActive(false);
    }
}
