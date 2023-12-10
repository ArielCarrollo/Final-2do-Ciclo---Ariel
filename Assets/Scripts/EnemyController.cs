using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D _compRigidBody2D;
    public Animator _compAnimator;
    public int DirectionX = -1;
    public int DirectionY = 0;
    public int Speed = 5;
    // Start is called before the first frame update
    void Awake()
    {
        _compAnimator = GetComponent<Animator>();
        _compRigidBody2D = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.transform.position.x <= -10)
        {
            Destroy();
        }
    }
    void FixedUpdate()
    {
        _compRigidBody2D.velocity = new Vector2(DirectionX * Speed, DirectionY * Speed);
    }
    public void Destroy()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            _compAnimator.SetBool("Explote?", true);

        }
        else if (collision.gameObject.tag == "Player")
        {
            _compAnimator.SetBool("Explote?", true);
        }
    }
}
