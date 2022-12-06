
var arr = new int[] { 2, 1, 5, 2, 5, 2, 1, 1, 1, 7, 9, 13, 127, 21 };
var xy = arr.OrderBy(i => i != 1);
Console.WriteLine(String.Join(", ", xy));




