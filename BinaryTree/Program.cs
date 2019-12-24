using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T>
    {
        public T Value { get; set; }
        public BinaryTree<T> LeftChild { get; private set; }
        public BinaryTree<T> RightChild { get; private set; }
        public BinaryTree(T value, BinaryTree<T> LeftChild, BinaryTree<T> RightChild)
        {
            this.Value = value;
            this.LeftChild = LeftChild;
            this.RightChild = RightChild;
        }
        public void PrintInOrder() //обход в глубину данного дерева (симметричный(In-Order))
        {
            if (this.LeftChild != null)
            {
                (this.LeftChild).PrintInOrder();
            }
            Console.Write("{0} ", this.Value);
            if (this.RightChild != null)
            {
                (this.RightChild).PrintInOrder();
            }
        }
        public void add_node(T value, string Path, int cnt, string direction,T S, T K)
        {
            if (Path[cnt] == '1' && cnt != Path.Length - 1)
            {
                (this.LeftChild).add_node(value, Path, cnt + 1, direction, S, K);
            }
            else if (Path[cnt] == '0' && cnt != Path.Length - 1)
            {
                (this.RightChild).add_node(value, Path, cnt + 1, direction, S, K);
            }
            else
            {
                if (Path[Path.Length - 1] == '1')
                {
                    if (direction == "Да" || direction == "да")
                    {
                        this.LeftChild = new BinaryTree<T>(value, new BinaryTree<T>(S, null, null), new BinaryTree<T>(K, null, null));
                    }
                    else
                    {
                        this.LeftChild = new BinaryTree<T>(value, new BinaryTree<T>(this.Value, null, null), new BinaryTree<T>(K, null, null));
                    }
                }
                else
                {
                    if (direction == "Да" || direction == "да")
                    {
                        this.RightChild = new BinaryTree<T>(value, new BinaryTree<T>(S, null, null), new BinaryTree<T>(K, null, null));
                    }
                    else
                    {
                        this.RightChild = new BinaryTree<T>(value, new BinaryTree<T>(K, null, null), new BinaryTree<T>(S, null, null));
                    }
                }
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> binaryTree =
                new BinaryTree<int>(14,
                    new BinaryTree<int>(19,
                        new BinaryTree<int>(23, null, null),
                        new BinaryTree<int>(6,
                            new BinaryTree<int>(10, null, null),
                            new BinaryTree<int>(21, null, null))),
                     new BinaryTree<int>(15,
                         new BinaryTree<int>(3,null,null),
                         null));
            binaryTree.PrintInOrder();
            //игра животные
            //исходное дерево знаний для игры "Животные"
            Console.WriteLine();
            BinaryTree<string> Animals =
                new BinaryTree<string>("Это Млекопитающее?",
                    new BinaryTree<string>("Оно лает?",
                        new BinaryTree<string>("Собака", null, null),
                        new BinaryTree<string>("Кошка", null, null)),
                            new BinaryTree<string>("Оно покрыто чешуёй?",
                            new BinaryTree<string>("Оно дышит в воде?",
                                new BinaryTree<string>("Рыба", null, null),
                                new BinaryTree<string>("Змея", null, null)),
                            new BinaryTree<string>("Птица", null, null)));
            while (true)
            {
                Animals.PrintInOrder();
                Console.WriteLine();
                BinaryTree<string> Buf = Animals;
                string Path = "";
                while (true)
                {
                    if (Buf.LeftChild == null || Buf.RightChild == null) //если дошли до терминальной вершины
                    {
                        Console.WriteLine("Это {0}?", Buf.Value); //если ответ - "Да", то всё ок
                        string s0 = Console.ReadLine();
                        if (s0 == "Нет" || s0 == "нет") //если ответ - "Нет", то добавляем внутреннюю вершину
                        {
                            Console.WriteLine("Какое животное вы загадали?");
                            string S = Console.ReadLine();
                            Console.WriteLine("Какой вопрос поможет отличить <{0}> от <{1}>?", Buf.Value, S);
                            string NewNode = Console.ReadLine();
                            Console.WriteLine("Для <{0}> ответ утвердительный?", S);
                            string direction = Console.ReadLine();
                            Animals.add_node(NewNode, Path, 0, direction, S, Buf.Value);
                        }
                        break;
                    }
                    Console.WriteLine(Buf.Value, " ");
                    string s = Console.ReadLine();
                    if (s == "Да" || s == "да")
                    {
                        Buf = Buf.LeftChild;
                        Path += "1";
                    }
                    else
                    {
                        Buf = Buf.RightChild;
                        Path += "0";
                    }
                }
                Console.WriteLine("Хотите сыграть ещё?");
                string q = Console.ReadLine();
                if (q == "Нет" || q == "нет")
                {
                    break;
                }
            }
        }
    }
}
