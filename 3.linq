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
	var filepath = @"C:\Users\Work\Desktop\Advent\2020\3.txt";
	long total = 1;
	var routes = new int[,] { { 1, 1 }, { 3, 1 }, { 5, 1 }, { 7, 1 }, { 1, 2 } };
	//var routes = new int[,] { { 3, 1 } };

	for (int i = 0; i < routes.GetLength(0); i++)
	{
		total *= Trees(routes[i, 0], routes[i, 1], filepath);
	}

	Console.WriteLine(total);
}

int Trees(int right, int down, string filepath)
{
	using (var sr = new StreamReader(filepath))
	{
		int total = 0;
		var index = 0;
		var line = "";

		while ((line = sr.ReadLine()) != null)
		{
			if (line[index % line.Length] == '#')
			{
				total++;
			}

			index += right;
			for (int i = 1; i < down; i++)
			{
				sr.ReadLine();
			}
		}
		return total;
	}
}
