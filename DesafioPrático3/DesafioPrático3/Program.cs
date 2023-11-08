using System;
using System.IO;

namespace Empréstimo
{
    class Program
    {
        static void Main(string[] args)
        {
            String nomecolaborador = "";
            decimal salario = 0, emprestimo = 0;
            int escolha, erro, aux, aux2 = 0;  
            var DatadeEmissão = DateTime.Now;

            Console.WriteLine($"Digite seu nome: ");
            nomecolaborador = Console.ReadLine();

            Console.WriteLine($"Digite a data de admissão (dd/mm/aaaa): ");
            do
            {

                try
                {
                    erro = 0;
                    DatadeEmissão = DateTime.Parse(Console.ReadLine());

                    if (DatadeEmissão.Year < 2015)
                    {
                        erro = 1;
                        Console.WriteLine("Data Inválida, ModalGR foi criada em 2015");
                    }


                    var DiadeHoje = DateTime.Today;
                    System.TimeSpan difdata = DiadeHoje.Subtract(DatadeEmissão);

                    if (difdata.Days < 1825)
                    {
                        erro = 1;
                        Console.WriteLine("Agradecemos seu interesse, mas você não atende os requisitos mínimos do programa.");

                    }

                }
                catch (Exception ex)
                {
                    erro = 1;
                    Console.WriteLine("Data Inválida");
                }
            } while (erro == 1);

            Console.WriteLine($"Digite o seu salário (R$ 000,00): ");
            do
            {
                try
                {
                    erro = 0;
                    salario = decimal.Parse(Console.ReadLine());
                    if (salario < 1)
                    {
                        erro = 1;
                        Console.WriteLine("Valor do salário inválido");
                    }
                }
                catch (Exception ex)
                {
                    erro = 1;
                    Console.WriteLine("Valor do salário inválido");
                }

            } while (erro == 1);
            Console.WriteLine($"Digite o valor do empréstimo até R$ {salario * 2} e multiplo de 2: ");
            do
            {
                try
                {
                    erro = 0;
                    emprestimo = decimal.Parse(Console.ReadLine());
                    if (emprestimo < 1)
                    {
                        erro = 1;
                        Console.WriteLine("Insira um valor válido!");
                    }
                    if (emprestimo % 2 != 0)
                    {
                        erro = 1;
                        Console.WriteLine("Insira um valor válido!");
                    }
                    if (emprestimo > salario * 2)
                    {
                        erro = 1;
                        Console.WriteLine("Insira um valor válido!");
                    }
                }
                catch (Exception ex)
                {
                    erro = 1;
                    Console.WriteLine("Insira um valor válido!");
                }

            } while (erro == 1);

            Console.Clear();
            Console.WriteLine($" Nome: {nomecolaborador} \n Data de Admissão: {DatadeEmissão} \n Salário: R$ {salario} \n Empréstimo: R$ {emprestimo} \n");
            Console.WriteLine($"Escolha uma opção de retirada de notas: \n(1) Notas de Maior Valor (2) Notas de Menor Valor (3) Notas Meio a Meio");
            try
            {
                escolha = int.Parse(Console.ReadLine());
                if (escolha == 1)
                {

                    aux = Decimal.ToInt32(emprestimo) / 100;
                    aux2 = (Decimal.ToInt32(emprestimo) % 100);
                    Console.WriteLine($"\nNotas de Maior Valor: ");
                    if (aux != 0) Console.WriteLine($"{aux} x 100 reais");
                    if (aux2 % 100 >= 1)
                    {
                        aux = aux2 / 50;
                        aux2 = aux2 % 50;
                        if (aux != 0) Console.WriteLine($"{aux} x 50 reais");
                        if (aux2 >= 1)
                        {
                            aux = aux2 / 20;
                            aux2 = aux2 % 20;
                            if (aux != 0) Console.WriteLine($"{aux} x 20 reais");
                            if (aux2 >= 1)
                            {
                                aux = aux2 / 10;
                                aux2 = aux2 % 10;
                                if (aux != 0) Console.WriteLine($"{aux} x 10 reais");
                                if (aux2 >= 1)
                                {
                                    if ((aux2 % 5) != 0)
                                    {
                                        aux = aux2 / 2;
                                        aux2 = aux2 % 2;
                                        if (aux != 0) Console.WriteLine($"{aux} x 2 reais");
                                    }
                                    else
                                    {
                                        aux = aux2 / 5;
                                        aux2 = aux2 % 5;
                                        if (aux != 0) Console.WriteLine($"{aux} x 5 reais");
                                    }
                                }
                            }
                        }

                    }
                }
                if (escolha == 2)
                {
                    aux = Decimal.ToInt32(emprestimo) / 20;
                    aux2 = (Decimal.ToInt32(emprestimo) % 20);
                    Console.WriteLine($"\nNotas de Menor Valor: ");
                    if (aux != 0) Console.WriteLine($"{aux} x 20 reais");
                    if (aux2 % 100 >= 1)
                    {
                        aux = aux2 / 10;
                        aux2 = aux2 % 10;
                        if (aux != 0) Console.WriteLine($"{aux} x 10 reais");
                        if (aux2 >= 1)
                        {
                            if ((aux2 %5) != 0)
                            {
                                aux = aux2 / 2;
                                aux2 = aux2 % 2;
                                if (aux != 0) Console.WriteLine($"{aux} x 2 reais");
                            }
                            else
                            {
                                aux = aux2 / 5;
                                aux2 = aux2 % 5;
                                if (aux != 0) Console.WriteLine($"{aux} x 5 reais");
                            }

                        }

                    }
                }
                if (escolha == 3)
                {
                    decimal emprestimomaior = emprestimo / 2;
                    emprestimo = emprestimo / 2;

                    aux = Decimal.ToInt32(emprestimomaior) / 100;
                    aux2 = (Decimal.ToInt32(emprestimomaior) % 100);

                    Console.WriteLine($"\nNotas de Maior Valor {emprestimomaior}: ");
                    if (aux != 0) Console.WriteLine($"{aux} x 100 reais");
                    if (aux2 % 100 >= 1)
                    {
                        aux = aux2 / 50;
                        aux2 = aux2 % 50;
                        if (aux != 0) Console.WriteLine($"{aux} x 50 reais");
                        if (aux2 >= 1)
                        {
                            aux = aux2 / 20;
                            aux2 = aux2 % 20;
                            if (aux != 0) Console.WriteLine($"{aux} x 20 reais");
                            if (aux2 >= 1)
                            {
                                aux = aux2 / 10;
                                aux2 = aux2 % 10;
                                if (aux != 0) Console.WriteLine($"{aux} x 10 reais");
                                if (aux2 >= 1)
                                {
                                    if ((aux2 % 5) != 0)
                                    {
                                        aux = aux2 / 2;
                                        aux2 = aux2 % 2;
                                        if (aux != 0) Console.WriteLine($"{aux} x 2 reais");
                                    }
                                    else
                                    {
                                        aux = aux2 / 5;
                                        aux2 = aux2 % 5;
                                        if (aux != 0) Console.WriteLine($"{aux} x 5 reais");
                                    }
                                }
                            }
                        }
                    }
                    aux = Decimal.ToInt32(emprestimo) / 20;
                    aux2 = (Decimal.ToInt32(emprestimo) % 20);

                    Console.WriteLine($"\nNotas de Menor Valor {emprestimo}: ");
                    if (aux != 0) Console.WriteLine($"{aux} x 20 reais");
                    if (aux2 % 100 >= 1)
                    {
                        aux = aux2 / 10;
                        aux2 = aux2 % 10;
                        if (aux != 0) Console.WriteLine($"{aux} x 10 reais");
                        if (aux2 >= 1)
                        {
                            if ((aux2 % 5) != 0)
                            {
                                aux = aux2 / 2;
                                aux2 = aux2 % 2;
                                if (aux != 0) Console.WriteLine($"{aux} x 2 reais");
                            }
                            else
                            {
                                aux = aux2 / 5;
                                aux2 = aux2 % 5;
                                if (aux != 0) Console.WriteLine($"{aux} x 5 reais");
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Escolha Inválida!");
            }
            Console.ReadKey();


        }
    }
}
