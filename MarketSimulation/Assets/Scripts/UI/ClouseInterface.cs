using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClouseInterface : MonoBehaviour
{
    public void _Clouse(GameObject Interface)
    {
        // Выключаем панель
        Interface.SetActive(false);
        
        // Блокируем курсор
        Cursor.lockState = CursorLockMode.Locked;
    }
}
