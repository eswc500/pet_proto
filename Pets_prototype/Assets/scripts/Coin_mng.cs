using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class Coin_mng : MonoBehaviour
{
    public List<coin_item> coin_item;
   

    public Manager mng;

    public void add_coins(int id, int qty, SO_GameInfo info)
    {
        info.coins[id] = info.coins[id] + qty;
        coin_item[id].coin_txt.text = info.coins[id].ToString();
        bounce_obj(coin_item[id].coin_rect);
    }

    public void bounce_obj(RectTransform rect)
    {
        float bounceScale = 1.5f;
        float bounceDuration = 0.1f;

        rect.transform.DOKill();
        rect.transform.DOScale(Vector3.one * bounceScale, bounceDuration)
            .SetEase(Ease.OutQuad)
            .OnComplete(() =>
            {
                rect.transform.DOScale(Vector3.one, bounceDuration)
                    .SetEase(Ease.InQuad).OnComplete(() => { rect.transform.localScale = Vector3.one; });
                ;
            });
    }

}

[System.Serializable]
public class coin_item
{
    public TextMeshProUGUI coin_txt;
    public RectTransform coin_rect;
}
