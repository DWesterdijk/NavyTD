using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomControl : MonoBehaviour
{

    public float minZoom = 1f;
    public float maxZoom = 10f;
    float _sensitivity = 2f;
    Vector3 _cameraPosition;
    Vector3 _mousePositionOnScreen;
    Vector3 _mousePositionOnScreen1;
    Vector3 _camPos1;
    Vector3 _mouseOnWorld;
    Vector3 _camDragBegin;
    Vector3 _camDragNext;

    // Start is called before the first frame update
    void Start()
    {
        _cameraPosition = Camera.main.transform.position;
        mousePositionOnScreen = new Vector3();
        mousePositionOnScreen1 = new Vector3();
        _camPos1 = new Vector3();
        _mouseOnWorld = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            _mousePositionOnScreen = _mousePositionOnScreen1;
            _mousePositionOnScreen1 = Input.mousePosition;
            if (Vector3.Distance(_mousePositionOnScreen, _mousePositionOnScreen1) == 0)
            {
                float fov = Camera.main.orthographicSize;
                fov += Input.GetAxis("Mouse ScrollWheel") * _sensitivity;
                fov = Mathf.Clamp(fov, minZoom, maxZoom);
                Camera.main.orthographicSize = fov;
                Vector3 mouseOnWorld1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 posDiff = _mouseOnWorld - mouseOnWorld1;
                Vector3 camPos = Camera.main.transform.position;
                Camera.main.transform.position = new Vector3(camPos.x + posDiff.x, camPos.y + posDiff.y, camPos.z);
            }
            else
            {
                _mouseOnWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }

        if (Input.GetMouseButtonDown(2))
        {
            _camDragBegin = Input.mousePosition;
            _camPos1 = Camera.main.transform.position;
        }
   
      
        if (Input.GetMouseButton(2))
        {
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                _camDragNext = Input.mousePosition;
                Vector3 screenDelta = _camDragBegin - _camDragNext;
                Vector2 screenSize = ScaleScreenToWorldSize(Camera.main.aspect,Camera.main.orthographicSize, Camera.main.scaledPixelWidth, Camera.main.scaledPixelHeight, screenDelta.x, screenDelta.y);
                Vector3 camPosMove = new Vector3(_camPos1.x + screenSize.x, _camPos1.y + screenSize.y, _camPos1.z);
                Camera.main.transform.position = camPosMove;
            }
        }
    }
 
    Vector2 ScaleScreenToWorldSize(float camAspect,float camSize,float camScreenPixelWidth,float camScreenPixelHeight,float screenW,float screenH)
    {
        float cameraWidth = camAspect * camSize * 2f;
        float cameraHeght = camSize * 2f;
        float screenWorldW = screenW * (cameraWidth / camScreenPixelWidth);
        float screenWorldH=screenH*(cameraHeght/camScreenPixelHeight);
        return new Vector2(screenWorldW,screenWorldH);
            
    }

}
