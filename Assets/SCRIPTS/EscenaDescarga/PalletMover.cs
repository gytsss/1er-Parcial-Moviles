using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PalletMover : ManejoPallets
{

    public MoveType miInput;
    public enum MoveType
    {
        WASD,
        Arrows
    }
    public ManejoPallets Desde, Hasta;
    bool segundoCompleto = false;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private Button step1Button;
    [SerializeField] private Button step2Button;
    [SerializeField] private Button step3Button;

    private void Start()
    {
        step1Button.onClick.AddListener(OnStep1ButtonClick);
        step2Button.onClick.AddListener(OnStep2ButtonClick);
        step3Button.onClick.AddListener(OnStep3ButtonClick);
    }
    
    private void Update()
    {
        switch (miInput)
        {
            case MoveType.WASD:
                if (!Tenencia() && Desde.Tenencia() && Input.GetKeyDown(KeyCode.A))
                {
                    PrimerPaso();
                }
                if (Tenencia() && Input.GetKeyDown(KeyCode.S))
                {
                    SegundoPaso();
                }
                if (segundoCompleto && Tenencia() && Input.GetKeyDown(KeyCode.D))
                {
                    TercerPaso();
                }
                break;
            case MoveType.Arrows:
                if (!Tenencia() && Desde.Tenencia() && Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    PrimerPaso();
                }
                if (Tenencia() && Input.GetKeyDown(KeyCode.DownArrow))
                {
                    SegundoPaso();
                }
                if (segundoCompleto && Tenencia() && Input.GetKeyDown(KeyCode.RightArrow))
                {
                    TercerPaso();
                }
                break;
            default:
                break;
        }
    }
    

#if UNITY_ANDROID || UNITY_IOS || UNITY_EDITOR
    private void OnStep1ButtonClick()
    {
        PrimerPaso();
    }
    private void OnStep2ButtonClick()
    {
        SegundoPaso();
    }
    private void OnStep3ButtonClick()
    {
        TercerPaso();
    }
#endif

    void PrimerPaso()
    {
        Desde.Dar(this);
        segundoCompleto = false;
    }
    void SegundoPaso()
    {
        base.Pallets[0].transform.position = transform.position;
        segundoCompleto = true;
    }
    void TercerPaso()
    {
        Dar(Hasta);
        segundoCompleto = false;
    }

    public override void Dar(ManejoPallets receptor)
    {
        if (Tenencia())
        {
            if (receptor.Recibir(Pallets[0]))
            {
                Pallets.RemoveAt(0);
            }
        }
    }
    public override bool Recibir(Pallet pallet)
    {
        if (!Tenencia())
        {
            pallet.Portador = this.gameObject;
            base.Recibir(pallet);
            return true;
        }
        else
            return false;
    }
}
