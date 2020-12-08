<Query Kind="Program">
  <NuGetReference>Azure.Identity</NuGetReference>
  <NuGetReference>Azure.Security.KeyVault.Keys</NuGetReference>
  <NuGetReference>Azure.Storage.Blobs</NuGetReference>
  <NuGetReference>Microsoft.Azure.Cosmos</NuGetReference>
  <NuGetReference>Microsoft.Azure.Cosmos.Table</NuGetReference>
  <Namespace>Microsoft.Azure.Cosmos</Namespace>
  <Namespace>Microsoft.Azure.Cosmos.Table</Namespace>
  <Namespace>Newtonsoft.Json</Namespace>
  <Namespace>Newtonsoft.Json.Serialization</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var filepath = @"C:\Users\Work\Desktop\Advent\2020\6.txt";
	HashSet<char> charHashes = new HashSet<char>(); //Sets
	List<string> lines = new List<string>();
	int total = 0;
	int uniqueAnswers = 0;
	
	using (var sr = new StreamReader(filepath))
	{
		var line = "";
		while ((line = sr.ReadLine()) != null)
		{
			if (string.IsNullOrEmpty(line))
			{
				total += charHashes.Count();
				if (lines.Any())
				{
					uniqueAnswers += Uniques(lines);
				}
				
				charHashes.Clear();
				lines.Clear();
			}
			else
			{
				lines.Add(line);
				foreach (char cha in line) //cha-cha!!
				{
					charHashes.Add(cha);
				}
			}
		}
	}
	Console.WriteLine(total);
	Console.WriteLine(uniqueAnswers);
}
// You can define other methods, fields, classes and namespaces here
int Uniques (List<string> input){
	var  p = input.ToArray();
	var x = p.First().ToArray();
	
	for (int i = 1; i < p.Count(); i++)
	{
		x = p[i].Intersect(x).ToArray();
	}
	
	return x.Distinct().Count();
}