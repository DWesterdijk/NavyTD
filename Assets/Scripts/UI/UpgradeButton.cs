using UnityEngine;
using UnityEngine.UI;

public class UpgradeButton : MonoBehaviour
{
    private GameObject _currentShip, _nextShip;
    [SerializeField]
    private Text _costText, _sellText;
    private int _cost, _sellPrice;

    public void SetShip(GameObject nextShip, GameObject currentShip, int cost, int sell)
    {
        _currentShip = currentShip;
        _nextShip = nextShip;
        _cost = cost;
        _costText.text = "Upgrade cost: " + _cost.ToString();
        _sellPrice = sell;
        _sellText.text = "Sell price: " + _sellPrice.ToString();
    }

    public void Sell()
    {
        Destroy(_currentShip);

        ScoringTracker.current.money += _sellPrice;

        _currentShip = null;
        _nextShip = null;
        this.gameObject.SetActive(false);
    }

    public void Upgrade()
    {
        if (ScoringTracker.current.money >= _cost)
        {
            ScoringTracker.current.money -= _cost;

            Transform currentShipTransform = _currentShip.transform;

            Destroy(_currentShip);
            Instantiate(_nextShip, new Vector3(currentShipTransform.position.x , _nextShip.transform.position.y, currentShipTransform.position.z), currentShipTransform.rotation);

            _currentShip = null;
            _nextShip = null;
            this.gameObject.SetActive(false);
        }
    }
}
