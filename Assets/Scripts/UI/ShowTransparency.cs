using UnityEngine;

public class ShowTransparency : MonoBehaviour
{
    [SerializeField]
    private Renderer _renderer;

    private void OnMouseOver()
    {
        IncreaseTransparency();
    }

    private void OnMouseExit()
    {
        DecreaseTransparency();
    }

    private void IncreaseTransparency()
    {
        _renderer.material.color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, 0.2f);
    }

    private void DecreaseTransparency()
    {
        _renderer.material.color = new Color(_renderer.material.color.r, _renderer.material.color.g, _renderer.material.color.b, 0);
    } 
}
