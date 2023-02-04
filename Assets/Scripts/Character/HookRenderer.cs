using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class HookRenderer : MonoBehaviour
{
    private new LineRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<LineRenderer>();
        renderer.enabled = false;
    }
    public void Render(Vector2 startPoint, Vector2 endPoint)
    {
        renderer.enabled = true;
        renderer.SetPosition(0, startPoint);
        renderer.SetPosition(1, endPoint);
    }

    public void Disable()
    {
        renderer.enabled = false;
    }
}
