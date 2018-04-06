using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_student1
{
  class Person
    {
        public static int Id = 0;
        public static string name = null;
        public static int age=0;
        public static string sex = null;
        public virtual int Age(int a);
        public virtual string Stage();
    }// end of person class
  // student class 
  class Student : Person
  {
      public float quizz1 = 0;
      public float quizz2 = 0;
      public float assigment = 0;
      public float midterm = 0;
      public float final = 0;
      public float total = 0;
      static public int itemcount = -1;
      public Student()
      {
          Console.Write("Enter student's ID:");
          Person.Id = int.Parse(Console.ReadLine());
          Console.Write("Enter the student name : ");
          Person.name = Console.ReadLine();
          //Person.age = age(the student age in this case) 
          Console.Write("Enter student's age:");
          Person.age = int.Parse(Console.ReadLine());
          while (Person.age < 0)
          {
              Console.Write("You have enter a wrong age!!\n ReEnter student's Age:");
              Person.age = int.Parse(Console.ReadLine());
          }
          Console.Write("Enter student's Sex(F or M):");
          Person.sex = Console.ReadLine().ToString();
      }
        public Student(int stnumber, int stage, string stname, string sex, float quizz1, float quizz2, float assigment, float midterm, float final, float total)
        {
            this.Person.Id = stnumber;
            this.Person.age = stage;
            this.Person.name = stname;
            this.Person.sex = sex;
            this.quizz1 = quizz1;
            this.quizz2 = quizz2;
            this.assigment = assigment;
            this.midterm = midterm;
            this.final = final;
            this.total = total;
        }//end the prametrized constractor   
    }//end the class student 
    class Initial
    {
        Student[] st = new Student[30];
          public  int itemcount = 0;
        public void displaymenu()
        {
            Console.WriteLine("======================================================\n                         MENU                         \n======================================================");
            Console.WriteLine(" 1.Add student records");
            Console.WriteLine(" 2.Delete student records");
            Console.WriteLine(" 3.Update student records");
            Console.WriteLine(" 4.View all student records");
            Console.WriteLine(" 5.Calculate an average of a selected student's scores");
            Console.WriteLine(" 6.Show student who get the max total score");
            Console.WriteLine(" 7.Show student who get the min total score");
            Console.WriteLine(" 8.Find a student by ID");
            Console.WriteLine(" 9.Sort students by TOTAL");
            //create an array to store only 30 students'records for testing.
            int choice;
            string confirm;
           
            do
            {
                Console.Write("Enter your choice(1-8):");

                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {

                    case 1:
                        add(ref itemcount);
                        break;
                    case 2:
                        delete(st, ref itemcount);
                        break;
                    case 3:
                        update(st, itemcount);
                        break;
                    case 4:
                        viewall(st, itemcount);
                        break;
                    case 5:
                        average(st, itemcount);
                        break;
                    case 6:
                        showmax(st, itemcount);
                        break;
                    case 7:
                        showmin(st, itemcount);
                        break;
                    case 8:
                        find(st, itemcount);
                        break;
                    case 9:
                        bubblesort(st, itemcount);
                        break;

                    default: Console.WriteLine("invalid"); break;
                }
                Console.Write("Press y or Y to continue:");

                confirm = Console.ReadLine().ToString();
            } while (confirm == "y" || confirm == "Y");
        }//end the desplay menu
       public override int Age(int a)
      	{
          if (a < 0 )
              a = a * -1;
          else 
          {
              if (a > 25)
                  Console.WriteLine("Not allowed !!");
          }
          return a;
     	 }
        public void add(ref int itemcount)
        {
            Console.WriteLine(itemcount);
            Console.Write("Enter student's ID:");
            Person.Id = int.Parse(Console.ReadLine());
            
           Console.Write("Enter student's age:");
	   Person.age=int.Parse(Console.ReadLine());
           Age(age);
            
	    Console.Write("Enter student's Name:");
            Person.name = Console.ReadLine().ToString();

            Console.Write("Enter student's Sex(F or M):");
            Person.sex = Console.ReadLine().ToString();

            Console.Write("Enter student's quizz1 score:");
            float quizz1 = float.Parse(Console.ReadLine());

            Console.Write("Enter student's quizz2 score:");
            float quizz2 = float.Parse(Console.ReadLine());

            Console.Write("Enter student's assigment score:");
            float assigment = float.Parse(Console.ReadLine());

            Console.Write("Enter student's mid term score:");
            float midterm = float.Parse(Console.ReadLine());
           
	    Console.Write("Enter student's final score:");
            float final = float.Parse(Console.ReadLine());
            
             float total = quizz1 + quizz2 + assigment + midterm +final;
            st[itemcount] = new student(Person.Id, Person.age, Person.name, Person.sex, quizz1, quizz2, assigment, midterm, final, total);
            itemcount++;
        }//end the added information 
        public int search(Student[] st, int id, int itemcount)
        {
            int found = -1;
            for (int i = 0; i < itemcount && found == -1; i++)
            { 
                if (st[i].Person.Id == id) found = i;
                else found = -1;
            }
            return found;
        }//end the search function 
        static void clean(Student[] st, int index)
        {
            st[index].Person.Id = 0;
            st[index].Person.age = 0;
            st[index].Person.name = null;
            st[index].Person.sex = null;
            st[index].quizz1 = 0;
            st[index].quizz2 = 0;
            st[index].assigment = 0;
            st[index].midterm = 0;
            st[index].final = 0;
            st[index].total = 0;
        }
        public void delete(Student[] st, ref int itemcount)
        {
            int id;
            int index;
            if (itemcount > 0)
            {
                Console.Write("Enter student's ID:");
                id = int.Parse(Console.ReadLine());
                index = search(st, id, itemcount);
                if ((index != -1) && (itemcount != 0))
                {
                    if (index == (itemcount - 1))
                    {
                        clean(st, index);
                        this.itemcount = itemcount--;
                        Console.WriteLine("The record was deleted.");
                    }
                    else
                    {
                        for (int i = index; i < itemcount - 1; i++)
                        {
                            st[i] = st[i + 1];
                            clean(st, itemcount);
                            --itemcount;
                        }
                    }
                }
                else Console.WriteLine("The record doesn't exist.Check the ID and try again.");
            }
            else Console.WriteLine("No record to delete");
        }
	    
        public void viewall(Student[] st, int itemcount)
        {
            int i = 0;

            Console.WriteLine("{0,-5}{1,-20}{2,-5}{3,-5}{4,-5}{5,-5}{6,-5}{7,-5}{8}(column index)", "0", "1", "2", "3", "4", "5", "6", "7", "8");
            Console.WriteLine("{0,-5}{1,-20}{2,-5}{3,-5}{4,-5}{5,-5}{6,-5}{7,-5}{8,-5}", "ID", "NAME", "SEX", "Q1", "Q2", "As", "Mi", "Fi", "TOTAL");
            Console.WriteLine("=====================================================");
            while (i < itemcount)
            {
                if (st[i].Person.Id != -1)
                {
                    Console.Write("{0,-5}{1,-20}{2,-5}", st[i].Person.Id, st[i].Person.name, st[i].Person.sex);
                    Console.Write("{0,-5}{1,-5}{2,-5}", st[i].quizz1, st[i].quizz2, st[i].assigment);
                    Console.Write("{0,-5}{1,-5}{2,-5}", st[i].midterm, st[i].final, st[i].total);
                    Console.Write("\n");
                }
                i = i + 1;
            }
        }
        public void update(Student[] st, int itemcount)
        {
            int id;
            int column_index;
            Console.Write("Enter student's ID:");
            id = int.Parse(Console.ReadLine());
            Console.WriteLine("1.Name 2.Sex 3. quizz1 4.quizz2 5.assigment score 6.midterm score 7.final score 8.Age");
            Console.Write("Which field you want to update(1-8)?:");
            column_index = int.Parse(Console.ReadLine());
            int index = search(st, id, itemcount);
            if ((index != -1) && (itemcount != 0))
            {
                if (column_index == 1)
                {
                    Console.Write("Enter student's Name:");
                    st[index].Person.name = Console.ReadLine().ToString();
                }
                else if (column_index == 2)
                {
                    Console.Write("Enter student's Sex(F or M):");
                    st[index].Person.sex = Console.ReadLine().ToString();
                }
                else if (column_index == 3)
                {
                    Console.Write("Enter student's quizz1 score:");
                    st[index].quizz1 = float.Parse(Console.ReadLine());
                }
                else if (column_index == 4)
                {
                    Console.Write("Enter student's quizz2 score:");
                    st[index].quizz2 = float.Parse(Console.ReadLine());
                }
                else if (column_index == 5)
                {
                    Console.Write("Enter student's assigment score:");
                    st[index].assigment = float.Parse(Console.ReadLine());
                }
                else if (column_index == 6)
                {
                    Console.Write("Enter student's midterm score:");
                    st[index].midterm = float.Parse(Console.ReadLine());
                }
                else if (column_index == 7)
                {
                    Console.Write("Enter student's final score:");
                    st[index].final = float.Parse(Console.ReadLine());
                }
                else if (column_index == 8)
                {
                    Console.Write("Enter student's Age:");
                    st[index].Person.age = int.Parse(Console.ReadLine());
                }
                else Console.WriteLine("Invalid column index");
                st[index].total = st[index].quizz1 + st[index].quizz2 + st[index].assigment + st[index].midterm + st[index].final ;
            }
            else Console.WriteLine("The record deosn't exits.Check the ID and try again.");
        }
        public void average(Student[] st, int itemcount)
        {
            int id;
            float avg = 0;
            Console.Write("Enter students'ID:");
            id = int.Parse(Console.ReadLine());
            int index = search(st, id, itemcount);
            if (index != -1 && itemcount > 0)
            {
                st[index].total = st[index].quizz1 + st[index].quizz2 + st[index].assigment + st[index].midterm + st[index].final;
                avg = st[index].total / 5;
            }
            Console.WriteLine("The average score is {0}.", avg);
        }
        public void showmax(Student[] st, int itemcount)
        {
            float max = st[0].total;
            int index = 0;
            Console.WriteLine(itemcount);
            if (itemcount >= 2)
            {
                for (int j = 0; j < itemcount - 1; ++j)
                    if (max < st[j + 1].total)
                    {
                        max = st[j + 1].total;
                        index = j + 1;
                    }
            }
            else if (itemcount == 1)
            {
                index = 0;
                max = st[0].total;
            }
            else Console.WriteLine("Not record found!");
            if (index != -1) Console.WriteLine("The student with ID:{0} gets the highest score {1}.", st[index].Person.Id, max);
        }
        //method to show min total score
        public void showmin(Student[] st, int itemcount)
        {
            float min = st[0].total;
            int index = 0;
            if (itemcount >= 2)
            {
                for (int j = 0; j < itemcount - 1; ++j)
                    if (min > st[j + 1].total)
                    {
                        min = st[j + 1].total;
                        index = j + 1;
                    }
            }
            else if (itemcount == 1)
            {
                index = 0;
                min = st[0].total;
            }
            else Console.WriteLine("No record found!");
            if (index != -1) Console.WriteLine("The student with ID:{0} gets the lowest score {1}.", st[index].Person.Id, min);
        }
        //method to find record
        public void find(Student[] st, int itemcount)
        {
            int id;
            Console.Write("Enter student's ID:");
            id = int.Parse(Console.ReadLine());
            int index = search(st, id, itemcount);
            if (index != -1)
            {
                Console.Write("{0,-5}{1,-20}{2,-5}", st[index].Person.Id, st[index].Person.name, st[index].Person.sex);
                Console.Write("{0,-5}{1,-5}{2,-5}", st[index].quizz1, st[index].quizz2, st[index].assigment);
                Console.Write("{0,-5}{1,-5}{2,-5}", st[index].midterm, st[index].final, st[index].total);
                Console.WriteLine();
            }
            else Console.WriteLine("The record doesn't exits.");
        }
        public void bubblesort(Student[] dataset, int n)
        {
            int i, j;
            for (i = 0; i < n; i++)
                for (j = n - 1; j > i; j--)
                    if (dataset[j].total < dataset[j - 1].total)
                    {
                        Student temp = dataset[j];
                        dataset[j] = dataset[j - 1];
                        dataset[j - 1] = temp;
                    }
	}
    } //end the intial student
     // the Teacher class
    class Teacher : Person
  {
      public string teachDept = null;
      public string teachingstage = null;

      public Teacher()
      {
          Console.Write("Enter the Teacher name : ");
          Person.name = Console.ReadLine();

          Console.Write("Enter Teacher's ID:");
          Person.Id = int.Parse(Console.ReadLine());
          //Person.age = age(the student age) 
          Console.Write("Enter Teacher's age:");
          Person.age = int.Parse(Console.ReadLine());
          Age(age);
	  
          Console.Write("Enter Teacher's Sex(F or M):");
          Person.sex = Console.ReadLine().ToString();

          Console.Write("Enter which Department the Teacher's graduated from");
          teachDept = Console.ReadLine().ToString();

          Console.Write("Enter the Teacher's Which class giveing lessons");
          teachingstage = Console.ReadLine().ToString();
      
      }
        public Teacher(string teachId, string teachname, int teachAge, string teachDept, string teachingstage, string teachsex)
        {
            this.Person.Id = teachId;
            this.Person.name = teachname;
            this.Person.age = teachAge;
            this.teachDept = teachDept;
            this.teachingstage = teachingstage;
            this.Person.sex = teachsex;
        }
    }
	 class InitialTeacher
    {
        Teacher[] te = new Teacher[20];
        public int itemcount = 0;
        public void displaymenu()
        {
            Console.WriteLine("======================================================\n                         MENU                         \n======================================================");   
            Console.WriteLine(" 1.Add Teacher records");
            Console.WriteLine(" 2.Delete Teacher records");
            Console.WriteLine(" 3.Update Teacher records");
            Console.WriteLine(" 4.View all Teacher records");
            Console.WriteLine(" 5.Show the Teacher Sex");
            Console.WriteLine(" 6.Show the Teacher Age");
            Console.WriteLine(" 7.Show the Teacher teaching stage");
            Console.WriteLine(" 8.Find a Teacher by ID");
            Console.WriteLine(" 9.Show the Teacher Department");
            Console.WriteLine(" 10.Clean the Teacher information");
            

                //create an array to store only 20 Teachers'records for testing.
                //show menu
                int choice;
                string confirm;

                do
                {
                    Console.Write("Enter your choice(1-8):");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            add( ref itemcount);
                            break;
                        case 2:
                        delete(te, ref itemcount);
                        break;
                      case 3:
                        update(te, itemcount);
                        break;
                      case 4:
                       viewall(te, itemcount);
                        break;
                    case 5:
                        showteachsex(te, itemcount);
                        break;
                    case 6:
                        showteachAge(te, itemcount);
                        break;
                    case 7:
                        showteachingstage(te, itemcount);
                        break;
                    case 8:
                        ID(te, itemcount);
                        break;
                    case 9:
                        showteachDept(te, itemcount);
                        break;
                    case 10:
                        clean(te, itemcount);
                        break;

                        //default: Console.WriteLine("invalid"); break;

                }
                Console.Write("Press y or Y to continue:");
                    confirm = Console.ReadLine().ToString();
                } while (confirm == "y" || confirm == "Y");
        }
        //method add/append a new record
        static int search(Teacher[] te, string id, int itemcount)
        {
            int found = -1;
            for (int i = 0; i < itemcount && found == -1; i++)
            {
                if (te[i].Person.Id == id)
                    found = i;
                else
                    found = -1;
            }
            return found;
        }
	public override int Age(int a)
        {
          if (a < 0)
          {
              a = a * -1;
          }
          else
          {
              if (a < 20 && a > 80)
                  Console.WriteLine("Not allowed !!");
          }
          return a;
      }
		 
      public void add( ref int itemcount)
      {
        Again:
        Console.WriteLine();
        Console.Write("Enter Teacher's ID:");
        Person.Id = Console.ReadLine().ToString();
        if (search(te, teachId, itemcount)!=-1)
        {
            Console.WriteLine("This ID already exists.");
            goto Again;
        }
        Console.Write("Enter Teacher's Name:");
        Person.name = Console.ReadLine();
       
	Console.Write("Enter Teacher's Sex(F or M):");
        Person.sex = Console.ReadLine();
	      
        Console.Write("Enter Teacher's Age:");
	Person.age=int.Parse(Console.ReadLine());
        Age(age);
	      
        Console.Write("Enter student's dept:");
        teachDept = Console.ReadLine();
	      
        Console.Write("Enter student's teaching stage:");
        teachingstage = Console.ReadLine();
	      
        te[itemcount] = new Teacher(Person.Id, Person.name, Person.age, teachDept, teachingstage, Person.sex);
        ++itemcount;
    }
        static void delete(Teacher[] te, ref int itemcount)
        {
            string id;
            int index;
            if (itemcount > 0)
            {
                Console.Write("Enter Teacher's ID:");
                id = Console.ReadLine();
                index = search(te, id.ToString(), itemcount);
                if ((index != -1) && (itemcount != 0))
                {
                    if (index == (itemcount - 1))
                    {
                        clean(te, index);
                        --itemcount;
                        Console.WriteLine("The record was deleted.");
                    }
                    else
                    {
                        for (int i = index; i < itemcount - 1; i++)
                        {
                            te[i] = te[i + 1];
                            clean(te, itemcount);
                            --itemcount;
                        }
                    }
                }
                else Console.WriteLine("The record doesn't exist.Check the ID and try again.");
            }
            else Console.WriteLine("No record to delete");
        }

        static void clean(Teacher[] te, int index)
        {
            te[index].Person.Id = null;
            te[index].Person.name = null;
            te[index].Person.sex = null;
            te[index].Person.age = -1;
            te[index].teachDept = null;
            te[index].teachingstage = null;
        }
       public void update(Teacher[] te, int itemcount)
        {
            string id;
            int column_index;
            Console.Write("Enter Teacher's ID:");
            id = Console.ReadLine();
            Console.WriteLine("1.Name 2.sex 3.Age 4.Dept 5.Stage");
            Console.Write("Which field you want to update(1-5)?:");
            column_index = int.Parse(Console.ReadLine());

            int index = search(te, id.ToString(), itemcount);

            if ((index != -1) && (itemcount != 0))
            {
                if (column_index == 1)
                {
                    Console.Write("Enter Teacher's Name:");

                    te[index].Person.name = Console.ReadLine().ToString();
                }

                else if (column_index == 2)
                {
                    Console.Write("Enter Teacher's Sex(F or M):");
                    te[index].Person.sex = Console.ReadLine().ToString();
                }
                else if (column_index == 3)
                {
                    Console.Write("Enter Teacher's Age:");
                    te[index].Person.age = int.Parse(Console.ReadLine());
                }
                else if (column_index == 4)
                {
                    Console.Write("Enter Teacher's dept:");
                    te[index].teachDept = Console.ReadLine().ToString();
                }
                else if (column_index == 5)
                {
                    Console.Write("Enter Teacher's teaching stage:");
                    te[index].teachingstage = Console.ReadLine().ToString();
                }
            }
            else Console.WriteLine("The record deosn't exits.Check the ID and try again.");
        }
        public static string ID(Teacher[] te, int itemcount)
        {
           
            if (te[itemcount].Person.Id == null)
            {
                Console.WriteLine("there is no teacher has this Id yet !!!");
            }
            return te[itemcount].Person.Id;
        }
        public static string showteachDept(Teacher[] te, int itemcount)
        {
            
            if (te[itemcount].teachDept == null)
            {
                Console.WriteLine("there is no teacher like this yet !!!");
            }
            return te[itemcount].teachDept;
        }

        public static string showteachingstage(Teacher[] te, int itemcount)
        {
          
            if (te[itemcount].teachingstage == null)
            {
                Console.WriteLine("there is no teacher yet !!!");
            }
            return te[itemcount].teachingstage;
        }

        public static int showteachAge(Teacher[] te, int itemcount)
        {
            
            if (te[itemcount].Person.age == -1)
            {
                Console.WriteLine("there is no teacher yet !!!");
            }
            return te[itemcount].Person.age;
        }
        public static string showteachsex(Teacher[] te, int itemcount)
        {
            
            if (te[itemcount].Person.sex == null)
            {
                Console.WriteLine("there is no teacher yet !!!");
            }
            return te[itemcount].Person.sex;
        }
        public void viewall(Teacher[] te, int itemcount)
        {
            int i = 0;
            Console.WriteLine("{0,-5}{1,-20}{2,-5}{3,-5}{4,-5}{5,-5}(column index)", "0", "1", "2", "3", "4", "5");
            Console.WriteLine("{0,-5}{1,-20}{2,-5}{3,-5}{4,-5}{5,-5}", "ID", "NAME", "SEX", "Age", "dept", "stage");
            Console.WriteLine("=====================================================");
            while (i < itemcount)
            {
                if (te[i].teachId != null)
                {
                    Console.Write("{0,-5}{1,-20}{2,-5}", te[i].Person.Id, te[i].Person.name, te[i].Person.sex);
                    Console.Write("{0,-5}{1,-5}{2,-5}", te[i].Person.age, te[i].teachDept, te[i].teachingstage);
                    Console.Write("\n");
                }
                i = i + 1;
            }
        }
		
    } //end the initial student
	// the school info.
    class SchoolInformation  
    {
        // return a string consisting of four or five lines of school infromation

        public static string school = null;
        public static string motto = null;
        public static string colors = null;
        public static string master = null;
        public static int year = 0;
        public SchoolInformation()
        {
            Console.Write("Enter the school name : ");
            school = Console.ReadLine();
            Console.Write("Enter the school motto : ");
            motto = Console.ReadLine();
            Console.Write("Enter the school Uniforms Colors : ");
            colors = Console.ReadLine();
            Console.Write("Enter the school master name : ");
            master = Console.ReadLine();
            Console.Write("Enter The school first year was established : ");
            year =int.Parse (Console.ReadLine());
            SchoolInformation.PrintSchoolInformation();
        }
       
        public SchoolInformation(string school, string motto, string colors, string master,int year)
        {
            SchoolInformation.school = school;
            SchoolInformation.motto = motto;
            SchoolInformation.colors = colors;
            SchoolInformation.master = master;
            SchoolInformation.year = year;
            SchoolInformation.PrintSchoolInformation();
        }
        public static void PrintSchoolInformation()
        {
            string information = "\n\n" + "#  The Schoole Name:  " + school + 
"\n" +
                                 "#  The SchooleMotto:         " + motto + "\n" 
+
                                 "#  The Schoole Uniforms Colors: " + colors + 
"\n" +
                                 "#  The School First Year was established : " +
year +"\n"+
                                 "#  The School Master: " + master;
            Console.WriteLine(information);
        }
    }	
    class Program
    {
        static void Main(string[] args)
        {
            SchoolInformation school = new SchoolInformation();
            SchoolInformation.PrintSchoolInformation();
            Student s1 = new Student();
            Initial I1 = new Intial();
            I1.displaymenu();
            InitialTeacher I1T=new IntialTeacher();
            I1T.displaymenu(); 
            Console.ReadKey();
        }
    }
}
