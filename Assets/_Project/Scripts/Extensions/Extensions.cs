using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Extensions
{
    public static void MoveToFacePoint(this Transform transform, Vector3 point, float speed)
    {
        float targetAngleDeg = Mathf.Atan2(point.y - transform.position.y, point.x - transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, Quaternion.Euler(0f, 0f, targetAngleDeg), speed);
    }
    public static void MoveToFaceDirection(this Transform transform, Vector3 direction, float speed)
    {
        transform.MoveToFacePoint(transform.position + direction, speed);
    }
    public static void LerpToFacePoint(this Transform transform, Vector3 point, float speed)
    {
        float targetAngleDeg = Mathf.Atan2(point.y - transform.position.y, point.x - transform.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, 0f, targetAngleDeg), speed);
    }
    public static void LerpToFaceDirection(this Transform transform, Vector3 direction, float speed)
    {
        transform.LerpToFacePoint(transform.position + direction, speed);
    }
    public static bool IsWorldPointOnScreen(this Camera cam, Vector3 point)
    {
        Vector2 scrPoint = cam.WorldToScreenPoint(point);
        return scrPoint.x > 0 && scrPoint.x < Screen.width && scrPoint.y > 0 && scrPoint.y < Screen.height;
    }
}
