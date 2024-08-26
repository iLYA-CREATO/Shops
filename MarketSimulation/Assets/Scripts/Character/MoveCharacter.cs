using UnityEngine;

public class MoveCharacter : MonoBehaviour, iMovePlayer
{
    [SerializeField] private CharacterController characterController;
    [SerializeField, Tooltip("Скорость игрока")] private float moveSpeed = 5f;
    [SerializeField, Tooltip("Гравитация котора будет прижимать игрока к земле")] private float gravityValue = -5;

    float moveX;
    float moveY;
    float moveZ;
    Vector3 velocity;
    private void Update()
    {
        // Получаем ввод с клавиатуры
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");
        if(transform.position.y > 1.1f)
        {
            moveY = gravityValue;
        }
        
        MovePlayer(moveX, moveY, moveZ);

        // Вектор движения

        velocity.y += gravityValue * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
    
    public void MovePlayer(float moveX, float moveY, float moveZ)
    {
        // Вектор движения
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Перемещение персонажа
        characterController.Move(move * moveSpeed * Time.deltaTime);
    }
}
