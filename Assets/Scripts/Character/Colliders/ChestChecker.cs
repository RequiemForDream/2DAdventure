using Assets.Scripts.Interactables.Opening;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ChestChecker : MonoBehaviour
{
    [SerializeField] private LayerMask chestLayer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IOpenableOnce openable = collision.GetComponent<IOpenableOnce>();        
        
        if (openable != null)
        {               
            if (openable.isOpened == false)
            {
               openable.Open();
            }
        }               
    }
}
