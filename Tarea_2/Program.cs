using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=====================================================");

            string respuesta, cedula, nombre = string.Empty;
            int horas_laboradas, precio_hora, cantidad_empleados= 0, cantidad_tipo1= 0, cantidad_tipo2= 0, cantidad_tipo3= 0, type_empleado= 0;
            float salario_ordinario, aumento, salario_bruto, deduccion_ccss, salario_neto, total_salario_ordinario= 0f;
            
            do
            {
                do
                {
                    cantidad_empleados++;
                    Console.WriteLine("*Ingrese el número de cédula: ");
                    cedula = Console.ReadLine();
                    Console.WriteLine("*Ingrese el nombre del trabajador: ");
                    nombre = Console.ReadLine();
                    Console.Write("*Que tipo de empleado es? \n1.Operativo\n2.Técnico\n3.Profesional: ");
                    int.TryParse(Console.ReadLine(), out type_empleado);
                    Console.WriteLine("*Ingrese la cantidad de horas laboradas: ");
                    int.TryParse(Console.ReadLine(), out horas_laboradas);
                    Console.WriteLine("*Ingrese el precio pagado por hora:");
                    int.TryParse(Console.ReadLine(), out precio_hora);

                    if (horas_laboradas <= 0 || precio_hora <= 0 || string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre) || type_empleado < 1 || type_empleado > 3)
                    {
                        Console.WriteLine("Los datos ingresados no son válidos. Por favor, ingrese nuevamente los datos del empleado.");
                        cantidad_empleados--;
                    }

                } while (horas_laboradas <= 0 || precio_hora <= 0 || string.IsNullOrEmpty(cedula) || string.IsNullOrEmpty(nombre) || type_empleado < 1 || type_empleado > 3);

                salario_ordinario = horas_laboradas * precio_hora;

                aumento = 0;
                switch (type_empleado)
                {
                   case 1:
                        cantidad_tipo1++;
                        aumento = salario_ordinario * (float)0.05;
                        break;
                    case 2:
                        cantidad_tipo2++;
                        aumento = salario_ordinario * (float)0.10;
                        break;
                    case 3:
                        cantidad_tipo3++;
                        aumento = salario_ordinario * (float)0.15;
                        break;
                    default:
                        Console.WriteLine("Tipo de empleado no válido.");
                        break;
                }
                
                salario_bruto = salario_ordinario + aumento;
                deduccion_ccss = salario_bruto * (float)0.0917;
                salario_neto = salario_bruto - deduccion_ccss;
                total_salario_ordinario += salario_ordinario;

                Console.WriteLine("---------------------------------Datos del empleado actual---------------------------------");
                Console.WriteLine("Cédula: {0}", cedula);
                Console.WriteLine("Nombre: {0}", nombre);
                Console.WriteLine("Tipo de empleado: {0}", type_empleado);
                Console.WriteLine("Salario por hora: {0}", precio_hora);
                Console.WriteLine("Horas laboradas: {0}", horas_laboradas);
                Console.WriteLine("Salario ordinario: {0}", salario_ordinario);
                Console.WriteLine("Aumento: {0}", aumento);
                Console.WriteLine("Salario bruto: {0}", salario_bruto);
                Console.WriteLine("Deducción CCSS: {0}", deduccion_ccss);
                Console.WriteLine("Salario neto: {0}", salario_neto);
                Console.WriteLine("\n--------------------------------------------------\n");

                Console.WriteLine("Deseas agregar otro empleado? (SI/NO)");
                respuesta = Console.ReadLine();
                Console.WriteLine("");
            }   while (respuesta.ToUpper() == "SI");

            Console.WriteLine($"Cantidad de empleados: {cantidad_empleados}");
            Console.WriteLine($"Cantidad de empleados Operativos: {cantidad_tipo1}");
            Console.WriteLine($"Cantidad de empleados Técnicos: {cantidad_tipo2}");
            Console.WriteLine($"Cantidad de empleados Profesionales: {cantidad_tipo3}");
            Console.WriteLine($"Total salario ordinario: {total_salario_ordinario}");

            Console.WriteLine("=====================================================");
        }
    }
}
