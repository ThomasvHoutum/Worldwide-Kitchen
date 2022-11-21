using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.World
{
    public class ChangeBackground : MonoBehaviour
    {
        [SerializeField] private Image _backGround;
        [SerializeField] private Image _backGroundToBe;
        [SerializeField] private Animator _backGroundToBeAnim;
        [SerializeField] private Sprite _europeBG;
        [SerializeField] private Sprite _africaBG;
        [SerializeField] private Sprite _oceaniaBG;
        [SerializeField] private Sprite _asiaBG;
        [SerializeField] private Sprite _defaultBG;

        private bool _faded;
        private bool _transitioning;

        /// <summary>
        /// Switches out the background based on where the player is
        /// </summary>
        public void UpdateBackGround(int backGround)
        {
            if (_transitioning) 
            {
                StartCoroutine(CheckTransition(backGround));
                return;
            }
            _faded = false;
            switch (backGround)
            {
                case 0:
                    {
                        StartCoroutine(SmoothTransition(_europeBG));
                        break;
                    }

                case 1:
                    {
                        StartCoroutine(SmoothTransition(_africaBG));
                        break;
                    }

                case 2:
                    {
                        StartCoroutine(SmoothTransition(_oceaniaBG));
                        break;
                    }

                case 3:
                    {
                        StartCoroutine(SmoothTransition(_asiaBG));
                        break;
                    }

                case 4:
                    {
                        StartCoroutine(SmoothTransition(_defaultBG));
                        break;
                    }
            }
        }

        private IEnumerator CheckTransition(int background)
        {
            yield return new WaitForSeconds(0.333f);
            UpdateBackGround(background);
        }

        private IEnumerator SmoothTransition(Sprite backgroundToBe)
        {
            if (_faded == false)
            {
                _transitioning = true;
                _backGroundToBe.sprite = backgroundToBe;
                _backGroundToBeAnim.SetBool("Faded", true);
            }
            else
            {
                _backGround.sprite = backgroundToBe;
                _backGroundToBeAnim.SetBool("Faded", false);
                _transitioning = false;
            }

            if (_faded == false)
            {
                yield return new WaitForSeconds(0.33f);
                _faded = true;
                StartCoroutine(SmoothTransition(backgroundToBe));
            }
        }
    }
}
