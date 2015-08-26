using System;
using System.Linq;
using System.Linq.Expressions;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using AutoMapper;

using EmitMapper;
using EmitMapper.MappingConfiguration;

namespace Infrastructure.Core.Test
{
    [TestClass]
    public class MapperTest
    {
        [TestMethod]
        public void MapperMethod() {

            AutoMapperInit();

            StudentDo xiaoming = new StudentDo() { StudentName = "小明", Age = 10 };
            SchoolDo xiaoxue = new SchoolDo() { SchoolName = "义津小学", Address = "安徽安庆枞阳" };
            ClassDo banji_01 = new ClassDo() { ClassName = "401班", ClassLevel = 1, StudentNum = 50 };
            xiaoxue.ClassInfo = banji_01;

            SchoolDo zhongxue = new SchoolDo() { SchoolName = "义津中学", Address = "安徽安庆枞阳" };
            ClassDo banji_02 = new ClassDo() { ClassName = "501班", ClassLevel = 2, StudentNum = 50 };
            zhongxue.ClassInfo = banji_02;

            xiaoming.SmallSchool = xiaoxue;
            xiaoming.MiddleSchool = zhongxue;

            Stopwatch watcher = new Stopwatch();
            watcher.Start();
            for (var i = 0; i < 100000; i++) {
                var xiaohong = AutoMapper.Mapper.Map<StudentDo, StudentDto>(xiaoming);
            }
            watcher.Stop();
            long time1 = watcher.ElapsedMilliseconds;
            Console.WriteLine("共花费{0}毫秒", time1);

            watcher.Reset();
            watcher.Restart();

            ObjectsMapper<StudentDo, StudentDto> mapper = new ObjectMapperManager().GetMapper<StudentDo, StudentDto>(new DefaultMapConfig());
            StudentDto xiaofang = null;
            for (var i = 0; i < 1000000; i++) {
                xiaofang = mapper.Map(xiaoming);
            }
            long time2 = watcher.ElapsedMilliseconds;
            Console.WriteLine("共花费{0}毫秒", time2);

            System.Threading.Thread.Sleep(5000);

            Console.ReadLine();

        }

        private void AutoMapperInit() {
            AutoMapper.Mapper.CreateMap<StudentDo, StudentDto>();
            AutoMapper.Mapper.CreateMap<SchoolDo, SchoolDto>();
            AutoMapper.Mapper.CreateMap<ClassDo, ClassDto>();

            AutoMapper.Mapper.CreateMap<StudentDto, StudentDto>();
            AutoMapper.Mapper.CreateMap<SchoolDto, SchoolDo>();
            AutoMapper.Mapper.CreateMap<ClassDto, ClassDo>();
        }

        private void EmitMapperInit() { 
            
        }
    }

    public class StudentDo {
        public String StudentName { get; set; }
        public Int32 Age { get; set; }
        public SchoolDo SmallSchool { get; set; }
        public SchoolDo MiddleSchool { get; set; }
    }

    public class SchoolDo {
        public String SchoolName { get; set; }
        public String Address { get; set; }
        public ClassDo ClassInfo { get; set; }
    }

    public class ClassDo {
        public String ClassName { get; set; }
        public Int32 StudentNum { get; set; }
        public Int32 ClassLevel { get; set; }
    }



    public class StudentDto
    {
        public String StudentName { get; set; }
        public Int32 Age { get; set; }
        public SchoolDto SmallSchool { get; set; }
        public SchoolDto MiddleSchool { get; set; }
    }

    public class SchoolDto
    {
        public String SchoolName { get; set; }
        public String Address { get; set; }
        public ClassDto ClassInfo { get; set; }
    }

    public class ClassDto
    {
        public String ClassName { get; set; }
        public Int32 StudentNum { get; set; }
        public Int32 ClassLevel { get; set; }
    }
    
}
