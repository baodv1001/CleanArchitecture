namespace hrm_core.Utils
{
    public static class CustomString
    {
        public static string PadAnInt(int N, int P)
        {
            // string used in Format() method
            string s = "{0:";
            for (int i = 0; i < P; i++)
            {
                s += "0";
            }
            s += "}";

            // use of string.Format() method
            string value = string.Format(s, N);

            // return output
            return value;
        }
    }
}
