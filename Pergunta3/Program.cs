var arr = new int[] { 1, 15, 2, 7, 2, 5, 7, 1, 4 };

Console.WriteLine(String.Join(", ", arr));
Console.WriteLine("digite um número: ");

int n = Int32.Parse(Console.ReadLine());

Console.WriteLine(TwoSum.PrintPairs(arr, n));




public class TwoSum
{

    public static bool PrintPairs(int[] arr, int sum)
    {
        HashSet<int> s = new HashSet<int>();
        for (int i = 0; i < arr.Length; ++i)
        {
            int temp = sum - arr[i];

            // checking for condition
            if (s.Contains(temp))
            {
                return true;
            }
            s.Add(arr[i]);
        }
        return false;
    }
}






























