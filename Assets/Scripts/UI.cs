using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

namespace LeafChage
{
    public class UI : MonoBehaviour
    {
        [SerializeField] private Text text;

        public void StartText()
        {
            StartCoroutine(StartTextCoroutine());
        }

        private IEnumerator StartTextCoroutine()
        {
            this.text.text = "<color=red> Start </color>";
            yield return new WaitForSeconds(1);
            this.text.text = "";
        }

        public void GoalText(Action action)
        {
            StartCoroutine(GoalTextCoroutine(action));
        }

        public IEnumerator GoalTextCoroutine(Action action)
        {
            this.text.text = "<color=white> GOAL </color>";
            yield return new WaitForSeconds(1);
            this.text.text = "";
            action();
        }
    }
}
