using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

//curso: https://www.alura.com.br/curso-online-criacao-de-jogos-com-unity - modificado
//habilidades 
public class PlayerAbilities : MonoBehaviour
{
    private FPSController player;

//salto recebe:
//forca do salto
//rapidez
//diretetion
//som
//e os riscos
    [Header("Updraft")]
    public bool isUpdrafting;
    public float updraftForce;
    public float updraftCooldown;
    [SerializeField] private AudioClip updraftSound;
    [SerializeField] private Image updraftUI;

//rapidez
//recebe tudo de cima mais se esta sendo usado no momento e seu vetor
    [Header("Dash")]
    public bool isDash;
    public float dashForce;
    public float dashDuration;
    public float dashCooldown;
    private Vector3 dashVector;
    [SerializeField] private AudioClip dashSound;
    [SerializeField] private Image dashUI;

    private bool fward, bward, left, right;
    [SerializeField] private ParticleSystem forwardDash, backwardDash, leftDash, rightDash, updraftParticle;


//invisibilidade que nao terminei
   [Header("Invisibility")]
   public bool isInvisibility;
   public float invisibilityTime;
   public float invisibilityCooldown;
   private float _invisibilityTime;
   [SerializeField] private AudioClip invisibilitySound;
   [SerializeField] private Image invisiblityUI;
   [SerializeField] private Image cloakFeedback;
   private Color alphaColor;
   private Color abilitieNotReadyColor;
   private Color abilitieReadyColor;
   private AudioSource _audio;


    private void Awake()
    {
        //instancia cor, audio, controller
        alphaColor = cloakFeedback.color;
        alphaColor.a = 0;
        cloakFeedback.color = alphaColor;

        _audio = GetComponent<AudioSource>();
        player = GetComponent<FPSController>();
        abilitieNotReadyColor = new Color(.3f, .009f, .15f, .5f);
        abilitieReadyColor = new Color(1, 1, 1, 1);
    }

    void Update()
    {
        //chama as funcoes
        Updraft();
        Dash();
    }

    void Updraft()
    {
        //se tiver no chao da dash uma vez 
        if (Input.GetKeyDown(KeyCode.Q) && !isUpdrafting && player._isGrounded)
        {
            //som
            _audio.PlayOneShot(updraftSound);
            updraftParticle.Play();
            //sdd forca
            player.GetComponent<Rigidbody>().AddForce(Vector3.up * updraftForce, ForceMode.Impulse);
            //se esta sendo usado
            isUpdrafting = true;
            updraftUI.fillAmount = 0;
            //cor
            updraftUI.color = abilitieNotReadyColor;
        }
        //caso estiver no ar
        if (isUpdrafting)
        {
            updraftUI.fillAmount += 1 / updraftCooldown * Time.deltaTime;
           
            if(updraftUI.fillAmount >= 1)
            {
                updraftUI.fillAmount = 1;
                updraftUI.color = abilitieReadyColor;
                isUpdrafting = false;
            }
        }
    }

//nao terminei apenas ignore, deu bug com a aula.
    void Invisibility()
    {
        cloakFeedback.color = alphaColor;
        if (Input.GetKeyDown(KeyCode.C) && !isInvisibility)
        {
            alphaColor.a = .75f;
            cloakFeedback.color = alphaColor;
            transform.gameObject.layer = 10;
            _audio.PlayOneShot(invisibilitySound);
            isInvisibility = true;
            invisiblityUI.fillAmount = 0;
            invisiblityUI.color = abilitieNotReadyColor;
        }
        if (transform.gameObject.layer == 10)
        {
            invisibilityTime -= Time.deltaTime;
            if (invisibilityTime <= 0)
            {
                alphaColor.a = 0;
                cloakFeedback.color = alphaColor;
                transform.gameObject.layer = 8;
                invisibilityTime = _invisibilityTime;
            }
        }
        if (isInvisibility)
        {
            invisiblityUI.fillAmount += 1 / invisibilityCooldown * Time.deltaTime;
            if (invisiblityUI.fillAmount >= 1)
            {
                invisiblityUI.fillAmount = 1;
                invisiblityUI.color = abilitieReadyColor;
                isInvisibility = false;
            }
        }

    }

    void Dash()
    {//ve o lado do dash e manda o player com x forca
        if (Input.GetKey(KeyCode.W))
        {
            fward = true;
            bward = false;
            left = false;
            right = false;
            dashVector = transform.forward * dashForce;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            fward = false;
            bward = true;
            left = false;
            right = false;
            dashVector = -transform.forward * dashForce;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            fward = false;
            bward = false;
            left = true;
            right = false;
            dashVector = -transform.right * dashForce;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            fward = false;
            bward = false;
            left = false;
            right = true;
            dashVector = transform.right * dashForce;
        }
        else
        {
            fward = true;
            bward = false;
            left = false;
            right = false;
            dashVector = player.transform.forward * dashForce;
        }

        if (Input.GetKeyDown(KeyCode.E) && !isDash)
        {//animation
            if (fward)
            {
                forwardDash.Play();
            }
            if (bward)
            {
                backwardDash.Play();
            }

            if (right)
            {
                rightDash.Play();
            }

            if (left)
            {
                leftDash.Play();
            }

            _audio.PlayOneShot(dashSound);
            StartCoroutine(DashCoroutine());
            isDash = true;
            dashUI.fillAmount = 0;
            dashUI.color = abilitieNotReadyColor;
        }
        if (isDash)
        {
            dashUI.fillAmount += 1 / dashCooldown * Time.deltaTime;
            if (dashUI.fillAmount >= 1)
            {
                dashUI.fillAmount = 1;
                dashUI.color = abilitieReadyColor;
                isDash = false;
            }
        }
    }

    IEnumerator DashCoroutine()
    {
        //corrotina pra lancar o jogador
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            player.GetComponent<Rigidbody>().AddForce(dashVector * dashForce, ForceMode.Impulse);  
            yield return null;
        }
    }

}
