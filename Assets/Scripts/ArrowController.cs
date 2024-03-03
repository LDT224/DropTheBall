using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public enum ArrowState
    {
        INIT,
        AIM,
        DROP,
    }
    private Camera mainCamera;
    private Vector3 mousePos;
    public ArrowState m_arrowState;
    public GameObject hook;
    // Start is called before the first frame update
    void Start()
    {
        m_arrowState = ArrowState.INIT;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x,Mathf.Clamp(mousePos.y,GameManager._instance.minY, GameManager._instance.maxY), 0);
            //Vector3 rotation = mousePos - transform.position;
            //float rotz = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            //transform.rotation = Quaternion.Euler(0, 0, rotz);
            transform.position = mousePos;
            m_arrowState = ArrowState.AIM;
            Debug.DrawLine(transform.position, hook.transform.position, Color.black);
        }
    }
}
