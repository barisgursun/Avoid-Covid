using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenMenu : MonoBehaviour
{
    public GameObject Open_Menu;
    public GameObject Close_Menu;

    public void Open()
    {
        Open_Menu.SetActive(true);
        Close_Menu.SetActive(false);
    }
}