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

long bagCount = 0;
List<string> bagHandles = new List<string>();
HashSet<Guid> correlations = new HashSet<Guid>();
void Main()
{
	var filepath = @"C:\Users\Work\Desktop\Advent\2020\7.txt";
	using (var sr = new StreamReader(filepath))
	{
		var line = "";
		while ((line = sr.ReadLine()) != null)
		{
			bagHandles.Add(line);
		}
	}
	
	//Part 2
	var shiny = bagHandles.Single(i => i.Substring(0, i.IndexOf(" contain")).Trim() == "shiny gold bags");
	GoDeep(shiny.Substring(0, shiny.IndexOf(" contain")), true, Guid.NewGuid(), 1);

	//part 1
	foreach (var bag in bagHandles)
	{
		GoDeep(bag.Substring(0, bag.IndexOf(" contain")), true, Guid.NewGuid(), 0);
	}
	
	Console.WriteLine(correlations.Count());
	Console.WriteLine(bagCount);
}

// You can define other methods, fields, classes and namespaces here

void GoDeep(string input, bool top, Guid correlation, long count)
{
	string line = "";
	if (!top )
	{
		line = bagHandles.Single(s => s.Substring(0,s.IndexOf(" contain") ) == input.Substring(2));
	}
	else
	{
		line = bagHandles.Single(s => s.StartsWith(input));
	}
	int index = line.IndexOf("contain ") + 7;
	var sub = line.Substring(index).Replace(".", "").Split(',');
	foreach (var element in sub)
	{
		if (element.Contains("shiny gold"))
		{
			correlations.Add(correlation);
		}

		if (element.Trim() != "no other bags")
		{
			int subBags = Int32.Parse(element.Trim().Substring(0, 1));			
			long carry = count * subBags;
			if (count != 1)
			{
				bagCount+=carry;
			}
			else
			{
				bagCount+=subBags;
			}
			var refined = element;
			if (!element.EndsWith("s"))
			{
				refined = string.Concat(element, "s");
			}

			GoDeep(refined.Trim(), false, correlation, carry);
		}		
	}
}