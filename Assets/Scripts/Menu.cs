using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject[] _menus;

    public void SetScreen(Screens screens)
    {
        for (int i = 0; i <_menus.Length ; i++)
        {
            _menus[i].SetActive(i == (int)screens);
        }
    }

    public enum Screens
    {
        Connect = 0,
        Wait,
        Rooms
    }
}
