using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{ 
    public static CameraManager instance;

    //References
    [SerializeField] private LayerMask collisionLayers;
    private Transform targetTransform;
    private Transform cameraTransform;
    private float defaultPosition;
    private Vector3 cameraFollowVelocity = Vector3.zero;
    [SerializeField] private Transform cameraPivot;
    private Vector3 cameraVectorPosition;

    [Header("Parameters")]
    [SerializeField] private float cameraFollowSpeed;
    [SerializeField] private float cameraLookSpeed;
    [SerializeField] private float cameraPivotSpeed;
    private float cameraCollisionRadius = 0.2f;
    private float cameraCollisionOffset = 0.2f;
    private float minimumCollsionOffset = 0.2f;

    private float lookAngle;
    private float pivotAngle;
    private float minPivotAngle = -35;
    private float maxPivotAngle = 35;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        cameraTransform = Camera.main.transform;
        defaultPosition = cameraTransform.localPosition.z;
    }

    private void Start()
    {
        targetTransform = PlayerManager.instance.transform;
    }

    public void HandleAllCameraMovement()
    {
        FollowTarget();
        RotateCamera();
        HandleCameraCollisions();
    }

    private void FollowTarget()
    {
        Vector3 targetPos = Vector3.SmoothDamp
            (transform.position, targetTransform.position, ref cameraFollowVelocity, cameraFollowSpeed);

        transform.position = targetPos;
    }

    private void RotateCamera()
    {
        Vector3 rotation;
        Quaternion targetRotation;

        lookAngle = lookAngle + (InputManager.instance.cameraHorizontalInput * cameraLookSpeed);
        pivotAngle = pivotAngle - (InputManager.instance.cameraVerticalInput * cameraPivotSpeed);
        pivotAngle = Mathf.Clamp(pivotAngle, minPivotAngle, maxPivotAngle);

        rotation = Vector3.zero;
        rotation.y = lookAngle;
        targetRotation = Quaternion.Euler(rotation);
        transform.rotation = targetRotation;

        rotation = Vector3.zero;
        rotation.x = pivotAngle;
        targetRotation = Quaternion.Euler(rotation);
        cameraPivot.localRotation = targetRotation;
    }

    private void HandleCameraCollisions()
    {
        float targetPosition = defaultPosition;
        RaycastHit hit;
        Vector3 direction = cameraTransform.position - cameraPivot.position;
        direction.Normalize();

        if (Physics.SphereCast(cameraPivot.transform.position, cameraCollisionRadius, direction, out hit, Mathf.Abs(targetPosition), collisionLayers))
        {
            float distance = Vector3.Distance(cameraPivot.position, hit.point);
            targetPosition =- (distance - cameraCollisionOffset);
        }

        if (Mathf.Abs(targetPosition) < minimumCollsionOffset)
        {
            targetPosition = targetPosition - minimumCollsionOffset;
        }

        cameraVectorPosition.z = Mathf.Lerp(cameraTransform.localPosition.z, targetPosition, 0.2f);
        cameraTransform.localPosition = cameraVectorPosition;
    }
}
