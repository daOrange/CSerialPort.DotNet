# CSerialPort.DotNet
C#(.NET)串口类库，对itas109/CSerialPort(C++)类库进行封装并增加部分方法，供C#语言环境调用。解决.NET自带的SerialPort类在多串口环境下占用CPU资源过高问题。

## 使用环境要求
目前SerialPort.DotNet环境要求如下：
* .Netframework 4.0及以上；
* Window(x86)

## 调用方法
使用SerialPort.DotNet下的SerialPort类进行串口操作，SerialPort.DotNet.SerialPort基本实现了与System.IO.Ports.SerialPort相同的方法接口，可参考System.IO.Ports.SerialPort的使用资料。

## 参考
[itas109/CSerialPort](https://github.com/itas109/CSerialPort) 该类库基于CSerialPort进行底层串口处理，并增加了部分方法。
[ZeBobo5/Vlc.DotNet](https://github.com/ZeBobo5/Vlc.DotNet) 模仿Vlc.DotNet对libvlc封装的思路，进行对CSerialPort的封装
