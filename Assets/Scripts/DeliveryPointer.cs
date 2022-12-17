using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPointer : MonoBehaviour
{
    [SerializeField]
    private Camera uiCamera;
    private Vector3 targetPosition;
    private RectTransform pointerRectTransform;
    GameObject package;

    private void awake()
    {
        Vector3 targetPosition = (GameObject.FindGameObjectWithTag("customer").transform.position);
        pointerRectTransform = transform.Find("ArrowPointer").GetComponent<RectTransform>();
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update()
    {
        package = GameObject.FindGameObjectWithTag("customer");
        Vector3 toPosition = targetPosition;
        Vector3 fromPosition = Camera.main.transform.position;
        fromPosition.z = 0f;
        Vector3 dir = (toPosition - fromPosition).normalized;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (angle < 0)
        {
            angle += 360;
        }
        pointerRectTransform.localEulerAngles = new Vector3(0, 0, angle);

        float borderSize = 100f;
        Vector3 targetPositionScreenPoint = Camera.main.WorldToScreenPoint(targetPosition);
        bool isOffScreen =
            targetPositionScreenPoint.x <= borderSize
            || targetPositionScreenPoint.x >= Screen.width - borderSize
            || targetPositionScreenPoint.y <= 0
            || targetPositionScreenPoint.y >= Screen.height - borderSize;

        if (isOffScreen)
        {
            Vector3 cappedTargetScreenPosition = targetPositionScreenPoint;
            if (cappedTargetScreenPosition.x <= borderSize)
                cappedTargetScreenPosition.x = borderSize;
            if (cappedTargetScreenPosition.x >= Screen.width - borderSize)
                cappedTargetScreenPosition.x = Screen.width - borderSize;
            if (cappedTargetScreenPosition.y <= borderSize)
                cappedTargetScreenPosition.y = borderSize;
            if (cappedTargetScreenPosition.y >= Screen.height - borderSize)
                cappedTargetScreenPosition.y = Screen.height - borderSize;

            Vector3 pointerWorldPosition = uiCamera.ScreenToWorldPoint(cappedTargetScreenPosition);
            pointerRectTransform.position = pointerWorldPosition;
            pointerRectTransform.localPosition = new Vector3(
                pointerRectTransform.localPosition.x,
                pointerRectTransform.localPosition.y,
                0f
            );
        }
    }
}
