<Query Kind="Program">
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	long accumulator = 0;
	List<string> lines = new List<string>();
	HashSet<int> steps= new HashSet<int>();
	var filepath = @"C:\Users\Work\Desktop\Advent\2020\8.txt";
	using (var sr = new StreamReader(filepath))
	{
		var line = "";
		while ((line = sr.ReadLine()) != null)
		{
			lines.Add(line);
		}
	}
	
	var instructions = lines.ToArray();
	
	for (int i = 0; i < instructions.Length; i++)
	{
		var clone = (string[])instructions.Clone();
		
		if (accumulator == 0)
		{
			var operationClone = clone[i].Split()[0];
			var codeClone = Int32.Parse(clone[i].Split()[1]);

			if (operationClone == "jmp")
			{
				clone[i] = $"nop {codeClone}";
			}
			else if (operationClone == "nop")
			{
				clone[i] = $"jmp {codeClone}";
			}

			//Task 1
			for (int j = 0; j < clone.Length;)
			{
				var instruction = clone[j].Split()[0];
				var code = Int32.Parse(clone[j].Split()[1]);
				
				if (steps.Contains(j))
				{
					//Console.WriteLine(accumulator);
					accumulator = 0;
					steps.Clear();
					break;
				}
				
				steps.Add(j);
				
				if (instruction == "acc")
				{
					accumulator += code;
					j++;

				}
				else if (instruction == "jmp")
				{
					j += code;
				}

				else
				{
					j++;
				}
			}
		}
		else
		{
			Console.WriteLine(accumulator);
			break;
		}
	}
}

// You can define other methods, fields, classes and namespaces here
