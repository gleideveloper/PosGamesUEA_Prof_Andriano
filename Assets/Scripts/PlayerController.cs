using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator Anime;
    public Rigidbody2D PlayerRigidbody2D;
    public int ForceJump;

    public bool Slide;

    //Verifica se está tocando no ground
    public bool Grounded;

    public Transform GroundCheck;
    public LayerMask WhatIsGround;

    //Slide
    public float SlideTemp;

    private float _timetemp;

    // Use this for initialization
    private void Start()
    {
        Debug.Log("Iniciou aqui");
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetButtonDown("Jump") && Grounded)
        {
            PlayerRigidbody2D.AddForce(new Vector2(0, ForceJump));
            Slide = false;
        }
        if (Input.GetButtonDown("Slide"))
        {
            Slide = true;
            _timetemp = 0;
        }

        Grounded = Physics2D.OverlapCircle(GroundCheck.position, 0.2f, WhatIsGround);

        if (Slide)
        {
            _timetemp += Time.deltaTime;
            if (_timetemp >= SlideTemp)
            {
                Slide = false;
            }
        }

        Anime.SetBool("Jump", !Grounded);
        Anime.SetBool("Slide", Slide);
    }
}
