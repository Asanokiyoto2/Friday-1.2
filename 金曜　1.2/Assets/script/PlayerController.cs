using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    [Header("Move")]
    public float moveSpeed = 5f;
    [Header("Shoot")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    [Header("Fire Rate")]
    public float fireCooldown = 1f;
    [Header("HP")]
    public int maxHP = 5;
    private int currentHP;
    private Vector2 moveInput;
    private Rigidbody rb;
    private Camera mainCamera;
    private float nextFireTime;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        currentHP = maxHP;
        UIManager.instance.UpdateHP(currentHP);
        Cursor.lockState = CursorLockMode.Locked;
    }
    void FixedUpdate()
    {
        Vector3 cameraForward =
            mainCamera.transform.forward;
        Vector3 cameraRight =
            mainCamera.transform.right;
        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();
        Vector3 move =
            cameraForward * moveInput.y +
            cameraRight * moveInput.x;
        rb.linearVelocity =
            move * moveSpeed;
        if (move != Vector3.zero)
        {
            transform.rotation =
                Quaternion.LookRotation(move);
        }
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime =
                    Time.time + fireCooldown;
            }
        }
    }
    void Shoot()
    {
        GameObject bullet =
            Instantiate(
                bulletPrefab,
                firePoint.position,
                firePoint.rotation
            );
        Rigidbody bulletRb =
            bullet.GetComponent<Rigidbody>();
        bulletRb.linearVelocity =
            firePoint.forward * bulletSpeed;
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
