var arr = new int[] { 9, 2, 3, 1, 4 };
var maior = arr.Max(x => x);
var dif = arr.Select(x => x - maior);
var conca = dif.Concat(arr);
Console.WriteLine(String.Join(", ", conca));