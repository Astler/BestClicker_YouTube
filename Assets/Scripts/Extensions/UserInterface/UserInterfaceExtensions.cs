using TMPro;

namespace Extensions.UserInterface
{
    public static class UserInterfaceExtensions
    {
        public static void SetText(this TMP_Text text, object value)
        {
            text.text = value.ToString();
        }
    }
}