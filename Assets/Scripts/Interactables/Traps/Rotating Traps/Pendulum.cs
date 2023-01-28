using Assets.Scripts.Character.CharacterHealth;
using DG.Tweening;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private float damage; 

    private void Update()
    {
        Rotate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IHandleHealth handleHealth = collision.gameObject.GetComponent<IHandleHealth>();
        if (handleHealth != null)
        {           
            handleHealth?.ApplyDamage(this.damage);                     
        }
    }

    private void Rotate()
    {
        transform.DORotate(new Vector3(0f, 0f, 360f), 5, RotateMode.LocalAxisAdd).
            SetLoops(-1).SetEase(Ease.Linear);
    }
}