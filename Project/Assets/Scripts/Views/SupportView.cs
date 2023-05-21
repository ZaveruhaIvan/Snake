using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class SupportView : MonoBehaviour
    {
        private const string SupportUrl = "https://www.donationalerts.com/r/zid_93";

        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(Support);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(Support);
        }

        private static void Support()
        {
            Application.OpenURL(SupportUrl);
        }
    }
}