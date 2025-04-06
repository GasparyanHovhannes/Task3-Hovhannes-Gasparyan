Strategy sort = new BubbleSort(); // StrategySort
var context = new Context(sort);
context.Sort();
context.Speed();
context.PrintArray();
//------------------------
sort = new SelectionSort();
context = new Context(sort);
context.Sort();
context.Speed();
context.PrintArray();
//---------------------
sort = new InsertionSort();
context = new Context(sort);
context.Sort();
context.Speed();
context.PrintArray();
//---------------------
sort = new MergeSort();
context = new Context(sort);
context.Sort();
context.Speed();
context.PrintArray();
//---------------------
sort = new ShellSort();
context = new Context(sort);
context.Sort();
context.Speed();
context.PrintArray();
class Context
{
    Strategy strategy;
    int[] array = { 3, 5, 1, 2, 4 };
    public Context(Strategy strategy)
    {
        this.strategy = strategy;
    }
    public void Sort()
    {
        strategy.Sort(ref array);
    }

    public void Speed()
    {
        int[] tempArray = (int[])array.Clone();
        DateTime start = DateTime.Now;
        strategy.Sort(ref tempArray);
        DateTime end = DateTime.Now;
        Console.WriteLine("Time = " + (end-start).TotalMilliseconds + "ms");
    }
    public void PrintArray()

    {
        for(int i = 0; i < array.Length; i++)
            Console.Write(array[i] + " ");
        Console.WriteLine();

    }
}
abstract class Strategy
{
    public abstract void Sort(ref int[] array);
}
class BubbleSort : Strategy
{
    public override void Sort(ref int[] array)

    {
        Console.WriteLine("BubbleSort");
        for(int i = 0; i < array.Length; i++)
        {
            for(int j = array.Length- 1; j > i; j--)

            {
                if (array[j] < array[j- 1])

                {
                    int temp = array[j];
                    array[j] = array[j- 1];
                    array[j- 1] = temp;

                }

            }

        }

    }
}
class SelectionSort : Strategy
{
    public override void Sort(ref int[] array)

    {
        Console.WriteLine("SelectionSort");
        for(int i = 0; i < array.Length - 1; i++)

        {
            int k = i;
            for(int j = i + 1; j < array.Length; j++)
                if (array[k] > array[j])
                    k = j;
            if (k != i)
            {
                int temp = array[k];
                array[k] = array[i];
                array[i] = temp;
            }
        }
    }
}
class InsertionSort : Strategy
{
    public override void Sort(ref int[] array)
    {
        Console.WriteLine("InsertionSort");
        for (int i = 1; i < array.Length; i++)
        {
            int j = 0;
            int buffer = array[i];
            for (j = i - 1; j >= 0; j--)
            {
                if (array[j] < buffer)
                    break;
                array[j + 1] = array[j];
            }
            array[j + 1] = buffer;
        }
    }
}

class MergeSort : Strategy
{
    public override void Sort(ref int[] array)
    {
        Console.WriteLine("MergeSort");
        array = MergeSortAlg(array);
    }

    private int[] MergeSortAlg(int[] array)
    {
        if (array.Length <= 1)
            return array;

        int mid = array.Length / 2;
        int[] left = new int[mid];
        int[] right = new int[array.Length - mid];
        for (int i = 0; i < mid; i++)
        {
            left[i] = array[i]; 
        }

        for (int j = 0; j < mid; j++)
        {
            right[j] = array[mid + j];
        }

        left = MergeSortAlg(left);
        right = MergeSortAlg(right);

        return Merge(left, right);
    }

    private int[] Merge(int[] left, int[] right)
    {
        int[] result = new int[left.Length + right.Length];
        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i] < right[j])
            {
                result[k] = left[i];
                k++;
                i++;
            }

            else
            {
                result[k] = right[j];
                k++;
                j++;
            }
                
        }
        while (i < left.Length)
        {
            result[k] = left[i];
            k++;
            i++;
        }
            
        while (j < right.Length)
        {
            result[k] = right[j];
            j++;
            k++;
        }
        return result;
    }
}

class ShellSort : Strategy
{
    public override void Sort(ref int[] array)
    {
        Console.WriteLine("ShellSort");
        int n = array.Length;
        for (int gap = n / 2; gap > 0; gap /= 2)
        {
            for (int i = gap; i < n; i++)
            {
                int temp = array[i];
                int j;
                for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                {
                    array[j] = array[j - gap];
                }
                array[j] = temp;
            }
        }
    }
}
