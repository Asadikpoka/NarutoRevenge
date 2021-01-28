using UnityEngine;
using DG.Tweening;

public class TrailFader : MonoBehaviour
{ 
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float fadeTo;
    [SerializeField] private float fadeOutTime;

    private void Start()
    {
        Fade(spriteRenderer, fadeTo, fadeOutTime);
        Destroy(gameObject, 10);
    }

    private static void Fade(SpriteRenderer element, float fadeTo, float timeToFade)
    {
        DOTween.Sequence()
            .Append(element.DOFade(fadeTo, timeToFade)
                .SetEase(Ease.InOutExpo));
    }
    
    /*    IEnumerator SpriteFadeOut(SpriteRenderer _sprite)
    {
        Color tmpColor = _sprite.color;
        while (tmpColor.a > 0f)
        {
            tmpColor.a -= Time.deltaTime / fadeOutTime;
            _sprite.color = tmpColor;

            if (tmpColor.a <= 0f)
            {
                tmpColor.a = 0.0f;
            }
            yield return null;
        }
        _sprite.color = tmpColor;
    }
    */
}
