using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public enum BallState
    {
        INIT,
        AIM,
        DROP,
        DESTROY,
    }
    public BallState m_ballState;
    private Camera mainCamera;
    private Vector3 mousePos;
    public Rigidbody2D rb;
    private SpawnBoxController spawnBoxCTL;
    // Start is called before the first frame update
    void Start()
    {
        m_ballState = BallState.INIT;
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        spawnBoxCTL = GameObject.FindObjectOfType<SpawnBoxController>();
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
    }
    public void Aim()
    {
        if (Input.GetMouseButton(0) && m_ballState.ToString() != "DROP")
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos = new Vector3(mousePos.x, mousePos.y, 0);
            Vector3 rotation = mousePos - transform.position;
            float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            m_ballState = BallState.AIM;
        }
        else if (Input.GetMouseButtonUp(0) && m_ballState.ToString() != "DROP")
        {
            gameObject.GetComponent<Rigidbody2D>().simulated = true;
            rb.velocity = new Vector2(mousePos.x, mousePos.y);
            m_ballState = BallState.DROP;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("bottom"))
        {
            GameManager._instance.dropTime++;
            spawnBoxCTL.CheckTopBoxs();
            spawnBoxCTL.SpawnBoxs();
            spawnBoxCTL.MoveAllBoxs();
            spawnBoxCTL.CheckBottomBoxs();
            Debug.Log(GameManager._instance.moveRow);
            m_ballState = BallState.DESTROY;
            Destroy(gameObject);
        }
    }
}
