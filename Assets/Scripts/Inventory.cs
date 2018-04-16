using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour, IHasChanged
{
    [SerializeField] Transform slots;
    [SerializeField] Text inventoryText;
    private GameObject[] comands;
    public Player player;

    // Use this for initialization
    void Start()
    {
        //HasChanged();
        comands = new GameObject[4];
    }

    #region IHasChanged implementation

    public void HasChanged()
    {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
        builder.Append(" - ");

        for(int i = 0; i < slots.childCount; i++)
        {
            GameObject item = slots.GetChild(i).GetComponent<Slot>().Item;
            if (item)
            {
                comands[i] = item;
                builder.Append(item.name);
                builder.Append(" - ");
            }
        }

        inventoryText.text = builder.ToString();

        /* foreach (Transform slotTransform in slots)
         {
             GameObject item = slotTransform.GetComponent<Slot>().item;
             if (item)
             {
                 comands()
                 builder.Append(item.name);
                 builder.Append(" - ");
             }
         }
         inventoryText.text = builder.ToString();*/
    }
    #endregion

    public void Comands()
    {
        //Debug.Log("comands.Count: " + comands.Length);
        for (int i = 0; i < comands.Length; i++)
        {
            if (comands[i] == null)
            {
                Debug.Log((i + 1) + "º Comando: null");
            }
            else
            {
                Debug.Log((i + 1) + "º Comando: " + comands[i].name);
                if(comands[i].name == "Direita")
                {
                    Debug.Log("Aqui");
                    Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
                    Transform rp = player.GetComponent<Transform>();
                    //float movX = Input.GetAxis("Horizontal");
                    rp.Translate(Vector2.right * 2 * Time.deltaTime);
                    
                }
            }
            
            //Debug.Log("i: " + i);
               
        }
    }

}


namespace UnityEngine.EventSystems
{
    public interface IHasChanged : IEventSystemHandler
    {
        void HasChanged();
    }
}