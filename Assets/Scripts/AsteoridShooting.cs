using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AsteoridShooting : NetworkBehaviour
{

    private const float MinScale = 1;
    private const float MaxScale = 1000;

    [Range(MinScale, MaxScale)]
    public float minAngularVelocity = 20;
    [Range(MinScale, MaxScale)]
    public float maxAngularVelocity = 30;

    public float autoDestroy = 3.5f;

    public GameObject AstroidPrefab;
    public float directionMean;
    public float directionVar;
    public int nrAstroids = 5;
    public float speedMean = 2;
    public float speedVar = 0.2f;

    private Vector2 firstMousePos;
    private Vector2 secondMousePos;

    private State state = State.firstClick;

    private enum State
    {
        firstClick,
        secondClick
    }

    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        /*if (Input.GetKeyDown(KeyCode.F) && isLocalPlayer) {
            fire();
        }*/
        if (Input.GetButtonDown("Fire1") && isServer)
        {
            if (state == State.firstClick)
            {
                Vector3 pos = Input.mousePosition;
                firstMousePos = new Vector2(pos.x, pos.y);
                state = State.secondClick;
            } else if (state == State.secondClick)
            {
                Vector3 pos = Input.mousePosition;
                secondMousePos = new Vector2(pos.x, pos.y);
                state = State.firstClick;

                Vector2 v2 = secondMousePos - firstMousePos;
                directionMean = Mathf.Atan2(v2.y, v2.x) * Mathf.Rad2Deg;
                fire();
            }
        }
    }

    public void fire()
    {
        CmdFire();
    }

    [Command]
    public void CmdFire()
    {
        for (int i = 0; i < nrAstroids; i++)
        {
            int sign = randomSign();
            float magnitude = Random.Range(minAngularVelocity, maxAngularVelocity);
            float direction = Random.Range(directionMean - directionVar / 2, directionMean + directionVar / 2);
            float speed = Random.Range(speedMean - speedVar / 2, speedMean + speedVar / 2);

            Vector3 startPosition = Camera.main.ScreenToWorldPoint(firstMousePos);
            startPosition.z = 0;

            GameObject astroid = (GameObject)Instantiate(
                AstroidPrefab,
                startPosition,
                gameObject.transform.rotation
                );
            astroid.GetComponent<Rigidbody2D>().angularVelocity = sign * magnitude;
            astroid.GetComponent<Rigidbody2D>().velocity = Quaternion.Euler(0, 0, direction) * new Vector2(speed, 0);

            // Spawn the astroid on the Clients
            NetworkServer.Spawn(astroid);

            // Destroy after X seconds
            Destroy(astroid, autoDestroy);

        }
    }

    private int randomSign() {
        if (Random.Range(0, 2) == 0)
        {
            return -1;
        }
        return 1;
    }
}
