using UnityEngine;
using UnityEngine.EventSystems;

public class StartBuyShop : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Размер увеличения кнопки
    [SerializeField] private Vector3 hoverScale = new Vector3(1.1f, 1.1f, 1.1f);

    // Исходный размер кнопки
    [SerializeField] private Vector3 originalScale;

    [SerializeField] private AudioSource source;

    [SerializeField] private AudioClip soundButton;
    
    [SerializeField] private GameObject indicatorToShop;
    [SerializeField] private GameObject imageWallet;



    // Этот метод вызывается, когда мышь наведена на кнопку
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Наведен на кнопку! ");
        transform.localScale = hoverScale; // Увеличиваем кнопку
    }

    // Этот метод вызывается, когда мышь покидает кнопку
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Убрали курсор с кнопки! ");
        transform.localScale = originalScale; // Возвращаем исходный размер
    }

    public void ClickButtonBuyShop()
    {
        // Проигрываем звук
        source.PlayOneShot(soundButton);
        // Отключаем указатель на покупку ларька

        indicatorToShop.SetActive(false);
        imageWallet.SetActive(false);

        hoverScale = new Vector3(1.3f, 1.3f, 1.3f);
    }
}
