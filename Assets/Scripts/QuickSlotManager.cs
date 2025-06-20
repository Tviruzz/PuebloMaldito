using UnityEngine;
using UnityEngine.UI;

public class QuickSlotManager : MonoBehaviour
{
    public Image[] slots; // Referencias a los slots
    public int currentSlot = 0;
    public Sprite[] toolIcons; // Iconos de herramientas visibles
    public GameObject[] tools; // Objetos reales que se activan

    void Start()
    {
        UpdateSlots();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentSlot = (currentSlot - 1 + slots.Length) % slots.Length;
            UpdateSlots();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            currentSlot = (currentSlot + 1) % slots.Length;
            UpdateSlots();
        }
    }

    void UpdateSlots()
    {
        // Cambiar visibilidad visual y activar herramienta correspondiente
        for (int i = 0; i < slots.Length; i++)
        {
            bool selected = i == currentSlot;
            slots[i].color = selected ? Color.white : Color.gray;

            if (tools[i] != null)
                tools[i].SetActive(selected);
        }
    }
}
