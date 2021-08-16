using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rocks : MonoBehaviour {

    [SerializeField]
    private GameObject particleAttractor;

    private GameObject RedRockUI;
    private ResourcesDisplay RedRockScript;

    [SerializeField]
    private float trailDecrease = 1f;

    [SerializeField]
    private float _enemySpeed = 2.0f;

    private float[] rotationSpeed = new float[2];

    Rigidbody2D rb;

    private Animator animator;

    BoxCollider2D boxCollider;

    // Use this for initialization
    void Start () {
        RedRockUI = GameObject.Find("Red Rock UI");
        RedRockScript = RedRockUI.GetComponentInChildren<ResourcesDisplay>();
        
        rb = gameObject.GetComponent<Rigidbody2D>();

        animator = gameObject.GetComponent<Animator>();

        rotationSpeed[0] = Random.Range(100f, 300f);
        rotationSpeed[1] = Random.Range(-100f, -300f);

        rb.AddTorque(rotationSpeed[Random.Range(0, 2)]);

        boxCollider = GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 moveDir = (new Vector3(0f, 0f, -1.5f) - transform.position).normalized;
        transform.position += moveDir * _enemySpeed * Time.deltaTime;

        if (this.transform.localScale.x < 0.08f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Trail")
        {
            Instantiate(particleAttractor, this.transform.position, Quaternion.identity);

            TrailRendererWith2DCollider.lifeTime -= trailDecrease;

            RedRockScript.RedRockDisplay();

			Destroy(this.gameObject);
        }
        else if(other.gameObject.tag == "Wormhole")
        {
            animator.SetBool("canShrink", true);

            boxCollider.enabled = !boxCollider.enabled;
        }
        else if(other.gameObject.tag == "Player")
        {
			Destroy(this.gameObject);
        }
    }
}
