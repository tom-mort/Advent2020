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
	var filepath = @"C:\Users\Work\Desktop\Advent\2020\5.txt";
	var line = "";
	int total = 0;
	List<int> seats = new List<int>();

	
	using (var sr = new StreamReader(filepath))
	{
		int iter = 0;
		while ((line = sr.ReadLine()) != null)
		{

			int low = 0;
			int high = 127;
			
			foreach (var element in line.Substring(0, 7))
			{
				if (element == 'F')
				{
					high = high - Middle(low, high);
				}
				else
				{
					low = low + Middle(low, high);
				}
			}

			int min = 0;
			int max = 7;

			foreach (var element in line.Substring(7))
			{
				if (element == 'L')
				{
					max = max - Middle(min, max);
				}
				else
				{
					min = min + Middle(min, max);
				}
			}
			iter++;
			int id = low * 8 + min;
			seats.Add(id);
			if (id > total) {
				total = id;
			}
		}
	}
	seats.Sort();
	foreach (var element in seats)
	{
		if (!seats.Contains(element + 1))
		{
			(element + 1).Dump();
		}
	}
	//seats.Dump();
	total.Dump();
}
// You can define other methods, fields, classes and namespaces here

int Middle(int low, int high)
{
	int middle = (high+1-low)/2;
	return middle;
}