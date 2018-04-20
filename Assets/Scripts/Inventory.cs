using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class Inventory : MonoBehaviour, IHasChanged
{
    [SerializeField] Transform slots;
    
    [SerializeField] Text inventoryText;
    private GameObject[] comands;
    public Button btPlay;
    public Player player;

    // Use this for initialization
    void Start()
    {
        //HasChanged();
        
        comands = new GameObject[4];
    }

    private void FixedUpdate()
    {
        if (VerificaCompleto())
        {
            btPlay.gameObject.GetComponent<Button>().interactable = true;
        }
        else
        {
            btPlay.gameObject.GetComponent<Button>().interactable = false;
        }
    }

    #region IHasChanged implementation

    public void HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();

        for (int i = 0; i < slots.childCount; i++)
        {
            GameObject item = slots.GetChild(i).GetComponent<Slot>().Item;
            if (item)
            {
                comands[i] = item;
                builder.Append((i+1) + "º: " + item.name);
                builder.Append("\n");
            }
        }

        inventoryText.text = builder.ToString();
    }
    #endregion

    public void Comands()
    {
        if (VerificaCompleto())
        {
            Debug.Log("Completo");
            for (int i = 0; i < comands.Length; i++)
            {
                Debug.Log((i + 1) + "º Comando: " + comands[i].name);

                switch (comands[i].name)
                {
                    case "Direita":
                        Debug.Log("Entrou no Direita");
                        /*Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                        Transform rp = player.GetComponent<Transform>();
                        //float movX = Input.GetAxis("Horizontal");
                        rp.Translate(Vector2.right * 2 * Time.deltaTime);*/
                        player.Move(1);
                        break;
                    case "Pular":
                        //player.Jump();
                        break;
                    default:
                        break;
                }

            }
        }
    }



    private bool VerificaCompleto()
    {
        for (int i = 0; i < slots.childCount; i++)
        {
            GameObject item = slots.GetChild(i).GetComponent<Slot>().Item;
            if (item == null)
            {
                return false;
            }
        }
        return true;
    }
}


namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}