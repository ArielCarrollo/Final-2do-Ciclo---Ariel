using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float SpeedX = 10;
    public float SpeedY = 7;
    public float Horizontal;
    public float Vertical;
    public Animator _compAnimator;
    public SpriteRenderer _compSpriteRenderer;
    public Rigidbody2D _compRigidbody2D;
    public AudioSource _compAudioSource;
    void Awake()
    {
        _compAnimator = GetComponent<Animator>();
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.Space) == true)
        {
            _compAudioSource.Play();
        }
        if (Horizontal == 1)
        {
            _compAnimator.SetBool("Run?", true);
        }
        else if (Horizontal < 1 )
        {
            _compAnimator.SetBool("Run?", false);
        }
    }
    void FixedUpdate()
    {
        _compRigidbody2D.velocity = new Vector2(Horizontal * SpeedX, Vertical * SpeedY);
    }
}
