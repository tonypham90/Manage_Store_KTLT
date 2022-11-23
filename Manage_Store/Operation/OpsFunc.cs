namespace Manage_Store.Operation;

public class OpsFunc
{
    public static string TaoID(string[] madattontai)
    {
        while (true)
        {
            string id = String.Empty;
            for (int i = 0; i < 4; i++)
            {
                string letter = GetLetter();
                id += letter;
            }

            if (madattontai.Length==0)
            {
                return id;
            }

            if (madattontai.Contains(id))
            {
                continue;
            }

            return id;
        }
    }

    private static string GetLetter()
    {
        string chars = "1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Random rand = new Random();
        int num = rand.Next(0, chars.Length);
        return chars[num].ToString();
    }

    public static string Notification(bool phanhoi)
    {
        if (phanhoi)
        {
            return "Thao tác thành công";
        }

        return "Thao tác thất bại";
    }


}