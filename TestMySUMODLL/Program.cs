using System;
using System.Runtime.InteropServices;
using static TestMySUMODLL.connectSUMO;

namespace TestMySUMODLL
{
    public class connectSUMO
    {
        public const string boolName = "Global\boolMappingObject";
        public const string networkName = "Global\networkMappingObject";
        public const string trafficName = "Global\trafficMappingObject";

        // The imported functions
        public class MemLoc
        {
            public IntPtr handle;
            public IntPtr pointer;
            public MemLoc() { }
        }
        public class Locus
        {
            public MemLoc bools;
            public MemLoc network;
            public MemLoc traffic;
            public Locus() { }
        }

        [DllImport("connectSUMO.dll", EntryPoint = "reserveAllMemory")]
        public static extern int reserveAllMemory(Locus pointers, int networkSize, int trafficSize, int boolSize = 10);
        [DllImport("connectSUMO.dll", EntryPoint = "closeMemory")]
        public static extern void closeMemory(string map, IntPtr handle);
        [DllImport("connectSUMO.dll", EntryPoint = "writeBool")]
        public static extern void writeBool(IntPtr boolMap, string boolMessage, int boolSize = 10);
        [DllImport("connectSUMO.dll", EntryPoint = "writeNetwork")]
        public static extern void writeNetwork(IntPtr networkMap, string networkMessage);
        [DllImport("connectSUMO.dll", EntryPoint = "readReservedMemory")]
        public static extern string readReservedMemory(string szName, int bufferSize);
        [DllImport("connectSUMO.dll", EntryPoint = "deleteCharPointer")]
        public static extern void deleteCharPointer(string memoryLeak);
        // TODO: NAMED Locking for reading/writing. Might need Boost.
        [DllImport ("connectSUMO.dll", EntryPoint = "simple")]
        public static extern int simple();
        [DllImport("connectSUMO.dll", EntryPoint = "simpleLocus")]
        public static extern Locus simpleLocus();
        [DllImport("connectSUMO.dll", EntryPoint = "simpleMemLoc")]
        public static extern Locus simpleMemLoc();
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine($"{simple()}");
            /*
            Locus l = new Locus();
            int retcode = reserveAllMemory(l, 256, 256, 10);
            writeBool(l.bools.pointer, "true", 10);
            writeNetwork(l.network.pointer, "Lorem Ipsum Dolor Sit Amet");

            string boolTest = readReservedMemory(boolName, 10);
            string networkTest = readReservedMemory(networkName, 10);
            //Console.WriteLine($"bool: {boolTest}, network: {networkTest}");
            */
            Locus l = simpleLocus();
            Console.ReadLine();
        }
    }
}
