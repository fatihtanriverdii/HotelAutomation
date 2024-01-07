namespace System
{
    internal class KeyPressEventArgs
    {
        private Action<object, Windows.Forms.KeyPressEventArgs> adminIDText_TextChanged;

        public KeyPressEventArgs(Action<object, Windows.Forms.KeyPressEventArgs> adminIDText_TextChanged)
        {
            this.adminIDText_TextChanged = adminIDText_TextChanged;
        }
    }
}