using UnityEngine;

namespace Omotenashi
{
    public class Dialogue : MonoBehaviour
    {
        [SerializeField] private int _size;
        public int Size => _size;
        
        [SerializeField] private string[] _intro;
        [SerializeField] private string[] _good;
        [SerializeField] private string[] _bad;
        [SerializeField] private string[] _noReact;


        public string GetIntro(int index)
        {
            return _intro[index];
        }

        public string GetGood(int index)
        {
            return _good[index];
        }

        public string GetBad(int index)
        {
            return _bad[index];
        }

        public string GetNoReact(int index)
        {
            return _noReact[index];
        }
    }
}