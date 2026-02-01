using UnityEngine;

namespace Omotenashi
{
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private string _intro;
        [SerializeField] private string _good;
        [SerializeField] private string _bad;
        [SerializeField] private string _noReact;


        public string GetIntro()
        {
            return _intro;
        }

        public string GetGood()
        {
            return _good;
        }

        public string GetBad()
        {
            return _bad;
        }

        public string GetNoReact()
        {
            return _noReact;
        }
    }
}