// See https://aka.ms/new-console-template for more information
using Pergunta2;
//maça morango pera goiaba limao abacaxi laranja banana cebola
Console.WriteLine("Frutas na cesta!");
Console.WriteLine("maça, morango, pera, goiaba, limao, abacaxi, laranja, banana, cebola");
Console.WriteLine("escolha uma fruta:");
var escolha = Console.ReadLine();


Dictionary<int, string> cesta = new Dictionary<int, string>();
cesta.Add(50, "maça");
cesta.Add(25, "morango");
cesta.Add(51, "pera");
cesta.Add(24, "goiaba");
cesta.Add(26, "limao");
cesta.Add(52, "abacaxi");
cesta.Add(63, "laranja");
cesta.Add(62, "banana");
cesta.Add(64, "cebola");


BinarySearchTree nums = new BinarySearchTree();
foreach (var fruta in cesta)
{
    nums.Insert(fruta.Key, fruta.Value);
}


var fruit = cesta.FirstOrDefault(x => x.Value == escolha).Key;
nums.FindAndPrint(fruit);
;

//nums.TraversePreOrder();
//nums.TraversePostOrder();
//nums.TraverseLevelOrder();
//nums.TraverseInOrder();




















