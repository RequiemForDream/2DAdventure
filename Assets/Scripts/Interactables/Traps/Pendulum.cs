using Assets.Scripts.Character.CharacterHealth;
using DG.Tweening;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private float damage;

    private Tweener tweener;  

    private void Update()
    {
        tweener = transform.DORotate(new Vector3(0f, 0f, 360f), 5, RotateMode.LocalAxisAdd).
            SetLoops(-1).SetEase(Ease.Linear);  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            IHandleHealth handleHealth = collision.gameObject.GetComponent<IHandleHealth>();
            handleHealth?.ApplyDamage(this.damage);                     
        }
    }
}
