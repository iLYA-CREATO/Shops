using TMPro;
using UnityEngine;

public class OutlineSklad : MonoBehaviour
{
    // Этот скрипт для наведение на сам товар и добавление его в корзину
    //
    #region  --- Переменные ---
    [SerializeField, Header("Скрипт Outline")] private AddItemSklad addItemSklad;

    [SerializeField, Header("Откуда происходит выпуск луча")] private AllRay allRay;
    [SerializeField, Header("")] private string textAction, textObject;

    [SerializeField, Tooltip("Тег объекта на который будем наводится")] private string TagRayCastObject;

    [SerializeField, Tooltip("Места хранения данных")] private DataTovar dataTovar;
    #endregion
    private void Update()
    {
        if(allRay.objectRaycast != null && allRay.objectRaycast.tag == TagRayCastObject)
        {
            textObject = allRay.objectRaycast.gameObject.name;
            textObject = dataTovar.ResetNameItem(textObject);
            allRay.InformationObject(textAction, textObject);

            // Тут и будем реалитцовывать добавление в корзину
            if (Input.GetKeyDown(KeyCode.E))
            {
                addItemSklad.AddItem(allRay.objectRaycast.name);
            }
        }
    }
}
