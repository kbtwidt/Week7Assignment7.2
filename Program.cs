namespace Week7Assignment7._2
{
    internal class Program
    {
        static void Divide(int[] arr, int left, int right)
        {
            if (left  < right)
            {
                int mid = (left + right) / 2;
                Divide(arr, left, mid);
                Divide(arr, mid + 1, right);
                Merge(arr, left, mid, right);
            }
        }
        static void Merge(int[] arr, int left, int mid, int right)
        {
            int i = left;
            int j = mid + 1;
            int[] temp = new int[right + 1];
            int k = left;

            while (i <= mid && j <= right)
            {
                if (arr[i] <= arr[j])
                {
                    temp[k] = arr[i];
                    i++;
                }
                else
                {
                    temp[k] = arr[j];
                    j++;
                }
                k++;
            }
            while(i <= mid)
            {
                temp[k] = arr[i];
                k++;
                i++;
            }
            while(j <= right)
            {
                temp[k] = arr[j];
                k++;
                j++;
            }
            for (int x = left;  x <= right; x++)
            {
                arr[x] = temp[x]; 
            }
        }
        static bool IsVowel(char c)
        {
            return "aeiouAEIOU".Contains(c);
        }
        static string ReverseVowels(string s)
        {
            char[] chars = s.ToCharArray();
            int left = 0;
            int right = chars.Length - 1;

            while (left < right)
            {
                while (left < right && !IsVowel(chars[left]))
                    left++;

                while (left < right && !IsVowel(chars[right]))
                    right--;

                if (left < right)
                {
                    (chars[left], chars[right]) = (chars[right], chars[left]);
                    left++;
                    right--;
                }
            }

            return new string(chars);
        }       
        static bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
                return false;

            char[] sArr = s.ToCharArray();
            char[] tArr = t.ToCharArray();

            Array.Sort(sArr);
            Array.Sort(tArr);

            for (int i = 0; i < s.Length; i++)
            {
                if (sArr[i] != tArr[i])
                    return false;
            }

            return true;
        }
        static void Main(string[] args)
        {
            #region Part 1
            Console.WriteLine("Part 1");
            Console.Write("\nEnter a size for an array: ");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Enter a whole number for Element[{i + 1}]: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Entered array:");
            Console.WriteLine(string.Join(", ", arr));
            Divide(arr, 0, arr.Length - 1);
            Console.WriteLine("Sorted array:");
            Console.WriteLine(string.Join(", ", arr));
            #endregion

            #region Part 2
            Console.WriteLine("\nPart 2");
            Console.Write("\nEnter a word: ");
            string input = Console.ReadLine();
            string output = ReverseVowels(input);
            Console.WriteLine($"{input} with vowels reversed is {output}.");
            #endregion

            #region Part 3
            Console.WriteLine("\nPart 3");
            Console.WriteLine("\nFinding Anagrams:");
            string s1 = "anagram";
            string t1 = "nagaram";
            string s2 = "rat";
            string t2 = "car";
            Console.WriteLine($"{s1} & {t1}: {IsAnagram(s1, t1)}");
            Console.WriteLine($"{s2} & {t2}: {IsAnagram(s2, t2)}"); 
            #endregion
        }
    }
}
