using UnityEngine;
using Characters;

namespace Assets.World
{
    public class Timer : MonoBehaviour
    {
        [Header("UI")]
        [SerializeField] private TMPro.TMP_Text _textObject;
        private float _timeAsSeconds = 0;
        private int _timeInMinutes = 0;
        private int _endTimeMinutes;
        private int _endTimeSeconds;
        private BaseCharacter character;

        private void Start()
        {
            character = new BaseCharacter();
        }
        private void FixedUpdate()
        {
            SetTime();
        }

        private void SetTime()
        {
            
            if (!character.GameEnded())
            {
                _timeAsSeconds += Time.deltaTime;
                int everySecond = Mathf.RoundToInt(_timeAsSeconds);
                if (everySecond >= 60)
                {
                    _timeInMinutes++;
                    _timeAsSeconds = 0;
                }
                _textObject.text = string.Format("{0:D2}:{1:D2}", _timeInMinutes, everySecond); 
            }
            else
            {
                _endTimeMinutes = _timeInMinutes;
                _endTimeSeconds = (int)_timeAsSeconds;
            }
        }
    }
}
