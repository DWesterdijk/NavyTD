using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropSchip : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField]
    private GameObject _ship;
    private GameObject _target;
    private Material _targetMat;
    private int _waterLayer = 1 << 4, _allLayers = 1 << 7;

    private void Awake()
    {
        _allLayers = ~_allLayers;
    }

    //Activates when the player begins the drag. Spawns a preview ship .
    public void OnBeginDrag(PointerEventData eventData)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            _target = Instantiate(_ship, hit.point, _ship.transform.rotation);
            _targetMat = _target.gameObject.GetComponent<Renderer>().material;
        }
    }

    //Activates every frame of the drag movement updates the color based on layermask check.
    public void OnDrag(PointerEventData eventData)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _allLayers))
        {
            _target.transform.position = hit.point;
            if(hit.transform.gameObject.layer == LayerMask.NameToLayer("Water"))
                _targetMat.color = Color.blue;
            else
                _targetMat.color = Color.red;
        }
    }

    //Activates when the player ends the drag movement.
    public void OnEndDrag(PointerEventData eventData)
    {
        Drop();
    }

    //Places or destroys the ship based on layermask.
    private void Drop()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _waterLayer))
        {
            Instantiate(_ship, hit.point, _ship.transform.rotation);
            Destroy(_target);
        }
        else
            Destroy(_target);
    }
}
