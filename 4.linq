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
	var filepath = @"C:\Users\Work\Desktop\Advent\2020\4.txt";
	var line = "";
	int toatl = 0;
	int tot2 = 0;
	using (var sr = new StreamReader(filepath))
	{
		passport p = new passport();
		while ((line = sr.ReadLine())!= null)
		{
			
			if (line.Trim() == string.Empty)
			{
				//p.Dump();
				if (p.IsValid())
				{
					toatl++;
					if (p.AllValid())
					{
						tot2++;
	
					}
					
				p = new passport();
				}
				
			}
			else
			{
				foreach (var element in line.Split())
				{
					//p.Dump();
					var items = element.Split(':');
					switch (items[0])
					{
						case "byr" :
							p.byr = items[1];
							break;
						case "iyr":
							p.iyr = items[1];
							break;
						case "eyr":
							p.eyr = items[1];
							break;
						case "hgt":
							p.hgt = items[1];
							break;
						case "hcl":
							p.hcl = items[1];
							break;
						case "ecl":
							p.ecl = items[1];
							break;
						case "pid":
							p.pid = items[1];
							break;
						case "cid":
							p.cid = items[1];
							break;
					}
				}
			}
			
		}
		
		toatl.Dump();
		tot2.Dump();
	}
}



class passport
{
	public string byr  { get; set; } //(Birth Year)
	public string iyr  { get; set; } //(Issue Year)
	public string eyr  { get; set; } //(Expiration Year)
	public string hgt  { get; set; } //(Height)
	public string hcl  { get; set; } //(Hair Color)
	public string ecl  { get; set; } //(Eye Color)
	public string pid  { get; set; } //(Passport ID)
	public string cid  { get; set; } //(Country ID)

	public bool IsValid()
	{
		if (byr == null || iyr == null || eyr == null || hgt == null || hcl == null || ecl == null || pid == null)
		{
			return false;
		}
		else
		{
			return true;
		}
	}
	
	public bool AllValid()
	{
		
		if (Byr() && Iyr() && Eyr() && Hgt() && Hcl() && Ecl() && Pid())
		{
			
			return true;
		}

		return false;
	}
	
	bool Byr()
	{
		var num = Int32.TryParse(byr, out int n);
		if (n > 1919 && n < 2003 && num)
		{
			return true;
		}
		return false;
	}

	bool Iyr()
	{
		var num = Int32.TryParse(iyr, out int n);
		if (n > 2009 && n < 2021 && num)
		{
			return true;
		}
		return false;
	}
	
	bool Eyr()
	{
		var num = Int32.TryParse(eyr, out int n);
		if (n > 2019 && n < 2031 && num)
		{
			return true;
		}
		return false;
	}
	bool Hgt()
	{

		if (hgt.EndsWith("cm"))
		{
			var num = Int32.TryParse(hgt.Remove(hgt.Length -2), out int n);
			if (n > 149 && n < 194 && num)
			{
				return true;
			}
		}
		if (hgt.EndsWith("in"))
		{
			var num = Int32.TryParse(hgt.Remove(hgt.Length -2), out int n);
			if (n > 58 && n < 77 && num)
			{
				return true;
			}
		}
		return false;
	}
	
	bool Hcl()
	{
		if (hcl.StartsWith('#') && hcl.Length == 7)
		{

			return System.Text.RegularExpressions.Regex.IsMatch(hcl.Substring(1), @"\A\b[0-9a-fA-F]+\b\Z");
		}
			
			return false;
	}
	
	bool Ecl()
	{
		if (ecl.Length != 3)
		{
			return false;
		}
		List<string> allowed = new List<string> {"amb","blu", "brn", "gry", "grn", "hzl", "oth"};
		if (allowed.Contains(ecl))
		{
			return true;
		}
		return false;
	}
	
	bool Pid()
	{
		if (pid.Length == 9)
		{
			return pid.All(char.IsDigit);
		}
		return false;
	}


}

