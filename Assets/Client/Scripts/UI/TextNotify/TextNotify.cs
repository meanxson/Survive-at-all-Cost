namespace Client.Scripts.UI.TextNotify
{
    public static class TextNotify
    {
        /// <summary>
        /// Shows 1 text
        /// </summary>
        /// <param name="text">text to show</param>
        /// <param name="duration">duration of animation</param>
        public static void Show(string text, float duration)
        {
            TextNotifyCore.Instance.Show(text,duration);
        }
    }
}