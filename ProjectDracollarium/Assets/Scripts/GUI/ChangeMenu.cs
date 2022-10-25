using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeMenu : MonoBehaviour{
    public void ChangeTo(GameObject panel)
    {
        panel.SetActive(true);
        this.gameObject.SetActive(false);
    }

}
