using System.Threading.Tasks;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform target; // プレイヤー
    public Vector3 offset = new Vector3(0, 5, -7);
    public float smoothSpeed = 5f;
    [Header("Mouse Rotate")]
    public float mouseSensitivity = 150f;
    float yaw = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        yaw = target.eulerAngles.y;
    }
    async Task LateUpdate()
    {
        if (target == null) return;
        // マウス左右のみ
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        yaw += mouseX;
        // プレイヤー回転
        target.rotation = Quaternion.Euler(0, yaw, 0);
        // カメラ回転
        Quaternion rotation = Quaternion.Euler(0, yaw, 0);
        // カメラ位置
        Vector3 desiredPosition = target.position + rotation * offset;
        // なめらか追尾
        Vector3 smoothedPosition = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );
        transform.position = smoothedPosition;
        // プレイヤーを見る
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}