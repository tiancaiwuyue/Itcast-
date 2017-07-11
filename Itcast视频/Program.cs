using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using System.Timers;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using ClassLibrary1;

namespace Itcast视频
{
    class Program
    {
        static void Main(string[] args)
        {













            #region 可空值类型
            //向数据库中插入null值，不能直接使用c#的null，必须使用DBNuallValue
            //string name = textBox1.Text;
            //int age = Convert.ToInt32(textBox2.Text.Trim());
            //int? height = textBox3.Text.Trim().Length == 0 ? null : (int?)Convert.ToInt32(textBox3.Text.Trim());//三元运算符要求冒号两边数据类型兼容
            //bool? gender = textBox4.Text.Trim().Length == 0 ? null : (bool?)Convert.ToBoolean(textBox4.Text.Trim());
            //string sql = "insert into TblPerson values (@name,@age,@height,@gender)";
            //SqlParameter[] pms = new SqlParameter[] {new SqlParameter("@name", SqlDbType.NVarChar, 50) { Value=name},
            //new SqlParameter("@age", SqlDbType.Int) { Value=age},
            //new SqlParameter("@height", SqlDbType.Int) { Value=height==null?DBNull.Value:(object)height},   //向数据库中插入null值，不能直接使用c#的null，必须使用DBNuallValue
            //new SqlParameter("@gender", SqlDbType.Bit) { Value=gender}};
            //SQLHelper.ExecuteNonQuery(sql, pms);
            //MessageBox.Show("插入成功");
            #endregion
            #region 使用带参数sql语句时的一个问题
            //string sql = "insert into TblPerson values (@name,@age,@height,@gender)";
            //SqlParameter[] pms = new SqlParameter[]
            //{
            //    new SqlParameter("@name","王海山"),
            //    //不推荐这样写，因为比如下面这个，它调用的是SqlDbType的枚举类，“0”表示BigInt这样后面Value又没给值，所以报错。
            //    //new SqlParameter("@age",0),
            //    new SqlParameter("@age",SqlDbType.Int){Value=0 },
            //    new SqlParameter("@height",180),
            //    new SqlParameter("@gender",true)
            //};
            //SQLHelper.ExecuteNonQuery(sql, pms);
            //Console.WriteLine("ok");
            //Console.ReadKey();
            #endregion
        }
        //AA aObj = new AA();
        //DD dObj = new DD();
        //BB bObj = new BB();
        //Console.WriteLine(aObj.DelegateA(bObj));
        //Console.ReadKey();




        #region 自己创建一个Dataset和DataTable
        ////DataSet就是一个集合，内存数据库，临时数据库。
        //DataSet ds = new DataSet("School");

        ////2.创建一张表
        //DataTable dt = new DataTable("Student");

        ////2.1向dt表中创建一些列
        //DataColumn dcAutoId = new DataColumn("AutoID",typeof(int));
        ////设置列为自动编号
        //dcAutoId.AutoIncrement = true;
        //dcAutoId.AutoIncrementSeed = 1;
        //dcAutoId.AutoIncrementStep = 1;
        ////把dcAutoId列加到表中
        //dt.Columns.Add(dcAutoId);

        ////增加一个姓名列
        //DataColumn dcUserName=dt.Columns.Add("UserName", typeof(string));
        ////设置列不允许为空
        //dcUserName.AllowDBNull = false;

        ////增加一个年龄列
        //dt.Columns.Add("UserAge", typeof(int));

        ////----------向dt表中增加一些行数据
        ////创建一个行对象
        //DataRow dr1 = dt.NewRow();//根据表的结构来创建，它构造函数为internal所以用属性创建
        //dr1["UserName"] = "我的朋友";
        //dr1["UserAge"] =21;
        ////把该行对象增加到dt中
        //dt.Rows.Add(dr1);

        ////--再增加一行
        //DataRow dr2 = dt.NewRow();
        //dr2["UserName"] = "碰碰";
        //dr2["UserAge"] = 33;
        //dt.Rows.Add(dr2);

        ////3.把dt加到ds中。
        //ds.Tables.Add(dt);
        //Console.WriteLine("----------遍历表中的数据---------");
        ////1.遍历DataSet中的每张表
        //for (int i = 0; i < ds.Tables.Count; i++)
        //{
        //    //输出每个表的表名
        //    Console.WriteLine("表名：{0}",ds.Tables[i].TableName);
        //    //遍历表中的每一行
        //    for (int r = 0; r < ds.Tables[i].Rows.Count; r++)
        //    {
        //        //获取每一行
        //        DataRow currentRow = ds.Tables[i].Rows[r];
        //        //输出当前行中的每一列
        //        for (int c = 0; c < ds.Tables[i].Columns.Count; c++)
        //        {
        //            Console.Write(currentRow[c].ToString()+"    |    ");
        //        }
        //        Console.WriteLine();
        //    }
        //}

        //Console.WriteLine("ok");
        //Console.ReadKey();


        #endregion
        #region 启用Ado.net连接池效果
        //string constr = "Data Source=localhost;initial catalog=myfirstdatabase;integrated security=true";
        ////默认情况下.net启用了连接池
        ////默认情况下ado.net连接池是被启用的
        //Stopwatch watch = new Stopwatch();
        //watch.Start();
        //for (int i = 0; i < 1000; i++)
        //{
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        con.Open();
        //        con.Close();//当启用Ado.net连接池后，调用con.Close()方法并不会关闭连接，而是把当前连接对象放入到连接池中。
        //    }
        //}
        //watch.Stop();
        //Console.WriteLine(watch.Elapsed);
        //Console.ReadKey(); 
        #endregion
        #region 禁用Ado.net连接池效果
        //string constr = "Data Source=localhost;initial catalog=myfirstdatabase;integrated security=true;Pooling=false";
        ////默认情况下.net启用了连接池
        ////默认情况下ado.net连接池是被启用的
        //Stopwatch watch = new Stopwatch();
        //watch.Start();
        //for (int i = 0; i < 1000; i++)
        //{
        //    using (SqlConnection con = new SqlConnection(constr))
        //    {
        //        con.Open();
        //    }
        //}
        //watch.Stop();
        //Console.WriteLine(watch.Elapsed);
        //Console.ReadKey();
        #endregion
        #region 强类型直接转换
        //string constr = "Data Source=localhost;initial catalog=myfirstdatabase;integrated security=true";
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    string str = "select * from tblstudent";
        //    using (SqlCommand com = new SqlCommand(str, con))
        //    {
        //        con.Open();
        //        using (SqlDataReader reader = com.ExecuteReader())
        //        {
        //            if (reader.HasRows)
        //            {
        //                //注意：通过reader.GetXxxxx()方式来获取表中的数据，如果数据为null那么就报异常了。此时需要手动写代码来判断数据是否为null。
        //                while (reader.Read())
        //                {
        //                    Console.Write(reader.GetInt32(0)+"\t");
        //                    Console.Write(reader.GetString(1) + "\t");
        //                    Console.Write(reader.IsDBNull(2)?"NULL\t":reader.GetString(2)+ "\t");
        //                    //Console.Write(reader.GetString(2) + "\t");
        //                    Console.WriteLine();
        //                }
        //            }
        //        }
        //    }
        //    Console.ReadKey();
        //}
        #endregion
        #region 通过调用ExecuteReader方法获取多行多列数据
        //string constr = "Data Source=localhost;initial catalog=myfirstdatabase;integrated security=true";
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    string str = "select * from tblstudent";
        //    using (SqlCommand com = new SqlCommand(str, con))
        //    {
        //        con.Open();
        //        //通过调用ExecuteReader方法，将给定的sql语句在服务器上执行。
        //        //执行完毕后，服务器端就已经查询出了数据。但是数据是保存在数据库服务器的内存当中。并没有返回给应用程序。只是返回给应用程序一个reader对象，这个对象就是用来获取数据的对象。
        //        using (SqlDataReader reader = com.ExecuteReader())
        //        {
        //            //接下来就要通过reader对象一条一条获取数据
        //            //1.在获取数据之前，先判断一下本次执行查询后，是否查询到了数据。
        //            if (reader.HasRows)
        //            {
        //                //2.如果有数据，那么接下来就要一条一条获取数据（只能一条条获取，一次只能取一条）
        //                //每次获取数据之前，都要先调用reader.read()方法，向后移动一条数据，如果成功移动到了某条数据上，则返回true，否则返回false
        //                while (reader.Read())
        //                {
        //                    //当遇到数据库中的null值的时候，通过reader.getvalue()或者reader[]索引器来获取列的值，拿到的时DBNull.Value，不是C#的null。而DBNull.Value的ToString()方法返回的是空字符串，所以最终并没有报错。
        //                    //获取当前reader指向的数据
        //                    //reader.FieldCount：可以获取当前查询语句!查询出的!列的个数
        //                    for (int i = 0; i < reader.FieldCount; i++)
        //                    {
        //                        //但是通过reader[]索引器，可以使用列名来获取列的值。先调的GetOrdinal(name)通过列的名称获取列的序号，再调GetValue
        //                        //Console.Write(reader[i].ToString().PadRightWhileDouble(12,'a')+"|");//通过索引器实际就时调GetValue函数
        //                        Console.WriteLine(reader["tSID"]);

        //                        //GetValue()只能通过列索引来获取列的值
        //                        //Console.Write(reader.GetValue(i) + "|");

        //                        //通过下面这种方式，读取到的数据直接就是对于的类型，不是object类型。使用起来更方便。
        //                        //reader.Getxxxx();//使用强类型读取列中的数据。
        //                    }
        //                    Console.WriteLine();
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("没有查询到任何数据");
        //            }
        //        }
        //    }
        //    Console.ReadKey();
        //}
        #endregion
        #region 查询出表中的记录条数
        //1.连接字符串
        //string constr = "Data Source=localhost;initial catalog=myfirstdatabase;integrated security=true";
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    string str = "select count(*) from tblstudent";
        //    using (SqlCommand com=new SqlCommand(str,con))
        //    {
        //        con.Open();
        //        //注意：当sql语句执行的时候，如果是聚合函数，那么ExecuteScalar()返回的不可能是null，因为聚合函数不会返回null,但是如果sql语句使用的不是聚合函数，那么ExecuteScalar()方法是有可能返回null的，那么再使用count变量的时候就需要先判断是否为null了。
        //        //object count = (int)cmd.ExecuteScalar(); //这样为拆箱，如果装箱的时候用的不是int装的箱，那么拆箱的时候就会报异常。
        //        //object count = Convert.ToInt32(cmd.ExecuteScalar());//不会
        //        object get=com.ExecuteScalar();
        //        Console.WriteLine(get.ToString());   
        //    }
        //    Console.ReadKey();
        //}
        #endregion
        #region 更新一条数据
        //string constr = "data source=localhost;initial catalog=Myfirstdatabase;integrated security=true";
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    string str = "update tblstudent set tsname='朋友1' where tsname='朋友'";
        //    using (SqlCommand cmd = new SqlCommand(str, con))
        //    {
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //}
        //Console.ReadKey();
        #endregion
        #region 删除一条数据
        ////1.连接字符串
        //string constr = "data source=localhost;initial catalog=Myfirstdatabase;integrated security=True";
        ////2.连接对象
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    //3.sql语句
        //    string del = "delete from tblstudent where tsname='朋友1'";
        //    //4.创建sqlCommand对象
        //    using (SqlCommand com=new SqlCommand(del,con))
        //    {
        //        //5.打开连接
        //        con.Open();
        //        //6.执行
        //        com.ExecuteNonQuery();
        //    }
        //}
        #endregion
        #region 通过ado.net向表中插入一条数据
        ////1.连接字符串.服务器上-默认实例-数据库
        //string constr = "Data Source=localhost;Initial catalog=Myfirstdatabase;integrated security=true";
        ////2.创建连接对象
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    //3.打开连接--其实不用这么早，再执行sql语句的时候再打开，打开后立刻关闭
        //    //con.Open();
        //    //4.编写sql语句
        //    string sql = "insert into tblstudent values('朋友1','女','dr',8,'1993-3-3',222,333)";
        //    //5.创建一个执行sql语句的对象（命令对象）sqlcommand
        //    using (SqlCommand cmd = new SqlCommand(sql, con))
        //    {
        //        //5.或者默认构造函数然后使用以下命令
        //        //cmd.commandtext=sql;
        //        //cmd.connection=con;

        //        //6.开始执行sql语句
        //        //（3.打开连接）
        //        con.Open();
        //        Console.WriteLine("连接成功");
        //        int r = cmd.ExecuteNonQuery();
        //        Console.WriteLine("成功插入了{0}行数据", r);
        //        //ExecuteNonQuery()这个方法有一个返回值是int类型，表示执行insert\delete\update后所影响的行数。特别注意：只有执行insert\delete\update语句的时候会返回所影响的行数，执行任何其他sql语句永远返回-1
        //        //cmd.ExecuteNonQuery();//insert\delete\update语句时。
        //        //cmd.ExecuteScalar();//当执行返回单个结果（一行一列）的时候。
        //        //cmd.ExecuteReader();//当查询出多行，多列结果的时候
        //    }
        //}
        //Console.ReadKey();
        #endregion
        #region 用委托实现的音乐播放器
        ////MusicPlayer mp3 = new MusicPlayer();
        ////mp3.AfterStartedPlay = () =>
        ////{
        ////    Console.WriteLine("加载歌词!");
        ////    Console.WriteLine("加载动感背景！");
        ////};
        ////mp3.StartPlay();
        ////mp3.BeforeMusicStop = () =>
        ////{
        ////    Console.WriteLine("删除歌词!");
        ////};
        ////mp3.EndMusic();
        ////Console.ReadKey();
        //#endregion
        //#region 用事件实现的音乐播放器
        ////MusicPlayer mp3 = new MusicPlayer();
        ////mp3.AfterStartedPlay += new Action(mp3_AfterStartedPlay);
        ////mp3.BeforeMusicStop += new Action(mp3_BeforeMusicStop);
        ////mp3.StartPlay();
        ////mp3.EndMusic();
        //////mp3.AfterStartedPlay();//事件在外部不能直接调用
        //////事件只能在定义事件的类的内部来出发
        //////事件是一个私有的委托和两个公有的方法
        ////Console.ReadKey();
        //#endregion
        //#region Type类型简单介绍
        //////1.怎么获取一个类型的Type（该类型的类型元数据）
        ////MyClass m = new MyClass();
        ////Type type1 = m.GetType();//获得了类型的MyClass对应的Type
        ////Type type2 = typeof(MyClass);//通过typeof关键字，无需获取MyClass类型的对象就可以拿到MyClass的Type对象。
        //////拿到这个Type能干啥？
        ////Type typeMyClass = typeof(MyClass);
        //////1.可以获取当前类型的父类是谁？
        ////Console.WriteLine(typeMyClass.BaseType.ToString());
        ////2.获取当前类型中的所有字段/属性信息
        //////这里只能获取非私有字段，如果要想获取私有字段需要采取其他方法。
        ////FieldInfo[] fields =typeMyClass.GetFields();
        ////for (int i = 0; i<fields.Length;i++)
        ////{
        ////    Console.WriteLine(fields[i].Name);
        ////}
        //////属性
        ////PropertyInfo[] infos = typeMyClass.GetProperties();
        ////foreach (var item in infos)
        ////{
        ////    Console.WriteLine(item.Name);
        ////}
        //#endregion
        //#region 动态加载程序集并且调用类型的成员
        ////根据程序的路径，动态加载一个程序集
        //Assembly asm = Assembly.LoadFile(@"C:\Users\May\Documents\visual studio 2017\Projects\Itcast视频\ClassLibrary1\bin\Debug\ClassLibrary1.dll");
        ////1.1获取该程序集中的所有类型。
        ////Type[] types = asm.GetTypes();
        ////for (int i = 0; i < types.Length; i++)
        ////{
        ////    Console.WriteLine(types[i].FullName);
        ////}
        ////1.2获取所有的public的类型
        //Type[] types = asm.GetExportedTypes();
        //for (int i = 0; i < types.Length; i++)
        //{
        //    Console.WriteLine(types[i].FullName);
        //}

        ////1.3 获取指定类型
        ////获取Person类型的Type
        //Type typePerson = asm.GetType("ClassLibrary1.Class1+Person");

        ////2.获取某个类型中的成员，调用
        ////2.1调用Person类中的方法：
        ////2.2调用SayHello方法
        ////MethodInfo method = typePerson.GetMethod("SayHello");
        //////创建一个Person类型的对象
        //////根据制定的Type，创建一个该类型的对象。
        ////object obj = Activator.CreateInstance(typePerson);
        //////调用该方法
        ////method.Invoke(obj, null);
        ////==============调用SayHi的无参数的重载=============
        ////MethodInfo method = typePerson.GetMethod("SayHi",new Type[] { });
        ////调用重载就是通过第二个Type[]参数来区分是调用的哪个方法。
        ////MethodInfo method = typePerson.GetMethod("SayHi", new Type[] { typeof(string)});
        ////调用该重载方法
        ////object obj = Activator.CreateInstance(typePerson);
        ////method.Invoke(obj, new object[] { "大家好"});
        ////如果方法有返回值得化，直接接受Invoke()方法的返回值就可以了。

        ////通过Type来创建对象
        ////1.根据Person的Type创建一个Person的对象
        ////typePerson.GetMethod().GetParameters()[0].ParameterType
        ////object obj = Activator.CreateInstance(typePerson);
        ////通过调用指定的构造函数来创建对象。
        //ConstructorInfo info = typePerson.GetConstructor(new Type[] { typeof(string) });
        //object obj= info.Invoke(new object[] { "朋友" });
        ////通过反射获取指定对象的属性的值
        //PropertyInfo pinfo = typePerson.GetProperty("Name");
        //string name = pinfo.GetValue(obj, null).ToString();
        //Console.WriteLine(name);
        #endregion
        #region 如何打开连接
        ////连接数据库的步骤：
        ////1.创建连接字符串
        ////Data Source=地址     连接到哪个服务器
        ////Initial Catalog=数据库名  连接哪个数据库
        ////Integrated Security=true   Windows连接方式为true
        //string constr = "Data Source=localhost;initial catalog=MyfirstDatabase;Integrated Security=true";
        ////用用户名密码方式连接
        ////string constr = "Data Source=localhost;initial catalog=MyfirstDatabase;UserId=sa;Password=123";
        ////server=.;database=Myfirstdatabase;uid=sa;pwd=123
        ////2.创建连接对象
        ////using=try finally 在finally里调用dispose
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    //测试打开连接
        //    //3.打开连接（如果打开数据连接没有问题，表示连接成功！~）
        //    con.Open();
        //    Console.WriteLine("打开连接成功-");
        //    //4.关闭连接，释放资源
        //    //con.Close();在dispose中已经调用close，
        //    //con.Dispose(); 在using下已经调用dispose
        //}
        //Console.WriteLine("close connection,release the resource");
        //Console.ReadKey();
        #endregion


        private static void mp3_BeforeMusicStop()
        {
            Console.WriteLine("删除歌词");
        }

        private static void mp3_AfterStartedPlay()
        {
            Console.WriteLine("加载歌词");
        }
    }
    
    delegate int delegateMethod(BB b);
    public class AA
    {
        public int DelegateA(BB b)
        {
            DD d = new DD();
            delegateMethod dM = new delegateMethod(d.MethodD);
            return dM(b);
            
        }
        public int PropertyA { get; set; }
    }
    public class BB
    {
        public int PropertyB { get; set; }

    }
    public class DD
    {
        public int MethodD(BB bb)
        {
            bb.PropertyB = 2;
            return 1;
        }
        public int PropertyD { get; set; }
    }
    //public class CC
    //{
    //    public int MethodC(AA aa)
    //    {
    //        aa.PropertyA = 2;
    //        return 2;
    //    }
    //    public int PropertyC { get; set; }
    //}

    public class MusicPlayer
    {
        //做几个事件
        //1.音乐开始播放后出发某个事件
        //public Action AfterStartedPlay;
        public event Action AfterStartedPlay;

        //2.音乐停止播放之前出发某个事件
        //public Action BeforeMusicStop;
        public event Action BeforeMusicStop;
        private void PlayMusic()
        {
            Console.WriteLine("Playing Music");

        }
        public void StartPlay()
        {
            PlayMusic();
            //当音乐开始播放以后出发该事件
            if (AfterStartedPlay != null)
            {
                AfterStartedPlay();
            }
            Thread.Sleep(2000);
        }
        public void EndMusic()
        {

            //播放音乐停止之前
            if (BeforeMusicStop != null)
            {
                BeforeMusicStop();
            }
            Console.WriteLine("End");
        }
    }

    [Serializable]
    public class Animal
    {
        void Eat() { }
    }
    // [Serializable]
    //public class Person : Animal
    //{
    //    public Car Mercedes
    //    {
    //        get;
    //        set;
    //    }
    //    public string Name { get; set; }
    //    // [NonSerialized] 不能标记在属性前

    //    //public int Age { get; set; }

    //    [NonSerialized] private int _age;
    //    public int Age
    //    {
    //        get
    //        {
    //            return _age;
    //        }
    //        set
    //        {
    //            _age = value;
    //        }
    //    }
    //    public MyClass SayHello(MyClass mc)
    //    {
    //        return new MyClass();
    //    }
    //}
    public class MyClass
    {
        public string[] _bfs;
        public string[] _gfs;
        public string Name { get; set; }
        public void Say() { Console.WriteLine("hi"); }
        private void SayHello() { Console.WriteLine("hello"); }
    }
    [Serializable]
    public class Car
    {

    }
    public static class StringExtensions
    {
        public static string PadLeftWhileDouble(this string input, int length, char paddingChar = '\0')
        {
            var singleLength = GetSingleLength(input);
            return input.PadLeft(length - singleLength + input.Length, paddingChar);
        }
        private static int GetSingleLength(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException();
            }
            return Regex.Replace(input, @"[^\x00-\xff]", "aa").Length;//计算得到该字符串对应单字节字符串的长度  
        }
        public static string PadRightWhileDouble(this string input, int length, char paddingChar)
        {
            var singleLength = GetSingleLength(input);
            return input.PadRight(length - singleLength + input.Length, paddingChar);
        }
    }
}
