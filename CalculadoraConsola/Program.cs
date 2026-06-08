using System;

namespace EjercicioPracticoConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            string continuar;

            do
            {
                Console.Clear();
                Console.WriteLine("=== CALCULADORA DE CONSOLA AVANZADA ===");

                try
                {
                    // 1. Solicitar y validar el primer número
                    Console.Write("Ingrese el primer número real: ");
                    string entrada1 = Console.ReadLine();

                    // Validación de campo vacío o espacios en blanco
                    if (string.IsNullOrWhiteSpace(entrada1))
                    {
                        throw new ArgumentException("Error: No ha ingresado el primer número. El campo no puede estar vacío.");
                    }

                    // Validación de que sea un número válido
                    if (!double.TryParse(entrada1, out double num1))
                    {
                        throw new FormatException("Error: El dato ingresado no es un número válido. Debe colocar un dato correcto.");
                    }


                    // 2. Solicitar y validar el segundo número
                    Console.Write("Ingrese el segundo número real: ");
                    string entrada2 = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(entrada2))
                    {
                        throw new ArgumentException("Error: No ha ingresado el segundo número. El campo no puede estar vacío.");
                    }

                    if (!double.TryParse(entrada2, out double num2))
                    {
                        throw new FormatException("Error: El dato ingresado no es un número válido. Debe colocar un dato correcto.");
                    }


                    // 3. Solicitar la clave de operación
                    Console.WriteLine("\nClaves disponibles: [+] Suma | [-] Resta | [*] Multiplicación | [/] División | [R] Raíz Cuadrada | [E] Elevación");
                    Console.Write("Ingrese la clave de la operación a realizar: ");
                    string clave = Console.ReadLine().ToUpper().Trim();

                    if (string.IsNullOrWhiteSpace(clave))
                    {
                        throw new ArgumentException("Error: Debe ingresar una clave de operación.");
                    }


                    // 4. Procesar la operación según la clave
                    double resultado = 0;

                    switch (clave)
                    {
                        case "+":
                            resultado = num1 + num2;
                            Console.WriteLine("\nResultado de la Suma ({0} + {1}) = {2}", num1, num2, resultado);
                            break;

                        case "-":
                            resultado = num1 - num2;
                            Console.WriteLine("\nResultado de la Resta ({0} - {1}) = {2}", num1, num2, resultado);
                            break;

                        case "*":
                            resultado = num1 * num2;
                            Console.WriteLine("\nResultado de la Multiplicación ({0} * {1}) = {2}", num1, num2, resultado);
                            break;

                        case "/":
                            // Validación estricta de división entre cero
                            if (num2 == 0)
                            {
                                throw new DivideByZeroException("Error: No es posible realizar divisiones entre 0.");
                            }
                            resultado = num1 / num2;
                            Console.WriteLine("\nResultado de la División ({0} / {1}) = {2}", num1, num2, resultado);
                            break;

                        case "R":
                            // Validación para raíces de números negativos en números reales
                            if (num1 < 0 || num2 < 0)
                            {
                                throw new ArithmeticException("Error: No se puede calcular la raíz cuadrada de un número negativo en el conjunto de los reales.");
                            }
                            Console.WriteLine("\nRaíz cuadrada de {0} = {1}", num1, Math.Sqrt(num1));
                            Console.WriteLine("Raíz cuadrada de {0} = {1}", num2, Math.Sqrt(num2));
                            break;

                        case "E":
                            // Eleva num1 a la potencia de num2 y redondea a máximo 3 decimales
                            double potencia = Math.Pow(num1, num2);
                            resultado = Math.Round(potencia, 3);
                            Console.WriteLine("\nResultado de {0} elevado a {1} (Redondeado a 3 dec.) = {2}", num1, num2, resultado);
                            break;

                        default:
                            Console.WriteLine("\nError: La clave ingresada no corresponde a ninguna operación válida.");
                            break;
                    }
                }
                catch (FormatException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[FORMATO INCORRECTO] -> {0}", ex.Message);
                    Console.ResetColor();
                }
                catch (ArgumentException ex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n[CAMPO VACÍO] -> {0}", ex.Message);
                    Console.ResetColor();
                }
                catch (DivideByZeroException ex)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("\n[OPERACIÓN INVÁLIDA] -> {0}", ex.Message);
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n[ERROR INESPERADO] -> {0}", ex.Message);
                    Console.ResetColor();
                }

                // Preguntar al usuario si desea continuar
                Console.WriteLine("\n--------------------------------------------------");
                Console.Write("¿Desea continuar realizando más operaciones? (S/N): ");
                continuar = Console.ReadLine().ToUpper().Trim();

            } while (continuar == "S" || continuar == "SI");

            Console.WriteLine("\n¡Programa finalizado! Presione cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}