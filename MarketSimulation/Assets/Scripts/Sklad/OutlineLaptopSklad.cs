using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutlineLaptopSklad : MonoBehaviour
{
    #region  --- ���������� ---
    // ���� ������ ��� ������� ������ �� ������� ����

    [SerializeField, Tooltip("��� ������� �� ������� ����� ���������")] private string TagRayCastObject;

    // ��� ���������� �������
    [SerializeField] private AddItemSklad addItemSklad;
    [SerializeField] private AddItemInventory addItemInventory;

    [SerializeField, Tooltip("����� �������� ������")] private DataTovar dataTovar;
    public List<ComponentKorzin> componentkorzin;

    // ���� �������
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
                if(wallet.MinusValuta(addItemSklad.amount))
                {
                    Debug.Log("������� �������");
                    componentkorzin = addItemSklad.componentkorzin;
                    if (componentkorzin.Count != 0)
                    {
                        BuyTovar();
                        AppledBuy.SetActive(true);
                       StartCoroutine(DeactivateAfterDelay(2.1f, AppledBuy));
                    }
                }
                
            }
        }
    }
    private void BuyTovar()
    {
        // ���� �������
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
        
        Debug.Log("�� ��������");
    }

    private IEnumerator DeactivateAfterDelay(float delay, GameObject Activate)
    {
        // ���� �������� �����
        yield return new WaitForSeconds(delay);
        // ��������� ������
        Activate.SetActive(false);
    }
}
