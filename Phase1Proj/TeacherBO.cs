using System;
using System.Collections.Generic;
using System.IO;

namespace Phase1Proj
{
    class TeacherBO
    {
        public List<TeacherModel> Teachers;
        public string TeacherFileName;

        public TeacherBO()
        {

            Teachers = new List<TeacherModel>();
            TeacherFileName = @"C:\Users\11035909\source\repos\Phase1Proj\Phase1Proj\TeacherData.txt";
        }

        public void StoreDataInList()
        {
            try
            {
                string[] lines = File.ReadAllLines(TeacherFileName);
                foreach (string record in lines)
                {
                    string[] data = record.Split(" ");
                    Teachers.Add(new TeacherModel { Id = int.Parse(data[0]), Name = data[1], Class = int.Parse(data[2]), Section = data[3] });
                }
                Console.WriteLine("file data stored in the List Successfully!!");
                Console.WriteLine("===================================================\n");
            }
            catch(FileNotFoundException)
            {
                Console.WriteLine("Error : File Not Found, please check the path ");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            
        }
        public void Add(TeacherModel t)
        {
            int index = Teachers.FindIndex(x => x.Id==t.Id);
            if(index != -1)
            {
                Console.WriteLine("Error : You Entered the Id Which is already Exists in the file");
                return;
            }
            Teachers.Add(t); //adding the Teacher object to list as well,  to get in sync with the file data
            using StreamWriter wrt = File.AppendText(TeacherFileName);
            wrt.WriteLine($"{t.Id} {t.Name} {t.Class} {t.Section}");
            Console.WriteLine("Added Successfuly!! ");
            Console.WriteLine("===================================================\n");

        }
        public void DisplyAll()
        {
            foreach (TeacherModel t1 in Teachers)
            {
                Console.WriteLine($"ID = {t1.Id} Name = {t1.Name}    Class = {t1.Class}   Section = {t1.Section}");
            }
            Console.WriteLine("===================================================\n");
        }

        public void Display(int id)
        {
            int index = Teachers.FindIndex(x => x.Id == id);
           if(index == -1)
            {
                Console.WriteLine("Error : You Entered an  Incorrect ID ");
                return;
            }
            Console.WriteLine($"ID = {Teachers[index].Id} Name = {Teachers[index].Name}    Class = {Teachers[index].Class}   Section = {Teachers[index].Section} ");
            Console.WriteLine("===================================================\n");
            
        }
        public void Update(TeacherModel t)
        {
            // First we are updating the teacher record in List and we write the list to the text file, again the List and file are in sync with each other
            int index = Teachers.FindIndex(x => x.Id == t.Id);
            if(index == -1)
            {
                Console.WriteLine("Error : You Entered an Id Which doesn't exist in the File to be Updated");
                return;
            }
            Teachers[index] = t;
            try
            {
                using (StreamWriter wrt = File.CreateText(TeacherFileName)) // Overwriting the existing file.
                {
                    foreach (TeacherModel t1 in Teachers)
                    {
                        wrt.WriteLine($"{t1.Id} {t1.Name} {t1.Class} {t1.Section}");
                    }
                }
                Console.WriteLine("Updated Successfully!!  ");
                Console.WriteLine("===================================================\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            
            
        }
        public void Delete(int teacherId)
        {
            int index = Teachers.FindIndex(x => x.Id == teacherId);
            if (index == -1)
            {
                Console.WriteLine("Error : You Entered an  Incorrect ID ");
                return;
            }
            Teachers.RemoveAt(index);
            try
            {
                using (StreamWriter wrt = File.CreateText(TeacherFileName)) // Overwriting the existing file.
                {
                    foreach (TeacherModel t1 in Teachers)
                    {
                        wrt.WriteLine($"{t1.Id} {t1.Name} {t1.Class} {t1.Section}");
                    }
                }
                Console.WriteLine("Deleted Succesfully!!  ");
                Console.WriteLine("===================================================\n");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

            
        }
    }
}
