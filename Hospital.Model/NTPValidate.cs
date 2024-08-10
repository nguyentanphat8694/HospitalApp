namespace Hospital.App
{
    public class NTPValidate
    {
        public static bool IsEmpty(string ob)
        {
            if (ob == null || ob.Trim() == "") return true;
            return false;
        }
    }
}
