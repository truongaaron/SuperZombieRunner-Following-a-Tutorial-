using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOffScreen : MonoBehaviour {

    public float offset = 16f;

    private bool offscreen;
    private float offScreenX = 0;
    private Rigidbody2D body2d;

    void Awake()
    {
        body2d = GetComponent<Rigidbody2D>();
    }

	// Use this for initialization
	void Start () {
        offScreenX = (Screen.width / PixelPerfectCamera.pixelsToUnits) / 2 + offset;
	}
	
	// Update is called once per frame
	void Update () {

        var posX = transform.position.x;
        var dirX = body2d.velocity.x;

        if(Mathf.Abs(posX) > offScreenX)
        {
            if(dirX < 0 && posX < -offScreenX) {
                offscreen = true;
            } else if(dirX > 0 && posX > offScreenX) {
                offscreen = true;
            }            

        } else {
            offscreen = false;
        }

        if (offscreen)
        {
            OnOutOfBounds();
        }
	}

    public void OnOutOfBounds()
    {
        offscreen = false;
        GameObjectUtil.Destroy(gameObject);
    }
}
