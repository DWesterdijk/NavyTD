using UnityEngine;
using UnityEngine.EventSystems;

public class DragDropSchip : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    [SerializeField]
    private UpgradeButton _upgradeButton;

    [SerializeField]
    private GameObject _ship, _previewShip;
    private GameObject _target;
    private Material _targetMat;
    private bool _dropable;
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
            _target = Instantiate(_previewShip, hit.point, _previewShip.transform.rotation);
            _targetMat = _target.gameObject.GetComponent<Renderer>().material;
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
            _target.transform.position = hit.point;
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
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.transform.gameObject.layer == 4 && _dropable)
            {
                GameObject obj = Instantiate(_ship, hit.point, _ship.transform.rotation);
                obj.gameObject.SendMessage("SetUpgradeUI", _upgradeButton, SendMessageOptions.DontRequireReceiver);

                //TODO: Ask Ruben to add a check for if player has enough money to place ship.
                ScoringTracker.current.money -= obj.gameObject.GetComponent<PlayerShipStats>().shipCost;
            }
        }
    }

    public void SetDropable(bool a)
    {
        _dropable = a;
        Debug.Log(_dropable);
    }
}
