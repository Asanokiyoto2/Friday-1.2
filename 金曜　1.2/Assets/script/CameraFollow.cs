using UnityEngine;

using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour

{

    public Transform target;

    public Vector3 offset =

        new Vector3(0, 5, -7);

    public float mouseSensitivity = 3f;

    public float smoothSpeed = 10f;

    private float yaw;

    void Start()

    {

        Cursor.lockState =

            CursorLockMode.Locked;

        yaw = target.eulerAngles.y;

    }

    void LateUpdate()

    {

        if (target == null) return;

        float mouseX =

            Mouse.current.delta.ReadValue().x

            * mouseSensitivity

            * Time.deltaTime;

        yaw += mouseX;

        Quaternion rotation =

            Quaternion.Euler(0, yaw, 0);

        Vector3 desiredPosition =

            target.position +

            rotation * offset;

        transform.position =

            Vector3.Lerp(

                transform.position,

                desiredPosition,

                smoothSpeed * Time.deltaTime

            );

        transform.LookAt(

            target.position + Vector3.up * 1.5f

        );

    }

}
