using Assets.Scripts.Interactables.Opening;
using System;
using UnityEngine;

public class Opening : MonoBehaviour
{
    public static bool isAbleToOpen { get; private set; }

    private void OnTriggerStay2D(Collider2D collision)
    {
        IOpenable openable = collision.GetComponent<IOpenable>();
        if (collision.gameObject.layer == 10)
        {
            if (collision.gameObject.GetComponent<Chest>().isOpened == false)
            {
                isAbleToOpen = true;
                Open(openable);
            }
        }
    }

    public void Open(IOpenable openable)
    {       
        if (openable == null)
        {
           throw new Exception($"There is no component IOpenable on gameObject");
        }
        openable.Open();       
    }
}
