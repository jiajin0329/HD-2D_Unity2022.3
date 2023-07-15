public struct StringBuilder {
    public static System.Text.StringBuilder instance = new System.Text.StringBuilder();
    public static string Set(string _set) {
        instance.Clear();
        instance.Append(_set);
        return instance.ToString();
    }
}
