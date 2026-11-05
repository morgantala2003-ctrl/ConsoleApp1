using ClassLibrary1;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{ 





    // ==========================================
    // الفئة الرئيسية لاختبار النظام
    // ==========================================
    class Program
    {
        static void Main(string[] args)


        {
            Console.WriteLine("=================================================");
            Console.WriteLine("--- Home Appliance Maintenance Center ---");
            Console.WriteLine("=================================================");

            List<Appliance> devicesList = new List<Appliance>();

            Console.WriteLine("\n>>> Enter Refrigerator Details:");
            Console.Write("Serial Number (int): "); int sn1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Brand: "); string b1 = Console.ReadLine();
            Console.Write("Needs Compressor? (true/false): "); bool nc = Convert.ToBoolean(Console.ReadLine());
            devicesList.Add(new Refrigerator(sn1, b1, nc));

            Console.WriteLine("\n>>> Enter Washing Machine Details:");
            Console.Write("Serial Number (int): "); int sn2 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Brand: "); string b2 = Console.ReadLine();
            Console.Write("Capacity (int): "); int cap = Convert.ToInt32(Console.ReadLine());
            devicesList.Add(new WashingMachine(sn2, b2, cap));

            Console.WriteLine("\n>>> Enter AC Details:");
            Console.Write("Serial Number (int): "); int sn3 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Brand: "); string b3 = Console.ReadLine();
            Console.Write("Needs Gas? (true/false): "); bool ng = Convert.ToBoolean(Console.ReadLine());
            devicesList.Add(new AirConditioner(sn3, b3, ng));

            // ربط الحدث (Event Subscription) لكل جهاز
            foreach (Appliance device in devicesList)
            {
                device.OnMaintenanceCompleted += DeviceRepairedNotification;
            }

            Console.WriteLine($"\nTotal Devices in Center: {SystemHelper.TotalDevicesCount}\n");

            // معالجة الأجهزة باستخدام تعدد الأشكال
            double totalRevenue = 0;

            foreach (Appliance device in devicesList)
            {
                device.PrintDeviceInfo();

                // حساب التكلفة بناءً على نوع الكائن الفعلي
                double cost = device.CalculateRepairCost();
                Console.WriteLine($"Repair Cost: ${cost}");
                totalRevenue += cost;

                // إصلاح الجهاز (سيقوم هذا بإطلاق الحدث وتغيير الحالة)
                device.FixDevice();
                Console.WriteLine("-------------------------------------------------");
            }

            Console.WriteLine($"\nTotal Expected Revenue: ${totalRevenue}");

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        // الدالة التي ستنفذ عند إطلاق الحدث
        static void DeviceRepairedNotification(string msg)
        {
            Console.WriteLine(">> EVENT TRIGGERED: " + msg);
        }
    }
}
