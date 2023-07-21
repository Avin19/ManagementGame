using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedCounter : MonoBehaviour
{
    [SerializeField] private BaseCounter baseCounter;
    [SerializeField] private GameObject[] visualGameObjectArraay;
   private void Start() {
    Player.Instance.OnSelectedCounterChanged +=Player_OnselectedCounterChnaged;

    
   }

    private void Player_OnselectedCounterChnaged(object sender, Player.OnSelectedCounterChangedEventArgs e)
    {
      if(e.selectCounter == baseCounter)
      {
        Show();
      }
      else{
        Hide();
      }
    }
    private void Show()
    {
        foreach (GameObject i in visualGameObjectArraay)
        {
          i.SetActive(true);
        }

    }
    private void Hide()
    {
         foreach (GameObject i in visualGameObjectArraay)
        {
          i.SetActive(false);
        }

    }
}
