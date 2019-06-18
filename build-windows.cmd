git clone https://github.com/pvl1175/thrift-interface-definitions
thrift -gen csharp -out . .\thrift-interface-definitions\lookfor9.thrift
dotnet add package apache-thrift-netcore --version 0.9.3.2
