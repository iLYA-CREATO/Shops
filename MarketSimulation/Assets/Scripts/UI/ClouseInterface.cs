using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClouseInterface : MonoBehaviour
{
    public void _Clouse(GameObject Interface)
    {
        // ��������� ������
        Interface.SetActive(false);
        
        // ��������� ������
        Cursor.lockState = CursorLockMode.Locked;
    }
}
