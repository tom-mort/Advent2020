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
	var filepath = @"C:\Users\Work\Desktop\Advent\2020\2.txt";

	using (var sr = new StreamReader(filepath))
	{
		int total = 0;
		int refined = 0;
		var line = "";
		
		while ((line = sr.ReadLine()) != null)
		{
			var p = line.Split();
			
			var min = Int32.Parse(p[0].Split("-")[0]);
			var max = Int32.Parse(p[0].Split("-")[1]);
			
			var letter = p[1].First();
			var count = p[2].Count(x => x == letter);
			
			if (count >= min && count <= max)
				total++;
				
			if (p[2][min - 1] == letter ^ p[2][max - 1] == letter)
				refined++;
		}
		
		Console.WriteLine(total);
		Console.WriteLine(refined);
	}
}
