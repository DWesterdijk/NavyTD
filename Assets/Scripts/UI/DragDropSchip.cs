using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropSchip : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField]
    private UpgradeButton _upgradeButton;

    [SerializeField]
    private GameObject _ship, _previewShip;

    [SerializeField]
    private int _cost;

    private GameObject _target;
    private bool _dropable;
    private int _allLayers = 1 << 7;

    private void Awake()
    {
        _allLayers =~ LayerMask.GetMask("Detection");
    }

    //Activates when the player begins the drag. Spawns a preview ship .
    public void OnBeginDrag(PointerEventData eventData)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            _target = Instantiate(_previewShip, hit.point, _previewShip.transform.rotation);
            _target.gameObject.SendMessage("OnSpawn", this, SendMessageOptions.DontRequireReceiver);
        }
    }

    //Activates every frame of the drag movement updates the color based on layermask check.
    public void OnDrag(PointerEventData eventData)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _allLayers))
        {
            _target.transform.position = new Vector3(hit.point.x, _ship.transform.position.y, hit.point.z);
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Water"))
                _dropable = true;
            else
                _dropable = false;
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
        DestroyImmediate(_target);
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, _allLayers))
        {
            if(hit.transform.gameObject.layer == 4 && _dropable && ScoringTracker.current.money >= _cost)
            {
                ScoringTracker.current.money -= _cost;
                GameObject obj = Instantiate(_ship, new Vector3(hit.point.x, _ship.transform.position.y,hit.point.z), _ship.transform.rotation);
                obj.gameObject.SendMessage("SetUpgradeUI", _upgradeButton, SendMessageOptions.DontRequireReceiver);
            }
        }
    }

    public void SetDropable(bool a)
    {
        _dropable = a;
        Debug.Log(_dropable);
    }
}
