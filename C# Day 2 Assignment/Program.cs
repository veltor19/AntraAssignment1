using C__Day_2_Assignment; // Add missing semicolon and fix syntax for using directive
/*
int[] GenerateArray(int size) {
    int[] array = new int[size];
    for (int i = 0; i < size; i++) {
        array[i] = i + 1;
    }
    return array;
}

void ReverseArray(int[] array) {
    int left = 0;
    int right = array.Length - 1;
    while (left < right) {
        int temp = array[left];
        array[left] = array[right];
        array[right] = temp;
        left++;
        right--;
    }
}

void PrintArray(int[] array) {
    foreach (var item in array) {
        Console.Write(item + " ");
    }
}

int[] array = GenerateArray(10);
ReverseArray(array);
PrintArray(array);
*/
/*
int Fibonacci(int n) {
    if (n <= 1) {
        return n;
    }
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

for (int i = 1; i <= 10; i++) {
    Console.WriteLine($"Fibonacci({i}) = {Fibonacci(i)}");
}
*/


Color color = new Color(255, 0, 0);
Ball ball = new Ball(5, color);
ball.Throw();
Console.WriteLine(ball.GetThrowCount());
ball.Pop();
ball.Size = 10;
Console.WriteLine(ball.Size);