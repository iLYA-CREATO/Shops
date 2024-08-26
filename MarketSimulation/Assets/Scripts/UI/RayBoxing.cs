using UnityEngine;

public class RayBoxing : MonoBehaviour
{
    #region --- ���������� ---
    [SerializeField, Tooltip("��� ������� �� ������� ����� ���������")] private string NameRayCastObject;
    
    [SerializeField, Tooltip("h")] private GameObject PanelInterface;
    [SerializeField, Tooltip("h")] private GameObject BoxingInterface;

    [SerializeField, Tooltip("h")] private KeyCode KeyOpenInterface;
    
    
    [SerializeField, Tooltip("AllRaycast")] private AllRay allRay;

    [SerializeField, Tooltip("textAction - ��� �������� ������� ����� ����� ��������� ���" +
        " ������ �� ������, textAction - " +
        "��� ��� ������� �� ������� ����� ���������")] 
    private string textAction, textObject;

    #endregion

    private void Update()
    {
        if (allRay.objectRaycast != null && allRay.objectRaycast.tag == NameRayCastObject)
        {
            allRay.InformationObject(textAction, textObject);

            if (Input.GetKeyDown(KeyOpenInterface))
            {
                PanelInterface.SetActive(true);
                BoxingInterface.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
            }
        }
    }
}