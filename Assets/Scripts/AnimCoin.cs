using TMPro;
using UnityEngine;
using DG.Tweening;
using System.Collections;

public class AnimCoin : MonoBehaviour
{
    [SerializeField] private GameObject pilhaMoedas;
    [SerializeField] private TextMeshProUGUI pontuacao;
    [SerializeField] private Vector3[] inicialPos;
    [SerializeField] private Quaternion[] inicialRot;
    [SerializeField] private int moedasColetaveis;

    public void Start()
    {
        inicialPos = new Vector3[moedasColetaveis];
        inicialRot = new Quaternion[moedasColetaveis];

        for (int i = 0; i < pilhaMoedas.transform.childCount; i++)
        {
            inicialPos[i] = pilhaMoedas.transform.GetChild(i).position;
            inicialRot[i] = pilhaMoedas.transform.GetChild(i).rotation;
        }
    }

    public void Reset()
    {
        for (int i = 0; i < pilhaMoedas.transform.childCount; i++)
        {
            pilhaMoedas.transform.GetChild(i).position = inicialPos[i];
            pilhaMoedas.transform.GetChild(i).rotation = inicialRot[i];
        }
    }

    public void Recompensa(int moedasColetaveis)
    {
        Reset();

        var delay = 0f;

        pilhaMoedas.SetActive(true);

        for (int i = 0; i < pilhaMoedas.transform.childCount; i++)
        {
            pilhaMoedas.transform.GetChild(i).DOScale(endValue: 1f, duration: 0.3f).SetDelay(delay).SetEase(Ease.OutBack);

            pilhaMoedas.transform.GetChild(i).GetComponent<RectTransform>().DOAnchorPos(endValue: new Vector2(x: 229f, y: 604f), duration: 1f).SetDelay(delay + 0.5f).SetEase(Ease.InBack);

            pilhaMoedas.transform.GetChild(i).DORotate(Vector3.zero, duration: 0.5f).SetDelay(delay + 0.5f).SetEase(Ease.Flash);

            pilhaMoedas.transform.GetChild(i).DOScale(endValue: 1f, duration: 0.3f).SetDelay(delay + 1f).SetEase(Ease.OutBack);

            delay += 0.2f;

            StartCoroutine(routine: ContadorMoedas(moedasColetaveis: 7));
        }

        IEnumerator ContadorMoedas(int moedasColetaveis)
        {
            yield return new WaitForSecondsRealtime(time: 1f);

            var timer = 0f;

            for (int i = 0; i < moedasColetaveis; i++)
            {
                PlayerPrefs.SetInt("moeda", PlayerPrefs.GetInt(key: "moeda") + moedasColetaveis);

                pontuacao.text = PlayerPrefs.GetInt(key: "moeda").ToString();

                timer += 0.1f;
            }
        }
    }


}

