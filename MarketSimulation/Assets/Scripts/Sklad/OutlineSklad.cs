using TMPro;
using UnityEngine;

public class OutlineSklad : MonoBehaviour
{
    // ���� ������ ��� ��������� �� ��� ����� � ���������� ��� � �������
    //
    #region  --- ���������� ---
    [SerializeField, Header("������ Outline")] private AddItemSklad addItemSklad;

    [SerializeField, Header("������ ���������� ������ ����")] private AllRay allRay;
    [SerializeField, Header("")] private string textAction, textObject;

    [SerializeField, Tooltip("��� ������� �� ������� ����� ���������")] private string TagRayCastObject;

    [SerializeField, Tooltip("����� �������� ������")] private DataTovar dataTovar;
    #endregion
    private void Update()
    {
        if(allRay.objectRaycast != null && allRay.objectRaycast.tag == TagRayCastObject)
        {
            textObject = allRay.objectRaycast.gameObject.name;
            textObject = dataTovar.ResetNameItem(textObject);
            allRay.InformationObject(textAction, textObject);

            // ��� � ����� �������������� ���������� � �������
            if (Input.GetKeyDown(KeyCode.E))
            {
                addItemSklad.AddItem(allRay.objectRaycast.name);
            }
        }
    }
}
