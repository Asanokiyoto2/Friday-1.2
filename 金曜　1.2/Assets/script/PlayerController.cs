using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 15f;
    public int maxHP = 5;
    private int currentHP;
    private Vector2 moveInput;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentHP = maxHP;
        UIManager.instance.UpdateHP(currentHP);
    }
    void FixedUpdate()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        rb.linearVelocity = move * moveSpeed;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject bullet = Instantiate(
                bulletPrefab,
                firePoint.position,
                firePoint.rotation
            );
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            bulletRb.linearVelocity = firePoint.forward * bulletSpeed;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        UIManager.instance.UpdateHP(currentHP);
        if (currentHP <= 0)
        {
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
    }
}
