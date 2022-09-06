using System;
using System.Collections.ObjectModel;



public class Video78Custom: IComparer<Video78>
{
    //IComparer ke liye Compare method necessary hai, yeh hum tab use karte hain jab hum access na ho dusri class ki implementation pe
    // tou hum dosri class banake uska object lete
    public int Compare(Video78 v78, Video78 v78_2)
    {
        return v78.Name.CompareTo(v78_2.Name);
    }
}
public class Video78: IComparable<Video78>
{
    //Icomparable ko chalane ke liye CompareTo method implement karna hoga
    public int Salary { get; set; }
    public int Rollno { get; set; }
    public string Name { get; set; }
    public int CompareTo(Video78 check)
    {
        if(this.Salary > check.Salary)
        {
            return 1;
        }
        else if (this.Salary < check.Salary)
        {
            return -1;
        }
        else
        {
            return 0;
        }
        // return this.Name.CompareTo(check.Name)
        // return this.Salary.CompareTo(check.Salary)
        //We can use this one statement to do comparison because salary is of type int and int has compareto in it implemented
    }
}


class Training_Practice
{
    public static void Video72()
    {
        Video78 v78_1 = new Video78()
        {
            Salary = 200,
            Name = "Aubrey",
            Rollno = 121
        };
        Video78 v78_2 = new Video78()
        {
            Salary = 100,
            Name = "Zack",
            Rollno = 125
        };
        Video78 v78_3 = new Video78()
        {
            Salary = 500,
            Name = "Mark",
            Rollno = 128
        };

        //<key,value>
        Dictionary<int, Video78> TeachersDictionary = new Dictionary<int, Video78>();
        TeachersDictionary.Add(v78_1.Rollno,v78_1);
        TeachersDictionary.Add(v78_2.Rollno, v78_2);
        if (!TeachersDictionary.ContainsKey(v78_3.Rollno)) 
        {
            TeachersDictionary.Add(v78_3.Rollno, v78_3);
        }
        
        //keys must be unique in dictionary
        // key value types must be defined
        
        Video78 results=TeachersDictionary[128];
        Console.WriteLine("Teacher Name:{0} && Teacher ID:{1} && Teacher Salary:{2}",results.Name,results.Rollno,results.Salary);
        
        // we can use var kvp instead of keyvaluepair but less readable.
        foreach(KeyValuePair<int, Video78> kvp in TeachersDictionary)
        {
            Console.WriteLine("ID={0}",kvp.Key);
            Video78 v78=kvp.Value;
            Console.WriteLine("Teacher Name:{0} && Teacher ID:{1} && Teacher Salary:{2}",v78.Name,v78.Rollno,v78.Salary);
            Console.WriteLine("------------------------------------------------------------");
        }


        ///////////////////////////////////////73////////////////////////////////////////
        /// we can try to check for a key that youre not sure it exists to avoid exception we try trygetvalue we will get value as return
        Console.WriteLine("\n Video 73: \n");
        Video78 v78_v73;
        if(TeachersDictionary.TryGetValue(128, out v78_v73))
        {
            Console.WriteLine("Teacher Name:{0} && Teacher ID:{1} && Teacher Salary:{2}",v78_v73.Name,v78_v73.Rollno,v78_v73.Salary);
        }
        else
        {
            Console.WriteLine("Key not found");
        }

        Console.WriteLine("\n Total entries in Teachers Dictionary:{0}",TeachersDictionary.Count);
        //count is overloaded in linq class
        Console.WriteLine("Total entries in Teachers Dictionary with salary above 100:  {0}", TeachersDictionary.Count(kvp=>kvp.Value.Salary>100));

        TeachersDictionary.Remove(111);
        //if key doesnt exist for removing no error
        //TeachersDictionary.Clear();
        
        //we can convert array/List into dist
        Video78[] ListTeachers = new Video78[3];
        ListTeachers[0] = v78_1;
        ListTeachers[1] = v78_2;
        ListTeachers[2] = v78_3;

        Dictionary<int, Video78> dict = ListTeachers.ToDictionary(cust => cust.Rollno, cust => cust);
        foreach(KeyValuePair<int,Video78> kvp in dict)
        {
            Console.WriteLine("ID={0}", kvp.Key);
            Video78 v78 = kvp.Value;
            Console.WriteLine("Teacher Name:{0} && Teacher ID:{1} && Teacher Salary:{2}", v78.Name, v78.Rollno, v78.Salary);
            Console.WriteLine("------------------------------------------------------------");
        }

        /////////////////////////////////74-builtin list functions//////////////////////////////////////////////////
        List<Video78> list = new List<Video78>();
        list.Add(v78_1);
        list.Add(v78_2);

        //Insert function
        list.Insert(0,v78_3);
        //IndexOf function
        Console.WriteLine("This object is present at index:{0}",list.IndexOf(v78_3));
        //IndexOf(element,start search from,number of elements you want to look)
        
        //Contains function
        //in exists function you will to have to give predicate(condition)
        if (list.Contains(v78_1))
        {
            Console.WriteLine("List contains item: {0}", v78_1);

        }
        else
        {
            Console.WriteLine("List does not contains item: {0}", v78_1);
        }

        //Exists functions
        if (list.Exists(cust=>cust.Name.StartsWith("Z")))
        {
            Console.WriteLine("List contains item Starting with Z");

        }
        else
        {
            Console.WriteLine("List does not contains item Starting with Z");
        }
        //find function, returns the first matching item
        Video78 v78_v75 = list.Find(cust => cust.Rollno > 122);
        Console.WriteLine("Teacher Name:{0} && Teacher ID:{1} && Teacher Salary:{2}", v78_v75.Name, v78_v75.Rollno, v78_v75.Salary);
        
        //findLast functions, return the last matching item
        Video78 v78_v75_2 = list.FindLast(cust => cust.Rollno > 102);
        Console.WriteLine("Teacher Name:{0} && Teacher ID:{1} && Teacher Salary:{2}", v78_v75_2.Name, v78_v75_2.Rollno, v78_v75_2.Salary);

        //findall functions, returns all matching items
        List<Video78> v78_v75_3 = list.FindAll(cust => cust.Rollno > 102);
        Console.WriteLine();
        foreach(Video78 v78 in v78_v75_3)
        {
            Console.WriteLine("Teacher Name:{0} && Teacher ID:{1} && Teacher Salary:{2}", v78.Name, v78.Rollno, v78.Salary);

        }
        Console.WriteLine();        
        Console.WriteLine();        
        Console.WriteLine();
        //findindex, returns the first matching index
        // we can also indicate from which index you want to start looking
        int index=list.FindIndex(cust => cust.Rollno > 102);
        Console.WriteLine("First Index is:{0}", index);
        //findlastindex, return the last matching index
        int index2 = list.FindLastIndex(cust => cust.Rollno > 102);
        Console.WriteLine("Last Index is:{0}", index);

        //ToList function- can convert an array into list
        Video78[] v78Array = new Video78[3];
        v78Array[0] = v78_1;
        v78Array[1] = v78_2;
        v78Array[2] = v78_3;
        List<Video78> v78list = v78Array.ToList();

        foreach(Video78 v78 in v78list)
        {
            Console.WriteLine("\n ID:{0} & Name:{1}",v78.Rollno,v78.Name);
        }
        //vice versa can happen with toarray() function
        //similarly we can convert them into dictionary with toDictionary().


    }



    public static int Video79Comparer(Video78 v78_1,Video78 v78_2)
    {
        return v78_1.Rollno.CompareTo(v78_2.Rollno);
    }
   
    public static void Video78Invoker()
    {
        Video78 v78_1 = new Video78()
        {
            Salary = 200,
            Name = "Aubrey",
            Rollno = 121
        };
        Video78 v78_2 = new Video78()
        {
            Salary = 100,
            Name = "Zack",
            Rollno = 122
        };
        Video78 v78_3 = new Video78()
        {
            Salary = 500,
            Name = "Mark",
            Rollno = 123
        };
        List<Video78> ListTeachers = new List<Video78>(40);
        ListTeachers.Add(v78_1);
        ListTeachers.Add(v78_2);
        ListTeachers.Add(v78_3);


        foreach (Video78 v78 in ListTeachers)
        {
            Console.WriteLine("Salary:{0}", v78.Salary);
        }
        ListTeachers.Sort();
        Console.WriteLine("Salary after sorting \n \n");
        foreach (Video78 v78 in ListTeachers)
        {
            Console.WriteLine("Salary:{0}", v78.Salary);
        }

        Video78Custom video78C = new Video78Custom();
        
        ListTeachers.Sort(video78C);
        //Icomparer object in above statement

        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        foreach (Video78 v78 in ListTeachers)
        {
            Console.WriteLine("Sorted by: Name{1} && Salary:{0}", v78.Salary, v78.Name);
        }
        ///////////////////////////////79////////////////////////////
        Console.WriteLine();
        Console.WriteLine();
        //First Create a function with delegate signature then create an instance and then pass delegate in .sort of a list
        Comparison<Video78> CustomComparer = new Comparison<Video78>(Video79Comparer);
        Console.WriteLine("Before Comparing by Customer field \n");
        foreach(Video78 v78 in ListTeachers)
        {
            Console.WriteLine(v78.Rollno);
        }
        ListTeachers.Sort(CustomComparer);
        Console.WriteLine("AFter Comparing by Customer field \n");
        foreach (Video78 v78 in ListTeachers)
        {
            Console.WriteLine(v78.Rollno);
        }
        /////////////////////////////////80/////////////////////////////////////////
        Console.WriteLine("Video80 \n");


        ReadOnlyCollection<Video78> Readonlyvideo78 = ListTeachers.AsReadOnly();
        //after this we can only retrieve an item but we cannot modify or remove an item;

        Console.WriteLine("Are all salaries greater than 100");
        Console.WriteLine(ListTeachers.TrueForAll(x => x.Salary >= 100));

        Console.WriteLine("Capacity Before Triming" + ListTeachers.Capacity);
        ListTeachers.TrimExcess();
        Console.WriteLine("and Capacity After Triming" + ListTeachers.Capacity);
        //if list is 90 percent full then trim will do nothing because according msdn if a list is 90% it shouldnt be trimmed

    }

    public static void Video77()
    {
        /////////////////////////////77////////////////////////////////////
        List<int> numbers = new List<int>() { 1, 8, 7, 2, 3, 4, 5, 6 };
        Console.WriteLine("Numbers Before Sorting:\n ", numbers);
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        numbers.Sort();
        Console.WriteLine("Numbers after Sorting Descending Order \n");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        numbers.Reverse();
        Console.WriteLine("Numbers after sorting Reverse Order \n");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        //integer/strings has Icomparable interface which compares integers/strings which are simple types
        //However complex types dont have that so we'll have to implement them by using Icomparable interface
    }
    public static void Video75()
    {
        List<int> T1 = new List<int>();
        T1.Add(1);
        T1.Add(2);
        T1.Add(3);
        List<int> T2 = new List<int>();

        T2.Add(4);
        T2.Add(5);
        T2.Add(6);

        T1.AddRange(T2);

        Console.WriteLine("First list with added range: \n");
        foreach (int a in T1)
        {
            Console.WriteLine("{0}",a);
        }
        
        //list has getrange to get range of items from GetRange(starting point, how many points)
        List<int> T3 = T1.GetRange(0,2);

        Console.WriteLine("Insert Range Function\n\n");
        //instead of inserting one item at a time we can add multiple items
        T1.InsertRange(0,T3);
        foreach (int a in T1)
        {
            Console.WriteLine("{0}", a);
        }
        //Removeat removes one item at a time
        Console.WriteLine("Removing 1 from list\n");
        T1.Remove(1);
        foreach (int a in T1)
        {
            Console.WriteLine("\n{0}", a);
        }
        //RemoveAt
        T1.RemoveAt(0);
        Console.WriteLine("Removing using removeat");
        foreach (int a in T1)
        {
            Console.WriteLine("\n{0}", a);
        }

        //RemoveRange
        Console.WriteLine("Removing using RemoveRange\n");
        T1.RemoveRange(0, 2);
        //Remove Range(start at, how many items to remove)
    }
    public class Video81
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Capital { get; set; }
    }
    public static void Video83()
    {
        Video81 C1 = new Video81() { Code = "AUS", Name = "Äustralia", Capital = "Canberra" };
        Video81 C2 = new Video81() { Code = "IND", Name = "India", Capital = "New Delhi" };
        Video81 C3 = new Video81() { Code = "PAK", Name = "Pakistan", Capital = "Islamabad" };
        Video81 C4 = new Video81() { Code = "CAD", Name = "Canada", Capital = "Ottawa" };
        Video81 C5 = new Video81() { Code = "USA", Name = "United", Capital = "Washington" };

        Stack<Video81> stack_v81 = new Stack<Video81>();
        stack_v81.Push(C1);
        stack_v81.Push(C2);
        stack_v81.Push(C3);
        stack_v81.Push(C4);
        stack_v81.Push(C5);

        stack_v81.Pop();

        stack_v81.Peek();

        stack_v81.Contains(C1);
    }
    public static void Video82()
    {
        Video81 C1 = new Video81() { Code = "AUS", Name = "Äustralia", Capital = "Canberra" };
        Video81 C2 = new Video81() { Code = "IND", Name = "India", Capital = "New Delhi" };
        Video81 C3 = new Video81() { Code = "PAK", Name = "Pakistan", Capital = "Islamabad" };
        Video81 C4 = new Video81() { Code = "CAD", Name = "Canada", Capital = "Ottawa" };
        Video81 C5 = new Video81() { Code = "USA", Name = "United", Capital = "Washington" };

        Queue<Video81> Queue_v82 = new Queue<Video81>();
        Queue_v82.Enqueue(C1);
        Queue_v82.Enqueue(C2);
        Queue_v82.Enqueue(C3);
        Queue_v82.Enqueue(C4);
        Queue_v82.Enqueue(C5);
        //will add an object at the end of a queue

        Queue_v82.Dequeue();
        Queue_v82.Dequeue();
        //will remove an object from the bottom of the que and return it.
        foreach(Video81 v in Queue_v82)
        {
            Console.WriteLine("Name:{0} && Code:{1}",v.Name,v.Code);
            Console.WriteLine("Items in Queue:{0} \n",Queue_v82.Count());
        }
        // we can use peek to view the object at the beginning of the queue and it wont remove the first object
        Console.WriteLine(Queue_v82.Peek().Name);
        Console.WriteLine(Queue_v82.Contains(C1));


    }
    static void Video81InvokerDict()
    {
        Video81 C1 = new Video81() { Code = "AUS", Name = "Äustralia", Capital = "Canberra" };
        Video81 C2 = new Video81() { Code = "IND", Name = "India", Capital = "New Delhi" };
        Video81 C3 = new Video81() { Code = "PAK", Name = "Pakistan", Capital = "Islamabad" };
        Video81 C4 = new Video81() { Code = "CAD", Name = "Canada", Capital = "Ottawa" };
        Video81 C5 = new Video81() { Code = "USA", Name = "United", Capital = "Washington" };

        Dictionary<string, Video81> dict = new Dictionary<string, Video81>();
        dict.Add(C1.Code,C1);
        dict.Add(C2.Code, C2);
        dict.Add(C3.Code, C3);
        dict.Add(C4.Code, C4);
        dict.Add(C5.Code, C5);

        string UserInput=string.Empty;
        do
        {
            Console.WriteLine("Enter the Country Code:");
            string U_input = Console.ReadLine().ToUpper();
            Video81 v81=dict.ContainsKey(U_input) ? dict[U_input] : null;
            if (v81 == null)
            {
                Console.WriteLine("Country Not found");
            }
            else
            {
                Console.WriteLine("Country Name:{0} && Coúntry Capital:{1}", v81.Name, v81.Capital);
            }
            do
            {
                Console.WriteLine("Do you want to continue? Yes or no");
                UserInput= Console.ReadLine().ToUpper();
            }while(UserInput!="NO" && UserInput!="YES");
                 
            

        } while (UserInput=="YES");

    }
    static void Video81Invoker()
    {
        Video81 C1 = new Video81() {Code="AUS",Name="Äustralia",Capital="Canberra"};
        Video81 C2 = new Video81() {Code="IND",Name="India",Capital="New Delhi"};
        Video81 C3 = new Video81() {Code="PAK",Name="Pakistan",Capital="Islamabad"};
        Video81 C4 = new Video81() {Code="CAD",Name="Canada",Capital="Ottawa"};
        Video81 C5 = new Video81() {Code="USA",Name="United",Capital="Washington"};

        List<Video81> CountryList = new List<Video81>();
        CountryList.Add(C1);
        CountryList.Add(C2);
        CountryList.Add(C3);
        CountryList.Add(C4);
        CountryList.Add(C5);
        int? i1=null;
        do
        {
            Console.WriteLine("Enter the Country Code:");
            string U_input = Console.ReadLine().ToUpper();

            Video81 User_Results = CountryList.Find(country => country.Code == U_input);

            if (User_Results != null)
            {
                Console.WriteLine("Country Name:{0} && Coúntry Capital:{1}", User_Results.Name, User_Results.Capital);
            }
            else
            {
                Console.WriteLine("Country Not found");
                Console.WriteLine("Do you want to continue");
      
                i1 = int.Parse(Console.ReadLine());
                //tryparse isliye use karte incase nahi convert hota tou error de warna explicit mein data loss hojata
                /* 
                 do{
                i1=Console.ReadLine().ToUpper();
                }while(i1==yes);
                 */
            }
        } while (i1 == 1);
    }
    static void Main()
    {
        Video82();
        //Video81InvokerDict();
        //Video81Invoker();
        //Video72();
        //Video75();
        //Video77();
        //Video78Invoker();
    }    

}

