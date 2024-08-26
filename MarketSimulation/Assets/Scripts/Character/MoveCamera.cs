using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class MoveCamera : MonoBehaviour, iMoveCamera
{
    public float mouseSensitivity = 100f; // Чувствительность мыши
    public Transform playerBody; // Объект игрока (например, его тело, к которому прикреплена камера)

    private float xRotation = 0f;

    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Скрываем и блокируем курсор в центре экрана
    }

    void Update()
    {
        // Получаем ввод с мыши
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _iMoveCamera(mouseX, mouseY);
    }

    public void _iMoveCamera(float _mouseX, float _mouseY)
    {
        // Поворот камеры вверх и вниз
        xRotation -= _mouseY; // Обновляем угол наклона по оси X
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Ограничиваем угол наклона

        // Применяем поворот к камере
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        // Поворот тела игрока влево и вправо
        playerBody.Rotate(Vector3.up * _mouseX);
    }
}
