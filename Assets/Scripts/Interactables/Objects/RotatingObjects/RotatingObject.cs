using DG.Tweening;
using UnityEngine;

public abstract class RotatingObject : MonoBehaviour
{
    [SerializeField] private float duration;
    [SerializeField] private Vector3 endValue;
    [SerializeField] private Ease ease;
    [SerializeField] private RotateMode rotateMode;

    protected void Rotate()
    {
        transform.DORotate(new Vector3(endValue.x, endValue.y, endValue.z), this.duration, rotateMode).SetLoops(-1).SetEase(ease);
    }
}
