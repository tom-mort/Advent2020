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
	MyExtensions.StartWatch();
	List<int> items = new List<int>();
	
	var filepath = @"C:\Users\Work\Desktop\Advent\2020\1.txt";
	
	using (var sr = new StreamReader(filepath))
	{
		var line = "";
		while ((line = sr.ReadLine())!= null)
		{
			items.Add(Int32.Parse(line));
		}
	}
	
	var input = items.ToArray();
	var output = Get2020(input);
	var output3 = Get2020x3(input);
	output.Dump();
	output3.Dump();
	
	MyExtensions.Finish();
}


int Get2020(int[] x)
{
	for (int i = 0; i < x.Length; i++)
	{
		for(int j = i; j < x.Length; j++)
		{
			if(x[i] + x[j] == 2020)
			{
				return x[i] * x[j];
			}
		}
	}
	
	return 0;
}

int Get2020x3(int[] x)
{
	for (int i = 0; i < x.Length; i++)
	{
		for (int j = i; j < x.Length; j++)
		{
			for (int k = j; k < x.Length; k++)
			{
				if (x[i] + x[j] + x[k] == 2020)
				{
					return x[i] * x[j] * x[k];
				}
			}
		}
	}

	return 0;
}