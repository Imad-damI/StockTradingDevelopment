namespace STD.Data
{
    public class ToastService
    {
        public string Message { get; private set; }
        public string ToastClass { get; private set; }

        private Timer toastTimer;

        public void ShowSuccess(string message)
        {
            SetToast("success", message);
        }

        public void ShowError(string message)
        {
            SetToast("error", message);
        }

        private void SetToast(string toastClass, string message)
        {
            ClearToast();
            Message = message;
            ToastClass = $"toast {toastClass} show";
            toastTimer = new Timer(delegate (object state) { ClearToast(); }, null, TimeSpan.FromSeconds(5), TimeSpan.FromMilliseconds(0));

        }

        private void ClearToast()
        {
            Message = null;
            ToastClass = "toast";
            toastTimer?.Dispose();
        }

        public string GetToastClass()
        {
            return ToastClass;
        }
    }
}