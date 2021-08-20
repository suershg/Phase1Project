using System;
using System.IO;
using System.Collections.Generic;

namespace Phase1Proj
{
    class Program
    {
        static void Main(string[] args)
        {
            
            TeacherBO o1 = new TeacherBO();
            o1.StoreDataInList();
            int x;
            while(true)
            {
                Console.WriteLine("\n Choose an option : ");
                Console.WriteLine(" 1.Add teacher   2.DisplayAll  3.DisplayOne   4.Update  5.Delete  6.Exit");
                try
                {
                    x = Convert.ToInt32(Console.ReadLine());
                    if (x == 6)
                        break;
                }
                catch(FormatException)
                {
                    Console.WriteLine("Error : Incorrect Input, Please Enter a Number(1-6) ");
                    x = 10;
                }
                catch(Exception ex)
                {
                    Console.WriteLine("Error : "+ex.Message);
                    x = 10;
                }
                
                TeacherModel teacherObj = new TeacherModel();
                string[] data;
                switch(x)
                {
                    case 1: 
                        Console.WriteLine("Please provide the teacher details with spaces inbetween each property: Id Name Class Section");
                        data = Console.ReadLine().Split(" ");
                        try
                        {
                            teacherObj.Id = int.Parse(data[0]);
                            teacherObj.Name = data[1];
                            teacherObj.Class = int.Parse(data[2]);
                            teacherObj.Section = data[3];
                            o1.Add(teacherObj);
                            
                        }
                        catch(FormatException)
                        {
                            Console.WriteLine("Error : Given Incorrect Format " );
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Error : " + ex.Message);
                        }
                        break;
                    case 2:
                        o1.DisplyAll();
                        break;
                    case 3:
                        Console.WriteLine("Enter the Id of the teacher to be Displayed");
                        try
                        {
                            int id = int.Parse(Console.ReadLine());
                            o1.Display(id);
                        }
                        catch(FormatException ex)
                        {
                            Console.WriteLine("Error :"+ ex.Message+" Id Should be an Integer");
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("Error : "+ex.Message);
                        }
                        break;
                    case 4:
                        Console.WriteLine("Please provide the teacher details with spaces inbetween each property: Id Name Class Section");
                        data = Console.ReadLine().Split(" ");
                        try
                        {
                            teacherObj.Id = int.Parse(data[0]);
                            teacherObj.Name = data[1];
                            teacherObj.Class = int.Parse(data[2]);
                            teacherObj.Section = data[3];
                            o1.Update(teacherObj);
                        }
                        catch (FormatException )
                        {
                            Console.WriteLine("Error : Given Incorrect Format " );
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error : " + ex.Message);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Enter the Id of the teacher to be Displayed");
                        try
                        {
                            int id = int.Parse(Console.ReadLine());
                            o1.Delete(id);
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Error :" + ex.Message + ", Id Should be an Integer " );
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Error : " + ex.Message);
                        }
                        break;
                    default:
                        Console.WriteLine("please Enter the Correct Option  \n");
                        break;
                }

            }

        }
    }
}
