using System;
using System.IO.Ports;

namespace hello_serialport
{
    class Program
    {
        static void Main(string[] args)
        {
            SerialPort _serialPort = new SerialPort();
            // Allow the user to set the appropriate properties.
            _serialPort.PortName = "/dev/ttyACM0";
            _serialPort.BaudRate = 115200;
            _serialPort.DtrEnable = true;
            _serialPort.Open();

            byte[] data = { 0x31 }; // or byte[] data = {'1'};
            _serialPort.Write(data, 0, 1);
            byte[] buffer = new byte[20];

            while (true)
            {
                if (_serialPort.BytesToRead > 16)
                {
                    
                    _serialPort.Read(buffer, 0, 20);
                    Console.WriteLine(System.Text.Encoding.ASCII.GetString(buffer));
                    Console.ReadKey();
                    _serialPort.Write(data, 0, 1);
                }
            }
        }
    }
}